using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class weg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_BuyerId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Images_EventId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("0587e2af-c192-4735-866a-364521be9013"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("2d5024f7-49e8-44d6-8e94-83c4abca3262"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("2fb9a86c-6358-4c23-b06d-c2ce89ee928b"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("4458fcf2-5cac-44b0-a80b-4f7b404585c0"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("b75a17c9-46e5-4420-8f51-736afeec81b0"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("08560384-6437-4c3b-9509-802688194f77"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("088d1ee5-5eac-4d89-9520-9594ac7d479e"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("1cced4d1-115d-4ae5-96b1-f0ee635ba8ca"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("4eb622a6-03e0-48e3-b9ca-c456bac67fee"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("502c0555-0e02-40fc-a14a-9e67f6920f98"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("5c89dd73-ec14-4a33-8a61-12e710de23ce"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("67f818b2-18f1-4c46-b15b-7ec77bac81a7"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("82479d15-15a6-4902-af74-d80e708460bb"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d7057c1e-7c8a-4f1c-bf69-fbd374df38ab"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f2c520af-d5c8-4909-a097-7f736f253a20"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("053252c7-5581-4ef7-a369-e84f41baee53"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("0bebe831-7819-4262-81e3-c78b6b6d032f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("0d9b6ed3-bbf7-48c4-839f-637c90814dae"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("102ee03a-d60a-4295-a1ed-92df48bc96df"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("133ea614-757c-43f9-87cd-90d55b18a666"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("14fb8bee-5bf7-4a92-8d8e-406cc45629a8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("177d978d-2f8f-4b83-894c-75c446a51677"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("17d5bffb-95db-4352-91fb-b67131bfc98f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("182e7a29-c1b9-460d-b881-7c550446de1e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1bf4627b-4ee7-498a-9236-af9bae9b9b40"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("209ec2e0-9e24-4107-8023-48faeb677b03"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("23a961cc-d027-4aa6-9c5f-02f84e8f0736"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("23b9f281-b8b5-4c02-9be8-9003e39b388a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("2e32a199-6ac9-4150-b7a1-642c1def0f5e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("3393149b-7fa1-41c4-8a20-9f740b5871d6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("476caf66-e6ad-4903-8c5c-dc9d15c7f271"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4975bce1-a930-4757-b65d-d03d7a623819"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4c910bb3-5aa7-43c4-b9c9-22fbb18c44ad"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4d43f178-6166-48bd-b412-6d11aad5f40a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4f572001-b386-4bda-b893-3773c6d3109f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5401fefc-17de-4bca-b080-5499042986e0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5b9a4b10-ce22-4079-b38d-801ffd4ca582"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("64a242d1-08d9-42ab-b934-66f51b22d356"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("6be8c429-8c28-440e-a847-fee4f7e315c6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("6e450326-e3b1-4fca-a645-95bfd8ae6c0c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("6e54b079-1a69-4553-8f0e-ecf179f24941"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("6f2df506-2008-4d9c-b6d2-354421324327"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8949b9a7-53b0-4100-9258-b9bf2801ebd4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8d9a3500-5358-418b-bc94-cad01bc58227"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8e5e6bf9-f57b-4687-aded-c0b8d86c0934"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("932b64bc-80d5-4b3e-a668-670c52cae332"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("986037d4-ca3b-4323-b5e5-5a48a62a0bc4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ab05144d-de7d-481b-b122-de211c3d0ada"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("abaf3946-4148-4ed3-a4a8-c29c2ebbe72e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("adf56fa4-791b-482e-890a-8c3585a39f12"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b37240ea-105f-4dfa-b522-9c1bae1a935a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b4ea1939-7609-4f57-aa25-fc6418141654"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b887747b-7b8e-4358-8036-947751d7ff66"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("bc907754-0484-4964-819c-36edea1fa75b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("bd7b7967-5453-42f2-a913-16f89df83334"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ced11ca3-1aa4-43c9-84fe-25fdb7347600"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("d3bc5708-6a86-45ba-8e3b-764b43ef467f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("d82d712b-59f0-4776-b034-09312f844195"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("dce17bf3-6c13-48c4-8c0e-1f20a8a06405"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("e812d412-aa2d-4958-840e-7beb0144f6b2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("e84301a6-6e4b-4b17-9e8b-aee50f2e57d9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("eca3dbf7-a948-491d-80bb-2ab90bcdc479"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f8c6d82c-f2e4-4f3c-9274-8bc9f3fe2782"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("fba4d511-87d6-4153-b2c6-95835f0a7038"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ffc38c7b-5efc-444e-acd5-4d652a76073d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6069148c-0148-4b1d-87a7-15734464cd9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6478a6f7-e82f-4042-bb81-0a723a43e311"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87b01dd3-ddc6-4e20-92ec-fdfa1fe11af9"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("11884b48-662c-4fb2-97b0-c485104baa59"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("15f4fee1-5ac6-4d2c-b084-b2ee20c95e22"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("1914aa47-eda0-400d-8258-f06e4117673e"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("229f1943-00fa-4601-a20d-101b4b40d58c"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("28d55ef2-bb8f-4f5d-98af-48168d172f34"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("4b89a33f-5042-416b-aad8-6af16561c76a"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("5c9b6739-c80a-439f-ad3f-38752bfc0d49"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("5dbbb7b4-cf4f-4fa5-b362-a2b56e27208f"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("63a76871-8078-4fc3-bd51-ce88ed340464"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("65c65d45-dc2b-4822-b9fe-76124bc8d140"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("68dbfb88-402b-49c8-8f77-718c46721d4a"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("72b96175-96b3-4d79-b593-de70f031391e"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("7785df99-026c-4a15-8582-2975ee36ffe2"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("7a2c488d-4ead-45cf-84fd-c96b11ae2205"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("7ee5f0c3-5a79-46c2-a8ae-7bc3eb8e3ca2"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("7fb4843a-7f10-4bd5-97c9-f12ca3db7bd5"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("80f19c7d-971f-4a4f-abc3-1a7cf1b2f790"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("874b286c-1dc9-4c43-9098-554815e724e0"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("a1c2dc96-2dfc-4d8e-848d-1cfe9d8c23ef"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("abd12495-137e-451b-925d-20de0169a0bf"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("c5d61a6a-c9e3-406a-a03a-373872ccb7ea"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("cf28a36d-a24b-4f0e-b92a-668336a0d7bc"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("cf993887-29b7-4b7b-a8de-d8b93e197d36"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("d1e9dc3f-0484-42f5-8cfe-1efd3391d0c7"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("f1e62a28-0cf7-4607-9a08-a6d9174696ae"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("57f7dfce-716f-4742-afad-4e6e701ab0ea"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("a99d1b22-45e1-4855-9c4a-6c30c1c4590a"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("e989e3c6-cdfb-43af-842b-1e730d22b9e9"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("038020d8-12e9-402b-b8c0-92d29821f0b4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("04cd91cd-df56-49b3-b170-6335847eaf88"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1bea191f-4cbb-4300-bba6-cbb3646f8dd9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3b75043d-7a71-48d5-a0c8-57cd8b9e90ef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("401c5178-21ed-4134-b9fe-47d514783814"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4265f660-da4a-429b-9490-615354aeeca3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("643758bc-271d-4a17-91d7-a3a475759b06"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("662ab944-ef90-434b-8902-6e79f4f0b069"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c69b26a-a027-4a9c-9f94-f4cf528f3de3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6dfef277-7efd-455a-b3ca-b2da7b87f9e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f8f1956-7f7e-47f4-8308-57e913730f9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("818eda47-8d9f-4abf-a820-ac1a6dead02d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9154dd80-942d-404f-a638-e234c7a4410b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ab7728f8-a2d0-45d0-b22c-cd6af53a6483"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b90793b8-9486-4d57-863b-aa29ea7a15c3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ba00b21a-f08d-4f73-8ba0-82504ebb0bbc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c58b7e14-db7a-4df3-a744-d69f736794f8"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Tickets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_BuyerId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DocumentNumber", "DocumentType", "FullName" },
                values: new object[,]
                {
                    { new Guid("0adbd4b1-b61b-42a8-9970-996fd3e4ae85"), new DateTime(2009, 5, 14, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4678), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4510 578209", "passport", "Петров Петр 10" },
                    { new Guid("0e97d68d-73a1-4c8a-9dc8-c66c5638f337"), new DateTime(2009, 12, 31, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4722), new DateTime(2025, 5, 4, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4524 754480", "passport", "Петров Петр 24" },
                    { new Guid("1081c702-c93d-4223-a746-72860977de96"), new DateTime(2002, 7, 26, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4707), new DateTime(2025, 5, 9, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "719473859", "foreign_passport", "Петров Петр 19" },
                    { new Guid("17dfefdb-fb66-4ad1-aa39-528d120607ea"), new DateTime(2003, 4, 6, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4711), new DateTime(2025, 5, 8, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4520 362902", "passport", "Петров Петр 20" },
                    { new Guid("1acb8846-92d2-48e7-96bf-c0355c8b7abd"), new DateTime(2002, 1, 26, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4687), new DateTime(2025, 5, 16, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4512 902704", "passport", "Петров Петр 12" },
                    { new Guid("217572ac-7775-4436-b77d-68bb9775b489"), new DateTime(2000, 6, 8, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4682), new DateTime(2025, 5, 17, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "716790394", "foreign_passport", "Петров Петр 11" },
                    { new Guid("479c27a3-64c8-4c92-8387-f549dcff9f52"), new DateTime(2009, 7, 16, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4716), new DateTime(2025, 5, 6, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4522 199316", "passport", "Петров Петр 22" },
                    { new Guid("48859492-7a6c-416b-bce2-5342b435a15e"), new DateTime(2009, 9, 19, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4672), new DateTime(2025, 5, 20, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4508 297700", "passport", "Петров Петр 8" },
                    { new Guid("519134c9-7930-4be0-a81d-d6aa46c88b4d"), new DateTime(2004, 12, 26, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4704), new DateTime(2025, 5, 10, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4518 382738", "passport", "Петров Петр 18" },
                    { new Guid("51dad4af-b470-42a2-b2d8-b99868eff818"), new DateTime(2006, 12, 30, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4757), new DateTime(2025, 4, 30, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4528 360601", "passport", "Петров Петр 28" },
                    { new Guid("5e189796-0ab4-4497-9139-37276f60ce65"), new DateTime(2004, 7, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4701), new DateTime(2025, 5, 11, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "711960668", "foreign_passport", "Петров Петр 17" },
                    { new Guid("6cef6402-7ea0-4e6a-8b49-56386ba99ceb"), new DateTime(2001, 8, 27, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4764), new DateTime(2025, 4, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4530 929068", "passport", "Петров Петр 30" },
                    { new Guid("78956fbf-a557-49bc-9c17-8cfac784d36c"), new DateTime(2006, 7, 1, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4760), new DateTime(2025, 4, 29, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "718177088", "foreign_passport", "Петров Петр 29" },
                    { new Guid("7ff65f2a-e945-4354-b448-af10bfacf5cc"), new DateTime(2000, 8, 5, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4730), new DateTime(2025, 5, 1, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "718180374", "foreign_passport", "Петров Петр 27" },
                    { new Guid("8a4c9180-9da6-4470-99fb-1a4f51712a2c"), new DateTime(2001, 12, 12, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4669), new DateTime(2025, 5, 21, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "714758423", "foreign_passport", "Петров Петр 7" },
                    { new Guid("90f96b7f-f83e-459c-92e2-c5db525dd848"), new DateTime(2001, 10, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4725), new DateTime(2025, 5, 3, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "719747977", "foreign_passport", "Петров Петр 25" },
                    { new Guid("a2c8b30c-4544-4622-a86c-e3a7773f17f7"), new DateTime(2002, 12, 27, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4714), new DateTime(2025, 5, 7, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "717547576", "foreign_passport", "Петров Петр 21" },
                    { new Guid("a810f716-ba82-4a86-8817-fb843dc21550"), new DateTime(2006, 2, 15, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4658), new DateTime(2025, 5, 24, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4504 120376", "passport", "Петров Петр 4" },
                    { new Guid("a94ab26c-c597-4a1d-aa9e-5400ca4d3b87"), new DateTime(2004, 5, 17, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4646), new DateTime(2025, 5, 26, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4502 241503", "passport", "Петров Петр 2" },
                    { new Guid("b33f4281-b14d-4097-a784-9c9b728c6fa8"), new DateTime(2000, 10, 12, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4693), new DateTime(2025, 5, 14, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4514 604664", "passport", "Петров Петр 14" },
                    { new Guid("b66f430e-c88c-449c-99b8-9af5be26dde2"), new DateTime(2003, 4, 14, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4639), new DateTime(2025, 5, 27, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "714307764", "foreign_passport", "Петров Петр 1" },
                    { new Guid("b6cae1c7-90cc-4617-8035-e62e1eb3c4b7"), new DateTime(2008, 1, 9, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4690), new DateTime(2025, 5, 15, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "711432257", "foreign_passport", "Петров Петр 13" },
                    { new Guid("c029a183-c9cf-4b8c-a0cf-dc723c0a38fc"), new DateTime(2000, 12, 26, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4720), new DateTime(2025, 5, 5, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "719848327", "foreign_passport", "Петров Петр 23" },
                    { new Guid("c0764839-60c4-4fb2-ac41-5da2c14cb900"), new DateTime(2006, 5, 11, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4728), new DateTime(2025, 5, 2, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4526 605755", "passport", "Петров Петр 26" },
                    { new Guid("d1a8915f-741f-4193-831f-621a83f8ecaa"), new DateTime(2003, 12, 9, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4674), new DateTime(2025, 5, 19, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "717256181", "foreign_passport", "Петров Петр 9" },
                    { new Guid("d444a7bf-7a05-4025-9f73-259160a7a0d3"), new DateTime(2009, 8, 7, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4653), new DateTime(2025, 5, 25, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "716102300", "foreign_passport", "Петров Петр 3" },
                    { new Guid("de08c01f-ecb5-4994-91f0-160aca1d5404"), new DateTime(2007, 3, 25, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4662), new DateTime(2025, 5, 23, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "716836404", "foreign_passport", "Петров Петр 5" },
                    { new Guid("e60c9626-d1e5-4004-82cb-12e2e3698725"), new DateTime(2002, 4, 25, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4698), new DateTime(2025, 5, 12, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4516 875553", "passport", "Петров Петр 16" },
                    { new Guid("eec0becd-b01d-477a-8df7-7c74d521f57e"), new DateTime(2002, 8, 24, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4666), new DateTime(2025, 5, 22, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "4506 898402", "passport", "Петров Петр 6" },
                    { new Guid("f209d43e-c7b5-428a-abc5-be4b758691b1"), new DateTime(2002, 1, 16, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4695), new DateTime(2025, 5, 13, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "716281965", "foreign_passport", "Петров Петр 15" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "Price", "StartTime", "Tag", "TicketsCount", "Title" },
                values: new object[,]
                {
                    { new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по коломенское", new DateTime(2025, 6, 2, 12, 0, 0, 0, DateTimeKind.Utc), true, "пр-т Андропова", 1800m, new DateTime(2025, 6, 2, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Коломенское" },
                    { new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по экскурсия в кремль", new DateTime(2025, 5, 29, 12, 0, 0, 0, DateTimeKind.Utc), true, "Красная площадь", 1000m, new DateTime(2025, 5, 29, 10, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Экскурсия в Кремль" },
                    { new Guid("5738ff8a-ed21-49a7-92dc-1b22f6495f10"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по царицыно", new DateTime(2025, 6, 1, 15, 0, 0, 0, DateTimeKind.Utc), true, "ул. Дольская", 1600m, new DateTime(2025, 6, 1, 13, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Царицыно" },
                    { new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по булгаковская москва", new DateTime(2025, 6, 6, 12, 0, 0, 0, DateTimeKind.Utc), true, "Патриаршие пруды", 2600m, new DateTime(2025, 6, 6, 10, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Булгаковская Москва" },
                    { new Guid("7509cb6d-b5d8-4690-9523-8d0661aea6bf"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по музей космонавтики", new DateTime(2025, 5, 31, 14, 0, 0, 0, DateTimeKind.Utc), true, "пр-т Мира", 1400m, new DateTime(2025, 5, 31, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Музей космонавтики" },
                    { new Guid("b76ab958-6527-41e0-83fe-c8b5a718f498"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по московское метро", new DateTime(2025, 6, 7, 13, 0, 0, 0, DateTimeKind.Utc), true, "Площадь Революции", 2800m, new DateTime(2025, 6, 7, 11, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Московское метро" },
                    { new Guid("bab876e3-e298-4dcc-a9f2-30300cca44d0"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по москва купеческая", new DateTime(2025, 6, 4, 14, 0, 0, 0, DateTimeKind.Utc), true, "Замоскворечье", 2200m, new DateTime(2025, 6, 4, 12, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Москва купеческая" },
                    { new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по третьяковская галерея", new DateTime(2025, 5, 30, 13, 0, 0, 0, DateTimeKind.Utc), true, "Лаврушинский переулок", 1200m, new DateTime(2025, 5, 30, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Третьяковская галерея" },
                    { new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по вечерняя москва", new DateTime(2025, 6, 5, 15, 0, 0, 0, DateTimeKind.Utc), true, "Тверская улица", 2400m, new DateTime(2025, 6, 5, 13, 0, 0, 0, DateTimeKind.Utc), "event", 15, "Вечерняя Москва" },
                    { new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "Увлекательная экскурсия по архитектурная прогулка", new DateTime(2025, 6, 3, 13, 0, 0, 0, DateTimeKind.Utc), true, "Китай-город", 2000m, new DateTime(2025, 6, 3, 11, 0, 0, 0, DateTimeKind.Utc), "excursion", 15, "Архитектурная прогулка" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("14c9d9e4-ea9d-43f3-ab4b-c477728a50b0"), new DateTime(1998, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4501), new DateTime(2025, 4, 29, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user1@example.com", "Иванов Иван 1", "hash123", "+79000000001", "user" },
                    { new Guid("15180930-7b77-43a1-a477-8ce9451cd0e8"), new DateTime(2005, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4613), new DateTime(2025, 5, 17, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user19@example.com", "Иванов Иван 19", "hash123", "+79000000019", "user" },
                    { new Guid("18117f34-3e38-447a-9875-1ee01c34ca2d"), new DateTime(1992, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4511), new DateTime(2025, 4, 30, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user2@example.com", "Иванов Иван 2", "hash123", "+79000000002", "user" },
                    { new Guid("1de89a86-7695-4371-aa69-f1c0d2e7235d"), new DateTime(1990, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4631), new DateTime(2025, 3, 29, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "admin3@example.com", "Администратор 3", "hashadmin", "+79990000003", "admin" },
                    { new Guid("1e46df74-0e6c-48ff-9127-f26fca91e3b4"), new DateTime(1986, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4593), new DateTime(2025, 5, 12, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user14@example.com", "Иванов Иван 14", "hash123", "+79000000014", "user" },
                    { new Guid("1fc49d0a-5f91-4a8d-9cfa-30ae69aa4f22"), new DateTime(2002, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4600), new DateTime(2025, 5, 14, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user16@example.com", "Иванов Иван 16", "hash123", "+79000000016", "user" },
                    { new Guid("3041a3bf-2282-4fe8-9298-c58cb688afc6"), new DateTime(2001, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4522), new DateTime(2025, 5, 2, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user4@example.com", "Иванов Иван 4", "hash123", "+79000000004", "user" },
                    { new Guid("49ae2a41-d128-4a25-a0fb-3f9fb9ee8dab"), new DateTime(1995, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4602), new DateTime(2025, 5, 15, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user17@example.com", "Иванов Иван 17", "hash123", "+79000000017", "user" },
                    { new Guid("6660a054-8b40-4a70-9aff-a7596a0b2c2e"), new DateTime(2004, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4616), new DateTime(2025, 5, 18, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user20@example.com", "Иванов Иван 20", "hash123", "+79000000020", "user" },
                    { new Guid("7f90ff26-bcf2-46a5-a69b-3242c14cf27b"), new DateTime(1986, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4623), new DateTime(2025, 3, 29, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "admin1@example.com", "Администратор 1", "hashadmin", "+79990000001", "admin" },
                    { new Guid("89b6d599-13df-47f9-86ad-c3fd3c5c92fe"), new DateTime(1999, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4596), new DateTime(2025, 5, 13, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user15@example.com", "Иванов Иван 15", "hash123", "+79000000015", "user" },
                    { new Guid("911f2337-e499-4605-b85e-fcdcfa1ea3dd"), new DateTime(2005, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4550), new DateTime(2025, 5, 9, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user11@example.com", "Иванов Иван 11", "hash123", "+79000000011", "user" },
                    { new Guid("9ac4ca9a-6ace-4550-8804-07cfa8dd4b13"), new DateTime(1995, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4554), new DateTime(2025, 5, 10, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user12@example.com", "Иванов Иван 12", "hash123", "+79000000012", "user" },
                    { new Guid("b1316131-b6f0-4706-8dfc-e3f591bb81d8"), new DateTime(1998, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4536), new DateTime(2025, 5, 6, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user8@example.com", "Иванов Иван 8", "hash123", "+79000000008", "user" },
                    { new Guid("c136faa2-b4e1-455c-9f0c-526d0ebc6227"), new DateTime(1999, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4545), new DateTime(2025, 5, 8, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user10@example.com", "Иванов Иван 10", "hash123", "+79000000010", "user" },
                    { new Guid("c29d8736-02bc-4627-874d-5665e1aaa60c"), new DateTime(1986, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4589), new DateTime(2025, 5, 11, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user13@example.com", "Иванов Иван 13", "hash123", "+79000000013", "user" },
                    { new Guid("d4c391f1-a40e-4505-8704-262e49db12d3"), new DateTime(1993, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4530), new DateTime(2025, 5, 4, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user6@example.com", "Иванов Иван 6", "hash123", "+79000000006", "user" },
                    { new Guid("d9c01f6c-5579-44d0-bc5d-959f2735ecd9"), new DateTime(2005, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4607), new DateTime(2025, 5, 16, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user18@example.com", "Иванов Иван 18", "hash123", "+79000000018", "user" },
                    { new Guid("e6292634-8fc9-4cb0-b247-fcf8a7209901"), new DateTime(2004, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4526), new DateTime(2025, 5, 3, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user5@example.com", "Иванов Иван 5", "hash123", "+79000000005", "user" },
                    { new Guid("e8cd1305-505a-4a2b-8ab6-e2640f0c5e21"), new DateTime(1990, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4539), new DateTime(2025, 5, 7, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user9@example.com", "Иванов Иван 9", "hash123", "+79000000009", "user" },
                    { new Guid("ecd35ba4-ee88-42d1-9c54-84f8d63d6745"), new DateTime(2004, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4518), new DateTime(2025, 5, 1, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user3@example.com", "Иванов Иван 3", "hash123", "+79000000003", "user" },
                    { new Guid("ed8fe693-e994-4d28-a776-33a761d691b9"), new DateTime(1987, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4628), new DateTime(2025, 3, 29, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "admin2@example.com", "Администратор 2", "hashadmin", "+79990000002", "admin" },
                    { new Guid("f4c72e94-96a5-46f5-af7f-996c6287326f"), new DateTime(1988, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4533), new DateTime(2025, 5, 5, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), "user7@example.com", "Иванов Иван 7", "hash123", "+79000000007", "user" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BuyerId", "CreatedAt", "PaidAt", "QrUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("105d555c-0d79-4755-9c2e-63f019ff1e75"), 2400m, new Guid("49ae2a41-d128-4a25-a0fb-3f9fb9ee8dab"), new DateTime(2025, 5, 31, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 31, 19, 27, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/105d555c-0d79-4755-9c2e-63f019ff1e75", "paid" },
                    { new Guid("2c12b941-3996-4194-88f6-f198c8443737"), 0m, new Guid("14c9d9e4-ea9d-43f3-ab4b-c477728a50b0"), new DateTime(2025, 6, 1, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 6, 1, 19, 20, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/2c12b941-3996-4194-88f6-f198c8443737", "paid" },
                    { new Guid("348ee1ae-6ffb-42ce-9628-c005d2ae583d"), 0m, new Guid("14c9d9e4-ea9d-43f3-ab4b-c477728a50b0"), new DateTime(2025, 6, 2, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 6, 2, 19, 22, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/348ee1ae-6ffb-42ce-9628-c005d2ae583d", "paid" },
                    { new Guid("541bc731-5927-4a88-ab84-eb91dede747a"), 4600m, new Guid("ecd35ba4-ee88-42d1-9c54-84f8d63d6745"), new DateTime(2025, 5, 29, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 29, 19, 12, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/541bc731-5927-4a88-ab84-eb91dede747a", "paid" },
                    { new Guid("6930dfcd-3364-4dbc-87d6-a54cd2e601ab"), 3200m, new Guid("911f2337-e499-4605-b85e-fcdcfa1ea3dd"), new DateTime(2025, 5, 27, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 27, 19, 25, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/6930dfcd-3364-4dbc-87d6-a54cd2e601ab", "paid" },
                    { new Guid("a5bb87fa-532c-48bd-8586-3d443968007d"), 5000m, new Guid("d9c01f6c-5579-44d0-bc5d-959f2735ecd9"), new DateTime(2025, 5, 25, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 25, 19, 19, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/a5bb87fa-532c-48bd-8586-3d443968007d", "paid" },
                    { new Guid("b041aff2-d763-4425-a3b2-abc744dc9083"), 3200m, new Guid("b1316131-b6f0-4706-8dfc-e3f591bb81d8"), new DateTime(2025, 5, 26, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 26, 19, 18, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/b041aff2-d763-4425-a3b2-abc744dc9083", "paid" },
                    { new Guid("b38fd599-b239-4bea-9c08-d50433f599c9"), 4600m, new Guid("1e46df74-0e6c-48ff-9127-f26fca91e3b4"), new DateTime(2025, 5, 24, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 24, 19, 17, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/b38fd599-b239-4bea-9c08-d50433f599c9", "paid" },
                    { new Guid("c655dc43-643c-4057-8494-6c18a303938d"), 3200m, new Guid("c136faa2-b4e1-455c-9f0c-526d0ebc6227"), new DateTime(2025, 5, 28, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 28, 19, 8, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/c655dc43-643c-4057-8494-6c18a303938d", "paid" },
                    { new Guid("e0dba10e-bb43-4879-98bc-74d972f4c134"), 4200m, new Guid("f4c72e94-96a5-46f5-af7f-996c6287326f"), new DateTime(2025, 5, 30, 19, 0, 33, 791, DateTimeKind.Utc).AddTicks(4311), new DateTime(2025, 5, 30, 19, 26, 33, 791, DateTimeKind.Utc).AddTicks(4311), "https://payment.example.com/e0dba10e-bb43-4879-98bc-74d972f4c134", "paid" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "EventId", "PaymentId", "QRCode", "UserId" },
                values: new object[,]
                {
                    { new Guid("078fa145-26ad-402e-b1b3-d5496da318f2"), null, new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), null, "TKTfb47d29a030", null },
                    { new Guid("145d89f5-f7fd-4378-b12b-d15ee82b0ba0"), null, new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), null, "TKTdee6c230019", null },
                    { new Guid("1687f405-a8f3-4b3f-96ec-2c02edffcd9f"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e038", null },
                    { new Guid("1c9c0c0b-c738-4fc5-be8a-8dbf839c329a"), null, new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), null, "TKTdee6c230018", null },
                    { new Guid("23a27055-5380-4c96-a7d3-49ca42615f27"), null, new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), null, "TKTdee6c230025", null },
                    { new Guid("2817653d-877c-49a2-9cce-fc8953209c07"), null, new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), null, "TKTdee6c230023", null },
                    { new Guid("2cf8d17f-a22a-4c1f-9a90-35cb5c131af6"), null, new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"), null, "TKTf237b1b6042", null },
                    { new Guid("384077c5-ccc0-4361-b192-55b6119545a1"), null, new Guid("7509cb6d-b5d8-4690-9523-8d0661aea6bf"), null, "TKT7509cb6d029", null },
                    { new Guid("40b0648e-357e-4886-afbf-3bc535eed9cf"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e020", null },
                    { new Guid("42b70435-9f29-4530-b792-9ffafcf1918c"), null, new Guid("b76ab958-6527-41e0-83fe-c8b5a718f498"), null, "TKTb76ab958017", null },
                    { new Guid("4820b3d8-9d7f-421b-99c2-8e42feeff96b"), null, new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"), null, "TKT19396e78047", null },
                    { new Guid("518d9020-8af6-477b-ab05-cc643bf538c6"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e046", null },
                    { new Guid("52dfc542-33d6-4740-9301-0ffb8a0230cf"), null, new Guid("5738ff8a-ed21-49a7-92dc-1b22f6495f10"), null, "TKT5738ff8a034", null },
                    { new Guid("5a90de6a-fb5f-44c7-a87e-9f08414b685f"), null, new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), null, "TKTfb47d29a022", null },
                    { new Guid("5f8372dc-6a4b-4dca-9823-94d6391a768f"), null, new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"), null, "TKTf237b1b6026", null },
                    { new Guid("5fccc21b-a9f8-406b-b80e-5598224a1afe"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e041", null },
                    { new Guid("765d9b14-869a-4243-a7e9-1bcfe80eec41"), null, new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), null, "TKT028acfbe033", null },
                    { new Guid("7d9b0bdb-740d-4a25-83b4-dbf2afbbade2"), null, new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), null, "TKTdee6c230044", null },
                    { new Guid("85d62aa4-d47f-4977-95a0-4d6fff861b64"), null, new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), null, "TKTfb47d29a021", null },
                    { new Guid("85dc110e-742c-4f52-913c-a831baac124f"), null, new Guid("7509cb6d-b5d8-4690-9523-8d0661aea6bf"), null, "TKT7509cb6d032", null },
                    { new Guid("87d1aa6e-4c04-4205-898d-da70b7b35b99"), null, new Guid("bab876e3-e298-4dcc-a9f2-30300cca44d0"), null, "TKTbab876e3040", null },
                    { new Guid("a188c071-11fc-4192-ae33-e6ae4da2713e"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e031", null },
                    { new Guid("a8a4358d-fd06-48ec-bc6e-d0b6f9a3d3ba"), null, new Guid("b76ab958-6527-41e0-83fe-c8b5a718f498"), null, "TKTb76ab958037", null },
                    { new Guid("ace95d70-ad0d-4855-a39e-0a2c62e56442"), null, new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), null, "TKTfb47d29a027", null },
                    { new Guid("adf9e9d5-402c-4e2b-ae2f-53548ecf1390"), null, new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), null, "TKT028acfbe050", null },
                    { new Guid("c18c221d-d06e-4c56-825b-64d2f52a55ac"), null, new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), null, "TKT028acfbe035", null },
                    { new Guid("ccf51b86-f96e-4866-a76b-dddfe30edad1"), null, new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"), null, "TKT19396e78028", null },
                    { new Guid("da5d8d27-68f8-42c2-8970-54b55de4b945"), null, new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"), null, "TKTdee6c230016", null },
                    { new Guid("dd8bd138-5df3-4323-80ea-83afc85e3fd1"), null, new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"), null, "TKT19396e78024", null },
                    { new Guid("e1b6dabd-91dc-4f8c-b297-338be88dcb11"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e043", null },
                    { new Guid("f6149ebb-de15-4ddd-b472-66b8ebce1c14"), null, new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), null, "TKT6819099e045", null },
                    { new Guid("f7ec32ff-f496-437f-b87a-ae09c92714fd"), null, new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"), null, "TKT19396e78049", null },
                    { new Guid("fa533050-0659-40f9-b6f5-fe64b1347957"), null, new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), null, "TKTfb47d29a036", null },
                    { new Guid("fba15366-8d9b-4660-a76b-3b4abec437e2"), null, new Guid("bab876e3-e298-4dcc-a9f2-30300cca44d0"), null, "TKTbab876e3039", null },
                    { new Guid("fef07dda-18ba-401b-bf08-602bc3cdaafe"), null, new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), null, "TKT028acfbe048", null },
                    { new Guid("07f42479-9e5b-4732-a40b-06d35b8f99a9"), new Guid("5e189796-0ab4-4497-9139-37276f60ce65"), new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"), new Guid("e0dba10e-bb43-4879-98bc-74d972f4c134"), "TKTf237b1b6013", null },
                    { new Guid("1e47cd32-95a8-4d2d-9b9e-ad113ba5e5d0"), new Guid("6cef6402-7ea0-4e6a-8b49-56386ba99ceb"), new Guid("bab876e3-e298-4dcc-a9f2-30300cca44d0"), new Guid("b041aff2-d763-4425-a3b2-abc744dc9083"), "TKTbab876e3005", null },
                    { new Guid("26b58f29-9495-47f9-bfb7-7cb1b4a1fbde"), new Guid("0e97d68d-73a1-4c8a-9dc8-c66c5638f337"), new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), new Guid("541bc731-5927-4a88-ab84-eb91dede747a"), "TKT6819099e012", null },
                    { new Guid("3cd2dcdc-e33b-423b-bec1-b8fdccb6c332"), new Guid("b66f430e-c88c-449c-99b8-9af5be26dde2"), new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), new Guid("6930dfcd-3364-4dbc-87d6-a54cd2e601ab"), "TKT028acfbe007", null },
                    { new Guid("3fb751ed-0a21-46da-9dc0-f7fa676b5718"), new Guid("1081c702-c93d-4223-a746-72860977de96"), new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"), new Guid("a5bb87fa-532c-48bd-8586-3d443968007d"), "TKTf237b1b6004", null },
                    { new Guid("4086a15e-696b-4be8-90ee-7e2165e14195"), new Guid("e60c9626-d1e5-4004-82cb-12e2e3698725"), new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), new Guid("541bc731-5927-4a88-ab84-eb91dede747a"), "TKTfb47d29a011", null },
                    { new Guid("48da781a-3e73-4d29-8b48-eec8a8c49fd6"), new Guid("1acb8846-92d2-48e7-96bf-c0355c8b7abd"), new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"), new Guid("b38fd599-b239-4bea-9c08-d50433f599c9"), "TKTfb47d29a002", null },
                    { new Guid("56aa58c6-1290-4818-afd0-7db3f8b2546b"), new Guid("de08c01f-ecb5-4994-91f0-160aca1d5404"), new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"), new Guid("b041aff2-d763-4425-a3b2-abc744dc9083"), "TKT19396e78006", null },
                    { new Guid("62a0a822-04f3-4999-9ddb-7ca0d6d3e2b8"), new Guid("90f96b7f-f83e-459c-92e2-c5db525dd848"), new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"), new Guid("105d555c-0d79-4755-9c2e-63f019ff1e75"), "TKTf237b1b6015", null },
                    { new Guid("79c7be3a-f12f-4262-90c1-b2e8c527d799"), new Guid("b33f4281-b14d-4097-a784-9c9b728c6fa8"), new Guid("7509cb6d-b5d8-4690-9523-8d0661aea6bf"), new Guid("6930dfcd-3364-4dbc-87d6-a54cd2e601ab"), "TKT7509cb6d008", null },
                    { new Guid("8e86177d-c476-429b-8526-54739765a7a0"), new Guid("78956fbf-a557-49bc-9c17-8cfac784d36c"), new Guid("7509cb6d-b5d8-4690-9523-8d0661aea6bf"), new Guid("c655dc43-643c-4057-8494-6c18a303938d"), "TKT7509cb6d010", null },
                    { new Guid("99ad1565-bdc4-482a-b321-c1ca53cbb97f"), new Guid("a810f716-ba82-4a86-8817-fb843dc21550"), new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), new Guid("c655dc43-643c-4057-8494-6c18a303938d"), "TKT028acfbe009", null },
                    { new Guid("a6ebe129-4b01-43b6-a2f3-cb1bfa6ed259"), new Guid("a94ab26c-c597-4a1d-aa9e-5400ca4d3b87"), new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"), new Guid("e0dba10e-bb43-4879-98bc-74d972f4c134"), "TKT028acfbe014", null },
                    { new Guid("ad9b4caf-caff-4705-8068-e2f35fda0736"), new Guid("d1a8915f-741f-4193-831f-621a83f8ecaa"), new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), new Guid("b38fd599-b239-4bea-9c08-d50433f599c9"), "TKT6819099e001", null },
                    { new Guid("ccec52e2-16c2-480d-8291-dd57a9de2b75"), new Guid("d444a7bf-7a05-4025-9f73-259160a7a0d3"), new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"), new Guid("a5bb87fa-532c-48bd-8586-3d443968007d"), "TKT6819099e003", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("0adbd4b1-b61b-42a8-9970-996fd3e4ae85"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("17dfefdb-fb66-4ad1-aa39-528d120607ea"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("217572ac-7775-4436-b77d-68bb9775b489"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("479c27a3-64c8-4c92-8387-f549dcff9f52"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("48859492-7a6c-416b-bce2-5342b435a15e"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("519134c9-7930-4be0-a81d-d6aa46c88b4d"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("51dad4af-b470-42a2-b2d8-b99868eff818"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("7ff65f2a-e945-4354-b448-af10bfacf5cc"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("8a4c9180-9da6-4470-99fb-1a4f51712a2c"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("a2c8b30c-4544-4622-a86c-e3a7773f17f7"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("b6cae1c7-90cc-4617-8035-e62e1eb3c4b7"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("c029a183-c9cf-4b8c-a0cf-dc723c0a38fc"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("c0764839-60c4-4fb2-ac41-5da2c14cb900"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("eec0becd-b01d-477a-8df7-7c74d521f57e"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("f209d43e-c7b5-428a-abc5-be4b758691b1"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("2c12b941-3996-4194-88f6-f198c8443737"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("348ee1ae-6ffb-42ce-9628-c005d2ae583d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("078fa145-26ad-402e-b1b3-d5496da318f2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("07f42479-9e5b-4732-a40b-06d35b8f99a9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("145d89f5-f7fd-4378-b12b-d15ee82b0ba0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1687f405-a8f3-4b3f-96ec-2c02edffcd9f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1c9c0c0b-c738-4fc5-be8a-8dbf839c329a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1e47cd32-95a8-4d2d-9b9e-ad113ba5e5d0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("23a27055-5380-4c96-a7d3-49ca42615f27"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("26b58f29-9495-47f9-bfb7-7cb1b4a1fbde"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("2817653d-877c-49a2-9cce-fc8953209c07"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("2cf8d17f-a22a-4c1f-9a90-35cb5c131af6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("384077c5-ccc0-4361-b192-55b6119545a1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("3cd2dcdc-e33b-423b-bec1-b8fdccb6c332"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("3fb751ed-0a21-46da-9dc0-f7fa676b5718"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4086a15e-696b-4be8-90ee-7e2165e14195"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("40b0648e-357e-4886-afbf-3bc535eed9cf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("42b70435-9f29-4530-b792-9ffafcf1918c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4820b3d8-9d7f-421b-99c2-8e42feeff96b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("48da781a-3e73-4d29-8b48-eec8a8c49fd6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("518d9020-8af6-477b-ab05-cc643bf538c6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("52dfc542-33d6-4740-9301-0ffb8a0230cf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("56aa58c6-1290-4818-afd0-7db3f8b2546b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5a90de6a-fb5f-44c7-a87e-9f08414b685f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5f8372dc-6a4b-4dca-9823-94d6391a768f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5fccc21b-a9f8-406b-b80e-5598224a1afe"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("62a0a822-04f3-4999-9ddb-7ca0d6d3e2b8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("765d9b14-869a-4243-a7e9-1bcfe80eec41"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("79c7be3a-f12f-4262-90c1-b2e8c527d799"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("7d9b0bdb-740d-4a25-83b4-dbf2afbbade2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("85d62aa4-d47f-4977-95a0-4d6fff861b64"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("85dc110e-742c-4f52-913c-a831baac124f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("87d1aa6e-4c04-4205-898d-da70b7b35b99"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8e86177d-c476-429b-8526-54739765a7a0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("99ad1565-bdc4-482a-b321-c1ca53cbb97f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a188c071-11fc-4192-ae33-e6ae4da2713e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a6ebe129-4b01-43b6-a2f3-cb1bfa6ed259"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a8a4358d-fd06-48ec-bc6e-d0b6f9a3d3ba"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ace95d70-ad0d-4855-a39e-0a2c62e56442"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ad9b4caf-caff-4705-8068-e2f35fda0736"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("adf9e9d5-402c-4e2b-ae2f-53548ecf1390"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("c18c221d-d06e-4c56-825b-64d2f52a55ac"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ccec52e2-16c2-480d-8291-dd57a9de2b75"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ccf51b86-f96e-4866-a76b-dddfe30edad1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("da5d8d27-68f8-42c2-8970-54b55de4b945"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("dd8bd138-5df3-4323-80ea-83afc85e3fd1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("e1b6dabd-91dc-4f8c-b297-338be88dcb11"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f6149ebb-de15-4ddd-b472-66b8ebce1c14"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f7ec32ff-f496-437f-b87a-ae09c92714fd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("fa533050-0659-40f9-b6f5-fe64b1347957"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("fba15366-8d9b-4660-a76b-3b4abec437e2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("fef07dda-18ba-401b-bf08-602bc3cdaafe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("15180930-7b77-43a1-a477-8ce9451cd0e8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("18117f34-3e38-447a-9875-1ee01c34ca2d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1de89a86-7695-4371-aa69-f1c0d2e7235d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1fc49d0a-5f91-4a8d-9cfa-30ae69aa4f22"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3041a3bf-2282-4fe8-9298-c58cb688afc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6660a054-8b40-4a70-9aff-a7596a0b2c2e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7f90ff26-bcf2-46a5-a69b-3242c14cf27b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("89b6d599-13df-47f9-86ad-c3fd3c5c92fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ac4ca9a-6ace-4550-8804-07cfa8dd4b13"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c29d8736-02bc-4627-874d-5665e1aaa60c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d4c391f1-a40e-4505-8704-262e49db12d3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6292634-8fc9-4cb0-b247-fcf8a7209901"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e8cd1305-505a-4a2b-8ab6-e2640f0c5e21"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ed8fe693-e994-4d28-a776-33a761d691b9"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("0e97d68d-73a1-4c8a-9dc8-c66c5638f337"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("1081c702-c93d-4223-a746-72860977de96"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("1acb8846-92d2-48e7-96bf-c0355c8b7abd"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("5e189796-0ab4-4497-9139-37276f60ce65"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("6cef6402-7ea0-4e6a-8b49-56386ba99ceb"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("78956fbf-a557-49bc-9c17-8cfac784d36c"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("90f96b7f-f83e-459c-92e2-c5db525dd848"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("a810f716-ba82-4a86-8817-fb843dc21550"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("a94ab26c-c597-4a1d-aa9e-5400ca4d3b87"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("b33f4281-b14d-4097-a784-9c9b728c6fa8"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("b66f430e-c88c-449c-99b8-9af5be26dde2"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("d1a8915f-741f-4193-831f-621a83f8ecaa"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("d444a7bf-7a05-4025-9f73-259160a7a0d3"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("de08c01f-ecb5-4994-91f0-160aca1d5404"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("e60c9626-d1e5-4004-82cb-12e2e3698725"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("028acfbe-ed39-4885-8288-ba6f8e5def77"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("19396e78-7160-4b9f-af1e-8cfc470504f0"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("5738ff8a-ed21-49a7-92dc-1b22f6495f10"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("6819099e-e523-4a87-9d6c-3e888cfda51d"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("7509cb6d-b5d8-4690-9523-8d0661aea6bf"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("b76ab958-6527-41e0-83fe-c8b5a718f498"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("bab876e3-e298-4dcc-a9f2-30300cca44d0"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("dee6c230-9a20-488c-8e55-7dfbecd10759"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f237b1b6-fc64-4ece-866c-0d55ab15a39b"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fb47d29a-7801-4265-83e9-b6c5e5ff212a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("105d555c-0d79-4755-9c2e-63f019ff1e75"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("541bc731-5927-4a88-ab84-eb91dede747a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6930dfcd-3364-4dbc-87d6-a54cd2e601ab"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("a5bb87fa-532c-48bd-8586-3d443968007d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b041aff2-d763-4425-a3b2-abc744dc9083"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b38fd599-b239-4bea-9c08-d50433f599c9"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("c655dc43-643c-4057-8494-6c18a303938d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("e0dba10e-bb43-4879-98bc-74d972f4c134"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("14c9d9e4-ea9d-43f3-ab4b-c477728a50b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1e46df74-0e6c-48ff-9127-f26fca91e3b4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49ae2a41-d128-4a25-a0fb-3f9fb9ee8dab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("911f2337-e499-4605-b85e-fcdcfa1ea3dd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b1316131-b6f0-4706-8dfc-e3f591bb81d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c136faa2-b4e1-455c-9f0c-526d0ebc6227"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9c01f6c-5579-44d0-bc5d-959f2735ecd9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ecd35ba4-ee88-42d1-9c54-84f8d63d6745"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4c72e94-96a5-46f5-af7f-996c6287326f"));

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tickets",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                newName: "IX_Tickets_BuyerId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EventId",
                table: "Images",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "DocumentNumber", "DocumentType", "FullName" },
                values: new object[,]
                {
                    { new Guid("0587e2af-c192-4735-866a-364521be9013"), new DateTime(2005, 6, 19, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(634), new DateTime(2025, 5, 6, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(637), "A000022", "passport", "Attendee 22" },
                    { new Guid("11884b48-662c-4fb2-97b0-c485104baa59"), new DateTime(2005, 6, 18, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(630), new DateTime(2025, 5, 7, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(632), "A000021", "passport", "Attendee 21" },
                    { new Guid("15f4fee1-5ac6-4d2c-b084-b2ee20c95e22"), new DateTime(2005, 6, 22, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(648), new DateTime(2025, 5, 3, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(651), "A000025", "passport", "Attendee 25" },
                    { new Guid("1914aa47-eda0-400d-8258-f06e4117673e"), new DateTime(2005, 6, 23, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(655), new DateTime(2025, 5, 2, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(657), "A000026", "passport", "Attendee 26" },
                    { new Guid("229f1943-00fa-4601-a20d-101b4b40d58c"), new DateTime(2005, 5, 31, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(495), new DateTime(2025, 5, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(497), "A000003", "passport", "Attendee 3" },
                    { new Guid("28d55ef2-bb8f-4f5d-98af-48168d172f34"), new DateTime(2005, 6, 12, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(598), new DateTime(2025, 5, 13, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(600), "A000015", "passport", "Attendee 15" },
                    { new Guid("2d5024f7-49e8-44d6-8e94-83c4abca3262"), new DateTime(2005, 6, 13, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(602), new DateTime(2025, 5, 12, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(605), "A000016", "passport", "Attendee 16" },
                    { new Guid("2fb9a86c-6358-4c23-b06d-c2ce89ee928b"), new DateTime(2005, 6, 1, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(500), new DateTime(2025, 5, 24, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(503), "A000004", "passport", "Attendee 4" },
                    { new Guid("4458fcf2-5cac-44b0-a80b-4f7b404585c0"), new DateTime(2005, 6, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(673), new DateTime(2025, 4, 28, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(676), "A000030", "passport", "Attendee 30" },
                    { new Guid("4b89a33f-5042-416b-aad8-6af16561c76a"), new DateTime(2005, 6, 14, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(607), new DateTime(2025, 5, 11, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(610), "A000017", "passport", "Attendee 17" },
                    { new Guid("5c9b6739-c80a-439f-ad3f-38752bfc0d49"), new DateTime(2005, 6, 21, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(643), new DateTime(2025, 5, 4, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(646), "A000024", "passport", "Attendee 24" },
                    { new Guid("5dbbb7b4-cf4f-4fa5-b362-a2b56e27208f"), new DateTime(2005, 6, 6, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(562), new DateTime(2025, 5, 19, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(564), "A000009", "passport", "Attendee 9" },
                    { new Guid("63a76871-8078-4fc3-bd51-ce88ed340464"), new DateTime(2005, 6, 9, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(584), new DateTime(2025, 5, 16, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(586), "A000012", "passport", "Attendee 12" },
                    { new Guid("65c65d45-dc2b-4822-b9fe-76124bc8d140"), new DateTime(2005, 6, 17, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(625), new DateTime(2025, 5, 8, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(628), "A000020", "passport", "Attendee 20" },
                    { new Guid("68dbfb88-402b-49c8-8f77-718c46721d4a"), new DateTime(2005, 6, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(664), new DateTime(2025, 4, 30, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(666), "A000028", "passport", "Attendee 28" },
                    { new Guid("72b96175-96b3-4d79-b593-de70f031391e"), new DateTime(2005, 6, 7, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(571), new DateTime(2025, 5, 18, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(576), "A000010", "passport", "Attendee 10" },
                    { new Guid("7785df99-026c-4a15-8582-2975ee36ffe2"), new DateTime(2005, 6, 16, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(620), new DateTime(2025, 5, 9, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(623), "A000019", "passport", "Attendee 19" },
                    { new Guid("7a2c488d-4ead-45cf-84fd-c96b11ae2205"), new DateTime(2005, 6, 4, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(515), new DateTime(2025, 5, 21, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(518), "A000007", "passport", "Attendee 7" },
                    { new Guid("7ee5f0c3-5a79-46c2-a8ae-7bc3eb8e3ca2"), new DateTime(2005, 5, 30, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(487), new DateTime(2025, 5, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(492), "A000002", "passport", "Attendee 2" },
                    { new Guid("7fb4843a-7f10-4bd5-97c9-f12ca3db7bd5"), new DateTime(2005, 6, 24, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(660), new DateTime(2025, 5, 1, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(662), "A000027", "passport", "Attendee 27" },
                    { new Guid("80f19c7d-971f-4a4f-abc3-1a7cf1b2f790"), new DateTime(2005, 6, 3, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(511), new DateTime(2025, 5, 22, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(513), "A000006", "passport", "Attendee 6" },
                    { new Guid("874b286c-1dc9-4c43-9098-554815e724e0"), new DateTime(2005, 6, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(668), new DateTime(2025, 4, 29, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(671), "A000029", "passport", "Attendee 29" },
                    { new Guid("a1c2dc96-2dfc-4d8e-848d-1cfe9d8c23ef"), new DateTime(2005, 5, 29, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(427), new DateTime(2025, 5, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(479), "A000001", "passport", "Attendee 1" },
                    { new Guid("abd12495-137e-451b-925d-20de0169a0bf"), new DateTime(2005, 6, 5, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(556), new DateTime(2025, 5, 20, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(559), "A000008", "passport", "Attendee 8" },
                    { new Guid("b75a17c9-46e5-4420-8f51-736afeec81b0"), new DateTime(2005, 6, 11, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(593), new DateTime(2025, 5, 14, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(596), "A000014", "passport", "Attendee 14" },
                    { new Guid("c5d61a6a-c9e3-406a-a03a-373872ccb7ea"), new DateTime(2005, 6, 8, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(578), new DateTime(2025, 5, 17, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(581), "A000011", "passport", "Attendee 11" },
                    { new Guid("cf28a36d-a24b-4f0e-b92a-668336a0d7bc"), new DateTime(2005, 6, 10, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(589), new DateTime(2025, 5, 15, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(591), "A000013", "passport", "Attendee 13" },
                    { new Guid("cf993887-29b7-4b7b-a8de-d8b93e197d36"), new DateTime(2005, 6, 2, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(505), new DateTime(2025, 5, 23, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(507), "A000005", "passport", "Attendee 5" },
                    { new Guid("d1e9dc3f-0484-42f5-8cfe-1efd3391d0c7"), new DateTime(2005, 6, 20, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(639), new DateTime(2025, 5, 5, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(641), "A000023", "passport", "Attendee 23" },
                    { new Guid("f1e62a28-0cf7-4607-9a08-a6d9174696ae"), new DateTime(2005, 6, 15, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(615), new DateTime(2025, 5, 10, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(618), "A000018", "passport", "Attendee 18" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "Price", "StartTime", "Tag", "TicketsCount", "Title" },
                values: new object[,]
                {
                    { new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), new DateTime(2025, 5, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(235), "Description 2", new DateTime(2025, 5, 30, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(235), true, "Location 2", 120m, new DateTime(2025, 5, 30, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(234), "event", 5, "Event 2" },
                    { new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), new DateTime(2025, 5, 18, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(330), "Description 10", new DateTime(2025, 6, 7, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(329), true, "Location 10", 200m, new DateTime(2025, 6, 7, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(329), "event", 5, "Event 10" },
                    { new Guid("57f7dfce-716f-4742-afad-4e6e701ab0ea"), new DateTime(2025, 5, 19, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(322), "Description 9", new DateTime(2025, 6, 6, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(322), true, "Location 9", 190m, new DateTime(2025, 6, 6, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(321), "event", 5, "Event 9" },
                    { new Guid("a99d1b22-45e1-4855-9c4a-6c30c1c4590a"), new DateTime(2025, 5, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(252), "Description 3", new DateTime(2025, 5, 31, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(251), true, "Location 3", 130m, new DateTime(2025, 5, 31, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(251), "event", 5, "Event 3" },
                    { new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"), new DateTime(2025, 5, 24, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(257), "Description 4", new DateTime(2025, 6, 1, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(257), true, "Location 4", 140m, new DateTime(2025, 6, 1, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(256), "event", 5, "Event 4" },
                    { new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), new DateTime(2025, 5, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(226), "Description 1", new DateTime(2025, 5, 29, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(220), true, "Location 1", 110m, new DateTime(2025, 5, 29, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(212), "event", 5, "Event 1" },
                    { new Guid("e989e3c6-cdfb-43af-842b-1e730d22b9e9"), new DateTime(2025, 5, 20, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(318), "Description 8", new DateTime(2025, 6, 5, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(317), true, "Location 8", 180m, new DateTime(2025, 6, 5, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(317), "event", 5, "Event 8" },
                    { new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), new DateTime(2025, 5, 22, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(308), "Description 6", new DateTime(2025, 6, 3, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(307), true, "Location 6", 160m, new DateTime(2025, 6, 3, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(307), "event", 5, "Event 6" },
                    { new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), new DateTime(2025, 5, 21, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(313), "Description 7", new DateTime(2025, 6, 4, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(313), true, "Location 7", 170m, new DateTime(2025, 6, 4, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(312), "event", 5, "Event 7" },
                    { new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"), new DateTime(2025, 5, 23, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(301), "Description 5", new DateTime(2025, 6, 2, 10, 47, 12, 384, DateTimeKind.Utc).AddTicks(300), true, "Location 5", 150m, new DateTime(2025, 6, 2, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(300), "event", 5, "Event 5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "PasswordHash", "Phone", "Role" },
                values: new object[,]
                {
                    { new Guid("038020d8-12e9-402b-b8c0-92d29821f0b4"), new DateTime(2025, 5, 16, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(382), "user12@mail.com", "User 12", "hash", null, "user" },
                    { new Guid("04cd91cd-df56-49b3-b170-6335847eaf88"), new DateTime(2025, 5, 24, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(354), "user4@mail.com", "User 4", "hash", null, "user" },
                    { new Guid("1bea191f-4cbb-4300-bba6-cbb3646f8dd9"), new DateTime(2025, 5, 23, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(357), "user5@mail.com", "User 5", "hash", null, "user" },
                    { new Guid("3b75043d-7a71-48d5-a0c8-57cd8b9e90ef"), new DateTime(2025, 5, 8, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(406), "user20@mail.com", "User 20", "hash", null, "user" },
                    { new Guid("401c5178-21ed-4134-b9fe-47d514783814"), new DateTime(2025, 5, 9, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(403), "user19@mail.com", "User 19", "hash", null, "user" },
                    { new Guid("4265f660-da4a-429b-9490-615354aeeca3"), new DateTime(2025, 5, 22, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(362), "user6@mail.com", "User 6", "hash", null, "user" },
                    { new Guid("6069148c-0148-4b1d-87a7-15734464cd9f"), new DateTime(2025, 5, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(420), "admin3@mail.com", "Admin 3", "hash", null, "admin" },
                    { new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new DateTime(2025, 5, 19, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(372), "user9@mail.com", "User 9", "hash", null, "user" },
                    { new Guid("6478a6f7-e82f-4042-bb81-0a723a43e311"), new DateTime(2025, 5, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(417), "admin2@mail.com", "Admin 2", "hash", null, "admin" },
                    { new Guid("662ab944-ef90-434b-8902-6e79f4f0b069"), new DateTime(2025, 5, 17, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(379), "user11@mail.com", "User 11", "hash", null, "user" },
                    { new Guid("6c69b26a-a027-4a9c-9f94-f4cf528f3de3"), new DateTime(2025, 5, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(351), "user3@mail.com", "User 3", "hash", null, "user" },
                    { new Guid("6dfef277-7efd-455a-b3ca-b2da7b87f9e1"), new DateTime(2025, 5, 18, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(376), "user10@mail.com", "User 10", "hash", null, "user" },
                    { new Guid("6f8f1956-7f7e-47f4-8308-57e913730f9c"), new DateTime(2025, 5, 11, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(397), "user17@mail.com", "User 17", "hash", null, "user" },
                    { new Guid("818eda47-8d9f-4abf-a820-ac1a6dead02d"), new DateTime(2025, 5, 10, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(400), "user18@mail.com", "User 18", "hash", null, "user" },
                    { new Guid("87b01dd3-ddc6-4e20-92ec-fdfa1fe11af9"), new DateTime(2025, 5, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(412), "admin1@mail.com", "Admin 1", "hash", null, "admin" },
                    { new Guid("9154dd80-942d-404f-a638-e234c7a4410b"), new DateTime(2025, 5, 12, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(392), "user16@mail.com", "User 16", "hash", null, "user" },
                    { new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new DateTime(2025, 5, 14, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(387), "user14@mail.com", "User 14", "hash", null, "user" },
                    { new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"), new DateTime(2025, 5, 15, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(384), "user13@mail.com", "User 13", "hash", null, "user" },
                    { new Guid("ab7728f8-a2d0-45d0-b22c-cd6af53a6483"), new DateTime(2025, 5, 20, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(368), "user8@mail.com", "User 8", "hash", null, "user" },
                    { new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new DateTime(2025, 5, 13, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(390), "user15@mail.com", "User 15", "hash", null, "user" },
                    { new Guid("b90793b8-9486-4d57-863b-aa29ea7a15c3"), new DateTime(2025, 5, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(343), "user1@mail.com", "User 1", "hash", null, "user" },
                    { new Guid("ba00b21a-f08d-4f73-8ba0-82504ebb0bbc"), new DateTime(2025, 5, 21, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(365), "user7@mail.com", "User 7", "hash", null, "user" },
                    { new Guid("c58b7e14-db7a-4df3-a744-d69f736794f8"), new DateTime(2025, 5, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(348), "user2@mail.com", "User 2", "hash", null, "user" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "BuyerId", "CreatedAt", "PaidAt", "QrUrl", "Status" },
                values: new object[,]
                {
                    { new Guid("08560384-6437-4c3b-9509-802688194f77"), 300m, new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"), new DateTime(2025, 5, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1136), new DateTime(2025, 5, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1139), "https://pay/08560384-6437-4c3b-9509-802688194f77", "paid" },
                    { new Guid("088d1ee5-5eac-4d89-9520-9594ac7d479e"), 300m, new Guid("c58b7e14-db7a-4df3-a744-d69f736794f8"), new DateTime(2025, 5, 23, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1176), new DateTime(2025, 5, 24, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1179), "https://pay/088d1ee5-5eac-4d89-9520-9594ac7d479e", "paid" },
                    { new Guid("1cced4d1-115d-4ae5-96b1-f0ee635ba8ca"), 300m, new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new DateTime(2025, 5, 26, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1083), new DateTime(2025, 5, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1085), "https://pay/1cced4d1-115d-4ae5-96b1-f0ee635ba8ca", "paid" },
                    { new Guid("4eb622a6-03e0-48e3-b9ca-c456bac67fee"), 0m, new Guid("9154dd80-942d-404f-a638-e234c7a4410b"), new DateTime(2025, 5, 21, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1231), new DateTime(2025, 5, 22, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1234), "https://pay/4eb622a6-03e0-48e3-b9ca-c456bac67fee", "paid" },
                    { new Guid("502c0555-0e02-40fc-a14a-9e67f6920f98"), 0m, new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new DateTime(2025, 5, 19, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1287), new DateTime(2025, 5, 20, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1289), "https://pay/502c0555-0e02-40fc-a14a-9e67f6920f98", "paid" },
                    { new Guid("5c89dd73-ec14-4a33-8a61-12e710de23ce"), 0m, new Guid("4265f660-da4a-429b-9490-615354aeeca3"), new DateTime(2025, 5, 18, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1315), new DateTime(2025, 5, 19, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1318), "https://pay/5c89dd73-ec14-4a33-8a61-12e710de23ce", "paid" },
                    { new Guid("67f818b2-18f1-4c46-b15b-7ec77bac81a7"), 0m, new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new DateTime(2025, 5, 20, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1261), new DateTime(2025, 5, 21, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1263), "https://pay/67f818b2-18f1-4c46-b15b-7ec77bac81a7", "paid" },
                    { new Guid("82479d15-15a6-4902-af74-d80e708460bb"), 300m, new Guid("6dfef277-7efd-455a-b3ca-b2da7b87f9e1"), new DateTime(2025, 5, 24, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1156), new DateTime(2025, 5, 25, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1158), "https://pay/82479d15-15a6-4902-af74-d80e708460bb", "paid" },
                    { new Guid("d7057c1e-7c8a-4f1c-bf69-fbd374df38ab"), 300m, new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new DateTime(2025, 5, 27, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1053), new DateTime(2025, 5, 28, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1055), "https://pay/d7057c1e-7c8a-4f1c-bf69-fbd374df38ab", "paid" },
                    { new Guid("f2c520af-d5c8-4909-a097-7f736f253a20"), 0m, new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new DateTime(2025, 5, 22, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1204), new DateTime(2025, 5, 23, 8, 47, 12, 384, DateTimeKind.Utc).AddTicks(1207), "https://pay/f2c520af-d5c8-4909-a097-7f736f253a20", "paid" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AttendeeId", "BuyerId", "EventId", "PaymentId", "QRCode", "Status" },
                values: new object[,]
                {
                    { new Guid("053252c7-5581-4ef7-a369-e84f41baee53"), new Guid("d1e9dc3f-0484-42f5-8cfe-1efd3391d0c7"), new Guid("662ab944-ef90-434b-8902-6e79f4f0b069"), new Guid("57f7dfce-716f-4742-afad-4e6e701ab0ea"), null, "QR0031", "Available" },
                    { new Guid("0bebe831-7819-4262-81e3-c78b6b6d032f"), new Guid("80f19c7d-971f-4a4f-abc3-1a7cf1b2f790"), new Guid("3b75043d-7a71-48d5-a0c8-57cd8b9e90ef"), new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), null, "QR0010", "Paid" },
                    { new Guid("0d9b6ed3-bbf7-48c4-839f-637c90814dae"), new Guid("7785df99-026c-4a15-8582-2975ee36ffe2"), new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"), null, "QR0044", "Available" },
                    { new Guid("102ee03a-d60a-4295-a1ed-92df48bc96df"), new Guid("1914aa47-eda0-400d-8258-f06e4117673e"), new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"), new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), null, "QR0012", "Paid" },
                    { new Guid("133ea614-757c-43f9-87cd-90d55b18a666"), new Guid("1914aa47-eda0-400d-8258-f06e4117673e"), new Guid("038020d8-12e9-402b-b8c0-92d29821f0b4"), new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), null, "QR0018", "Available" },
                    { new Guid("14fb8bee-5bf7-4a92-8d8e-406cc45629a8"), new Guid("cf28a36d-a24b-4f0e-b92a-668336a0d7bc"), new Guid("3b75043d-7a71-48d5-a0c8-57cd8b9e90ef"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0007", "Paid" },
                    { new Guid("177d978d-2f8f-4b83-894c-75c446a51677"), new Guid("68dbfb88-402b-49c8-8f77-718c46721d4a"), new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), null, "QR0027", "Available" },
                    { new Guid("17d5bffb-95db-4352-91fb-b67131bfc98f"), new Guid("229f1943-00fa-4601-a20d-101b4b40d58c"), new Guid("662ab944-ef90-434b-8902-6e79f4f0b069"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0023", "Available" },
                    { new Guid("182e7a29-c1b9-460d-b881-7c550446de1e"), new Guid("5dbbb7b4-cf4f-4fa5-b362-a2b56e27208f"), new Guid("9154dd80-942d-404f-a638-e234c7a4410b"), new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), null, "QR0029", "Available" },
                    { new Guid("1bf4627b-4ee7-498a-9236-af9bae9b9b40"), new Guid("874b286c-1dc9-4c43-9098-554815e724e0"), new Guid("6dfef277-7efd-455a-b3ca-b2da7b87f9e1"), new Guid("57f7dfce-716f-4742-afad-4e6e701ab0ea"), null, "QR0005", "Paid" },
                    { new Guid("209ec2e0-9e24-4107-8023-48faeb677b03"), new Guid("a1c2dc96-2dfc-4d8e-848d-1cfe9d8c23ef"), new Guid("662ab944-ef90-434b-8902-6e79f4f0b069"), new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"), null, "QR0049", "Available" },
                    { new Guid("23a961cc-d027-4aa6-9c5f-02f84e8f0736"), new Guid("cf28a36d-a24b-4f0e-b92a-668336a0d7bc"), new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0043", "Available" },
                    { new Guid("23b9f281-b8b5-4c02-9be8-9003e39b388a"), new Guid("cf993887-29b7-4b7b-a8de-d8b93e197d36"), new Guid("9154dd80-942d-404f-a638-e234c7a4410b"), new Guid("e989e3c6-cdfb-43af-842b-1e730d22b9e9"), null, "QR0019", "Available" },
                    { new Guid("2e32a199-6ac9-4150-b7a1-642c1def0f5e"), new Guid("11884b48-662c-4fb2-97b0-c485104baa59"), new Guid("9154dd80-942d-404f-a638-e234c7a4410b"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0028", "Available" },
                    { new Guid("3393149b-7fa1-41c4-8a20-9f740b5871d6"), new Guid("28d55ef2-bb8f-4f5d-98af-48168d172f34"), new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"), null, "QR0008", "Paid" },
                    { new Guid("476caf66-e6ad-4903-8c5c-dc9d15c7f271"), new Guid("65c65d45-dc2b-4822-b9fe-76124bc8d140"), new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), null, "QR0033", "Available" },
                    { new Guid("4975bce1-a930-4757-b65d-d03d7a623819"), new Guid("63a76871-8078-4fc3-bd51-ce88ed340464"), new Guid("6f8f1956-7f7e-47f4-8308-57e913730f9c"), new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), null, "QR0030", "Available" },
                    { new Guid("4c910bb3-5aa7-43c4-b9c9-22fbb18c44ad"), new Guid("7a2c488d-4ead-45cf-84fd-c96b11ae2205"), new Guid("401c5178-21ed-4134-b9fe-47d514783814"), new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), null, "QR0016", "Available" },
                    { new Guid("4d43f178-6166-48bd-b412-6d11aad5f40a"), new Guid("229f1943-00fa-4601-a20d-101b4b40d58c"), new Guid("ab7728f8-a2d0-45d0-b22c-cd6af53a6483"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0048", "Available" },
                    { new Guid("4f572001-b386-4bda-b893-3773c6d3109f"), new Guid("65c65d45-dc2b-4822-b9fe-76124bc8d140"), new Guid("b90793b8-9486-4d57-863b-aa29ea7a15c3"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0047", "Available" },
                    { new Guid("5401fefc-17de-4bca-b080-5499042986e0"), new Guid("15f4fee1-5ac6-4d2c-b084-b2ee20c95e22"), new Guid("038020d8-12e9-402b-b8c0-92d29821f0b4"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0021", "Available" },
                    { new Guid("5b9a4b10-ce22-4079-b38d-801ffd4ca582"), new Guid("5c9b6739-c80a-439f-ad3f-38752bfc0d49"), new Guid("6c69b26a-a027-4a9c-9f94-f4cf528f3de3"), new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), null, "QR0013", "Paid" },
                    { new Guid("64a242d1-08d9-42ab-b934-66f51b22d356"), new Guid("7ee5f0c3-5a79-46c2-a8ae-7bc3eb8e3ca2"), new Guid("ba00b21a-f08d-4f73-8ba0-82504ebb0bbc"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0041", "Available" },
                    { new Guid("6be8c429-8c28-440e-a847-fee4f7e315c6"), new Guid("cf28a36d-a24b-4f0e-b92a-668336a0d7bc"), new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), null, "QR0037", "Available" },
                    { new Guid("6e450326-e3b1-4fca-a645-95bfd8ae6c0c"), new Guid("65c65d45-dc2b-4822-b9fe-76124bc8d140"), new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), null, "QR0020", "Available" },
                    { new Guid("6e54b079-1a69-4553-8f0e-ecf179f24941"), new Guid("a1c2dc96-2dfc-4d8e-848d-1cfe9d8c23ef"), new Guid("b90793b8-9486-4d57-863b-aa29ea7a15c3"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0001", "Paid" },
                    { new Guid("6f2df506-2008-4d9c-b6d2-354421324327"), new Guid("4b89a33f-5042-416b-aad8-6af16561c76a"), new Guid("ab7728f8-a2d0-45d0-b22c-cd6af53a6483"), new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"), null, "QR0035", "Available" },
                    { new Guid("8949b9a7-53b0-4100-9258-b9bf2801ebd4"), new Guid("11884b48-662c-4fb2-97b0-c485104baa59"), new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), null, "QR0032", "Available" },
                    { new Guid("8d9a3500-5358-418b-bc94-cad01bc58227"), new Guid("5c9b6739-c80a-439f-ad3f-38752bfc0d49"), new Guid("4265f660-da4a-429b-9490-615354aeeca3"), new Guid("57f7dfce-716f-4742-afad-4e6e701ab0ea"), null, "QR0014", "Paid" },
                    { new Guid("8e5e6bf9-f57b-4687-aded-c0b8d86c0934"), new Guid("7fb4843a-7f10-4bd5-97c9-f12ca3db7bd5"), new Guid("401c5178-21ed-4134-b9fe-47d514783814"), new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"), null, "QR0004", "Paid" },
                    { new Guid("932b64bc-80d5-4b3e-a668-670c52cae332"), new Guid("874b286c-1dc9-4c43-9098-554815e724e0"), new Guid("04cd91cd-df56-49b3-b170-6335847eaf88"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0026", "Available" },
                    { new Guid("986037d4-ca3b-4323-b5e5-5a48a62a0bc4"), new Guid("5c9b6739-c80a-439f-ad3f-38752bfc0d49"), new Guid("6f8f1956-7f7e-47f4-8308-57e913730f9c"), new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"), null, "QR0024", "Available" },
                    { new Guid("ab05144d-de7d-481b-b122-de211c3d0ada"), new Guid("65c65d45-dc2b-4822-b9fe-76124bc8d140"), new Guid("9154dd80-942d-404f-a638-e234c7a4410b"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0002", "Paid" },
                    { new Guid("abaf3946-4148-4ed3-a4a8-c29c2ebbe72e"), new Guid("c5d61a6a-c9e3-406a-a03a-373872ccb7ea"), new Guid("6f8f1956-7f7e-47f4-8308-57e913730f9c"), new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"), null, "QR0015", "Paid" },
                    { new Guid("adf56fa4-791b-482e-890a-8c3585a39f12"), new Guid("cf993887-29b7-4b7b-a8de-d8b93e197d36"), new Guid("6f8f1956-7f7e-47f4-8308-57e913730f9c"), new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), null, "QR0003", "Paid" },
                    { new Guid("b37240ea-105f-4dfa-b522-9c1bae1a935a"), new Guid("5c9b6739-c80a-439f-ad3f-38752bfc0d49"), new Guid("943a39fe-6749-4463-aad7-7f50ada7826b"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0042", "Available" },
                    { new Guid("b4ea1939-7609-4f57-aa25-fc6418141654"), new Guid("4b89a33f-5042-416b-aad8-6af16561c76a"), new Guid("818eda47-8d9f-4abf-a820-ac1a6dead02d"), new Guid("f24c8d5e-f6ae-4f3b-adfe-e58942f8d562"), null, "QR0006", "Paid" },
                    { new Guid("b887747b-7b8e-4358-8036-947751d7ff66"), new Guid("cf28a36d-a24b-4f0e-b92a-668336a0d7bc"), new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new Guid("a99d1b22-45e1-4855-9c4a-6c30c1c4590a"), null, "QR0045", "Available" },
                    { new Guid("bc907754-0484-4964-819c-36edea1fa75b"), new Guid("11884b48-662c-4fb2-97b0-c485104baa59"), new Guid("ba00b21a-f08d-4f73-8ba0-82504ebb0bbc"), new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"), null, "QR0039", "Available" },
                    { new Guid("bd7b7967-5453-42f2-a913-16f89df83334"), new Guid("11884b48-662c-4fb2-97b0-c485104baa59"), new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new Guid("e989e3c6-cdfb-43af-842b-1e730d22b9e9"), null, "QR0034", "Available" },
                    { new Guid("ced11ca3-1aa4-43c9-84fe-25fdb7347600"), new Guid("cf993887-29b7-4b7b-a8de-d8b93e197d36"), new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"), new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), null, "QR0011", "Paid" },
                    { new Guid("d3bc5708-6a86-45ba-8e3b-764b43ef467f"), new Guid("874b286c-1dc9-4c43-9098-554815e724e0"), new Guid("818eda47-8d9f-4abf-a820-ac1a6dead02d"), new Guid("df0f0436-d9f9-46c6-9ced-d2a310e28510"), null, "QR0036", "Available" },
                    { new Guid("d82d712b-59f0-4776-b034-09312f844195"), new Guid("4b89a33f-5042-416b-aad8-6af16561c76a"), new Guid("ba00b21a-f08d-4f73-8ba0-82504ebb0bbc"), new Guid("fa8cd1b9-1e15-484d-a584-269075566d3c"), null, "QR0038", "Available" },
                    { new Guid("dce17bf3-6c13-48c4-8c0e-1f20a8a06405"), new Guid("c5d61a6a-c9e3-406a-a03a-373872ccb7ea"), new Guid("1bea191f-4cbb-4300-bba6-cbb3646f8dd9"), new Guid("39186acd-cd56-4cc4-820f-0c47a5026a53"), null, "QR0046", "Available" },
                    { new Guid("e812d412-aa2d-4958-840e-7beb0144f6b2"), new Guid("f1e62a28-0cf7-4607-9a08-a6d9174696ae"), new Guid("b1e79aa7-230a-4341-b501-4dc96f9ece32"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0050", "Available" },
                    { new Guid("e84301a6-6e4b-4b17-9e8b-aee50f2e57d9"), new Guid("874b286c-1dc9-4c43-9098-554815e724e0"), new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"), new Guid("e989e3c6-cdfb-43af-842b-1e730d22b9e9"), null, "QR0022", "Available" },
                    { new Guid("eca3dbf7-a948-491d-80bb-2ab90bcdc479"), new Guid("72b96175-96b3-4d79-b593-de70f031391e"), new Guid("a49a21ae-dfd4-42e7-8560-ed013222d778"), new Guid("04e3e24a-b4e1-4bbb-9e20-dfcd985b8dbb"), null, "QR0009", "Paid" },
                    { new Guid("f8c6d82c-f2e4-4f3c-9274-8bc9f3fe2782"), new Guid("abd12495-137e-451b-925d-20de0169a0bf"), new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), null, "QR0040", "Available" },
                    { new Guid("fba4d511-87d6-4153-b2c6-95835f0a7038"), new Guid("cf993887-29b7-4b7b-a8de-d8b93e197d36"), new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new Guid("ee0e58f7-e06a-4d16-bd99-c792362b12bb"), null, "QR0017", "Available" },
                    { new Guid("ffc38c7b-5efc-444e-acd5-4d652a76073d"), new Guid("15f4fee1-5ac6-4d2c-b084-b2ee20c95e22"), new Guid("643758bc-271d-4a17-91d7-a3a475759b06"), new Guid("ac7c5ab4-9a29-4ff3-b40d-650c5662f366"), null, "QR0025", "Available" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_EventId",
                table: "Images",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_BuyerId",
                table: "Tickets",
                column: "BuyerId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
