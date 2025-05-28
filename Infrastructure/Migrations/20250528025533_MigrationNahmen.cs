using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationNahmen : Migration
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
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    BuyerId = table.Column<Guid>(type: "uuid", nullable: true),
                    AttendeeId = table.Column<Guid>(type: "uuid", nullable: true),
                    PaymentId = table.Column<Guid>(type: "uuid", nullable: true),
                    QRCode = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
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
                        name: "FK_Tickets_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DocumentNumber", "DocumentType", "FullName" },
                values: new object[,]
                {
                    { new Guid("0030e547-04e5-4937-b029-006a2060e742"), new DateTime(2005, 6, 7, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(132), new DateTime(2025, 5, 18, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(136), "A000010", "passport", "Attendee 10" },
                    { new Guid("05296ee5-752d-4209-aa1a-e254edac6fb1"), new DateTime(2005, 6, 23, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(256), new DateTime(2025, 5, 2, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(258), "A000026", "passport", "Attendee 26" },
                    { new Guid("0e788018-2f30-4a08-a643-ff1973c4a5a5"), new DateTime(2005, 6, 27, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(272), new DateTime(2025, 4, 28, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(274), "A000030", "passport", "Attendee 30" },
                    { new Guid("19ba738b-8874-4697-92bb-4433272677d8"), new DateTime(2005, 6, 18, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(178), new DateTime(2025, 5, 7, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(180), "A000021", "passport", "Attendee 21" },
                    { new Guid("2001e11d-2571-4f40-b95c-4dac4822764c"), new DateTime(2005, 6, 9, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(142), new DateTime(2025, 5, 16, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(144), "A000012", "passport", "Attendee 12" },
                    { new Guid("237e0cd9-b988-4a74-836d-ba0bdf0cecd4"), new DateTime(2005, 6, 11, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(149), new DateTime(2025, 5, 14, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(151), "A000014", "passport", "Attendee 14" },
                    { new Guid("2b820c37-b9cb-467d-a795-a9bf1a6fb8dc"), new DateTime(2005, 6, 21, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(189), new DateTime(2025, 5, 4, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(191), "A000024", "passport", "Attendee 24" },
                    { new Guid("34abd386-e0e3-4af6-a23b-d3895868f86f"), new DateTime(2005, 6, 19, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(181), new DateTime(2025, 5, 6, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(183), "A000022", "passport", "Attendee 22" },
                    { new Guid("3ba0b48d-c168-4c21-a66a-27f0f94fb78a"), new DateTime(2005, 5, 30, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(95), new DateTime(2025, 5, 26, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(99), "A000002", "passport", "Attendee 2" },
                    { new Guid("4a7c1912-78d1-46e0-9046-c5907fc30f97"), new DateTime(2005, 6, 26, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(269), new DateTime(2025, 4, 29, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(271), "A000029", "passport", "Attendee 29" },
                    { new Guid("4d61864f-d4d0-460c-ae48-07905ebc4674"), new DateTime(2005, 6, 6, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(125), new DateTime(2025, 5, 19, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(127), "A000009", "passport", "Attendee 9" },
                    { new Guid("5cad0a92-8fb6-47d2-bd57-d3b1b4a7ade2"), new DateTime(2005, 6, 12, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(153), new DateTime(2025, 5, 13, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(155), "A000015", "passport", "Attendee 15" },
                    { new Guid("61c45657-14d8-41a5-9839-a922f3a83737"), new DateTime(2005, 6, 8, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(138), new DateTime(2025, 5, 17, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(140), "A000011", "passport", "Attendee 11" },
                    { new Guid("61d1d735-771f-4872-8bfa-5a8bcd802d02"), new DateTime(2005, 6, 25, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(265), new DateTime(2025, 4, 30, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(267), "A000028", "passport", "Attendee 28" },
                    { new Guid("6d97930a-1f06-43a3-8a32-97ccdd896612"), new DateTime(2005, 6, 20, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(185), new DateTime(2025, 5, 5, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(187), "A000023", "passport", "Attendee 23" },
                    { new Guid("8011a3e6-473d-449e-a736-1468b9d5bb0a"), new DateTime(2005, 5, 31, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(101), new DateTime(2025, 5, 25, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(103), "A000003", "passport", "Attendee 3" },
                    { new Guid("82fca6d4-ee8e-4575-af3a-b7de7db3fd32"), new DateTime(2005, 5, 29, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(50), new DateTime(2025, 5, 27, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(90), "A000001", "passport", "Attendee 1" },
                    { new Guid("8ef53e1f-b083-4358-9d28-729d1ce3ec05"), new DateTime(2005, 6, 4, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(118), new DateTime(2025, 5, 21, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(120), "A000007", "passport", "Attendee 7" },
                    { new Guid("9ef72dbf-14f8-4b55-91c0-a81a36dd44c6"), new DateTime(2005, 6, 24, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(261), new DateTime(2025, 5, 1, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(263), "A000027", "passport", "Attendee 27" },
                    { new Guid("af0e490c-0ce0-4fe7-b9c5-2cb71afa62bf"), new DateTime(2005, 6, 2, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(109), new DateTime(2025, 5, 23, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(111), "A000005", "passport", "Attendee 5" },
                    { new Guid("b747f661-a50f-470b-a5ad-d11f9a97fb99"), new DateTime(2005, 6, 15, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(166), new DateTime(2025, 5, 10, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(168), "A000018", "passport", "Attendee 18" },
                    { new Guid("c0c2058a-f0fd-4a89-bc99-fb30523d19a2"), new DateTime(2005, 6, 16, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(170), new DateTime(2025, 5, 9, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(172), "A000019", "passport", "Attendee 19" },
                    { new Guid("dfa19d7d-09c9-40eb-a797-f8ad6c8bd1c3"), new DateTime(2005, 6, 14, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(160), new DateTime(2025, 5, 11, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(162), "A000017", "passport", "Attendee 17" },
                    { new Guid("e46b1d0e-13eb-4fa7-9af7-1972df0aa0ad"), new DateTime(2005, 6, 17, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(174), new DateTime(2025, 5, 8, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(176), "A000020", "passport", "Attendee 20" },
                    { new Guid("eccd2d95-d22c-4be9-aa48-fb555580bfc9"), new DateTime(2005, 6, 3, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(114), new DateTime(2025, 5, 22, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(116), "A000006", "passport", "Attendee 6" },
                    { new Guid("f4760dff-5b7f-4c80-8d87-20ec67fc0222"), new DateTime(2005, 6, 13, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(156), new DateTime(2025, 5, 12, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(158), "A000016", "passport", "Attendee 16" },
                    { new Guid("f48caff4-fea3-4045-9350-6c7db62faf2d"), new DateTime(2005, 6, 22, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(192), new DateTime(2025, 5, 3, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(194), "A000025", "passport", "Attendee 25" },
                    { new Guid("f7a0daaf-3f9c-4be4-a7c0-75c34806805b"), new DateTime(2005, 6, 10, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(145), new DateTime(2025, 5, 15, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(147), "A000013", "passport", "Attendee 13" },
                    { new Guid("fad538e6-7fce-425a-ba4e-3221c3b8abe5"), new DateTime(2005, 6, 5, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(122), new DateTime(2025, 5, 20, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(123), "A000008", "passport", "Attendee 8" },
                    { new Guid("ff253b5d-d8eb-4832-9a25-fd1c86756b36"), new DateTime(2005, 6, 1, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(106), new DateTime(2025, 5, 24, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(108), "A000004", "passport", "Attendee 4" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "Price", "StartTime", "Tag", "TicketsCount", "Title" },
                values: new object[,]
                {
                    { new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), new DateTime(2025, 5, 20, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9928), "Description 8", new DateTime(2025, 6, 5, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9928), true, "Location 8", 180m, new DateTime(2025, 6, 5, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9927), "event", 5, "Event 8" },
                    { new Guid("0f29f13d-4926-4fdd-97ab-e954513332ed"), new DateTime(2025, 5, 21, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9924), "Description 7", new DateTime(2025, 6, 4, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9924), true, "Location 7", 170m, new DateTime(2025, 6, 4, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9924), "event", 5, "Event 7" },
                    { new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), new DateTime(2025, 5, 25, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9907), "Description 3", new DateTime(2025, 5, 31, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9906), true, "Location 3", 130m, new DateTime(2025, 5, 31, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9906), "event", 5, "Event 3" },
                    { new Guid("4312b0a5-95ca-44fe-8a98-eb8617339525"), new DateTime(2025, 5, 23, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9915), "Description 5", new DateTime(2025, 6, 2, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9915), true, "Location 5", 150m, new DateTime(2025, 6, 2, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9915), "event", 5, "Event 5" },
                    { new Guid("db5ebd98-9977-4d72-9b70-5f3d6c224e24"), new DateTime(2025, 5, 26, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9893), "Description 2", new DateTime(2025, 5, 30, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9892), true, "Location 2", 120m, new DateTime(2025, 5, 30, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9892), "event", 5, "Event 2" },
                    { new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), new DateTime(2025, 5, 18, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9937), "Description 10", new DateTime(2025, 6, 7, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9936), true, "Location 10", 200m, new DateTime(2025, 6, 7, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9936), "event", 5, "Event 10" },
                    { new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), new DateTime(2025, 5, 19, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9931), "Description 9", new DateTime(2025, 6, 6, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9931), true, "Location 9", 190m, new DateTime(2025, 6, 6, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9930), "event", 5, "Event 9" },
                    { new Guid("f30ff617-5909-4952-ab7a-1d61d71e5c5f"), new DateTime(2025, 5, 27, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9886), "Description 1", new DateTime(2025, 5, 29, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9881), true, "Location 1", 110m, new DateTime(2025, 5, 29, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9877), "event", 5, "Event 1" },
                    { new Guid("fba434d7-8db7-42bd-b01e-248a07fd4797"), new DateTime(2025, 5, 22, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9921), "Description 6", new DateTime(2025, 6, 3, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9921), true, "Location 6", 160m, new DateTime(2025, 6, 3, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9920), "event", 5, "Event 6" },
                    { new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), new DateTime(2025, 5, 24, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9912), "Description 4", new DateTime(2025, 6, 1, 4, 55, 33, 227, DateTimeKind.Utc).AddTicks(9911), true, "Location 4", 140m, new DateTime(2025, 6, 1, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9911), "event", 5, "Event 4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("092b0d76-1a67-4d9e-ad65-46dbe78b5a01"), new DateTime(2025, 5, 26, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9954), "user2@mail.com", "User 2", "hash", null, "user" },
                    { new Guid("0a3202d7-fbcb-4539-8ea3-db1e8aa27f35"), new DateTime(2025, 5, 11, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(25), "user17@mail.com", "User 17", "hash", null, "user" },
                    { new Guid("0de200c9-b151-481a-88e8-7547fae85847"), new DateTime(2025, 5, 10, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(28), "user18@mail.com", "User 18", "hash", null, "user" },
                    { new Guid("0fdd3bd3-bc97-428f-aa1f-caabdc00456a"), new DateTime(2025, 5, 22, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9964), "user6@mail.com", "User 6", "hash", null, "user" },
                    { new Guid("16932bed-afa4-4c6e-bac6-5c320d6a1aea"), new DateTime(2025, 5, 27, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9949), "user1@mail.com", "User 1", "hash", null, "user" },
                    { new Guid("179e1a6d-93d4-4d6a-a0e4-5285d5ecf5f1"), new DateTime(2025, 5, 19, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(3), "user9@mail.com", "User 9", "hash", null, "user" },
                    { new Guid("3ced4e54-4870-473b-b93e-44a9f8af2406"), new DateTime(2025, 5, 8, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(33), "user20@mail.com", "User 20", "hash", null, "user" },
                    { new Guid("462287b1-1cb4-4856-a60f-2bbbcc16469f"), new DateTime(2025, 5, 27, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(38), "admin1@mail.com", "Admin 1", "hash", null, "admin" },
                    { new Guid("59031698-a35e-435e-ab62-7a93b0e21e4a"), new DateTime(2025, 5, 25, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9956), "user3@mail.com", "User 3", "hash", null, "user" },
                    { new Guid("5f12b703-2d56-4b07-a65c-ecd403692906"), new DateTime(2025, 5, 15, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(14), "user13@mail.com", "User 13", "hash", null, "user" },
                    { new Guid("60e7701a-534f-4ba4-a471-be66025356d8"), new DateTime(2025, 5, 18, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(7), "user10@mail.com", "User 10", "hash", null, "user" },
                    { new Guid("6a830adb-244a-47a4-8758-2b7dfc1bdea1"), new DateTime(2025, 5, 21, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9966), "user7@mail.com", "User 7", "hash", null, "user" },
                    { new Guid("6b0880df-ae96-4f74-906e-df37923a6bd4"), new DateTime(2025, 5, 14, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(16), "user14@mail.com", "User 14", "hash", null, "user" },
                    { new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"), new DateTime(2025, 5, 12, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(21), "user16@mail.com", "User 16", "hash", null, "user" },
                    { new Guid("7538b821-90d8-4521-abf4-4b788afcaf05"), new DateTime(2025, 5, 25, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(44), "admin3@mail.com", "Admin 3", "hash", null, "admin" },
                    { new Guid("7eb1df74-b7fa-4fa4-b5e4-41e20e04879e"), new DateTime(2025, 5, 16, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(12), "user12@mail.com", "User 12", "hash", null, "user" },
                    { new Guid("91765462-a05f-428b-ab3a-517a02e5646d"), new DateTime(2025, 5, 26, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(42), "admin2@mail.com", "Admin 2", "hash", null, "admin" },
                    { new Guid("a5a81139-739b-41a6-a7eb-2195aeae7bee"), new DateTime(2025, 5, 20, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9999), "user8@mail.com", "User 8", "hash", null, "user" },
                    { new Guid("a964513e-18e0-450e-a50b-3cb9c4f478ea"), new DateTime(2025, 5, 23, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9961), "user5@mail.com", "User 5", "hash", null, "user" },
                    { new Guid("a9cec712-4a0a-4f56-ab23-feabbcb1760c"), new DateTime(2025, 5, 9, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(31), "user19@mail.com", "User 19", "hash", null, "user" },
                    { new Guid("c43c4c0b-e9d6-4a7b-95d0-45cbd632dd29"), new DateTime(2025, 5, 24, 2, 55, 33, 227, DateTimeKind.Utc).AddTicks(9959), "user4@mail.com", "User 4", "hash", null, "user" },
                    { new Guid("e8bd16ea-4f1f-4deb-80c2-84dc4ea4e6cc"), new DateTime(2025, 5, 13, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(19), "user15@mail.com", "User 15", "hash", null, "user" },
                    { new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"), new DateTime(2025, 5, 17, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(10), "user11@mail.com", "User 11", "hash", null, "user" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BuyerId", "CreatedAt", "PaidAt", "QrUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("008df5c6-f800-4ea4-9ef3-327445773c75"), 0m, new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"), new DateTime(2025, 5, 22, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(680), new DateTime(2025, 5, 23, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(682), "https://pay/008df5c6-f800-4ea4-9ef3-327445773c75", "paid" },
                    { new Guid("48071d69-54bc-4b17-a398-a3fc7ce22e9d"), 0m, new Guid("5f12b703-2d56-4b07-a65c-ecd403692906"), new DateTime(2025, 5, 18, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(922), new DateTime(2025, 5, 19, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(924), "https://pay/48071d69-54bc-4b17-a398-a3fc7ce22e9d", "paid" },
                    { new Guid("494d4d2a-d26a-4bb0-a8c9-cacdd8fe4ad2"), 300m, new Guid("a9cec712-4a0a-4f56-ab23-feabbcb1760c"), new DateTime(2025, 5, 23, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(657), new DateTime(2025, 5, 24, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(659), "https://pay/494d4d2a-d26a-4bb0-a8c9-cacdd8fe4ad2", "paid" },
                    { new Guid("6b0441fe-a633-4b62-9a9c-3382d5a6aec8"), 0m, new Guid("5f12b703-2d56-4b07-a65c-ecd403692906"), new DateTime(2025, 5, 20, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(725), new DateTime(2025, 5, 21, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(727), "https://pay/6b0441fe-a633-4b62-9a9c-3382d5a6aec8", "paid" },
                    { new Guid("95c81d1c-87b8-4da9-9041-3626df7b2a67"), 300m, new Guid("a5a81139-739b-41a6-a7eb-2195aeae7bee"), new DateTime(2025, 5, 26, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(613), new DateTime(2025, 5, 27, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(614), "https://pay/95c81d1c-87b8-4da9-9041-3626df7b2a67", "paid" },
                    { new Guid("b2edbf97-d8bf-4176-9a8a-c48eb7571eb3"), 300m, new Guid("a9cec712-4a0a-4f56-ab23-feabbcb1760c"), new DateTime(2025, 5, 24, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(642), new DateTime(2025, 5, 25, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(644), "https://pay/b2edbf97-d8bf-4176-9a8a-c48eb7571eb3", "paid" },
                    { new Guid("d8a1e412-df68-44b2-a296-0a04b6a2cf55"), 300m, new Guid("7eb1df74-b7fa-4fa4-b5e4-41e20e04879e"), new DateTime(2025, 5, 25, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(627), new DateTime(2025, 5, 26, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(629), "https://pay/d8a1e412-df68-44b2-a296-0a04b6a2cf55", "paid" },
                    { new Guid("ea7e4b0a-4370-4840-91ee-1832aca8032a"), 300m, new Guid("e8bd16ea-4f1f-4deb-80c2-84dc4ea4e6cc"), new DateTime(2025, 5, 27, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(587), new DateTime(2025, 5, 28, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(590), "https://pay/ea7e4b0a-4370-4840-91ee-1832aca8032a", "paid" },
                    { new Guid("ed2d2420-6d17-4e33-ad08-4b7592140d09"), 0m, new Guid("0de200c9-b151-481a-88e8-7547fae85847"), new DateTime(2025, 5, 19, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(850), new DateTime(2025, 5, 20, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(853), "https://pay/ed2d2420-6d17-4e33-ad08-4b7592140d09", "paid" },
                    { new Guid("f306af9d-6ddf-4b88-af05-6a8417360d9d"), 0m, new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"), new DateTime(2025, 5, 21, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(702), new DateTime(2025, 5, 22, 2, 55, 33, 228, DateTimeKind.Utc).AddTicks(703), "https://pay/f306af9d-6ddf-4b88-af05-6a8417360d9d", "paid" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "BuyerId", "EventId", "PaymentId", "QRCode", "Status" },
                values: new object[,]
                {
                    { new Guid("02064404-a54f-43d9-8dce-b61e8b39f1c2"), new Guid("61c45657-14d8-41a5-9839-a922f3a83737"), new Guid("a964513e-18e0-450e-a50b-3cb9c4f478ea"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0040", "Available" },
                    { new Guid("04ebdc6b-16e4-4768-8e89-91e7629f1d23"), new Guid("19ba738b-8874-4697-92bb-4433272677d8"), new Guid("0fdd3bd3-bc97-428f-aa1f-caabdc00456a"), new Guid("0f29f13d-4926-4fdd-97ab-e954513332ed"), null, "QR0020", "Available" },
                    { new Guid("06256b2c-9ce5-48a2-9a46-c569b1726031"), new Guid("19ba738b-8874-4697-92bb-4433272677d8"), new Guid("3ced4e54-4870-473b-b93e-44a9f8af2406"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0015", "Paid" },
                    { new Guid("066d01c3-1cd7-4a76-8ba7-8fdaf0533127"), new Guid("b747f661-a50f-470b-a5ad-d11f9a97fb99"), new Guid("092b0d76-1a67-4d9e-ad65-46dbe78b5a01"), new Guid("0f29f13d-4926-4fdd-97ab-e954513332ed"), null, "QR0038", "Available" },
                    { new Guid("0688219c-08d5-4815-8b66-2429c5701537"), new Guid("5cad0a92-8fb6-47d2-bd57-d3b1b4a7ade2"), new Guid("179e1a6d-93d4-4d6a-a0e4-5285d5ecf5f1"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0044", "Available" },
                    { new Guid("06dc4dd3-5f5a-43d5-8174-44ca8f8fa7e4"), new Guid("19ba738b-8874-4697-92bb-4433272677d8"), new Guid("0a3202d7-fbcb-4539-8ea3-db1e8aa27f35"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0012", "Paid" },
                    { new Guid("0ab8de78-a222-49dd-bb4e-6a16f170aa6c"), new Guid("4d61864f-d4d0-460c-ae48-07905ebc4674"), new Guid("e8bd16ea-4f1f-4deb-80c2-84dc4ea4e6cc"), new Guid("4312b0a5-95ca-44fe-8a98-eb8617339525"), null, "QR0047", "Available" },
                    { new Guid("0f0b987a-20ff-42dc-9256-8d57cd8da007"), new Guid("5cad0a92-8fb6-47d2-bd57-d3b1b4a7ade2"), new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0050", "Available" },
                    { new Guid("190d75da-e3f0-4a4a-8d2a-6dc87ab18b69"), new Guid("4a7c1912-78d1-46e0-9046-c5907fc30f97"), new Guid("6a830adb-244a-47a4-8758-2b7dfc1bdea1"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0029", "Available" },
                    { new Guid("1d228755-7d52-4065-92f5-6a07fc65a37d"), new Guid("0e788018-2f30-4a08-a643-ff1973c4a5a5"), new Guid("60e7701a-534f-4ba4-a471-be66025356d8"), new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), null, "QR0021", "Available" },
                    { new Guid("22cebb10-fd68-4785-aefd-af0280ac160e"), new Guid("dfa19d7d-09c9-40eb-a797-f8ad6c8bd1c3"), new Guid("0fdd3bd3-bc97-428f-aa1f-caabdc00456a"), new Guid("f30ff617-5909-4952-ab7a-1d61d71e5c5f"), null, "QR0031", "Available" },
                    { new Guid("22f6a18c-00d1-4eaa-9ad9-81956ca86769"), new Guid("c0c2058a-f0fd-4a89-bc99-fb30523d19a2"), new Guid("a9cec712-4a0a-4f56-ab23-feabbcb1760c"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0003", "Paid" },
                    { new Guid("299cd783-2001-4b72-ace3-6495da904393"), new Guid("b747f661-a50f-470b-a5ad-d11f9a97fb99"), new Guid("a964513e-18e0-450e-a50b-3cb9c4f478ea"), new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), null, "QR0001", "Paid" },
                    { new Guid("30e7e0b8-bca2-43b9-a2f9-a9a283679dfb"), new Guid("b747f661-a50f-470b-a5ad-d11f9a97fb99"), new Guid("0fdd3bd3-bc97-428f-aa1f-caabdc00456a"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0024", "Available" },
                    { new Guid("35297b6f-4441-40ae-ba23-77484538746a"), new Guid("2b820c37-b9cb-467d-a795-a9bf1a6fb8dc"), new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0030", "Available" },
                    { new Guid("3853f483-bc56-4453-8613-f20aa863806a"), new Guid("82fca6d4-ee8e-4575-af3a-b7de7db3fd32"), new Guid("6b0880df-ae96-4f74-906e-df37923a6bd4"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0026", "Available" },
                    { new Guid("4628bd0b-7933-4246-89d0-d0f8cd348461"), new Guid("3ba0b48d-c168-4c21-a66a-27f0f94fb78a"), new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0025", "Available" },
                    { new Guid("48e842d7-5673-4ed5-894d-c784b5300f8d"), new Guid("5cad0a92-8fb6-47d2-bd57-d3b1b4a7ade2"), new Guid("59031698-a35e-435e-ab62-7a93b0e21e4a"), new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), null, "QR0023", "Available" },
                    { new Guid("50411810-301f-473e-8a65-5373034d6a81"), new Guid("fad538e6-7fce-425a-ba4e-3221c3b8abe5"), new Guid("3ced4e54-4870-473b-b93e-44a9f8af2406"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0041", "Available" },
                    { new Guid("52617a73-3fe6-4d55-9d60-6aadb16581b4"), new Guid("19ba738b-8874-4697-92bb-4433272677d8"), new Guid("e8bd16ea-4f1f-4deb-80c2-84dc4ea4e6cc"), new Guid("4312b0a5-95ca-44fe-8a98-eb8617339525"), null, "QR0017", "Available" },
                    { new Guid("57557726-4c83-4758-959c-1879bca2ca54"), new Guid("9ef72dbf-14f8-4b55-91c0-a81a36dd44c6"), new Guid("179e1a6d-93d4-4d6a-a0e4-5285d5ecf5f1"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0033", "Available" },
                    { new Guid("5885d94c-1662-4315-8fa6-7c560f945e5f"), new Guid("c0c2058a-f0fd-4a89-bc99-fb30523d19a2"), new Guid("60e7701a-534f-4ba4-a471-be66025356d8"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0034", "Available" },
                    { new Guid("59ff3eae-dbe0-4eb6-9374-70d6bc93e9de"), new Guid("f48caff4-fea3-4045-9350-6c7db62faf2d"), new Guid("60e7701a-534f-4ba4-a471-be66025356d8"), new Guid("fba434d7-8db7-42bd-b01e-248a07fd4797"), null, "QR0011", "Paid" },
                    { new Guid("5ebfa9c1-9d0f-4e30-b5e2-d560a504637d"), new Guid("2001e11d-2571-4f40-b95c-4dac4822764c"), new Guid("0a3202d7-fbcb-4539-8ea3-db1e8aa27f35"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0045", "Available" },
                    { new Guid("69387117-54f0-4e4b-988f-dbf38e3cf083"), new Guid("9ef72dbf-14f8-4b55-91c0-a81a36dd44c6"), new Guid("59031698-a35e-435e-ab62-7a93b0e21e4a"), new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), null, "QR0022", "Available" },
                    { new Guid("6f4ff8b3-855a-4f26-8289-c3e29928283c"), new Guid("0e788018-2f30-4a08-a643-ff1973c4a5a5"), new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0016", "Available" },
                    { new Guid("766d60a7-0e0f-4d1f-b491-49fcea961078"), new Guid("2001e11d-2571-4f40-b95c-4dac4822764c"), new Guid("0de200c9-b151-481a-88e8-7547fae85847"), new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), null, "QR0005", "Paid" },
                    { new Guid("8640263e-b0ee-4b96-bf1f-a1fc289993a4"), new Guid("61c45657-14d8-41a5-9839-a922f3a83737"), new Guid("7eb1df74-b7fa-4fa4-b5e4-41e20e04879e"), new Guid("fba434d7-8db7-42bd-b01e-248a07fd4797"), null, "QR0039", "Available" },
                    { new Guid("86af063e-1ade-4bef-8487-964156a1ce0c"), new Guid("f7a0daaf-3f9c-4be4-a7c0-75c34806805b"), new Guid("0fdd3bd3-bc97-428f-aa1f-caabdc00456a"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0010", "Paid" },
                    { new Guid("8771f9f9-4426-4228-8654-aedc7568211e"), new Guid("8011a3e6-473d-449e-a736-1468b9d5bb0a"), new Guid("6a830adb-244a-47a4-8758-2b7dfc1bdea1"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0007", "Paid" },
                    { new Guid("8c8d3ca9-0db3-4bff-8dab-d7f4a0009779"), new Guid("5cad0a92-8fb6-47d2-bd57-d3b1b4a7ade2"), new Guid("e8bd16ea-4f1f-4deb-80c2-84dc4ea4e6cc"), new Guid("fba434d7-8db7-42bd-b01e-248a07fd4797"), null, "QR0006", "Paid" },
                    { new Guid("8da3bedb-d5b5-4f81-befa-db32a97f68e5"), new Guid("9ef72dbf-14f8-4b55-91c0-a81a36dd44c6"), new Guid("092b0d76-1a67-4d9e-ad65-46dbe78b5a01"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0032", "Available" },
                    { new Guid("96887698-74ee-4642-b23c-35ffcb87f345"), new Guid("82fca6d4-ee8e-4575-af3a-b7de7db3fd32"), new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0013", "Paid" },
                    { new Guid("9e3a2ee8-0245-4f4b-a69c-258b04010e2d"), new Guid("9ef72dbf-14f8-4b55-91c0-a81a36dd44c6"), new Guid("c43c4c0b-e9d6-4a7b-95d0-45cbd632dd29"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0019", "Available" },
                    { new Guid("a53e4002-a05c-455c-9699-317463297d96"), new Guid("ff253b5d-d8eb-4832-9a25-fd1c86756b36"), new Guid("0de200c9-b151-481a-88e8-7547fae85847"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0004", "Paid" },
                    { new Guid("a94c6621-3082-4a6b-95ec-ecc746ff35a7"), new Guid("c0c2058a-f0fd-4a89-bc99-fb30523d19a2"), new Guid("59031698-a35e-435e-ab62-7a93b0e21e4a"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0036", "Available" },
                    { new Guid("ad1d3d91-9bbc-42e3-938d-440893e9e4ed"), new Guid("f7a0daaf-3f9c-4be4-a7c0-75c34806805b"), new Guid("6a830adb-244a-47a4-8758-2b7dfc1bdea1"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0046", "Available" },
                    { new Guid("ae04ec9d-4823-4967-ae96-d395b9d7063f"), new Guid("237e0cd9-b988-4a74-836d-ba0bdf0cecd4"), new Guid("c43c4c0b-e9d6-4a7b-95d0-45cbd632dd29"), new Guid("db5ebd98-9977-4d72-9b70-5f3d6c224e24"), null, "QR0002", "Paid" },
                    { new Guid("afcd3680-6072-42c1-a38e-395e47c8b166"), new Guid("e46b1d0e-13eb-4fa7-9af7-1972df0aa0ad"), new Guid("5f12b703-2d56-4b07-a65c-ecd403692906"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0027", "Available" },
                    { new Guid("b1a4ae38-57ef-4abc-bfcf-f053167d9f2f"), new Guid("05296ee5-752d-4209-aa1a-e254edac6fb1"), new Guid("0a3202d7-fbcb-4539-8ea3-db1e8aa27f35"), new Guid("4312b0a5-95ca-44fe-8a98-eb8617339525"), null, "QR0037", "Available" },
                    { new Guid("b2a066e6-c4bd-41b1-ac06-58e38c92f935"), new Guid("dfa19d7d-09c9-40eb-a797-f8ad6c8bd1c3"), new Guid("16932bed-afa4-4c6e-bac6-5c320d6a1aea"), new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"), null, "QR0035", "Available" },
                    { new Guid("b79f14c1-4282-4685-8ae9-38c4a7664fc4"), new Guid("19ba738b-8874-4697-92bb-4433272677d8"), new Guid("a5a81139-739b-41a6-a7eb-2195aeae7bee"), new Guid("eb738875-d309-479b-8a3b-767ce4a96011"), null, "QR0043", "Available" },
                    { new Guid("b8db3353-24c1-4056-be95-37228331ebd7"), new Guid("b747f661-a50f-470b-a5ad-d11f9a97fb99"), new Guid("7eb1df74-b7fa-4fa4-b5e4-41e20e04879e"), new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"), null, "QR0048", "Available" },
                    { new Guid("c0131708-fcbc-47aa-8be9-9f6c4f3cb6cf"), new Guid("af0e490c-0ce0-4fe7-b9c5-2cb71afa62bf"), new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"), new Guid("f30ff617-5909-4952-ab7a-1d61d71e5c5f"), null, "QR0018", "Available" },
                    { new Guid("c5eddb45-baf0-4324-b29e-46d337cb78a8"), new Guid("61d1d735-771f-4872-8bfa-5a8bcd802d02"), new Guid("0a3202d7-fbcb-4539-8ea3-db1e8aa27f35"), new Guid("0f29f13d-4926-4fdd-97ab-e954513332ed"), null, "QR0014", "Paid" },
                    { new Guid("ca5c5628-a5a8-4171-b414-742129afda43"), new Guid("0e788018-2f30-4a08-a643-ff1973c4a5a5"), new Guid("0de200c9-b151-481a-88e8-7547fae85847"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0009", "Paid" },
                    { new Guid("d16b9f96-58eb-45f3-b472-fb365a05a676"), new Guid("e46b1d0e-13eb-4fa7-9af7-1972df0aa0ad"), new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"), new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"), null, "QR0042", "Available" },
                    { new Guid("dbf09d46-c6c5-4387-87eb-7e1f89b29f40"), new Guid("05296ee5-752d-4209-aa1a-e254edac6fb1"), new Guid("179e1a6d-93d4-4d6a-a0e4-5285d5ecf5f1"), new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"), null, "QR0008", "Paid" },
                    { new Guid("ec619312-adf0-4f39-87f9-1cc651d477f3"), new Guid("f4760dff-5b7f-4c80-8d87-20ec67fc0222"), new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"), new Guid("0f29f13d-4926-4fdd-97ab-e954513332ed"), null, "QR0028", "Available" },
                    { new Guid("f78b1e06-af63-4234-a95c-cff799a034af"), new Guid("4a7c1912-78d1-46e0-9046-c5907fc30f97"), new Guid("092b0d76-1a67-4d9e-ad65-46dbe78b5a01"), new Guid("f30ff617-5909-4952-ab7a-1d61d71e5c5f"), null, "QR0049", "Available" }
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
                name: "IX_Tickets_BuyerId",
                table: "Tickets",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PaymentId",
                table: "Tickets",
                column: "PaymentId");

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
