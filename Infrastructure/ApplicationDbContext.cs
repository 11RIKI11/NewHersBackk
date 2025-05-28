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
            .HasOne(t => t.Buyer)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.BuyerId);

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

        // --- Генерация данных ---
        var events = new List<Event>();
        var users = new List<User>();
        var admins = new List<User>();
        var tickets = new List<Ticket>();
        var attendees = new List<Attendee>();
        var payments = new List<Payment>();
        //var paymentTickets = new List<PaymentTicket>();

        // 10 событий
        for (int i = 1; i <= 10; i++)
        {
            events.Add(new Event
            {
                Id = Guid.NewGuid(),
                Title = $"Event {i}",
                Description = $"Description {i}",
                Location = $"Location {i}",
                StartTime = DateTime.UtcNow.AddDays(i),
                EndTime = DateTime.UtcNow.AddDays(i).AddHours(2),
                Price = 100 + i * 10,
                TicketsCount = 5,
                IsActive = true,
                Tag = "event",
                CreatedAt = DateTime.UtcNow.AddDays(-i)
            });
        }

        // 20 пользователей
        for (int i = 1; i <= 20; i++)
        {
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                FullName = $"User {i}",
                Email = $"user{i}@mail.com",
                PasswordHash = "hash",
                Role = "user",
                CreatedAt = DateTime.UtcNow.AddDays(-i)
            });
        }

        // 3 админа
        for (int i = 1; i <= 3; i++)
        {
            admins.Add(new User
            {
                Id = Guid.NewGuid(),
                FullName = $"Admin {i}",
                Email = $"admin{i}@mail.com",
                PasswordHash = "hash",
                Role = "admin",
                CreatedAt = DateTime.UtcNow.AddDays(-i)
            });
        }

        // 30 посетителей
        for (int i = 1; i <= 30; i++)
        {
            attendees.Add(new Attendee
            {
                Id = Guid.NewGuid(),
                FullName = $"Attendee {i}",
                BirthDate = DateTime.UtcNow.AddYears(-20).AddDays(i),
                DocumentType = "passport",
                DocumentNumber = $"A{i:000000}",
                CreatedAt = DateTime.UtcNow.AddDays(-i)
            });
        }

        // 50 билетов (30% оплачены)
        var rnd = new Random();
        int paidCount = (int)(50 * 0.3);
        for (int i = 1; i <= 50; i++)
        {
            var eventId = events[rnd.Next(events.Count)].Id;
            var buyer = users[rnd.Next(users.Count)];
            var attendee = attendees[rnd.Next(attendees.Count)];
            var status = i <= paidCount ? "Paid" : "Available";

            tickets.Add(new Ticket
            {
                Id = Guid.NewGuid(),
                EventId = eventId,
                BuyerId = buyer.Id,
                AttendeeId = attendee.Id,
                QRCode = $"QR{i:0000}",
                Status = status
            });
        }

        // 10 оплат (каждая оплата на 1-2 билета)
        for (int i = 1; i <= 10; i++)
        {
            var buyer = users[rnd.Next(users.Count)];
            var paymentId = Guid.NewGuid();
            var paidTickets = tickets.Where(t => t.Status == "Paid").Skip((i - 1) * 3).Take(2).ToList();

            payments.Add(new Payment
            {
                Id = paymentId,
                BuyerId = buyer.Id,
                Amount = paidTickets.Count * 150,
                Status = "paid",
                QrUrl = $"https://pay/{paymentId}",
                CreatedAt = DateTime.UtcNow.AddDays(-i),
                PaidAt = DateTime.UtcNow.AddDays(-i + 1)
            });

            /*foreach (var t in paidTickets)
            {
                paymentTickets.Add(new PaymentTicket
                {
                    Id = Guid.NewGuid(),
                    PaymentId = paymentId,
                    TicketId = t.Id
                });
            }*/
        }

        // --- Добавление данных через HasData ---
        modelBuilder.Entity<Event>().HasData(events);
        modelBuilder.Entity<User>().HasData(users.Concat(admins));
        modelBuilder.Entity<Attendee>().HasData(attendees);
        modelBuilder.Entity<Ticket>().HasData(tickets);
        modelBuilder.Entity<Payment>().HasData(payments);
        //modelBuilder.Entity<PaymentTicket>().HasData(paymentTickets);

        // ... остальные связи и настройки, если нужны
    }
}



