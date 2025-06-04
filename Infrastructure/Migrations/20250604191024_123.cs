using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DocumentType = table.Column<string>(type: "text", nullable: false),
                    DocumentNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TicketsCount = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Tag = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    ImageType = table.Column<string>(type: "text", nullable: false),
                    LocalOrderRank = table.Column<short>(type: "smallint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EntityId = table.Column<string>(type: "text", nullable: true),
                    EntityTarget = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    QrUrl = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAttendees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAttendees_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAttendees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEventCalendars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true),
                    ReminderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEventCalendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEventCalendars_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEventCalendars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    QRCode = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DocumentNumber", "DocumentType", "FullName" },
                values: new object[,]
                {
                    { new Guid("013813d9-ab33-47cc-b3d9-1bde836160f7"), new DateTime(2000, 9, 28, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5512), new DateTime(2025, 5, 24, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "711003241", "foreignPassport", "Петров Петр 11" },
                    { new Guid("01c60dcb-02a7-4f7a-afca-0a39153e3bf7"), new DateTime(2002, 10, 31, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5604), new DateTime(2025, 5, 11, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4524 229589", "passport", "Петров Петр 24" },
                    { new Guid("026d8281-c4cc-438e-9216-3217f58032e2"), new DateTime(2009, 2, 5, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5600), new DateTime(2025, 5, 13, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4522 232733", "passport", "Петров Петр 22" },
                    { new Guid("0b2c731a-24b8-494c-9b84-c871f6a2db7b"), new DateTime(2006, 3, 13, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5591), new DateTime(2025, 5, 16, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "714086937", "foreignPassport", "Петров Петр 19" },
                    { new Guid("110a8208-8eaa-48e4-940e-fecd36d4fb15"), new DateTime(2004, 5, 2, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5474), new DateTime(2025, 6, 3, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "717460565", "foreignPassport", "Петров Петр 1" },
                    { new Guid("13abb2ab-0756-4934-a60b-d20d41b80b09"), new DateTime(2007, 4, 10, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5593), new DateTime(2025, 5, 15, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4520 380465", "passport", "Петров Петр 20" },
                    { new Guid("15efdf51-90ac-42a5-9b25-bb315acb7252"), new DateTime(2003, 4, 18, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5489), new DateTime(2025, 5, 31, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4504 397608", "passport", "Петров Петр 4" },
                    { new Guid("2176bf76-59ff-47f3-8b70-9081fa155b35"), new DateTime(2009, 7, 27, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5528), new DateTime(2025, 5, 18, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "713844506", "foreignPassport", "Петров Петр 17" },
                    { new Guid("2917bfa6-3bcf-433a-b1a6-f81cfef0cdbe"), new DateTime(2004, 10, 22, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5596), new DateTime(2025, 5, 14, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "716335164", "foreignPassport", "Петров Петр 21" },
                    { new Guid("29e0d7a2-a04e-400a-a6aa-9f52c9dd5069"), new DateTime(2004, 9, 10, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5619), new DateTime(2025, 5, 6, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "717079175", "foreignPassport", "Петров Петр 29" },
                    { new Guid("2fabd7ef-6569-4613-91a6-b379931012ba"), new DateTime(2009, 5, 26, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5607), new DateTime(2025, 5, 10, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "712460414", "foreignPassport", "Петров Петр 25" },
                    { new Guid("386e55af-dc99-431c-9f38-1ae3d3fa8e7f"), new DateTime(2008, 5, 24, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5526), new DateTime(2025, 5, 19, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4516 891441", "passport", "Петров Петр 16" },
                    { new Guid("4d465982-5c14-4c00-afab-c95625ffadc4"), new DateTime(2003, 6, 28, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5503), new DateTime(2025, 5, 27, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4508 933161", "passport", "Петров Петр 8" },
                    { new Guid("4ffe2598-f6a3-4e2c-90f5-44ae787a6a28"), new DateTime(2010, 3, 28, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5501), new DateTime(2025, 5, 28, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "712915713", "foreignPassport", "Петров Петр 7" },
                    { new Guid("66a530e4-72a8-496f-b7d4-0650956f3c89"), new DateTime(2009, 8, 20, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5523), new DateTime(2025, 5, 20, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "719924747", "foreignPassport", "Петров Петр 15" },
                    { new Guid("68fd866a-0a21-46e3-990e-6f9c6af47b6f"), new DateTime(2007, 11, 27, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5487), new DateTime(2025, 6, 1, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "715956633", "foreignPassport", "Петров Петр 3" },
                    { new Guid("70dd0949-ba4e-4a1a-afd2-3d1d534b3705"), new DateTime(2008, 7, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5613), new DateTime(2025, 5, 8, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "715803068", "foreignPassport", "Петров Петр 27" },
                    { new Guid("74dfb566-da93-4176-9a6e-6ceeb665d612"), new DateTime(2010, 4, 16, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5588), new DateTime(2025, 5, 17, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4518 452963", "passport", "Петров Петр 18" },
                    { new Guid("8450f0ed-b47f-4564-8982-aafc1e8da40f"), new DateTime(2005, 4, 29, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5521), new DateTime(2025, 5, 21, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4514 298439", "passport", "Петров Петр 14" },
                    { new Guid("8ae8f722-5eaa-4880-9a7b-221ec221de8b"), new DateTime(2006, 1, 15, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5623), new DateTime(2025, 5, 5, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4530 273468", "passport", "Петров Петр 30" },
                    { new Guid("97b6777f-e05b-43b2-83e6-f43be1c44b31"), new DateTime(2000, 7, 30, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5514), new DateTime(2025, 5, 23, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4512 940779", "passport", "Петров Петр 12" },
                    { new Guid("98661d35-6e40-49f2-958e-ada95e9b2fd0"), new DateTime(2008, 10, 12, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5509), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4510 714052", "passport", "Петров Петр 10" },
                    { new Guid("be29b1d2-5f22-4610-b779-fb34c359d026"), new DateTime(2004, 5, 11, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5493), new DateTime(2025, 5, 30, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "711569997", "foreignPassport", "Петров Петр 5" },
                    { new Guid("c432ed8c-4bd5-48cc-ba9f-bd5507e35bd5"), new DateTime(2002, 4, 22, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5497), new DateTime(2025, 5, 29, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4506 145417", "passport", "Петров Петр 6" },
                    { new Guid("cca8def9-540b-4866-a1a8-96cf344850fa"), new DateTime(2007, 2, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5610), new DateTime(2025, 5, 9, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4526 298269", "passport", "Петров Петр 26" },
                    { new Guid("ce27b345-781e-48d9-8291-17aafe1a1235"), new DateTime(2009, 9, 8, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5481), new DateTime(2025, 6, 2, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4502 596973", "passport", "Петров Петр 2" },
                    { new Guid("db62fac7-78ef-4b8e-826c-61f989d973e4"), new DateTime(2004, 2, 28, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5602), new DateTime(2025, 5, 12, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "714885020", "foreignPassport", "Петров Петр 23" },
                    { new Guid("e0f21c31-2d52-4943-9f31-96661a90b874"), new DateTime(2004, 7, 26, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5616), new DateTime(2025, 5, 7, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "4528 566393", "passport", "Петров Петр 28" },
                    { new Guid("e3324c19-3f3a-4da4-ad5a-23566a84355c"), new DateTime(2010, 2, 18, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5505), new DateTime(2025, 5, 26, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "714484971", "foreignPassport", "Петров Петр 9" },
                    { new Guid("fc0030e4-2e43-4a56-8e37-8dc7c0a3f45c"), new DateTime(2004, 8, 24, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5517), new DateTime(2025, 5, 22, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "715948199", "foreignPassport", "Петров Петр 13" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "Price", "StartTime", "Tag", "TicketsCount", "Title" },
                values: new object[,]
                {
                    { new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по вечерняя москва", new DateTime(2025, 6, 12, 15, 0, 0, 0, DateTimeKind.Utc), true, "Тверская улица", 2400m, new DateTime(2025, 6, 12, 13, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Вечерняя Москва" },
                    { new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по экскурсия в кремль", new DateTime(2025, 6, 5, 12, 0, 0, 0, DateTimeKind.Utc), true, "Красная площадь", 1000m, new DateTime(2025, 6, 5, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Экскурсия в Кремль" },
                    { new Guid("2cc2c87a-e41e-4a3e-b49f-e63d46245fc7"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по третьяковская галерея", new DateTime(2025, 6, 6, 13, 0, 0, 0, DateTimeKind.Utc), true, "Лаврушинский переулок", 1200m, new DateTime(2025, 6, 6, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Третьяковская галерея" },
                    { new Guid("3354259e-6f05-456f-941e-fb84df2f3097"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по музей космонавтики", new DateTime(2025, 6, 7, 14, 0, 0, 0, DateTimeKind.Utc), true, "пр-т Мира", 1400m, new DateTime(2025, 6, 7, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Музей космонавтики" },
                    { new Guid("96d56ba5-bc43-48ab-9bef-67ce1f436e6d"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по московское метро", new DateTime(2025, 6, 14, 13, 0, 0, 0, DateTimeKind.Utc), true, "Площадь Революции", 2800m, new DateTime(2025, 6, 14, 11, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Московское метро" },
                    { new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по архитектурная прогулка", new DateTime(2025, 6, 10, 13, 0, 0, 0, DateTimeKind.Utc), true, "Китай-город", 2000m, new DateTime(2025, 6, 10, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Архитектурная прогулка" },
                    { new Guid("b10191df-e5db-4165-81a1-243b1b7e2aa6"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по коломенское", new DateTime(2025, 6, 9, 12, 0, 0, 0, DateTimeKind.Utc), true, "пр-т Андропова", 1800m, new DateTime(2025, 6, 9, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Коломенское" },
                    { new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по москва купеческая", new DateTime(2025, 6, 11, 14, 0, 0, 0, DateTimeKind.Utc), true, "Замоскворечье", 2200m, new DateTime(2025, 6, 11, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Москва купеческая" },
                    { new Guid("c4b2b002-f88b-4541-b3bf-eee41d44d6c5"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по царицыно", new DateTime(2025, 6, 8, 15, 0, 0, 0, DateTimeKind.Utc), true, "ул. Дольская", 1600m, new DateTime(2025, 6, 8, 13, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Царицыно" },
                    { new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "Увлекательная экскурсия по булгаковская москва", new DateTime(2025, 6, 13, 12, 0, 0, 0, DateTimeKind.Utc), true, "Патриаршие пруды", 2600m, new DateTime(2025, 6, 13, 10, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Булгаковская Москва" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("0466994d-5630-4847-a758-67800a6fda99"), new DateTime(1995, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5469), new DateTime(2025, 4, 5, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "admin3@example.com", "Администратор 3", "hashadmin", "+79990000003", "admin" },
                    { new Guid("1d1b9628-a82e-4e21-ab72-90f6bc59eaf6"), new DateTime(1993, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5437), new DateTime(2025, 5, 19, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user14@example.com", "Иванов Иван 14", "hash123", "+79000000014", "user" },
                    { new Guid("238a4092-1433-4a6a-b4fb-c2be5aa0f0f4"), new DateTime(2002, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5416), new DateTime(2025, 5, 13, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user8@example.com", "Иванов Иван 8", "hash123", "+79000000008", "user" },
                    { new Guid("2d305769-b08b-4b73-8b8d-93227e5cea93"), new DateTime(1990, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5445), new DateTime(2025, 5, 22, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user17@example.com", "Иванов Иван 17", "hash123", "+79000000017", "user" },
                    { new Guid("376574cb-db0b-45c1-bd6e-d9b581998446"), new DateTime(2002, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5320), new DateTime(2025, 5, 7, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user2@example.com", "Иванов Иван 2", "hash123", "+79000000002", "user" },
                    { new Guid("439869cc-b72b-4a1e-a52b-30c07d535259"), new DateTime(2002, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5419), new DateTime(2025, 5, 14, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user9@example.com", "Иванов Иван 9", "hash123", "+79000000009", "user" },
                    { new Guid("4bff6303-44e6-4296-90c9-5f92cf1a8605"), new DateTime(2000, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5442), new DateTime(2025, 5, 21, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user16@example.com", "Иванов Иван 16", "hash123", "+79000000016", "user" },
                    { new Guid("540f806b-2c15-4dd3-89f9-78b2e131587d"), new DateTime(1999, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5335), new DateTime(2025, 5, 11, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user6@example.com", "Иванов Иван 6", "hash123", "+79000000006", "user" },
                    { new Guid("5b74b9ae-2f2d-45b2-929c-293319ab2e01"), new DateTime(1991, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5425), new DateTime(2025, 5, 15, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user10@example.com", "Иванов Иван 10", "hash123", "+79000000010", "user" },
                    { new Guid("5dae534f-facc-4915-b3ce-e8a2f241b66b"), new DateTime(1999, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5434), new DateTime(2025, 5, 18, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user13@example.com", "Иванов Иван 13", "hash123", "+79000000013", "user" },
                    { new Guid("7c7e657e-829b-4e8c-8e36-6d5e801cded9"), new DateTime(1987, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5428), new DateTime(2025, 5, 16, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user11@example.com", "Иванов Иван 11", "hash123", "+79000000011", "user" },
                    { new Guid("82cad756-208e-4022-9344-50b25afb61e1"), new DateTime(2004, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5331), new DateTime(2025, 5, 10, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user5@example.com", "Иванов Иван 5", "hash123", "+79000000005", "user" },
                    { new Guid("9ec2f282-630a-4402-ac4f-290b4484ffd0"), new DateTime(2002, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5326), new DateTime(2025, 5, 9, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user4@example.com", "Иванов Иван 4", "hash123", "+79000000004", "user" },
                    { new Guid("a1128bbc-71c9-4af3-a5d1-f6a12ee21f32"), new DateTime(1993, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5412), new DateTime(2025, 5, 12, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user7@example.com", "Иванов Иван 7", "hash123", "+79000000007", "user" },
                    { new Guid("abd2d703-75e8-4b06-8735-c86799334fe4"), new DateTime(1994, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5439), new DateTime(2025, 5, 20, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user15@example.com", "Иванов Иван 15", "hash123", "+79000000015", "user" },
                    { new Guid("b1e2fb5a-b31d-4f1c-a037-e5a65858abad"), new DateTime(1989, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5461), new DateTime(2025, 4, 5, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "admin1@example.com", "Администратор 1", "hashadmin", "+79990000001", "admin" },
                    { new Guid("c46e616d-94fc-463a-b494-e938d3772225"), new DateTime(2002, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5314), new DateTime(2025, 5, 6, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user1@example.com", "Иванов Иван 1", "hash123", "+79000000001", "user" },
                    { new Guid("c6fcca63-cc39-4c68-8d23-d2449f7cef38"), new DateTime(1986, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5466), new DateTime(2025, 4, 5, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "admin2@example.com", "Администратор 2", "hashadmin", "+79990000002", "admin" },
                    { new Guid("c844a3ec-65fc-46b2-a936-87f88199a295"), new DateTime(1997, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5454), new DateTime(2025, 5, 25, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user20@example.com", "Иванов Иван 20", "hash123", "+79000000020", "user" },
                    { new Guid("db3f90ad-7d19-4020-98c3-63d2407ce1dd"), new DateTime(2005, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5430), new DateTime(2025, 5, 17, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user12@example.com", "Иванов Иван 12", "hash123", "+79000000012", "user" },
                    { new Guid("eec7af0e-8251-4482-9d9c-c8a846f73572"), new DateTime(1997, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5451), new DateTime(2025, 5, 24, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user19@example.com", "Иванов Иван 19", "hash123", "+79000000019", "user" },
                    { new Guid("fbee18e7-9332-4e43-83c9-efb3aebbd1f4"), new DateTime(1986, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5324), new DateTime(2025, 5, 8, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user3@example.com", "Иванов Иван 3", "hash123", "+79000000003", "user" },
                    { new Guid("fe13277d-0ec4-4257-aae2-c4d5eb2e84a7"), new DateTime(2005, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5449), new DateTime(2025, 5, 23, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), "user18@example.com", "Иванов Иван 18", "hash123", "+79000000018", "user" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BuyerId", "CreatedAt", "PaidAt", "QrUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("011382b0-a292-4436-a19d-ae040806679f"), 0m, new Guid("7c7e657e-829b-4e8c-8e36-6d5e801cded9"), new DateTime(2025, 6, 8, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 8, 19, 33, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/011382b0-a292-4436-a19d-ae040806679f", "paid" },
                    { new Guid("34d35398-8d27-45d2-8081-37ca533cbb45"), 4200m, new Guid("1d1b9628-a82e-4e21-ab72-90f6bc59eaf6"), new DateTime(2025, 6, 6, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 6, 19, 37, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/34d35398-8d27-45d2-8081-37ca533cbb45", "paid" },
                    { new Guid("3f81032b-2b0f-4286-a487-ca42bd3ed0a9"), 0m, new Guid("5dae534f-facc-4915-b3ce-e8a2f241b66b"), new DateTime(2025, 6, 9, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 9, 19, 25, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/3f81032b-2b0f-4286-a487-ca42bd3ed0a9", "paid" },
                    { new Guid("87d7f811-f523-4aa0-9c73-ac8c05fb1767"), 2800m, new Guid("5b74b9ae-2f2d-45b2-929c-293319ab2e01"), new DateTime(2025, 6, 7, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 7, 19, 25, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/87d7f811-f523-4aa0-9c73-ac8c05fb1767", "paid" },
                    { new Guid("8d1f48fe-8ae7-4668-8881-393172403acb"), 4800m, new Guid("db3f90ad-7d19-4020-98c3-63d2407ce1dd"), new DateTime(2025, 6, 3, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 3, 19, 30, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/8d1f48fe-8ae7-4668-8881-393172403acb", "paid" },
                    { new Guid("8f60025c-a83b-457e-98f9-cfedf2a1f247"), 3600m, new Guid("2d305769-b08b-4b73-8b8d-93227e5cea93"), new DateTime(2025, 6, 5, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 5, 19, 34, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/8f60025c-a83b-457e-98f9-cfedf2a1f247", "paid" },
                    { new Guid("baefb53c-2ddf-46e2-ba71-c01a5bf6ec60"), 3800m, new Guid("2d305769-b08b-4b73-8b8d-93227e5cea93"), new DateTime(2025, 6, 4, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 4, 19, 22, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/baefb53c-2ddf-46e2-ba71-c01a5bf6ec60", "paid" },
                    { new Guid("d5270f8a-4a12-4aed-b20f-efc7bc94a91b"), 4600m, new Guid("7c7e657e-829b-4e8c-8e36-6d5e801cded9"), new DateTime(2025, 6, 2, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 2, 19, 32, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/d5270f8a-4a12-4aed-b20f-efc7bc94a91b", "paid" },
                    { new Guid("d7594e40-5183-45aa-8121-9249c2960982"), 5400m, new Guid("2d305769-b08b-4b73-8b8d-93227e5cea93"), new DateTime(2025, 5, 31, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 5, 31, 19, 20, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/d7594e40-5183-45aa-8121-9249c2960982", "paid" },
                    { new Guid("e41fdc8d-dd98-45a6-b953-2d7cebbf84d3"), 3800m, new Guid("a1128bbc-71c9-4af3-a5d1-f6a12ee21f32"), new DateTime(2025, 6, 1, 19, 10, 23, 487, DateTimeKind.Utc).AddTicks(5147), new DateTime(2025, 6, 1, 19, 25, 23, 487, DateTimeKind.Utc).AddTicks(5147), "https://payment.example.com/e41fdc8d-dd98-45a6-b953-2d7cebbf84d3", "paid" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "EventId", "PaymentId", "QRCode", "UserId" },
                values: new object[,]
                {
                    { new Guid("0638cf4e-e460-409f-b695-4762274a6b19"), null, new Guid("b10191df-e5db-4165-81a1-243b1b7e2aa6"), null, "TKTb10191df034", null },
                    { new Guid("0b082856-db31-4949-90e6-3759259d8938"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0021", null },
                    { new Guid("0d9b3e22-db8e-45cd-bb55-2991e1abb422"), null, new Guid("b10191df-e5db-4165-81a1-243b1b7e2aa6"), null, "TKTb10191df048", null },
                    { new Guid("15864f5b-0797-4574-8f2f-0360829a404d"), null, new Guid("b10191df-e5db-4165-81a1-243b1b7e2aa6"), null, "TKTb10191df017", null },
                    { new Guid("1a25b745-a70d-44ba-8246-bfe4398521a1"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0043", null },
                    { new Guid("22799b5e-a4e5-428c-a552-1f980ba4d210"), null, new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), null, "TKT0283516e030", null },
                    { new Guid("23b6b0d6-d5c7-4e13-8aa4-ba7c1bfb6f91"), null, new Guid("c4b2b002-f88b-4541-b3bf-eee41d44d6c5"), null, "TKTc4b2b002035", null },
                    { new Guid("2523dac0-f1b9-4e72-93ac-4e725900c3e3"), null, new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), null, "TKT12c81cc2033", null },
                    { new Guid("298000ae-f99c-4066-a0ed-b50ab0201cef"), null, new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), null, "TKTc39ed2f1026", null },
                    { new Guid("2ad33a67-bb0b-464e-b081-e89e9b2364f4"), null, new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), null, "TKT0283516e041", null },
                    { new Guid("37d6f0ca-6ddf-4bcc-a8b8-635267b7d35b"), null, new Guid("b10191df-e5db-4165-81a1-243b1b7e2aa6"), null, "TKTb10191df045", null },
                    { new Guid("418bfbc6-ff3f-45f4-ae45-e065188f8357"), null, new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), null, "TKTab369c7d037", null },
                    { new Guid("43fc75af-3faa-4f4d-9730-24afd21f147a"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0046", null },
                    { new Guid("45055b75-a20e-47b0-b900-8a4c0d8a1e10"), null, new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), null, "TKT12c81cc2027", null },
                    { new Guid("4c02d4ba-08fc-43d2-87dc-61e4507d3b97"), null, new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), null, "TKTab369c7d050", null },
                    { new Guid("5142d116-bb58-419a-82f2-1182d7f8df89"), null, new Guid("c4b2b002-f88b-4541-b3bf-eee41d44d6c5"), null, "TKTc4b2b002023", null },
                    { new Guid("603e9efa-1a39-4d6d-a135-93e88d0daf06"), null, new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), null, "TKTc39ed2f1049", null },
                    { new Guid("66c10d16-db48-4416-aabc-63b798710500"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0047", null },
                    { new Guid("6804d82f-c5f0-45c9-bde1-23dbe3356daa"), null, new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), null, "TKTc39ed2f1042", null },
                    { new Guid("7056ef4a-7c60-4c81-998d-284b12ab3b09"), null, new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), null, "TKTab369c7d031", null },
                    { new Guid("873b7c95-516a-45e4-8936-863b71705e9b"), null, new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), null, "TKTab369c7d018", null },
                    { new Guid("8c76d00e-c5c3-4c42-9e9d-d2e7479ec07b"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0020", null },
                    { new Guid("9dd0ca50-2a70-4283-bcf1-6fba796b14fb"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0039", null },
                    { new Guid("b0a9c3b0-ce6c-442a-91e0-d97b342b1e15"), null, new Guid("2cc2c87a-e41e-4a3e-b49f-e63d46245fc7"), null, "TKT2cc2c87a028", null },
                    { new Guid("c3299eef-fad0-4e3e-bccd-2f7bc0571707"), null, new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), null, "TKTfe9622d0032", null },
                    { new Guid("c44cd7a9-aae0-4bc3-a40f-7c10bc06316f"), null, new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), null, "TKTc39ed2f1019", null },
                    { new Guid("c6a34761-c359-45f1-9d71-4159ca13a04d"), null, new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), null, "TKT0283516e040", null },
                    { new Guid("c9ad920d-91a0-46ce-99dd-682d0da43ff6"), null, new Guid("96d56ba5-bc43-48ab-9bef-67ce1f436e6d"), null, "TKT96d56ba5044", null },
                    { new Guid("d0969c3f-1b1c-4ce9-b69e-d5eb5d60df49"), null, new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), null, "TKTc39ed2f1038", null },
                    { new Guid("d3548dba-1b49-42da-8b7d-f12a6e44ec79"), null, new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), null, "TKT0283516e024", null },
                    { new Guid("dc1b15e6-a745-4664-a888-25ea6216ce29"), null, new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), null, "TKT12c81cc2036", null },
                    { new Guid("e24434a3-8378-4a5c-8cdc-99081594a22a"), null, new Guid("c39ed2f1-060a-4d49-bf92-139693de5f8b"), null, "TKTc39ed2f1029", null },
                    { new Guid("eb69ee0e-03c4-42b6-b078-d257e69c381f"), null, new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), null, "TKT12c81cc2025", null },
                    { new Guid("f514b20a-59c2-47ea-8774-4725236329cc"), null, new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), null, "TKT12c81cc2016", null },
                    { new Guid("fa96b415-5c50-4529-a272-e942c0855639"), null, new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), null, "TKTab369c7d022", null },
                    { new Guid("1a163aa9-5e29-4055-9251-6cb92ed75ae0"), new Guid("026d8281-c4cc-438e-9216-3217f58032e2"), new Guid("12c81cc2-f696-4b9d-970c-4810167aa891"), new Guid("8f60025c-a83b-457e-98f9-cfedf2a1f247"), "TKT12c81cc2011", null },
                    { new Guid("1ca7480d-23f3-4ae9-994a-0e5b1322455b"), new Guid("70dd0949-ba4e-4a1a-afd2-3d1d534b3705"), new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), new Guid("d7594e40-5183-45aa-8121-9249c2960982"), "TKTfe9622d0001", null },
                    { new Guid("1d9da093-61ca-459e-8189-06930da58978"), new Guid("68fd866a-0a21-46e3-990e-6f9c6af47b6f"), new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), new Guid("e41fdc8d-dd98-45a6-b953-2d7cebbf84d3"), "TKTab369c7d003", null },
                    { new Guid("2d50e9a9-3239-4e8f-a62d-92b9652518f5"), new Guid("db62fac7-78ef-4b8e-826c-61f989d973e4"), new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), new Guid("8f60025c-a83b-457e-98f9-cfedf2a1f247"), "TKTfe9622d0012", null },
                    { new Guid("2e6558d6-7001-4e6d-b00c-1dd42da2c24a"), new Guid("110a8208-8eaa-48e4-940e-fecd36d4fb15"), new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), new Guid("8d1f48fe-8ae7-4668-8881-393172403acb"), "TKT0283516e007", null },
                    { new Guid("4977bb5c-5a7d-4a91-bf2f-4a657f991cdd"), new Guid("68fd866a-0a21-46e3-990e-6f9c6af47b6f"), new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), new Guid("d5270f8a-4a12-4aed-b20f-efc7bc94a91b"), "TKTfe9622d0006", null },
                    { new Guid("6149238e-ac25-4e54-ad18-5635c93b0344"), new Guid("2176bf76-59ff-47f3-8b70-9081fa155b35"), new Guid("ab369c7d-1f1a-4c79-8f98-44a2089eb1df"), new Guid("d5270f8a-4a12-4aed-b20f-efc7bc94a91b"), "TKTab369c7d005", null },
                    { new Guid("6e6ef72b-5d31-49d3-93c9-c0a119b2e922"), new Guid("66a530e4-72a8-496f-b7d4-0650956f3c89"), new Guid("b10191df-e5db-4165-81a1-243b1b7e2aa6"), new Guid("e41fdc8d-dd98-45a6-b953-2d7cebbf84d3"), "TKTb10191df004", null },
                    { new Guid("95a23d32-77ae-41c2-95e3-cb1e12f6fb2c"), new Guid("70dd0949-ba4e-4a1a-afd2-3d1d534b3705"), new Guid("96d56ba5-bc43-48ab-9bef-67ce1f436e6d"), new Guid("87d7f811-f523-4aa0-9c73-ac8c05fb1767"), "TKT96d56ba5015", null },
                    { new Guid("a5cb39e1-5136-497e-a66c-6a8828c38431"), new Guid("98661d35-6e40-49f2-958e-ada95e9b2fd0"), new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), new Guid("baefb53c-2ddf-46e2-ba71-c01a5bf6ec60"), "TKT0283516e010", null },
                    { new Guid("d4b6dbca-e65b-4abd-b374-082457c38956"), new Guid("01c60dcb-02a7-4f7a-afca-0a39153e3bf7"), new Guid("0283516e-b3a6-4d8f-bbc5-ff0e4a1c0482"), new Guid("8d1f48fe-8ae7-4668-8881-393172403acb"), "TKT0283516e008", null },
                    { new Guid("e342d7b3-2e35-49b8-9b78-df3cd0e5984b"), new Guid("8450f0ed-b47f-4564-8982-aafc1e8da40f"), new Guid("fe9622d0-58a4-40c6-8d53-8663bac757a1"), new Guid("34d35398-8d27-45d2-8081-37ca533cbb45"), "TKTfe9622d0013", null },
                    { new Guid("e78a72bc-01ed-438e-bebe-ae6065adcb2b"), new Guid("66a530e4-72a8-496f-b7d4-0650956f3c89"), new Guid("96d56ba5-bc43-48ab-9bef-67ce1f436e6d"), new Guid("d7594e40-5183-45aa-8121-9249c2960982"), "TKT96d56ba5002", null },
                    { new Guid("f42cb008-fdf3-4893-86c4-61306e9b4ef0"), new Guid("97b6777f-e05b-43b2-83e6-f43be1c44b31"), new Guid("c4b2b002-f88b-4541-b3bf-eee41d44d6c5"), new Guid("34d35398-8d27-45d2-8081-37ca533cbb45"), "TKTc4b2b002014", null },
                    { new Guid("f99ff172-9aa3-4b22-a8ad-5092309b799c"), new Guid("2fabd7ef-6569-4613-91a6-b379931012ba"), new Guid("3354259e-6f05-456f-941e-fb84df2f3097"), new Guid("baefb53c-2ddf-46e2-ba71-c01a5bf6ec60"), "TKT3354259e009", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_BuyerId",
                table: "Payments",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AttendeeId",
                table: "Tickets",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PaymentId",
                table: "Tickets",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAttendees_AttendeeId",
                table: "UserAttendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAttendees_UserId",
                table: "UserAttendees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventCalendars_EventId",
                table: "UserEventCalendars",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEventCalendars_UserId",
                table: "UserEventCalendars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserAttendees");

            migrationBuilder.DropTable(
                name: "UserEventCalendars");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Attendees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
