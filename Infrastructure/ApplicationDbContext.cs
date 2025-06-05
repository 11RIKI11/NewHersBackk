using Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSet для пользователей
    public DbSet<User> Users { get; set; }

    // DbSet для событий
    public DbSet<Event> Events { get; set; }

    // DbSet для билетов
    public DbSet<Ticket> Tickets { get; set; }

    // DbSet для платежей
    public DbSet<Payment> Payments { get; set; }

    // DbSet для связи платежей и билетов

    // DbSet для владельцев билетов
    public DbSet<Attendee> Attendees { get; set; }

    // DbSet для изображений
    public DbSet<Image> Images { get; set; }

    // DbSet для календаря событий пользователей
    public DbSet<UserEventCalendar> UserEventCalendars { get; set; }

    public DbSet<UserAttendee> UserAttendees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Настройка связей и ограничений
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Event)
            .WithMany(e => e.Tickets)
            .HasForeignKey(t => t.EventId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Attendee)
            .WithMany()
            .HasForeignKey(t => t.AttendeeId);

        modelBuilder.Entity<UserEventCalendar>()
            .HasOne(uec => uec.User)
            .WithMany(u => u.Calendars)
            .HasForeignKey(uec => uec.UserId);

        modelBuilder.Entity<UserEventCalendar>()
            .HasOne(uec => uec.Event)
            .WithMany()
            .HasForeignKey(uec => uec.EventId);

        modelBuilder.Entity<UserAttendee>()
            .HasOne(ua => ua.User)
            .WithMany()
            .HasForeignKey(ua => ua.UserId);

        modelBuilder.Entity<UserAttendee>()
            .HasOne(ua => ua.Attendee)
            .WithMany()
            .HasForeignKey(ua => ua.AttendeeId);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Payment)
            .WithMany()
            .HasForeignKey(t => t.PaymentId);

        modelBuilder.Entity<Payment>()
            .HasMany(p => p.Tickets)
            .WithOne(t => t.Payment)
            .HasForeignKey(t => t.PaymentId);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Buyer)
            .WithMany()
            .HasForeignKey(p => p.BuyerId);

        GenerateData(modelBuilder);
    }


    private void GenerateData(ModelBuilder modelBuilder)
    {
        var events = new List<Event>();
        var users = new List<User>();
        var admins = new List<User>();
        var attendees = new List<Attendee>();
        var tickets = new List<Ticket>();
        var payments = new List<Payment>();
        var userAttendees = new List<UserAttendee>();

        var rnd = new Random();
        var now = DateTime.UtcNow;

        // Названия экскурсий по Новому Херсонесу
        string[] eventTitles = {
    "Экскурсия по древнему Херсонесу",
    "Секреты раскопок в Херсонесе",
    "Археологические находки Херсонеса",
    "Вечерний Херсонес",
    "Античный театр Херсонеса",
    "История христианства в Херсонесе",
    "Херсонес и Византия",
    "Подземелья Херсонеса",
    "Башни и укрепления Херсонеса",
    "Мозаики и фрески Херсонеса"
};
        string location = "Новый Херсонес, Севастополь";

        // 10 событий
        for (int i = 0; i < 10; i++)
        {
            var startTime = now.AddDays(-(10 - i)).Date.AddHours(10 + i % 4); // прошедшие ивенты
            events.Add(new Event
            {
                Id = Guid.NewGuid(),
                Title = eventTitles[i],
                Description = $"Увлекательная экскурсия по {eventTitles[i].ToLower()}",
                Location = location,
                StartTime = startTime,
                EndTime = startTime.AddHours(2),
                Price = 1200 + (i * 150),
                TicketsCount = 20,
                IsActive = i == 9, // последнее активное
                Tag = "excursion",
                CreatedAt = now.AddDays(-20 + i)
            });
        }

        // 50 пользователей
        for (int i = 1; i <= 50; i++)
        {
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                FullName = $"Гость Херсонеса {i}",
                Email = $"guest{i}@example.com",
                PasswordHash = "hash123",
                Phone = $"+7978{i:D7}",
                Role = "user",
                BirthDate = DateTime.UtcNow.AddYears(-18 - rnd.Next(40)),
                CreatedAt = now.AddDays(-50 + i)
            });
        }

        // 3 администратора
        for (int i = 1; i <= 3; i++)
        {
            admins.Add(new User
            {
                Id = Guid.NewGuid(),
                FullName = $"Администратор {i}",
                Email = $"admin{i}@example.com",
                PasswordHash = "hashadmin",
                Phone = $"+7999{i:D7}",
                Role = "admin",
                BirthDate = DateTime.UtcNow.AddYears(-35 - rnd.Next(10)),
                CreatedAt = now.AddDays(-60)
            });
        }

        // 100 участников
        for (int i = 1; i <= 100; i++)
        {
            attendees.Add(new Attendee
            {
                Id = Guid.NewGuid(),
                FullName = $"Участник Херсонеса {i}",
                BirthDate = DateTime.UtcNow.AddYears(-25).AddDays(rnd.Next(3650)),
                DocumentType = i % 2 == 0 ? "passport" : "foreignPassport",
                DocumentNumber = i % 2 == 0 ? $"40{i:D02} {rnd.Next(100000, 999999)}" : $"72{rnd.Next(1000000, 9999999)}",
                CreatedAt = now.AddDays(-i)
            });
        }

        // 50 билетов (30% оплачены)
        int paidCount = 15;
        for (int i = 0; i < 50; i++)
        {
            var selectedEvent = events[rnd.Next(events.Count)];
            var selectedAttendee = attendees[rnd.Next(attendees.Count)];

            tickets.Add(new Ticket
            {
                Id = Guid.NewGuid(),
                EventId = selectedEvent.Id,
                AttendeeId = i < paidCount ? selectedAttendee.Id : null,
                PaymentId = i < paidCount ? Guid.NewGuid() : null,
                QRCode = $"HXN{selectedEvent.Id.ToString()[..8]}{i:D3}"
            });
        }

        // 10 оплат
        var paidTickets = tickets.Take(paidCount).ToList();
        int ticketIndex = 0;

        for (int i = 0; i < 10; i++)
        {
            var paymentId = Guid.NewGuid();
            var buyer = users[rnd.Next(users.Count)];
            var ticketsInPayment = Math.Min(2, paidCount - ticketIndex);
            var paymentTickets = paidTickets.Skip(ticketIndex).Take(ticketsInPayment);

            var amount = paymentTickets.Sum(t =>
                events.First(e => e.Id == t.EventId).Price);

            payments.Add(new Payment
            {
                Id = paymentId,
                BuyerId = buyer.Id,
                Amount = amount,
                Status = "Successed",
                QrUrl = $"https://localhost:7177/images/qr-code.png",
                CreatedAt = now.AddDays(-8 + i),
                PaidAt = now.AddDays(-8 + i).AddMinutes(rnd.Next(5, 30))
            });

            foreach (var ticket in paymentTickets)
            {
                ticket.PaymentId = paymentId;
            }

            ticketIndex += ticketsInPayment;
        }

        // Связь UserAttendee: участники, для которых пользователь оплатил билет
        foreach (var payment in payments)
        {
            var buyerId = payment.BuyerId;
            var relatedTickets = tickets
                .Where(t => t.PaymentId == payment.Id && t.AttendeeId.HasValue)
                .ToList();

            foreach (var ticket in relatedTickets)
            {
                userAttendees.Add(new UserAttendee
                {
                    Id = Guid.NewGuid(),
                    UserId = buyerId,
                    AttendeeId = ticket.AttendeeId!.Value
                });
            }
        }

        // Сохранение данных
        modelBuilder.Entity<Event>().HasData(events);
        modelBuilder.Entity<User>().HasData(users.Concat(admins));
        modelBuilder.Entity<Attendee>().HasData(attendees);
        modelBuilder.Entity<Payment>().HasData(payments);
        modelBuilder.Entity<Ticket>().HasData(tickets);
        modelBuilder.Entity<UserAttendee>().HasData(userAttendees);
    }
}



