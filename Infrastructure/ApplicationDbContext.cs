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

        // --- Генерация данных ---
        var events = new List<Event>();
        var users = new List<User>();
        var admins = new List<User>();
        var tickets = new List<Ticket>();
        var attendees = new List<Attendee>();
        var payments = new List<Payment>();

        var rnd = new Random();
        var now = DateTime.UtcNow;

        // 10 событий
        string[] eventTitles = {"Экскурсия в Кремль", "Третьяковская галерея", "Музей космонавтики", 
                               "Царицыно", "Коломенское", "Архитектурная прогулка", "Москва купеческая",
                               "Вечерняя Москва", "Булгаковская Москва", "Московское метро"};
        string[] locations = {"Красная площадь", "Лаврушинский переулок", "пр-т Мира", 
                             "ул. Дольская", "пр-т Андропова", "Китай-город",
                             "Замоскворечье", "Тверская улица", "Патриаршие пруды", "Площадь Революции"};

        for (int i = 0; i < 10; i++)
        {
            var startTime = now.AddDays(i + 1).Date.AddHours(10 + i % 4);
            events.Add(new Event
            {
                Id = Guid.NewGuid(),
                Title = eventTitles[i],
                Description = $"Увлекательная экскурсия по {eventTitles[i].ToLower()}",
                Location = locations[i],
                StartTime = startTime,
                EndTime = startTime.AddHours(2),
                Price = 1000 + (i * 200),
                TicketsCount = 15,
                IsActive = true,
                Tag = i < 7 ? "excursion" : "event",
                CreatedAt = now.AddDays(-10)
            });
        }

        // 20 пользователей + 3 админа
        for (int i = 1; i <= 20; i++)
        {
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                FullName = $"Иванов Иван {i}",
                Email = $"user{i}@example.com",
                PasswordHash = "hash123",
                Phone = $"+7900{i:D7}",
                Role = "user",
                BirthDate = DateTime.UtcNow.AddYears(-20 - rnd.Next(20)),
                CreatedAt = now.AddDays(-30 + i)
            });
        }

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
                BirthDate = DateTime.UtcNow.AddYears(-30 - rnd.Next(10)),
                CreatedAt = now.AddDays(-60)
            });
        }

        // 30 посетителей
        for (int i = 1; i <= 30; i++)
        {
            attendees.Add(new Attendee
            {
                Id = Guid.NewGuid(),
                FullName = $"Петров Петр {i}",
                BirthDate = DateTime.UtcNow.AddYears(-25).AddDays(rnd.Next(3650)),
                DocumentType = i % 2 == 0 ? "passport" : "foreignPassport",
                DocumentNumber = i % 2 == 0 ? $"45{i:D02} {rnd.Next(100000, 999999)}" : $"71{rnd.Next(1000000, 9999999)}",
                CreatedAt = now.AddDays(-i)
            });
        }

        // 50 билетов (30% оплачены)
        int paidCount = 15; // 30% от 50
        for (int i = 1; i <= 50; i++)
        {
            var selectedEvent = events[rnd.Next(events.Count)];
            var selectedAttendee = attendees[rnd.Next(attendees.Count)];

            tickets.Add(new Ticket
            {
                Id = Guid.NewGuid(),
                EventId = selectedEvent.Id,
                AttendeeId = i <= paidCount ? selectedAttendee.Id : null,
                PaymentId = i <= paidCount ? Guid.NewGuid() : null,
                QRCode = $"TKT{selectedEvent.Id.ToString()[..8]}{i:D3}"
            });
        }

        // 10 оплат
        var paidTickets = tickets.Take(paidCount).ToList();
        int ticketIndex = 0;
        
        for (int i = 1; i <= 10; i++)
        {
            var paymentId = Guid.NewGuid();
            var buyer = users[rnd.Next(users.Count)];
            var ticketsInPayment = Math.Min(2, paidCount - ticketIndex);
            var paymentTickets = paidTickets.Skip(ticketIndex).Take(ticketsInPayment);
            
            // Получаем сумму, используя прямую ссылку на событие
            var amount = paymentTickets.Sum(t => 
                events.First(e => e.Id == t.EventId).Price);

            payments.Add(new Payment
            {
                Id = paymentId,
                BuyerId = buyer.Id,
                Amount = amount,
                Status = "Successed",
                QrUrl = $"https://payment.example.com/{paymentId}",
                CreatedAt = now.AddDays(-5 + i),
                PaidAt = now.AddDays(-5 + i).AddMinutes(rnd.Next(5, 30))
            });

            foreach (var ticket in paymentTickets)
            {
                ticket.PaymentId = paymentId;
            }

            ticketIndex += ticketsInPayment;
        }

        // Сохранение данных
        modelBuilder.Entity<Event>().HasData(events);
        modelBuilder.Entity<User>().HasData(users.Concat(admins));
        modelBuilder.Entity<Attendee>().HasData(attendees);
        modelBuilder.Entity<Payment>().HasData(payments);
        modelBuilder.Entity<Ticket>().HasData(tickets);
    }
}



