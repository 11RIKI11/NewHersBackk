using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    { new Guid("05f7a3ea-9028-435e-ae24-374336a7286b"), new DateTime(2004, 1, 11, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6585), new DateTime(2025, 5, 26, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4508 719064", "passport", "Петров Петр 8" },
                    { new Guid("09900b10-4638-43c1-9e91-1ebef3d083c5"), new DateTime(2008, 1, 9, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6690), new DateTime(2025, 5, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4530 682348", "passport", "Петров Петр 30" },
                    { new Guid("0a49c5c2-2151-48b6-bb6b-899e9cf760f2"), new DateTime(2004, 8, 19, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6588), new DateTime(2025, 5, 25, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "716621081", "foreign_passport", "Петров Петр 9" },
                    { new Guid("166db998-77a3-4add-8832-189f9bfc646c"), new DateTime(2008, 3, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6635), new DateTime(2025, 5, 21, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "718667873", "foreign_passport", "Петров Петр 13" },
                    { new Guid("16a1eb9c-a487-49d7-9869-88843eee7ee3"), new DateTime(2002, 3, 23, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6668), new DateTime(2025, 5, 11, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "711684046", "foreign_passport", "Петров Петр 23" },
                    { new Guid("22b532a5-6e8d-4ac8-9b85-707628ec8eee"), new DateTime(2007, 1, 26, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6638), new DateTime(2025, 5, 20, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4514 609140", "passport", "Петров Петр 14" },
                    { new Guid("269355b9-67f4-413b-b97e-19005e1d1899"), new DateTime(2009, 11, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6663), new DateTime(2025, 5, 13, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "718911778", "foreign_passport", "Петров Петр 21" },
                    { new Guid("36919f53-52ab-4746-9c3b-1355b82f1647"), new DateTime(2005, 1, 6, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6558), new DateTime(2025, 6, 1, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4502 354874", "passport", "Петров Петр 2" },
                    { new Guid("3c8db3a5-105d-4054-b080-47c967446149"), new DateTime(2001, 7, 25, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6568), new DateTime(2025, 5, 30, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4504 929793", "passport", "Петров Петр 4" },
                    { new Guid("431f03e5-69f1-43df-8339-fdfc618d8963"), new DateTime(2004, 8, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6598), new DateTime(2025, 5, 22, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4512 106247", "passport", "Петров Петр 12" },
                    { new Guid("482de6fc-411e-464c-a525-85082bbe58ee"), new DateTime(2007, 9, 12, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6658), new DateTime(2025, 5, 14, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4520 658550", "passport", "Петров Петр 20" },
                    { new Guid("4d9dc997-d7d9-47b7-a163-67bd95410cb1"), new DateTime(2001, 8, 16, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6688), new DateTime(2025, 5, 5, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "714266870", "foreign_passport", "Петров Петр 29" },
                    { new Guid("52f87051-5f6c-4869-8535-351b9b0d049b"), new DateTime(2008, 5, 15, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6655), new DateTime(2025, 5, 15, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "711964418", "foreign_passport", "Петров Петр 19" },
                    { new Guid("53c08289-84d6-46e9-b818-dfa6d8da4a0f"), new DateTime(2003, 5, 28, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6642), new DateTime(2025, 5, 19, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "712655280", "foreign_passport", "Петров Петр 15" },
                    { new Guid("59b9618a-5535-4a4e-845e-9e4c02265b13"), new DateTime(2006, 1, 8, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6674), new DateTime(2025, 5, 9, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "719355124", "foreign_passport", "Петров Петр 25" },
                    { new Guid("638c2954-c17f-4030-9d2d-0360e43d2b85"), new DateTime(2003, 6, 9, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6565), new DateTime(2025, 5, 31, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "712648195", "foreign_passport", "Петров Петр 3" },
                    { new Guid("6bffe0a3-4408-4249-ae36-36565809ae9f"), new DateTime(2007, 9, 6, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6573), new DateTime(2025, 5, 29, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "719585079", "foreign_passport", "Петров Петр 5" },
                    { new Guid("6dd23b55-e1a0-4bc0-b6d2-10c2e1956c42"), new DateTime(2009, 8, 11, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6581), new DateTime(2025, 5, 27, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "711048034", "foreign_passport", "Петров Петр 7" },
                    { new Guid("72914bf6-3665-4000-997f-b19de189a99a"), new DateTime(2009, 2, 19, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6550), new DateTime(2025, 6, 2, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "717964150", "foreign_passport", "Петров Петр 1" },
                    { new Guid("848320fb-2c51-45ff-89d0-86bdd144dad2"), new DateTime(2010, 1, 8, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6592), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4510 144660", "passport", "Петров Петр 10" },
                    { new Guid("8bd89f32-817c-4f6a-ba1e-faec95dd4216"), new DateTime(2003, 2, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6680), new DateTime(2025, 5, 7, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "715767443", "foreign_passport", "Петров Петр 27" },
                    { new Guid("92060bdd-0a2e-4b7f-a502-6ab9e5a0fdd8"), new DateTime(2005, 11, 19, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6648), new DateTime(2025, 5, 17, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "717010736", "foreign_passport", "Петров Петр 17" },
                    { new Guid("a62aa04d-5e34-470d-a9e7-fef04eba931e"), new DateTime(2002, 3, 6, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6683), new DateTime(2025, 5, 6, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4528 716136", "passport", "Петров Петр 28" },
                    { new Guid("a700f80d-dfdf-46aa-bf3a-911504065485"), new DateTime(2010, 3, 27, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6665), new DateTime(2025, 5, 12, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4522 788133", "passport", "Петров Петр 22" },
                    { new Guid("c2d8563a-5801-4b80-8ca2-899e8ec97059"), new DateTime(2006, 12, 26, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6645), new DateTime(2025, 5, 18, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4516 535549", "passport", "Петров Петр 16" },
                    { new Guid("d604a11a-6e92-4bc4-af3c-585b28e5ccc5"), new DateTime(2002, 8, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6652), new DateTime(2025, 5, 16, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4518 350843", "passport", "Петров Петр 18" },
                    { new Guid("dc7cac57-399f-4910-ad68-06b6e8300249"), new DateTime(2000, 8, 13, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6595), new DateTime(2025, 5, 23, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "717361446", "foreign_passport", "Петров Петр 11" },
                    { new Guid("f028997d-bd96-4b24-a62a-f0b859eb4019"), new DateTime(2005, 11, 11, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6678), new DateTime(2025, 5, 8, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4526 207440", "passport", "Петров Петр 26" },
                    { new Guid("f824c455-81b1-41ba-861c-31750e783db5"), new DateTime(2005, 3, 21, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6578), new DateTime(2025, 5, 28, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4506 573560", "passport", "Петров Петр 6" },
                    { new Guid("ff25a554-a5f4-41e2-bfcb-d11dd758f850"), new DateTime(2007, 1, 10, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6671), new DateTime(2025, 5, 10, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "4524 839352", "passport", "Петров Петр 24" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "Price", "StartTime", "Tag", "TicketsCount", "Title" },
                values: new object[,]
                {
                    { new Guid("0d56bddc-ca2d-4141-a654-94dadd739fe5"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по вечерняя москва", new DateTime(2025, 6, 11, 15, 0, 0, 0, DateTimeKind.Utc), true, "Тверская улица", 2400m, new DateTime(2025, 6, 11, 13, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Вечерняя Москва" },
                    { new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по москва купеческая", new DateTime(2025, 6, 10, 14, 0, 0, 0, DateTimeKind.Utc), true, "Замоскворечье", 2200m, new DateTime(2025, 6, 10, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Москва купеческая" },
                    { new Guid("441eb09d-ef74-4198-9d22-4153ff1366a6"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по московское метро", new DateTime(2025, 6, 13, 13, 0, 0, 0, DateTimeKind.Utc), true, "Площадь Революции", 2800m, new DateTime(2025, 6, 13, 11, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Московское метро" },
                    { new Guid("528b32d2-de91-40b7-81a6-e1a49dc40a54"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по архитектурная прогулка", new DateTime(2025, 6, 9, 13, 0, 0, 0, DateTimeKind.Utc), true, "Китай-город", 2000m, new DateTime(2025, 6, 9, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Архитектурная прогулка" },
                    { new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по музей космонавтики", new DateTime(2025, 6, 6, 14, 0, 0, 0, DateTimeKind.Utc), true, "пр-т Мира", 1400m, new DateTime(2025, 6, 6, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Музей космонавтики" },
                    { new Guid("8ceacdc0-3f08-4893-a79f-a5ce100a4f72"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по булгаковская москва", new DateTime(2025, 6, 12, 12, 0, 0, 0, DateTimeKind.Utc), true, "Патриаршие пруды", 2600m, new DateTime(2025, 6, 12, 10, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Булгаковская Москва" },
                    { new Guid("a482e26c-a668-4af0-b775-f5222683a8c8"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по экскурсия в кремль", new DateTime(2025, 6, 4, 12, 0, 0, 0, DateTimeKind.Utc), true, "Красная площадь", 1000m, new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Экскурсия в Кремль" },
                    { new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по царицыно", new DateTime(2025, 6, 7, 15, 0, 0, 0, DateTimeKind.Utc), true, "ул. Дольская", 1600m, new DateTime(2025, 6, 7, 13, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Царицыно" },
                    { new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по коломенское", new DateTime(2025, 6, 8, 12, 0, 0, 0, DateTimeKind.Utc), true, "пр-т Андропова", 1800m, new DateTime(2025, 6, 8, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Коломенское" },
                    { new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "Увлекательная экскурсия по третьяковская галерея", new DateTime(2025, 6, 5, 13, 0, 0, 0, DateTimeKind.Utc), true, "Лаврушинский переулок", 1200m, new DateTime(2025, 6, 5, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Третьяковская галерея" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("06c98e8c-1fb4-4d24-bcd4-f505e1e4f329"), new DateTime(1995, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6510), new DateTime(2025, 5, 20, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user16@example.com", "Иванов Иван 16", "hash123", "+79000000016", "user" },
                    { new Guid("136749bf-4820-42fb-ba5f-e49e1e151210"), new DateTime(1989, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6489), new DateTime(2025, 5, 14, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user10@example.com", "Иванов Иван 10", "hash123", "+79000000010", "user" },
                    { new Guid("14b89b15-41d3-4648-ba8a-e27d8a38be5c"), new DateTime(2001, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6392), new DateTime(2025, 5, 6, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user2@example.com", "Иванов Иван 2", "hash123", "+79000000002", "user" },
                    { new Guid("15e95276-17f9-44bc-9bcb-07cee7dd58b6"), new DateTime(1990, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6505), new DateTime(2025, 5, 18, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user14@example.com", "Иванов Иван 14", "hash123", "+79000000014", "user" },
                    { new Guid("1d552548-659f-45e8-9925-61e65e31a53c"), new DateTime(1999, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6382), new DateTime(2025, 5, 5, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user1@example.com", "Иванов Иван 1", "hash123", "+79000000001", "user" },
                    { new Guid("2d1e5bdc-7c2e-4ddd-ab05-1f89ed59b9f6"), new DateTime(1992, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6513), new DateTime(2025, 5, 21, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user17@example.com", "Иванов Иван 17", "hash123", "+79000000017", "user" },
                    { new Guid("2ff0fb86-563d-4845-bd45-709b3a1d1f40"), new DateTime(1989, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6482), new DateTime(2025, 5, 13, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user9@example.com", "Иванов Иван 9", "hash123", "+79000000009", "user" },
                    { new Guid("60b67356-fb07-4c98-906a-cdde28a419e6"), new DateTime(1990, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6521), new DateTime(2025, 5, 23, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user19@example.com", "Иванов Иван 19", "hash123", "+79000000019", "user" },
                    { new Guid("6b7ff871-84d1-4577-812d-d543c01d730c"), new DateTime(1996, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6474), new DateTime(2025, 5, 11, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user7@example.com", "Иванов Иван 7", "hash123", "+79000000007", "user" },
                    { new Guid("6bc4adef-d7db-4788-b290-14c286474cc0"), new DateTime(1994, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6478), new DateTime(2025, 5, 12, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user8@example.com", "Иванов Иван 8", "hash123", "+79000000008", "user" },
                    { new Guid("7d740557-77de-49da-9882-d12122f6f1e6"), new DateTime(1993, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6493), new DateTime(2025, 5, 15, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user11@example.com", "Иванов Иван 11", "hash123", "+79000000011", "user" },
                    { new Guid("7e6ed28e-17c3-4e3a-b6f7-a2717b36c902"), new DateTime(1988, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6539), new DateTime(2025, 4, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "admin2@example.com", "Администратор 2", "hashadmin", "+79990000002", "admin" },
                    { new Guid("7f175dfa-fad1-4332-9981-1d7ca5653540"), new DateTime(1991, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6543), new DateTime(2025, 4, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "admin3@example.com", "Администратор 3", "hashadmin", "+79990000003", "admin" },
                    { new Guid("a98ee5e6-efef-47c4-bc92-bbd26d4591b9"), new DateTime(1986, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6518), new DateTime(2025, 5, 22, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user18@example.com", "Иванов Иван 18", "hash123", "+79000000018", "user" },
                    { new Guid("b4c45b06-5158-43ef-a209-4e2d87689a9b"), new DateTime(1988, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6498), new DateTime(2025, 5, 16, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user12@example.com", "Иванов Иван 12", "hash123", "+79000000012", "user" },
                    { new Guid("b4df66bd-f199-48f6-ad56-47b23516b8c6"), new DateTime(1994, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6534), new DateTime(2025, 4, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "admin1@example.com", "Администратор 1", "hashadmin", "+79990000001", "admin" },
                    { new Guid("bd5f7c42-2b9a-41af-97af-04b6d8ce138a"), new DateTime(2002, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6465), new DateTime(2025, 5, 9, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user5@example.com", "Иванов Иван 5", "hash123", "+79000000005", "user" },
                    { new Guid("be52a04e-4be2-4d7e-8a5c-409013d72ba1"), new DateTime(1997, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6470), new DateTime(2025, 5, 10, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user6@example.com", "Иванов Иван 6", "hash123", "+79000000006", "user" },
                    { new Guid("d6e30141-983a-4cbf-8316-a41ae3c75f3d"), new DateTime(1993, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6526), new DateTime(2025, 5, 24, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user20@example.com", "Иванов Иван 20", "hash123", "+79000000020", "user" },
                    { new Guid("daa4f299-b390-4384-bf81-61656b3f7221"), new DateTime(1991, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6501), new DateTime(2025, 5, 17, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user13@example.com", "Иванов Иван 13", "hash123", "+79000000013", "user" },
                    { new Guid("daae1eef-841b-4444-80b1-4cc0a4201503"), new DateTime(2001, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6455), new DateTime(2025, 5, 7, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user3@example.com", "Иванов Иван 3", "hash123", "+79000000003", "user" },
                    { new Guid("e708edcd-93bb-4fcd-aab1-d30e0bb069d4"), new DateTime(2001, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6508), new DateTime(2025, 5, 19, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user15@example.com", "Иванов Иван 15", "hash123", "+79000000015", "user" },
                    { new Guid("f8e38584-806b-457e-aad8-9996a406a883"), new DateTime(2002, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6461), new DateTime(2025, 5, 8, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), "user4@example.com", "Иванов Иван 4", "hash123", "+79000000004", "user" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BuyerId", "CreatedAt", "PaidAt", "QrUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("236710f7-3a3e-40cb-93e7-bd779f03fe24"), 3200m, new Guid("daa4f299-b390-4384-bf81-61656b3f7221"), new DateTime(2025, 5, 30, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 5, 30, 16, 2, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/236710f7-3a3e-40cb-93e7-bd779f03fe24", "paid" },
                    { new Guid("28ae2f6d-21b4-47e3-a623-663ef3cd9c77"), 1200m, new Guid("a98ee5e6-efef-47c4-bc92-bbd26d4591b9"), new DateTime(2025, 6, 6, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 6, 15, 53, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/28ae2f6d-21b4-47e3-a623-663ef3cd9c77", "paid" },
                    { new Guid("63075259-a13a-4e43-b94c-90625872c5da"), 0m, new Guid("bd5f7c42-2b9a-41af-97af-04b6d8ce138a"), new DateTime(2025, 6, 7, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 7, 16, 6, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/63075259-a13a-4e43-b94c-90625872c5da", "paid" },
                    { new Guid("6fadee5b-916c-4953-8610-bf1cd2dd03b5"), 3200m, new Guid("bd5f7c42-2b9a-41af-97af-04b6d8ce138a"), new DateTime(2025, 6, 3, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 3, 15, 49, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/6fadee5b-916c-4953-8610-bf1cd2dd03b5", "paid" },
                    { new Guid("70ef6e96-80e6-43f0-b85b-852d602c2f35"), 0m, new Guid("be52a04e-4be2-4d7e-8a5c-409013d72ba1"), new DateTime(2025, 6, 8, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 8, 16, 0, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/70ef6e96-80e6-43f0-b85b-852d602c2f35", "paid" },
                    { new Guid("84757dd4-9913-4d16-945b-3657dd48818e"), 4000m, new Guid("bd5f7c42-2b9a-41af-97af-04b6d8ce138a"), new DateTime(2025, 6, 2, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 2, 16, 9, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/84757dd4-9913-4d16-945b-3657dd48818e", "paid" },
                    { new Guid("8e8976dd-6d13-4e2d-ba34-5e8755039b79"), 3800m, new Guid("daae1eef-841b-4444-80b1-4cc0a4201503"), new DateTime(2025, 6, 4, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 4, 15, 55, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/8e8976dd-6d13-4e2d-ba34-5e8755039b79", "paid" },
                    { new Guid("b00f0a9e-9a56-4c8d-af0e-df2d15ecd1df"), 3800m, new Guid("15e95276-17f9-44bc-9bcb-07cee7dd58b6"), new DateTime(2025, 5, 31, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 5, 31, 15, 45, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/b00f0a9e-9a56-4c8d-af0e-df2d15ecd1df", "paid" },
                    { new Guid("b88c88b1-29d6-464e-8662-2c6a35a2a361"), 2800m, new Guid("7d740557-77de-49da-9882-d12122f6f1e6"), new DateTime(2025, 6, 5, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 5, 15, 53, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/b88c88b1-29d6-464e-8662-2c6a35a2a361", "paid" },
                    { new Guid("d9329098-a3ad-471e-861f-25d17a54b052"), 3000m, new Guid("06c98e8c-1fb4-4d24-bcd4-f505e1e4f329"), new DateTime(2025, 6, 1, 15, 40, 53, 168, DateTimeKind.Utc).AddTicks(6207), new DateTime(2025, 6, 1, 16, 4, 53, 168, DateTimeKind.Utc).AddTicks(6207), "https://payment.example.com/d9329098-a3ad-471e-861f-25d17a54b052", "paid" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "Event", "PaymentId", "QRCode", "UserId" },
                values: new object[,]
                {
                    { new Guid("00c45b7e-6446-4c7a-8a43-346f599c2d4b"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec030", null },
                    { new Guid("129f4b5f-475e-4af5-9805-4569a36ca215"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435026", null },
                    { new Guid("1344ac77-40df-434b-ba3e-15cfabdeb883"), null, new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), null, "TKTf2bdbbbf038", null },
                    { new Guid("1ace637a-f226-441a-b3e4-1fcc0cb455dc"), null, new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), null, "TKTf2bdbbbf025", null },
                    { new Guid("1b5a9ec0-6de2-4037-bf1a-d34b5763c35e"), null, new Guid("a482e26c-a668-4af0-b775-f5222683a8c8"), null, "TKTa482e26c024", null },
                    { new Guid("1b629593-7142-4d8e-b00b-983f0162c801"), null, new Guid("441eb09d-ef74-4198-9d22-4153ff1366a6"), null, "TKT441eb09d034", null },
                    { new Guid("1db4e669-1a1d-4169-8884-c547b1bcf872"), null, new Guid("441eb09d-ef74-4198-9d22-4153ff1366a6"), null, "TKT441eb09d036", null },
                    { new Guid("262449e1-19fb-4557-abe1-2f87b1a56226"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec049", null },
                    { new Guid("295a3cb7-4c30-4139-9262-f70ec84e4001"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435041", null },
                    { new Guid("29730f3d-68e3-4d41-8469-62ebe7f9caf3"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec027", null },
                    { new Guid("2cc4bf65-82ab-4691-b352-42c9a65a6ddf"), null, new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), null, "TKTf2bdbbbf020", null },
                    { new Guid("2d84312e-f1ca-4ec5-9b04-6d561f869974"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec039", null },
                    { new Guid("38bbb29d-374a-4f33-819e-4aa8a87a919f"), null, new Guid("0d56bddc-ca2d-4141-a654-94dadd739fe5"), null, "TKT0d56bddc047", null },
                    { new Guid("41267beb-c9fd-44b9-aa2e-0f510712f72c"), null, new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), null, "TKTd864fc46033", null },
                    { new Guid("4635f2da-c0f0-440d-9dc0-d2c02775ccaf"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435048", null },
                    { new Guid("570fb42a-367b-4e0a-b456-341e677972bf"), null, new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), null, "TKTd864fc46050", null },
                    { new Guid("603f80ea-626f-4e43-9cfd-541b55ff354a"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec016", null },
                    { new Guid("68730227-8e52-4f6e-9073-bb16f1afdea0"), null, new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), null, "TKTf2bdbbbf018", null },
                    { new Guid("70585432-d0da-4fc9-8a27-1e41fc62e2ea"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435019", null },
                    { new Guid("708f7395-cd4f-4d59-989b-ea9c19faa792"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435037", null },
                    { new Guid("731aeb77-b082-4d93-ba39-6d440ffd62af"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435021", null },
                    { new Guid("89f78ead-0c34-4c33-bfe9-49001c08b3ea"), null, new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), null, "TKT5b7b5988043", null },
                    { new Guid("ac278cbc-f2f6-4349-8d5d-005fb819f922"), null, new Guid("528b32d2-de91-40b7-81a6-e1a49dc40a54"), null, "TKT528b32d2017", null },
                    { new Guid("ad808136-d307-4c50-a203-1cef0c1fd11b"), null, new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), null, "TKT5b7b5988042", null },
                    { new Guid("b879c97f-9cc4-42c8-b202-74bc9c03a952"), null, new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), null, "TKT5b7b5988046", null },
                    { new Guid("c71e22c7-1fda-4d74-b4e6-f92bbb244d15"), null, new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), null, "TKT37cd5435023", null },
                    { new Guid("c9fd5c42-e6bb-4254-9ab4-97bd2bd13c57"), null, new Guid("8ceacdc0-3f08-4893-a79f-a5ce100a4f72"), null, "TKT8ceacdc0031", null },
                    { new Guid("cbeeefec-6761-4b94-a8a2-a5e9818437a2"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec029", null },
                    { new Guid("cc192b23-4854-42a9-900a-24b8cfa75fde"), null, new Guid("528b32d2-de91-40b7-81a6-e1a49dc40a54"), null, "TKT528b32d2040", null },
                    { new Guid("ce191abc-3b1f-44c0-9107-3c55367665f5"), null, new Guid("a482e26c-a668-4af0-b775-f5222683a8c8"), null, "TKTa482e26c044", null },
                    { new Guid("d565406d-2d26-4a73-9e8e-0981ae0c6a3a"), null, new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), null, "TKTd43be1ec035", null },
                    { new Guid("daa71b64-ec86-4b82-a0ba-d545921624c0"), null, new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), null, "TKTd864fc46045", null },
                    { new Guid("e0971454-d7f1-4ebe-9bfb-075701224ec9"), null, new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), null, "TKT5b7b5988028", null },
                    { new Guid("f134af38-7397-401b-8088-753b90f7ab28"), null, new Guid("0d56bddc-ca2d-4141-a654-94dadd739fe5"), null, "TKT0d56bddc032", null },
                    { new Guid("fe2860b5-c788-462c-a397-a9b26ed87314"), null, new Guid("0d56bddc-ca2d-4141-a654-94dadd739fe5"), null, "TKT0d56bddc022", null },
                    { new Guid("00333c23-4312-4642-b2bb-fa446ad15628"), new Guid("269355b9-67f4-413b-b97e-19005e1d1899"), new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), new Guid("8e8976dd-6d13-4e2d-ba34-5e8755039b79"), "TKTd43be1ec012", null },
                    { new Guid("03000fbd-4ea3-49eb-91ed-dd7484197da3"), new Guid("d604a11a-6e92-4bc4-af3c-585b28e5ccc5"), new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), new Guid("8e8976dd-6d13-4e2d-ba34-5e8755039b79"), "TKT37cd5435011", null },
                    { new Guid("0ca576ef-b9f1-4437-b27c-dc87e1a0ce0c"), new Guid("269355b9-67f4-413b-b97e-19005e1d1899"), new Guid("37cd5435-ee58-41f7-ab33-6b302a457dc7"), new Guid("84757dd4-9913-4d16-945b-3657dd48818e"), "TKT37cd5435007", null },
                    { new Guid("13679d81-b942-4d59-8391-8cdb8662a83b"), new Guid("8bd89f32-817c-4f6a-ba1e-faec95dd4216"), new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), new Guid("6fadee5b-916c-4953-8610-bf1cd2dd03b5"), "TKTd43be1ec009", null },
                    { new Guid("1f2901a4-be40-48d9-9d9c-1de5c673a369"), new Guid("6bffe0a3-4408-4249-ae36-36565809ae9f"), new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), new Guid("d9329098-a3ad-471e-861f-25d17a54b052"), "TKTd864fc46005", null },
                    { new Guid("284ba885-250b-4924-b30c-1154280215e0"), new Guid("0a49c5c2-2151-48b6-bb6b-899e9cf760f2"), new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), new Guid("b00f0a9e-9a56-4c8d-af0e-df2d15ecd1df"), "TKTf2bdbbbf004", null },
                    { new Guid("5d680c55-9f5a-47ca-9b8a-b3524b0830d7"), new Guid("a700f80d-dfdf-46aa-bf3a-911504065485"), new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), new Guid("236710f7-3a3e-40cb-93e7-bd779f03fe24"), "TKTd864fc46001", null },
                    { new Guid("8d9f949e-f861-484c-bd79-f4e77a390baf"), new Guid("52f87051-5f6c-4869-8535-351b9b0d049b"), new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), new Guid("b88c88b1-29d6-464e-8662-2c6a35a2a361"), "TKT5b7b5988014", null },
                    { new Guid("8e0da62c-cef1-4d4a-9248-ccdc097dab40"), new Guid("dc7cac57-399f-4910-ad68-06b6e8300249"), new Guid("8ceacdc0-3f08-4893-a79f-a5ce100a4f72"), new Guid("b00f0a9e-9a56-4c8d-af0e-df2d15ecd1df"), "TKT8ceacdc0003", null },
                    { new Guid("b33a8512-1e4f-4bf3-8315-cc1d7a82050c"), new Guid("638c2954-c17f-4030-9d2d-0360e43d2b85"), new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), new Guid("236710f7-3a3e-40cb-93e7-bd779f03fe24"), "TKT5b7b5988002", null },
                    { new Guid("b37d7c75-ac52-4d3d-b106-af2d75c2c207"), new Guid("0a49c5c2-2151-48b6-bb6b-899e9cf760f2"), new Guid("d43be1ec-ddc0-4330-99ed-c513636f7b52"), new Guid("6fadee5b-916c-4953-8610-bf1cd2dd03b5"), "TKTd43be1ec010", null },
                    { new Guid("e00e7a25-c6b5-4988-9b8e-360fc4cbd360"), new Guid("4d9dc997-d7d9-47b7-a163-67bd95410cb1"), new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), new Guid("d9329098-a3ad-471e-861f-25d17a54b052"), "TKTf2bdbbbf006", null },
                    { new Guid("e1028833-d55e-4e1f-8a66-758bf7c57e3b"), new Guid("482de6fc-411e-464c-a525-85082bbe58ee"), new Guid("d864fc46-723a-4b22-a5f4-2b69c562bacc"), new Guid("84757dd4-9913-4d16-945b-3657dd48818e"), "TKTd864fc46008", null },
                    { new Guid("e1b383b1-ff6d-4f04-8ccb-c2413da1f87c"), new Guid("3c8db3a5-105d-4054-b080-47c967446149"), new Guid("5b7b5988-cdce-4724-bbb7-476db0785ee1"), new Guid("b88c88b1-29d6-464e-8662-2c6a35a2a361"), "TKT5b7b5988013", null },
                    { new Guid("edd303a8-30e7-4f35-b12d-c74547523a64"), new Guid("05f7a3ea-9028-435e-ae24-374336a7286b"), new Guid("f2bdbbbf-c407-4fe8-b81a-afd85e45bd6a"), new Guid("28ae2f6d-21b4-47e3-a623-663ef3cd9c77"), "TKTf2bdbbbf015", null }
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
                column: "Event");

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
                column: "Event");

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
