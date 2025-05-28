using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrationhNahmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("0030e547-04e5-4937-b029-006a2060e742"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("34abd386-e0e3-4af6-a23b-d3895868f86f"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("6d97930a-1f06-43a3-8a32-97ccdd896612"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("8ef53e1f-b083-4358-9d28-729d1ce3ec05"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("eccd2d95-d22c-4be9-aa48-fb555580bfc9"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("008df5c6-f800-4ea4-9ef3-327445773c75"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("48071d69-54bc-4b17-a398-a3fc7ce22e9d"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("494d4d2a-d26a-4bb0-a8c9-cacdd8fe4ad2"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("6b0441fe-a633-4b62-9a9c-3382d5a6aec8"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("95c81d1c-87b8-4da9-9041-3626df7b2a67"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("b2edbf97-d8bf-4176-9a8a-c48eb7571eb3"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("d8a1e412-df68-44b2-a296-0a04b6a2cf55"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ea7e4b0a-4370-4840-91ee-1832aca8032a"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("ed2d2420-6d17-4e33-ad08-4b7592140d09"));

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: new Guid("f306af9d-6ddf-4b88-af05-6a8417360d9d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("02064404-a54f-43d9-8dce-b61e8b39f1c2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("04ebdc6b-16e4-4768-8e89-91e7629f1d23"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("06256b2c-9ce5-48a2-9a46-c569b1726031"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("066d01c3-1cd7-4a76-8ba7-8fdaf0533127"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("0688219c-08d5-4815-8b66-2429c5701537"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("06dc4dd3-5f5a-43d5-8174-44ca8f8fa7e4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("0ab8de78-a222-49dd-bb4e-6a16f170aa6c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("0f0b987a-20ff-42dc-9256-8d57cd8da007"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("190d75da-e3f0-4a4a-8d2a-6dc87ab18b69"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1d228755-7d52-4065-92f5-6a07fc65a37d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("22cebb10-fd68-4785-aefd-af0280ac160e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("22f6a18c-00d1-4eaa-9ad9-81956ca86769"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("299cd783-2001-4b72-ace3-6495da904393"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("30e7e0b8-bca2-43b9-a2f9-a9a283679dfb"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("35297b6f-4441-40ae-ba23-77484538746a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("3853f483-bc56-4453-8613-f20aa863806a"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4628bd0b-7933-4246-89d0-d0f8cd348461"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("48e842d7-5673-4ed5-894d-c784b5300f8d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("50411810-301f-473e-8a65-5373034d6a81"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("52617a73-3fe6-4d55-9d60-6aadb16581b4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("57557726-4c83-4758-959c-1879bca2ca54"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5885d94c-1662-4315-8fa6-7c560f945e5f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("59ff3eae-dbe0-4eb6-9374-70d6bc93e9de"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5ebfa9c1-9d0f-4e30-b5e2-d560a504637d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("69387117-54f0-4e4b-988f-dbf38e3cf083"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("6f4ff8b3-855a-4f26-8289-c3e29928283c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("766d60a7-0e0f-4d1f-b491-49fcea961078"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8640263e-b0ee-4b96-bf1f-a1fc289993a4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("86af063e-1ade-4bef-8487-964156a1ce0c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8771f9f9-4426-4228-8654-aedc7568211e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8c8d3ca9-0db3-4bff-8dab-d7f4a0009779"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("8da3bedb-d5b5-4f81-befa-db32a97f68e5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("96887698-74ee-4642-b23c-35ffcb87f345"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("9e3a2ee8-0245-4f4b-a69c-258b04010e2d"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a53e4002-a05c-455c-9699-317463297d96"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a94c6621-3082-4a6b-95ec-ecc746ff35a7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ad1d3d91-9bbc-42e3-938d-440893e9e4ed"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ae04ec9d-4823-4967-ae96-d395b9d7063f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("afcd3680-6072-42c1-a38e-395e47c8b166"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b1a4ae38-57ef-4abc-bfcf-f053167d9f2f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b2a066e6-c4bd-41b1-ac06-58e38c92f935"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b79f14c1-4282-4685-8ae9-38c4a7664fc4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b8db3353-24c1-4056-be95-37228331ebd7"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("c0131708-fcbc-47aa-8be9-9f6c4f3cb6cf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("c5eddb45-baf0-4324-b29e-46d337cb78a8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ca5c5628-a5a8-4171-b414-742129afda43"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("d16b9f96-58eb-45f3-b472-fb365a05a676"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("dbf09d46-c6c5-4387-87eb-7e1f89b29f40"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ec619312-adf0-4f39-87f9-1cc651d477f3"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f78b1e06-af63-4234-a95c-cff799a034af"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("462287b1-1cb4-4856-a60f-2bbbcc16469f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7538b821-90d8-4521-abf4-4b788afcaf05"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("91765462-a05f-428b-ab3a-517a02e5646d"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("05296ee5-752d-4209-aa1a-e254edac6fb1"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("0e788018-2f30-4a08-a643-ff1973c4a5a5"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("19ba738b-8874-4697-92bb-4433272677d8"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("2001e11d-2571-4f40-b95c-4dac4822764c"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("237e0cd9-b988-4a74-836d-ba0bdf0cecd4"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("2b820c37-b9cb-467d-a795-a9bf1a6fb8dc"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("3ba0b48d-c168-4c21-a66a-27f0f94fb78a"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("4a7c1912-78d1-46e0-9046-c5907fc30f97"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("4d61864f-d4d0-460c-ae48-07905ebc4674"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("5cad0a92-8fb6-47d2-bd57-d3b1b4a7ade2"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("61c45657-14d8-41a5-9839-a922f3a83737"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("61d1d735-771f-4872-8bfa-5a8bcd802d02"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("8011a3e6-473d-449e-a736-1468b9d5bb0a"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("82fca6d4-ee8e-4575-af3a-b7de7db3fd32"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("9ef72dbf-14f8-4b55-91c0-a81a36dd44c6"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("af0e490c-0ce0-4fe7-b9c5-2cb71afa62bf"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("b747f661-a50f-470b-a5ad-d11f9a97fb99"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("c0c2058a-f0fd-4a89-bc99-fb30523d19a2"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("dfa19d7d-09c9-40eb-a797-f8ad6c8bd1c3"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("e46b1d0e-13eb-4fa7-9af7-1972df0aa0ad"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("f4760dff-5b7f-4c80-8d87-20ec67fc0222"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("f48caff4-fea3-4045-9350-6c7db62faf2d"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("f7a0daaf-3f9c-4be4-a7c0-75c34806805b"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("fad538e6-7fce-425a-ba4e-3221c3b8abe5"));

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: new Guid("ff253b5d-d8eb-4832-9a25-fd1c86756b36"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("09a8ea8c-2f54-446f-b8b5-5bb2bdeeaae6"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("0f29f13d-4926-4fdd-97ab-e954513332ed"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("34d66fc6-ead6-4e7e-94f7-6adbe6ff8d3a"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("4312b0a5-95ca-44fe-8a98-eb8617339525"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("db5ebd98-9977-4d72-9b70-5f3d6c224e24"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("eb738875-d309-479b-8a3b-767ce4a96011"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ee493d94-55cf-46b6-9bd8-1ea4d6b060a7"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("f30ff617-5909-4952-ab7a-1d61d71e5c5f"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("fba434d7-8db7-42bd-b01e-248a07fd4797"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("ff7c7c97-f9c1-4c42-bcce-b93bce291304"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("092b0d76-1a67-4d9e-ad65-46dbe78b5a01"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0a3202d7-fbcb-4539-8ea3-db1e8aa27f35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0de200c9-b151-481a-88e8-7547fae85847"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0fdd3bd3-bc97-428f-aa1f-caabdc00456a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("16932bed-afa4-4c6e-bac6-5c320d6a1aea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("179e1a6d-93d4-4d6a-a0e4-5285d5ecf5f1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ced4e54-4870-473b-b93e-44a9f8af2406"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("59031698-a35e-435e-ab62-7a93b0e21e4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5f12b703-2d56-4b07-a65c-ecd403692906"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("60e7701a-534f-4ba4-a471-be66025356d8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6a830adb-244a-47a4-8758-2b7dfc1bdea1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6b0880df-ae96-4f74-906e-df37923a6bd4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6f05c27b-d2a4-4dbf-ae22-6b3ed017bcac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7eb1df74-b7fa-4fa4-b5e4-41e20e04879e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a5a81139-739b-41a6-a7eb-2195aeae7bee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a964513e-18e0-450e-a50b-3cb9c4f478ea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a9cec712-4a0a-4f56-ab23-feabbcb1760c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c43c4c0b-e9d6-4a7b-95d0-45cbd632dd29"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e8bd16ea-4f1f-4deb-80c2-84dc4ea4e6cc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("fd5bde55-fcbf-4c32-8761-93e66df112e7"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Events_EventId",
                table: "Images");

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
                name: "EventId",
                table: "Images");

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
        }
    }
}
