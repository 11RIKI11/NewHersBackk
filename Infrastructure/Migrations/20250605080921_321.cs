using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _321 : Migration
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
                    { new Guid("03cc68b7-58ee-4cdb-b4ba-22b4613ba451"), new DateTime(2004, 4, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9284), new DateTime(2025, 4, 7, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722948394", "foreignPassport", "Участник Херсонеса 59" },
                    { new Guid("07568300-aa35-4e99-b816-96511a0fa1c8"), new DateTime(2007, 8, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9170), new DateTime(2025, 5, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722948864", "foreignPassport", "Участник Херсонеса 19" },
                    { new Guid("0912fcc3-1750-49b4-8e66-c73244253b53"), new DateTime(2006, 12, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9410), new DateTime(2025, 2, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4098 514913", "passport", "Участник Херсонеса 98" },
                    { new Guid("1113036a-e3e9-421a-af7b-ea2999fa522f"), new DateTime(2007, 1, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9251), new DateTime(2025, 4, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4044 130525", "passport", "Участник Херсонеса 44" },
                    { new Guid("18cf480d-2811-405a-a6b9-6d1cb9f3a8f6"), new DateTime(2004, 12, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9126), new DateTime(2025, 6, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4002 489191", "passport", "Участник Херсонеса 2" },
                    { new Guid("215773c5-0e07-4d7b-b0c7-7f68c5a810f0"), new DateTime(2003, 12, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9187), new DateTime(2025, 5, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "726986019", "foreignPassport", "Участник Херсонеса 27" },
                    { new Guid("21d1fbcd-18c8-4ad8-b64d-396b877adea3"), new DateTime(2002, 2, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9295), new DateTime(2025, 4, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4064 285892", "passport", "Участник Херсонеса 64" },
                    { new Guid("22610c90-ec92-4bdb-b014-be673fe71790"), new DateTime(2008, 9, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9278), new DateTime(2025, 4, 10, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4056 778582", "passport", "Участник Херсонеса 56" },
                    { new Guid("2393dbfc-0a01-4a29-b3de-fec739d81173"), new DateTime(2005, 6, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9380), new DateTime(2025, 3, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4084 367982", "passport", "Участник Херсонеса 84" },
                    { new Guid("24b32027-3eeb-44b9-b08c-2f726484552c"), new DateTime(2005, 2, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9274), new DateTime(2025, 4, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4054 226610", "passport", "Участник Херсонеса 54" },
                    { new Guid("2bd2be13-ab0d-47ce-a856-85203f63f2ee"), new DateTime(2007, 3, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9260), new DateTime(2025, 4, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4048 340799", "passport", "Участник Херсонеса 48" },
                    { new Guid("2cd8ae16-5402-48cb-bbfd-f1f3ffea766e"), new DateTime(2005, 10, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9196), new DateTime(2025, 5, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "727358004", "foreignPassport", "Участник Херсонеса 31" },
                    { new Guid("33cf855d-a515-4389-8da5-d685e07954f7"), new DateTime(2008, 11, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9247), new DateTime(2025, 4, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4042 186133", "passport", "Участник Херсонеса 42" },
                    { new Guid("34884df2-6274-4fbd-9b3c-b816b5587643"), new DateTime(2008, 12, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9280), new DateTime(2025, 4, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "726687600", "foreignPassport", "Участник Херсонеса 57" },
                    { new Guid("34c6f5f8-3cfd-4472-ac75-4bc2ca4b767a"), new DateTime(2008, 3, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9172), new DateTime(2025, 5, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4020 131105", "passport", "Участник Херсонеса 20" },
                    { new Guid("3655b329-9bc5-41d5-947e-6e55523c6ee2"), new DateTime(2003, 2, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9152), new DateTime(2025, 5, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722286062", "foreignPassport", "Участник Херсонеса 11" },
                    { new Guid("389509ca-ef78-4f66-9961-effff3d1a08a"), new DateTime(2007, 10, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9150), new DateTime(2025, 5, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4010 731827", "passport", "Участник Херсонеса 10" },
                    { new Guid("423b042e-7c45-4b70-85b6-783c49f5247b"), new DateTime(2006, 1, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9311), new DateTime(2025, 3, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4072 474253", "passport", "Участник Херсонеса 72" },
                    { new Guid("44a9bad0-0cdd-442c-a0aa-629d75659f50"), new DateTime(2004, 3, 7, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9256), new DateTime(2025, 4, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4046 110335", "passport", "Участник Херсонеса 46" },
                    { new Guid("4bfd0a83-5fba-4e56-a177-37bbe40738a0"), new DateTime(2008, 9, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9200), new DateTime(2025, 5, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721335959", "foreignPassport", "Участник Херсонеса 33" },
                    { new Guid("4da14c68-5f9a-4584-9ef4-415342065bda"), new DateTime(2003, 7, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9315), new DateTime(2025, 3, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4074 594747", "passport", "Участник Херсонеса 74" },
                    { new Guid("4e24432b-04d4-4375-ba2e-78bff0e4b3ae"), new DateTime(2005, 1, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9243), new DateTime(2025, 4, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4040 810870", "passport", "Участник Херсонеса 40" },
                    { new Guid("4eefab71-fa7f-4044-950c-09d01b7380cb"), new DateTime(2007, 9, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9286), new DateTime(2025, 4, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4060 832215", "passport", "Участник Херсонеса 60" },
                    { new Guid("4f9969c3-03c5-4ac4-8050-9f015bc074f2"), new DateTime(2008, 12, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9166), new DateTime(2025, 5, 19, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "729141640", "foreignPassport", "Участник Херсонеса 17" },
                    { new Guid("5258364d-f5fe-44b4-9317-4934ed842577"), new DateTime(2001, 8, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9263), new DateTime(2025, 4, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "725209610", "foreignPassport", "Участник Херсонеса 49" },
                    { new Guid("54e8c984-3688-427d-82f3-0c18f5d8b14a"), new DateTime(2006, 9, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9402), new DateTime(2025, 3, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4094 228242", "passport", "Участник Херсонеса 94" },
                    { new Guid("5d01279c-7a39-43d2-9f22-a9a03abf7049"), new DateTime(2001, 10, 10, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9319), new DateTime(2025, 3, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4076 706224", "passport", "Участник Херсонеса 76" },
                    { new Guid("5de00c40-3983-41fb-a69f-919d2edf52fa"), new DateTime(2002, 10, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9210), new DateTime(2025, 4, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721573661", "foreignPassport", "Участник Херсонеса 37" },
                    { new Guid("5e4c88bd-5eca-4ed5-b864-9cd5d6d7e865"), new DateTime(2006, 4, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9194), new DateTime(2025, 5, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4030 302564", "passport", "Участник Херсонеса 30" },
                    { new Guid("5fedd773-85a8-45c9-9ac0-b08f1b5a612c"), new DateTime(2004, 6, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9378), new DateTime(2025, 3, 14, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "725513335", "foreignPassport", "Участник Херсонеса 83" },
                    { new Guid("6052fdf4-d4fa-4018-85e5-b5c216644376"), new DateTime(2006, 3, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9168), new DateTime(2025, 5, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4018 360186", "passport", "Участник Херсонеса 18" },
                    { new Guid("63fa3409-ad59-4418-8b64-fcc0062ba474"), new DateTime(2003, 1, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9143), new DateTime(2025, 5, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722671975", "foreignPassport", "Участник Херсонеса 7" },
                    { new Guid("67210f02-c3fc-4e57-a3d0-c411240899b5"), new DateTime(2009, 6, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9395), new DateTime(2025, 3, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728923793", "foreignPassport", "Участник Херсонеса 91" },
                    { new Guid("6d334bd9-69b5-488b-b50a-6bcbe1eb37bc"), new DateTime(2009, 4, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9265), new DateTime(2025, 4, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4050 169663", "passport", "Участник Херсонеса 50" },
                    { new Guid("6d827a77-5d12-42e4-bdc7-8d73951e34bf"), new DateTime(2003, 6, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9145), new DateTime(2025, 5, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4008 455691", "passport", "Участник Херсонеса 8" },
                    { new Guid("72bff8bb-e794-41b3-b2ed-f2a09026acbf"), new DateTime(2004, 10, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9205), new DateTime(2025, 5, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "724504350", "foreignPassport", "Участник Херсонеса 35" },
                    { new Guid("74fe23d3-47e4-4bb1-b5d8-36b1d34a86b6"), new DateTime(2002, 1, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9183), new DateTime(2025, 5, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728897499", "foreignPassport", "Участник Херсонеса 25" },
                    { new Guid("7519c93a-10f9-4a24-a811-2b57222f88a6"), new DateTime(2000, 7, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9404), new DateTime(2025, 3, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728245472", "foreignPassport", "Участник Херсонеса 95" },
                    { new Guid("76080d87-f976-40f1-8b10-a53630284249"), new DateTime(2007, 2, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9289), new DateTime(2025, 4, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722293516", "foreignPassport", "Участник Херсонеса 61" },
                    { new Guid("78073e63-3234-471c-a132-4ba128b2762d"), new DateTime(2004, 8, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9408), new DateTime(2025, 2, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722480874", "foreignPassport", "Участник Херсонеса 97" },
                    { new Guid("7ab64205-2710-4772-b7df-6a0990bd3a91"), new DateTime(2005, 2, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9273), new DateTime(2025, 4, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "724867260", "foreignPassport", "Участник Херсонеса 53" },
                    { new Guid("7c9d2f00-fee9-4d24-8e84-318c1f8bb3ab"), new DateTime(2004, 1, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9389), new DateTime(2025, 3, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4088 182878", "passport", "Участник Херсонеса 88" },
                    { new Guid("7ebb515e-88a1-42c0-a750-4a1fc532744f"), new DateTime(2003, 1, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9376), new DateTime(2025, 3, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4082 475778", "passport", "Участник Херсонеса 82" },
                    { new Guid("839a9764-2262-4c51-a9d4-7c36fec3edfd"), new DateTime(2002, 9, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9297), new DateTime(2025, 4, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721411498", "foreignPassport", "Участник Херсонеса 65" },
                    { new Guid("86a12db6-1909-4717-9e3b-7c9c57bbd524"), new DateTime(2009, 2, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9368), new DateTime(2025, 3, 19, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4078 666909", "passport", "Участник Херсонеса 78" },
                    { new Guid("897c170f-cb3a-4714-80ac-d557e8e24c8d"), new DateTime(2004, 11, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9241), new DateTime(2025, 4, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "724646604", "foreignPassport", "Участник Херсонеса 39" },
                    { new Guid("8ea15733-b7f8-4d94-893b-04b7bbbd8804"), new DateTime(2010, 5, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9185), new DateTime(2025, 5, 10, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4026 918139", "passport", "Участник Херсонеса 26" },
                    { new Guid("8f6f160e-757c-4355-804a-bd68aa520b63"), new DateTime(2001, 6, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9393), new DateTime(2025, 3, 7, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4090 252827", "passport", "Участник Херсонеса 90" },
                    { new Guid("8fb8a53e-62f4-4e35-a959-9c6ccbda84d0"), new DateTime(2004, 12, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9299), new DateTime(2025, 3, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4066 520814", "passport", "Участник Херсонеса 66" },
                    { new Guid("92964d03-153d-4b7b-b882-981486b077c5"), new DateTime(2001, 2, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9134), new DateTime(2025, 6, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4004 349979", "passport", "Участник Херсонеса 4" },
                    { new Guid("93596350-bc43-41c1-8a7c-5b88aff62a7d"), new DateTime(2004, 10, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9413), new DateTime(2025, 2, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "40100 778256", "passport", "Участник Херсонеса 100" },
                    { new Guid("95f6294e-2183-4eb0-a463-28babed4597f"), new DateTime(2001, 4, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9132), new DateTime(2025, 6, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "725819109", "foreignPassport", "Участник Херсонеса 3" },
                    { new Guid("996c602a-22c7-4acf-8be5-563ccb36838f"), new DateTime(2008, 9, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9164), new DateTime(2025, 5, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4016 613066", "passport", "Участник Херсонеса 16" },
                    { new Guid("99dbfb88-4c60-463c-beb7-1201ae899787"), new DateTime(2008, 2, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9148), new DateTime(2025, 5, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728442478", "foreignPassport", "Участник Херсонеса 9" },
                    { new Guid("9b104526-5b82-4d34-959b-aaf0e4f87164"), new DateTime(2008, 7, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9374), new DateTime(2025, 3, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728944401", "foreignPassport", "Участник Херсонеса 81" },
                    { new Guid("9d91a722-ccd9-4af3-bcac-bceb30e66092"), new DateTime(2004, 10, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9141), new DateTime(2025, 5, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4006 193943", "passport", "Участник Херсонеса 6" },
                    { new Guid("a339c206-3288-4d8e-8a2a-92d2c20bdbe7"), new DateTime(2002, 11, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9308), new DateTime(2025, 3, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4070 258332", "passport", "Участник Херсонеса 70" },
                    { new Guid("a3aab0b0-b136-4875-9313-512a4484c0d4"), new DateTime(2005, 6, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9269), new DateTime(2025, 4, 14, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4052 820472", "passport", "Участник Херсонеса 52" },
                    { new Guid("a5180c2a-5bd1-4325-8e41-756a7713df69"), new DateTime(2005, 11, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9179), new DateTime(2025, 5, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728968688", "foreignPassport", "Участник Херсонеса 23" },
                    { new Guid("a5ad8ff7-5fb4-44e8-ab76-fb2689a5d45a"), new DateTime(2002, 6, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9176), new DateTime(2025, 5, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "729043293", "foreignPassport", "Участник Херсонеса 21" },
                    { new Guid("a5f504ad-620f-4430-ab11-796701726c76"), new DateTime(2009, 8, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9192), new DateTime(2025, 5, 7, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "729762872", "foreignPassport", "Участник Херсонеса 29" },
                    { new Guid("a6030668-a3d7-4499-9d7f-46d674e0d000"), new DateTime(2004, 8, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9411), new DateTime(2025, 2, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728720867", "foreignPassport", "Участник Херсонеса 99" },
                    { new Guid("a9515cf9-23ef-43c9-bf89-0e85459ca30e"), new DateTime(2008, 5, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9313), new DateTime(2025, 3, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "723594045", "foreignPassport", "Участник Херсонеса 73" },
                    { new Guid("ab0bc4c9-e944-4fcc-9ec6-e7bb1cd78cca"), new DateTime(2003, 5, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9276), new DateTime(2025, 4, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "725672103", "foreignPassport", "Участник Херсонеса 55" },
                    { new Guid("abb63f99-b58b-44c1-b9bd-c5b40649fa85"), new DateTime(2008, 8, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9249), new DateTime(2025, 4, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "727416057", "foreignPassport", "Участник Херсонеса 43" },
                    { new Guid("aed2f5f4-51b6-444e-b035-75f985c54224"), new DateTime(2008, 8, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9160), new DateTime(2025, 5, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4014 495471", "passport", "Участник Херсонеса 14" },
                    { new Guid("b03ddd25-99d8-4f25-b332-cb245b6a5f66"), new DateTime(2009, 1, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9162), new DateTime(2025, 5, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721548969", "foreignPassport", "Участник Херсонеса 15" },
                    { new Guid("b0bee630-30b5-4fab-bc74-ef5a3fa41f19"), new DateTime(2009, 9, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9207), new DateTime(2025, 4, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4036 731513", "passport", "Участник Херсонеса 36" },
                    { new Guid("b4f44439-2a0c-440b-86d9-4806748d4dd8"), new DateTime(2009, 10, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9391), new DateTime(2025, 3, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "726227710", "foreignPassport", "Участник Херсонеса 89" },
                    { new Guid("b7c085ea-5dda-4f9b-b6fc-a284327ec0d5"), new DateTime(2005, 3, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9406), new DateTime(2025, 3, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4096 707533", "passport", "Участник Херсонеса 96" },
                    { new Guid("bcff8abf-4f5c-44c9-9447-5fe9ed98ef14"), new DateTime(2007, 5, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9138), new DateTime(2025, 5, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721913622", "foreignPassport", "Участник Херсонеса 5" },
                    { new Guid("bd201d85-0b77-4acf-bdaf-8999cd56f8e7"), new DateTime(2003, 1, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9198), new DateTime(2025, 5, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4032 557876", "passport", "Участник Херсонеса 32" },
                    { new Guid("c2a9c6f6-2990-497f-9e90-2636b66e31f2"), new DateTime(2007, 11, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9387), new DateTime(2025, 3, 10, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "722538072", "foreignPassport", "Участник Херсонеса 87" },
                    { new Guid("c3622708-8a33-4b62-9d8f-aff91cd249b4"), new DateTime(2001, 5, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9306), new DateTime(2025, 3, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "725441586", "foreignPassport", "Участник Херсонеса 69" },
                    { new Guid("c719284b-4466-4d8e-851b-4d1b1eb100f4"), new DateTime(2002, 5, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9245), new DateTime(2025, 4, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "728667312", "foreignPassport", "Участник Херсонеса 41" },
                    { new Guid("c834823a-37ea-4c6b-bb14-5e4df8cc9e78"), new DateTime(2001, 3, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9303), new DateTime(2025, 3, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4068 209002", "passport", "Участник Херсонеса 68" },
                    { new Guid("cb1af63e-4fd5-4d6b-8038-de20e24f33c1"), new DateTime(2008, 5, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9293), new DateTime(2025, 4, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "729941372", "foreignPassport", "Участник Херсонеса 63" },
                    { new Guid("ccc3f196-e3a3-456b-bc9b-ca33c1681ef3"), new DateTime(2000, 8, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9254), new DateTime(2025, 4, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "723793358", "foreignPassport", "Участник Херсонеса 45" },
                    { new Guid("ce93746f-cc96-4849-afd6-f034f6a957c2"), new DateTime(2008, 5, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9282), new DateTime(2025, 4, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4058 988165", "passport", "Участник Херсонеса 58" },
                    { new Guid("ceabd557-c142-44b6-9254-8bc00bf9155a"), new DateTime(2006, 6, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9121), new DateTime(2025, 6, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "724571221", "foreignPassport", "Участник Херсонеса 1" },
                    { new Guid("d31b342c-4def-49ad-bebe-cc62057107ee"), new DateTime(2001, 1, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9301), new DateTime(2025, 3, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721789863", "foreignPassport", "Участник Херсонеса 67" },
                    { new Guid("d6d58ad1-398c-472c-951d-419dcdd680bd"), new DateTime(2001, 12, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9203), new DateTime(2025, 5, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4034 264353", "passport", "Участник Херсонеса 34" },
                    { new Guid("d91c1fcb-68b6-4abe-afd5-86812ccbb487"), new DateTime(2002, 5, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9238), new DateTime(2025, 4, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4038 199982", "passport", "Участник Херсонеса 38" },
                    { new Guid("d9330a13-4dd4-4b9b-a9d2-f0f44c037f72"), new DateTime(2000, 7, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9267), new DateTime(2025, 4, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "724390978", "foreignPassport", "Участник Херсонеса 51" },
                    { new Guid("da618abb-3ca4-4b3f-ba9f-99188bd2b96e"), new DateTime(2001, 8, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9189), new DateTime(2025, 5, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4028 829315", "passport", "Участник Херсонеса 28" },
                    { new Guid("df61318f-116e-4468-9963-c521152b59a2"), new DateTime(2005, 8, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9310), new DateTime(2025, 3, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "723315504", "foreignPassport", "Участник Херсонеса 71" },
                    { new Guid("e0dc3fc6-6321-4ffa-911d-65c72cdb1771"), new DateTime(2001, 10, 14, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9384), new DateTime(2025, 3, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721357622", "foreignPassport", "Участник Херсонеса 85" },
                    { new Guid("e285ef3a-3fe8-4615-b844-af5f98f0aaad"), new DateTime(2007, 7, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9397), new DateTime(2025, 3, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4092 556195", "passport", "Участник Херсонеса 92" },
                    { new Guid("e2d674f3-2707-4c10-8340-6a531c2a62c6"), new DateTime(2002, 3, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9291), new DateTime(2025, 4, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4062 921771", "passport", "Участник Херсонеса 62" },
                    { new Guid("e8f92d1b-a350-43c4-bc55-24d198b5e07a"), new DateTime(2003, 8, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9385), new DateTime(2025, 3, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4086 404776", "passport", "Участник Херсонеса 86" },
                    { new Guid("e8fd5589-3532-4547-a5a5-b0696bcdafc5"), new DateTime(2005, 3, 7, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9181), new DateTime(2025, 5, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4024 519935", "passport", "Участник Херсонеса 24" },
                    { new Guid("eb92c96e-f674-4baa-a536-1a9390a5b8af"), new DateTime(2000, 7, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9400), new DateTime(2025, 3, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "721035168", "foreignPassport", "Участник Херсонеса 93" },
                    { new Guid("f16cb390-cb00-4521-ab6f-d48b388a8515"), new DateTime(2004, 10, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9317), new DateTime(2025, 3, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "723536125", "foreignPassport", "Участник Херсонеса 75" },
                    { new Guid("f1a43522-9afa-427c-878b-e4050d7d8ec8"), new DateTime(2009, 4, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9158), new DateTime(2025, 5, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "723710412", "foreignPassport", "Участник Херсонеса 13" },
                    { new Guid("f6e87243-74ad-41b7-b08c-d6bc91859939"), new DateTime(2007, 5, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9154), new DateTime(2025, 5, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4012 396356", "passport", "Участник Херсонеса 12" },
                    { new Guid("f940fc5e-2662-476c-bf86-0be803c25af1"), new DateTime(2004, 9, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9322), new DateTime(2025, 3, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "723916437", "foreignPassport", "Участник Херсонеса 77" },
                    { new Guid("f96588c8-2300-4d0e-bc06-975fa29aaa78"), new DateTime(2006, 3, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9258), new DateTime(2025, 4, 19, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "725527535", "foreignPassport", "Участник Херсонеса 47" },
                    { new Guid("f9ec55d8-3dd0-46a4-9ead-999aa1bcf9ac"), new DateTime(2001, 6, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9372), new DateTime(2025, 3, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4080 707263", "passport", "Участник Херсонеса 80" },
                    { new Guid("fa4dc8f9-848a-48fd-acaa-7b8ff287c616"), new DateTime(2004, 7, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9370), new DateTime(2025, 3, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "724529269", "foreignPassport", "Участник Херсонеса 79" },
                    { new Guid("fc33be71-954d-4ca6-928f-00dc48817b6c"), new DateTime(2007, 9, 14, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9178), new DateTime(2025, 5, 14, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "4022 774117", "passport", "Участник Херсонеса 22" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "Price", "StartTime", "Tag", "TicketsCount", "Title" },
                values: new object[,]
                {
                    { new Guid("02eaf3b4-f5a4-4627-9bd3-c27a4fe6a971"), new DateTime(2025, 5, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по херсонес и византия", new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 2100m, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Херсонес и Византия" },
                    { new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), new DateTime(2025, 5, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по античный театр херсонеса", new DateTime(2025, 5, 30, 12, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 1800m, new DateTime(2025, 5, 30, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Античный театр Херсонеса" },
                    { new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), new DateTime(2025, 5, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по археологические находки херсонеса", new DateTime(2025, 5, 28, 14, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 1500m, new DateTime(2025, 5, 28, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Археологические находки Херсонеса" },
                    { new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), new DateTime(2025, 5, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по секреты раскопок в херсонесе", new DateTime(2025, 5, 27, 13, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 1350m, new DateTime(2025, 5, 27, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Секреты раскопок в Херсонесе" },
                    { new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), new DateTime(2025, 5, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по экскурсия по древнему херсонесу", new DateTime(2025, 5, 26, 12, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 1200m, new DateTime(2025, 5, 26, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Экскурсия по древнему Херсонесу" },
                    { new Guid("6c482e64-c94e-45be-83e2-84a10f349268"), new DateTime(2025, 5, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по мозаики и фрески херсонеса", new DateTime(2025, 6, 4, 13, 0, 0, 0, DateTimeKind.Utc), true, "Новый Херсонес, Севастополь", 2550m, new DateTime(2025, 6, 4, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Мозаики и фрески Херсонеса" },
                    { new Guid("8556a549-9839-459c-8c42-431ecfab013c"), new DateTime(2025, 5, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по история христианства в херсонесе", new DateTime(2025, 5, 31, 13, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 1950m, new DateTime(2025, 5, 31, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "История христианства в Херсонесе" },
                    { new Guid("d1f20b27-983e-401c-8ba4-a313c44fdcb2"), new DateTime(2025, 5, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по подземелья херсонеса", new DateTime(2025, 6, 2, 15, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 2250m, new DateTime(2025, 6, 2, 13, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Подземелья Херсонеса" },
                    { new Guid("db8838f7-22f5-4828-833e-4c665c82aaf8"), new DateTime(2025, 5, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по башни и укрепления херсонеса", new DateTime(2025, 6, 3, 12, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 2400m, new DateTime(2025, 6, 3, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Башни и укрепления Херсонеса" },
                    { new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), new DateTime(2025, 5, 19, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "Увлекательная экскурсия по вечерний херсонес", new DateTime(2025, 5, 29, 15, 0, 0, 0, DateTimeKind.Utc), false, "Новый Херсонес, Севастополь", 1650m, new DateTime(2025, 5, 29, 13, 0, 0, 0, DateTimeKind.Utc), "excursion", 20, "Вечерний Херсонес" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("054ed04e-f830-42c6-89f6-3a9604b24289"), new DateTime(1993, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9026), new DateTime(2025, 5, 19, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest33@example.com", "Гость Херсонеса 33", "hash123", "+79780000033", "user" },
                    { new Guid("07f86dd6-31c2-46a4-bdae-e63439b0fadb"), new DateTime(1970, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8924), new DateTime(2025, 4, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest5@example.com", "Гость Херсонеса 5", "hash123", "+79780000005", "user" },
                    { new Guid("1ac15591-b7af-41ea-bd1f-e9eb30045f3c"), new DateTime(2005, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8962), new DateTime(2025, 5, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest19@example.com", "Гость Херсонеса 19", "hash123", "+79780000019", "user" },
                    { new Guid("1ade44ce-3879-4c2e-951b-ce2ae9e30057"), new DateTime(1981, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9045), new DateTime(2025, 5, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest41@example.com", "Гость Херсонеса 41", "hash123", "+79780000041", "user" },
                    { new Guid("1de8f90d-9bc4-4959-8a04-89a36c88759b"), new DateTime(1991, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8945), new DateTime(2025, 4, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest12@example.com", "Гость Херсонеса 12", "hash123", "+79780000012", "user" },
                    { new Guid("219080a1-b736-4544-8c78-df9b79479f61"), new DateTime(1996, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9063), new DateTime(2025, 6, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest49@example.com", "Гость Херсонеса 49", "hash123", "+79780000049", "user" },
                    { new Guid("275645e3-7b30-4cba-8ffb-9659a2e2d07a"), new DateTime(2001, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8966), new DateTime(2025, 5, 7, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest21@example.com", "Гость Херсонеса 21", "hash123", "+79780000021", "user" },
                    { new Guid("2a8c63ea-f715-4732-b952-5ed8bcdc5e3f"), new DateTime(2004, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9008), new DateTime(2025, 5, 11, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest25@example.com", "Гость Херсонеса 25", "hash123", "+79780000025", "user" },
                    { new Guid("2d708e3b-86c5-4250-9da0-6d1dad8a1fb1"), new DateTime(1969, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8949), new DateTime(2025, 4, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest14@example.com", "Гость Херсонеса 14", "hash123", "+79780000014", "user" },
                    { new Guid("2df07da0-f57b-4145-aab8-5bbf419aad83"), new DateTime(1996, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9011), new DateTime(2025, 5, 12, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest26@example.com", "Гость Херсонеса 26", "hash123", "+79780000026", "user" },
                    { new Guid("3522ea81-f4ed-496a-924d-d13d29782892"), new DateTime(1986, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9112), new DateTime(2025, 4, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "admin2@example.com", "Администратор 2", "hashadmin", "+79990000002", "admin" },
                    { new Guid("35954b2d-2a15-41db-bc2e-d32ea1a4f17e"), new DateTime(1969, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8964), new DateTime(2025, 5, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest20@example.com", "Гость Херсонеса 20", "hash123", "+79780000020", "user" },
                    { new Guid("3c496081-ee25-41d8-ab23-b64ff3185bed"), new DateTime(1970, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8922), new DateTime(2025, 4, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest4@example.com", "Гость Херсонеса 4", "hash123", "+79780000004", "user" },
                    { new Guid("3f7b9ee2-eed8-4060-9eff-9dc0a82c1d67"), new DateTime(1984, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9074), new DateTime(2025, 4, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "admin1@example.com", "Администратор 1", "hashadmin", "+79990000001", "admin" },
                    { new Guid("47ce4d6c-e3de-4b93-a2d5-86a71c0e0c70"), new DateTime(1992, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8927), new DateTime(2025, 4, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest6@example.com", "Гость Херсонеса 6", "hash123", "+79780000006", "user" },
                    { new Guid("494ecf8a-2336-4a15-916a-6b89d5cf3359"), new DateTime(1998, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8943), new DateTime(2025, 4, 27, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest11@example.com", "Гость Херсонеса 11", "hash123", "+79780000011", "user" },
                    { new Guid("4b6d2557-7d3e-4a73-b93d-189d275238e5"), new DateTime(1984, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9024), new DateTime(2025, 5, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest32@example.com", "Гость Херсонеса 32", "hash123", "+79780000032", "user" },
                    { new Guid("56a5feab-1970-4131-99c1-c1bfa0241f52"), new DateTime(1997, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8947), new DateTime(2025, 4, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest13@example.com", "Гость Херсонеса 13", "hash123", "+79780000013", "user" },
                    { new Guid("57c50cfa-4e8b-4617-a072-1fab54c6923a"), new DateTime(1987, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8919), new DateTime(2025, 4, 19, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest3@example.com", "Гость Херсонеса 3", "hash123", "+79780000003", "user" },
                    { new Guid("5891b767-ebb0-482b-9262-5ffc0276de83"), new DateTime(1989, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9032), new DateTime(2025, 5, 21, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest35@example.com", "Гость Херсонеса 35", "hash123", "+79780000035", "user" },
                    { new Guid("5a02dc80-2072-4e43-81e7-21d0ec8b1456"), new DateTime(1979, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8973), new DateTime(2025, 5, 10, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest24@example.com", "Гость Херсонеса 24", "hash123", "+79780000024", "user" },
                    { new Guid("5e62fdea-553c-42e8-87a9-8e26ab709158"), new DateTime(1975, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9014), new DateTime(2025, 5, 13, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest27@example.com", "Гость Херсонеса 27", "hash123", "+79780000027", "user" },
                    { new Guid("648dbfb3-7071-450b-bc5a-da0804c52148"), new DateTime(1972, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9061), new DateTime(2025, 6, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest48@example.com", "Гость Херсонеса 48", "hash123", "+79780000048", "user" },
                    { new Guid("6d931cfc-0da6-421a-9cf5-774c4459c88c"), new DateTime(1974, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8932), new DateTime(2025, 4, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest8@example.com", "Гость Херсонеса 8", "hash123", "+79780000008", "user" },
                    { new Guid("6e85bee8-18d5-43b6-a9d1-b202ed37bbfb"), new DateTime(2005, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9043), new DateTime(2025, 5, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest40@example.com", "Гость Херсонеса 40", "hash123", "+79780000040", "user" },
                    { new Guid("6f9e81f8-2975-4134-803f-2678781d77bf"), new DateTime(1995, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8960), new DateTime(2025, 5, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest18@example.com", "Гость Херсонеса 18", "hash123", "+79780000018", "user" },
                    { new Guid("71fae49a-cf25-4da9-a772-9a0c7205a02d"), new DateTime(1997, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9018), new DateTime(2025, 5, 15, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest29@example.com", "Гость Херсонеса 29", "hash123", "+79780000029", "user" },
                    { new Guid("724f17bc-46b3-46e0-b101-4fe73c5733ef"), new DateTime(2001, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9057), new DateTime(2025, 6, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest46@example.com", "Гость Херсонеса 46", "hash123", "+79780000046", "user" },
                    { new Guid("74c9dfee-9f0c-4b86-ade5-f8ec4f17c61d"), new DateTime(1998, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9049), new DateTime(2025, 5, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest42@example.com", "Гость Херсонеса 42", "hash123", "+79780000042", "user" },
                    { new Guid("754485c9-6fe9-4575-8552-3951e0838dfd"), new DateTime(1987, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9035), new DateTime(2025, 5, 22, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest36@example.com", "Гость Херсонеса 36", "hash123", "+79780000036", "user" },
                    { new Guid("84566a54-a053-4490-9469-f5a02a35a171"), new DateTime(1990, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9020), new DateTime(2025, 5, 16, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest30@example.com", "Гость Херсонеса 30", "hash123", "+79780000030", "user" },
                    { new Guid("8b76ac5f-49b2-4306-a903-54650e8e7e00"), new DateTime(2007, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9039), new DateTime(2025, 5, 24, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest38@example.com", "Гость Херсонеса 38", "hash123", "+79780000038", "user" },
                    { new Guid("8f526831-2f49-4a2f-9084-0c14c6b1c2cc"), new DateTime(1994, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8930), new DateTime(2025, 4, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest7@example.com", "Гость Херсонеса 7", "hash123", "+79780000007", "user" },
                    { new Guid("9246f8b7-36a7-4a1f-8056-32536381e0f6"), new DateTime(1993, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8971), new DateTime(2025, 5, 9, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest23@example.com", "Гость Херсонеса 23", "hash123", "+79780000023", "user" },
                    { new Guid("967421c3-789f-494d-9e3d-054d2d82ff99"), new DateTime(1984, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8956), new DateTime(2025, 5, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest17@example.com", "Гость Херсонеса 17", "hash123", "+79780000017", "user" },
                    { new Guid("9a48cefa-08c0-4412-a4c6-0c3418081ad6"), new DateTime(1999, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8952), new DateTime(2025, 5, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest15@example.com", "Гость Херсонеса 15", "hash123", "+79780000015", "user" },
                    { new Guid("a3c19eb8-c2e6-496d-b120-2549c873f82d"), new DateTime(1996, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9053), new DateTime(2025, 5, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest44@example.com", "Гость Херсонеса 44", "hash123", "+79780000044", "user" },
                    { new Guid("a3e0dcf0-36ce-4fa5-8df6-b6c9db15acdf"), new DateTime(2004, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9030), new DateTime(2025, 5, 20, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest34@example.com", "Гость Херсонеса 34", "hash123", "+79780000034", "user" },
                    { new Guid("a9c7ebc0-70c9-4c6c-a9a2-7e668b202fd2"), new DateTime(1986, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9055), new DateTime(2025, 5, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest45@example.com", "Гость Херсонеса 45", "hash123", "+79780000045", "user" },
                    { new Guid("aeadd9e0-58b6-4029-bcc2-b60f7837d498"), new DateTime(1996, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9037), new DateTime(2025, 5, 23, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest37@example.com", "Гость Херсонеса 37", "hash123", "+79780000037", "user" },
                    { new Guid("b5d7b089-eaa0-4267-b578-ba2008cc9c23"), new DateTime(1983, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9022), new DateTime(2025, 5, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest31@example.com", "Гость Херсонеса 31", "hash123", "+79780000031", "user" },
                    { new Guid("b7afd8cb-e654-4280-be88-d89685e63406"), new DateTime(2005, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9059), new DateTime(2025, 6, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest47@example.com", "Гость Херсонеса 47", "hash123", "+79780000047", "user" },
                    { new Guid("c1812067-47e6-4285-9b6b-73efeaa6fe95"), new DateTime(1987, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9115), new DateTime(2025, 4, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "admin3@example.com", "Администратор 3", "hashadmin", "+79990000003", "admin" },
                    { new Guid("c3e429a0-fccc-4a99-b089-9b85423febc2"), new DateTime(2006, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8953), new DateTime(2025, 5, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest16@example.com", "Гость Херсонеса 16", "hash123", "+79780000016", "user" },
                    { new Guid("cbf6ac64-dd14-468b-8f36-0d2a3a0073e9"), new DateTime(1985, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9016), new DateTime(2025, 5, 14, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest28@example.com", "Гость Херсонеса 28", "hash123", "+79780000028", "user" },
                    { new Guid("d102d1e9-3eb8-4efe-8587-7b1e970f3f54"), new DateTime(1984, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8905), new DateTime(2025, 4, 17, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest1@example.com", "Гость Херсонеса 1", "hash123", "+79780000001", "user" },
                    { new Guid("d612962f-314b-4531-9be4-5eeed966438f"), new DateTime(1973, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8941), new DateTime(2025, 4, 26, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest10@example.com", "Гость Херсонеса 10", "hash123", "+79780000010", "user" },
                    { new Guid("eadbb3f5-fdb3-418d-aaa0-1f1044d16038"), new DateTime(2007, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9067), new DateTime(2025, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest50@example.com", "Гость Херсонеса 50", "hash123", "+79780000050", "user" },
                    { new Guid("eaeaab44-64c3-4b00-9b95-46883a4730c1"), new DateTime(1993, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9051), new DateTime(2025, 5, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest43@example.com", "Гость Херсонеса 43", "hash123", "+79780000043", "user" },
                    { new Guid("ed64b557-ebd8-4c7b-9d21-db37ccba4fde"), new DateTime(1992, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(9041), new DateTime(2025, 5, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest39@example.com", "Гость Херсонеса 39", "hash123", "+79780000039", "user" },
                    { new Guid("f0b397ad-df69-434a-a1ac-71eee3b3e0d1"), new DateTime(2000, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8968), new DateTime(2025, 5, 8, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest22@example.com", "Гость Херсонеса 22", "hash123", "+79780000022", "user" },
                    { new Guid("f1cfdefa-8c7d-4c0d-af96-a133c763daa6"), new DateTime(1990, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8934), new DateTime(2025, 4, 25, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest9@example.com", "Гость Херсонеса 9", "hash123", "+79780000009", "user" },
                    { new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02"), new DateTime(1989, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8915), new DateTime(2025, 4, 18, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), "guest2@example.com", "Гость Херсонеса 2", "hash123", "+79780000002", "user" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BuyerId", "CreatedAt", "PaidAt", "QrUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("0d2036e6-a0a8-49e2-8328-b935b97d22d5"), 3150m, new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02"), new DateTime(2025, 5, 30, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 5, 30, 8, 14, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/0d2036e6-a0a8-49e2-8328-b935b97d22d5", "Successed" },
                    { new Guid("1f04d6ee-7670-441d-b44d-97ac8b03a226"), 3600m, new Guid("967421c3-789f-494d-9e3d-054d2d82ff99"), new DateTime(2025, 5, 31, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 5, 31, 8, 14, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/1f04d6ee-7670-441d-b44d-97ac8b03a226", "Successed" },
                    { new Guid("2c93b3a9-ba6c-41f8-b723-1a6e6b40d237"), 1200m, new Guid("ed64b557-ebd8-4c7b-9d21-db37ccba4fde"), new DateTime(2025, 6, 4, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 6, 4, 8, 29, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/2c93b3a9-ba6c-41f8-b723-1a6e6b40d237", "Successed" },
                    { new Guid("5841bf3c-07a3-42a3-a663-364350c8e7b9"), 3150m, new Guid("07f86dd6-31c2-46a4-bdae-e63439b0fadb"), new DateTime(2025, 6, 3, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 6, 3, 8, 15, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/5841bf3c-07a3-42a3-a663-364350c8e7b9", "Successed" },
                    { new Guid("61af8998-b6bc-4c82-ad14-4e95640abf94"), 4800m, new Guid("a3c19eb8-c2e6-496d-b120-2549c873f82d"), new DateTime(2025, 6, 2, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 6, 2, 8, 15, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/61af8998-b6bc-4c82-ad14-4e95640abf94", "Successed" },
                    { new Guid("72fd5b0f-268d-48f0-8d26-2b9f0af0027d"), 3600m, new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02"), new DateTime(2025, 5, 28, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 5, 28, 8, 19, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/72fd5b0f-268d-48f0-8d26-2b9f0af0027d", "Successed" },
                    { new Guid("83ff7b26-f173-4c54-8da4-aca1b8769cbc"), 0m, new Guid("a3c19eb8-c2e6-496d-b120-2549c873f82d"), new DateTime(2025, 6, 5, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 6, 5, 8, 18, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/83ff7b26-f173-4c54-8da4-aca1b8769cbc", "Successed" },
                    { new Guid("8c8ac7d1-64d2-4be1-a7f1-6e197f74b621"), 3000m, new Guid("2d708e3b-86c5-4250-9da0-6d1dad8a1fb1"), new DateTime(2025, 5, 29, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 5, 29, 8, 36, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/8c8ac7d1-64d2-4be1-a7f1-6e197f74b621", "Successed" },
                    { new Guid("a4acb483-c395-474b-9c52-46275854b458"), 0m, new Guid("1ac15591-b7af-41ea-bd1f-e9eb30045f3c"), new DateTime(2025, 6, 6, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 6, 6, 8, 34, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/a4acb483-c395-474b-9c52-46275854b458", "Successed" },
                    { new Guid("f5ffb61f-b609-4a09-bdd7-205a853ae4ea"), 3450m, new Guid("ed64b557-ebd8-4c7b-9d21-db37ccba4fde"), new DateTime(2025, 6, 1, 8, 9, 20, 751, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 6, 1, 8, 22, 20, 751, DateTimeKind.Utc).AddTicks(8729), "https://payment.example.com/f5ffb61f-b609-4a09-bdd7-205a853ae4ea", "Successed" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "EventId", "PaymentId", "QRCode", "UserId" },
                values: new object[,]
                {
                    { new Guid("012d1013-c7f4-4a73-9570-577909dea7a6"), null, new Guid("db8838f7-22f5-4828-833e-4c665c82aaf8"), null, "HXNdb8838f7036", null },
                    { new Guid("0d6db7f0-4303-4e7b-9e05-e41ed24c93aa"), null, new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), null, "HXN0f95718b049", null },
                    { new Guid("0da9f261-f283-417f-a1f2-2286f6fa7be4"), null, new Guid("db8838f7-22f5-4828-833e-4c665c82aaf8"), null, "HXNdb8838f7037", null },
                    { new Guid("0e505fce-7d17-4d4d-83c0-5f81b76b06e5"), null, new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), null, "HXN09aa57dd041", null },
                    { new Guid("1abbbc89-996d-4528-8746-413b25d1af33"), null, new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), null, "HXN3ee92ac8016", null },
                    { new Guid("1b2dba02-1f1d-4f33-a7da-c8348a8eb308"), null, new Guid("d1f20b27-983e-401c-8ba4-a313c44fdcb2"), null, "HXNd1f20b27029", null },
                    { new Guid("1c2d5552-742b-4f45-81dd-fcd57a7285c5"), null, new Guid("6c482e64-c94e-45be-83e2-84a10f349268"), null, "HXN6c482e64043", null },
                    { new Guid("2bf94cc6-95c4-4c84-8465-2c15b8b32953"), null, new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), null, "HXN36d5f51f031", null },
                    { new Guid("3206959f-be17-4b4b-86ff-aca861af1ba3"), null, new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), null, "HXNff797b66040", null },
                    { new Guid("46e292b7-a890-430d-89c8-49bdaff73898"), null, new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), null, "HXN3ee92ac8024", null },
                    { new Guid("47de7285-ba82-420b-9f6e-0c39cfa58258"), null, new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), null, "HXN0f95718b020", null },
                    { new Guid("53fff942-b214-4bf8-b4aa-066443cefd3e"), null, new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), null, "HXN0f95718b018", null },
                    { new Guid("5483abbb-a812-425f-8a46-bdcc1ae360f9"), null, new Guid("02eaf3b4-f5a4-4627-9bd3-c27a4fe6a971"), null, "HXN02eaf3b4039", null },
                    { new Guid("57bcd65f-cd10-4ab4-a318-61bb1ca54ad8"), null, new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), null, "HXN0f95718b038", null },
                    { new Guid("5ba4bc2c-a484-40cf-8478-f38b171308aa"), null, new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), null, "HXNff797b66048", null },
                    { new Guid("61320869-6d89-4f09-bf11-3c25b65f5e69"), null, new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), null, "HXN0f95718b017", null },
                    { new Guid("730c7216-df6a-4861-a68c-ef92f765d7e0"), null, new Guid("0f95718b-6ae2-45e9-94e4-59a1859d0df6"), null, "HXN0f95718b045", null },
                    { new Guid("79ce1058-eec7-4438-84e1-94dbec804eef"), null, new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), null, "HXNff797b66027", null },
                    { new Guid("8bc9ee75-43e5-457d-857b-efd85ec89dae"), null, new Guid("d1f20b27-983e-401c-8ba4-a313c44fdcb2"), null, "HXNd1f20b27026", null },
                    { new Guid("9c40d1ad-d3bf-497c-934c-50a5a3508e1d"), null, new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), null, "HXN09aa57dd042", null },
                    { new Guid("9fc2db3a-84eb-434e-a25e-f3633d50c5a2"), null, new Guid("8556a549-9839-459c-8c42-431ecfab013c"), null, "HXN8556a549023", null },
                    { new Guid("a80b1da8-448c-4591-b72b-f6750f719b18"), null, new Guid("db8838f7-22f5-4828-833e-4c665c82aaf8"), null, "HXNdb8838f7030", null },
                    { new Guid("b1476aea-bef4-4c35-9000-5178c7aa571e"), null, new Guid("db8838f7-22f5-4828-833e-4c665c82aaf8"), null, "HXNdb8838f7046", null },
                    { new Guid("b39a0cd2-2aba-47d3-b87a-3596ee0d1461"), null, new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), null, "HXNff797b66033", null },
                    { new Guid("b3e455d5-ab1c-4d3d-aed0-0772077336a8"), null, new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), null, "HXNff797b66021", null },
                    { new Guid("b62715e8-65e6-4e82-a9cb-f5e91f6f3963"), null, new Guid("6c482e64-c94e-45be-83e2-84a10f349268"), null, "HXN6c482e64019", null },
                    { new Guid("c68f80e1-b6d5-4192-afde-88e9faa894ec"), null, new Guid("d1f20b27-983e-401c-8ba4-a313c44fdcb2"), null, "HXNd1f20b27044", null },
                    { new Guid("d2541279-e665-472f-ba72-03f1f0327ca3"), null, new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), null, "HXN36d5f51f035", null },
                    { new Guid("d34cc5c1-1a2b-4729-b0e7-abdc0253d3a1"), null, new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), null, "HXN36d5f51f028", null },
                    { new Guid("da11fc38-518c-43b1-9a43-010075c4ef4c"), null, new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), null, "HXNff797b66015", null },
                    { new Guid("e41bd4a6-f71a-4439-8445-b08d24a2316d"), null, new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), null, "HXN3ee92ac8047", null },
                    { new Guid("f7e57a7e-1a3d-49e6-aa21-cdd82a26020c"), null, new Guid("02eaf3b4-f5a4-4627-9bd3-c27a4fe6a971"), null, "HXN02eaf3b4034", null },
                    { new Guid("f8140527-48f5-4415-9c01-53d5c7578bb8"), null, new Guid("8556a549-9839-459c-8c42-431ecfab013c"), null, "HXN8556a549025", null },
                    { new Guid("fb957e1e-45b6-483c-b293-246d40170105"), null, new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), null, "HXN3ee92ac8022", null },
                    { new Guid("fd6ca7c6-eebb-48e7-8cd9-1db36cbb2641"), null, new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), null, "HXN36d5f51f032", null }
                });

            migrationBuilder.InsertData(
                table: "UserAttendees",
                columns: new[] { "Id", "AttendeeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("06449b48-633f-4423-a04e-240a6d82a9eb"), new Guid("5e4c88bd-5eca-4ed5-b864-9cd5d6d7e865"), new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02") },
                    { new Guid("21eef939-d1e7-4eb6-88cb-ac8a6b0cd360"), new Guid("423b042e-7c45-4b70-85b6-783c49f5247b"), new Guid("ed64b557-ebd8-4c7b-9d21-db37ccba4fde") },
                    { new Guid("3fb7f4b3-f352-46e9-8292-ee69a4d79d8d"), new Guid("897c170f-cb3a-4714-80ac-d557e8e24c8d"), new Guid("07f86dd6-31c2-46a4-bdae-e63439b0fadb") },
                    { new Guid("3fe40186-c65e-469f-965c-fdca78cd6c68"), new Guid("2cd8ae16-5402-48cb-bbfd-f1f3ffea766e"), new Guid("ed64b557-ebd8-4c7b-9d21-db37ccba4fde") },
                    { new Guid("4105683c-afd3-4097-9042-513f24179fcb"), new Guid("76080d87-f976-40f1-8b10-a53630284249"), new Guid("07f86dd6-31c2-46a4-bdae-e63439b0fadb") },
                    { new Guid("5bb88782-b041-4a42-8209-a82f565ebf5a"), new Guid("f6e87243-74ad-41b7-b08c-d6bc91859939"), new Guid("2d708e3b-86c5-4250-9da0-6d1dad8a1fb1") },
                    { new Guid("5ee28615-4344-459e-8979-1464c2a4d750"), new Guid("bd201d85-0b77-4acf-bdaf-8999cd56f8e7"), new Guid("2d708e3b-86c5-4250-9da0-6d1dad8a1fb1") },
                    { new Guid("73119720-980e-4639-856b-bd532936b18b"), new Guid("4da14c68-5f9a-4584-9ef4-415342065bda"), new Guid("ed64b557-ebd8-4c7b-9d21-db37ccba4fde") },
                    { new Guid("9693468f-5f6b-4631-b332-63a2b424edc6"), new Guid("cb1af63e-4fd5-4d6b-8038-de20e24f33c1"), new Guid("967421c3-789f-494d-9e3d-054d2d82ff99") },
                    { new Guid("9bca2b3f-f49f-4795-87ab-516cac5ebe24"), new Guid("93596350-bc43-41c1-8a7c-5b88aff62a7d"), new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02") },
                    { new Guid("a9760bb0-ad60-4efd-a66a-5f22a576589a"), new Guid("5258364d-f5fe-44b4-9317-4934ed842577"), new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02") },
                    { new Guid("c4fa58c1-f760-4514-bcab-c3becacfce97"), new Guid("7519c93a-10f9-4a24-a811-2b57222f88a6"), new Guid("a3c19eb8-c2e6-496d-b120-2549c873f82d") },
                    { new Guid("c92871e8-1ab4-472d-a5c4-9b267cbf52b5"), new Guid("c2a9c6f6-2990-497f-9e90-2636b66e31f2"), new Guid("967421c3-789f-494d-9e3d-054d2d82ff99") },
                    { new Guid("d58b9872-3a8a-417e-9433-099901bcf18e"), new Guid("24b32027-3eeb-44b9-b08c-2f726484552c"), new Guid("fcf945fc-330d-47e8-9063-53ad58a60f02") },
                    { new Guid("f8bb6796-aa78-4434-9688-b128aa08acb4"), new Guid("44a9bad0-0cdd-442c-a0aa-629d75659f50"), new Guid("a3c19eb8-c2e6-496d-b120-2549c873f82d") }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "EventId", "PaymentId", "QRCode", "UserId" },
                values: new object[,]
                {
                    { new Guid("06dc7eb6-9a34-4cdb-bc3e-d3c405509b8c"), new Guid("76080d87-f976-40f1-8b10-a53630284249"), new Guid("8556a549-9839-459c-8c42-431ecfab013c"), new Guid("5841bf3c-07a3-42a3-a663-364350c8e7b9"), "HXN8556a549013", null },
                    { new Guid("28b6e087-3b34-47d0-a064-915a29e719d8"), new Guid("7519c93a-10f9-4a24-a811-2b57222f88a6"), new Guid("6c482e64-c94e-45be-83e2-84a10f349268"), new Guid("61af8998-b6bc-4c82-ad14-4e95640abf94"), "HXN6c482e64011", null },
                    { new Guid("2fe2a5eb-28b4-4539-ac73-98ffc5b78215"), new Guid("bd201d85-0b77-4acf-bdaf-8999cd56f8e7"), new Guid("ff797b66-7c97-4a88-94dd-c97f7673f554"), new Guid("8c8ac7d1-64d2-4be1-a7f1-6e197f74b621"), "HXNff797b66002", null },
                    { new Guid("349c1601-f5eb-4615-9cca-4ced7ae8b691"), new Guid("93596350-bc43-41c1-8a7c-5b88aff62a7d"), new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), new Guid("72fd5b0f-268d-48f0-8d26-2b9f0af0027d"), "HXN09aa57dd000", null },
                    { new Guid("3927bfeb-b118-4b29-95a4-83056fd982a1"), new Guid("24b32027-3eeb-44b9-b08c-2f726484552c"), new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), new Guid("72fd5b0f-268d-48f0-8d26-2b9f0af0027d"), "HXN09aa57dd001", null },
                    { new Guid("424bae95-cea6-4c7d-bab1-107185d3cc36"), new Guid("2cd8ae16-5402-48cb-bbfd-f1f3ffea766e"), new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), new Guid("f5ffb61f-b609-4a09-bdd7-205a853ae4ea"), "HXN36d5f51f008", null },
                    { new Guid("5271d95a-f3c2-49f7-b02b-4cbdebd9e0a6"), new Guid("cb1af63e-4fd5-4d6b-8038-de20e24f33c1"), new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), new Guid("1f04d6ee-7670-441d-b44d-97ac8b03a226"), "HXN09aa57dd007", null },
                    { new Guid("6b60147c-81cf-4397-b3cb-b15bb8a91dc8"), new Guid("c2a9c6f6-2990-497f-9e90-2636b66e31f2"), new Guid("09aa57dd-aa27-459e-8986-c2e50ba1def1"), new Guid("1f04d6ee-7670-441d-b44d-97ac8b03a226"), "HXN09aa57dd006", null },
                    { new Guid("7689250a-1290-4d65-b711-2b7318cfe77c"), new Guid("897c170f-cb3a-4714-80ac-d557e8e24c8d"), new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), new Guid("5841bf3c-07a3-42a3-a663-364350c8e7b9"), "HXN3ee92ac8012", null },
                    { new Guid("76ca117c-4443-4504-bf0b-b43c1894523c"), new Guid("5258364d-f5fe-44b4-9317-4934ed842577"), new Guid("8556a549-9839-459c-8c42-431ecfab013c"), new Guid("0d2036e6-a0a8-49e2-8328-b935b97d22d5"), "HXN8556a549005", null },
                    { new Guid("82e667c7-af93-42d4-bc9b-55fe8b3e0802"), new Guid("f6e87243-74ad-41b7-b08c-d6bc91859939"), new Guid("36d5f51f-2901-48f8-935c-cc4659a87b9a"), new Guid("8c8ac7d1-64d2-4be1-a7f1-6e197f74b621"), "HXN36d5f51f003", null },
                    { new Guid("88fa4234-1e8f-407a-97ef-58f83db05c35"), new Guid("423b042e-7c45-4b70-85b6-783c49f5247b"), new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), new Guid("2c93b3a9-ba6c-41f8-b723-1a6e6b40d237"), "HXN3ee92ac8014", null },
                    { new Guid("89dbeb85-721f-44ad-9989-d97c10ae5eed"), new Guid("44a9bad0-0cdd-442c-a0aa-629d75659f50"), new Guid("d1f20b27-983e-401c-8ba4-a313c44fdcb2"), new Guid("61af8998-b6bc-4c82-ad14-4e95640abf94"), "HXNd1f20b27010", null },
                    { new Guid("8ba1ba6f-e6bc-4321-aaa6-b232a65c7ccc"), new Guid("4da14c68-5f9a-4584-9ef4-415342065bda"), new Guid("02eaf3b4-f5a4-4627-9bd3-c27a4fe6a971"), new Guid("f5ffb61f-b609-4a09-bdd7-205a853ae4ea"), "HXN02eaf3b4009", null },
                    { new Guid("fe1d60bf-1bf3-4597-9088-8ea1f8bab0a2"), new Guid("5e4c88bd-5eca-4ed5-b864-9cd5d6d7e865"), new Guid("3ee92ac8-8a39-41ce-ad25-447f7bda6b02"), new Guid("0d2036e6-a0a8-49e2-8328-b935b97d22d5"), "HXN3ee92ac8004", null }
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
