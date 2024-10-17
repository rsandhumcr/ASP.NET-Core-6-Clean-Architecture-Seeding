using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyNameSpace.ProjectName.Persistence.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EntityOne",
                columns: new[] { "EntityOneId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "Name", "Price", "TypeId" },
                values: new object[,]
                {
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second Item", null, null, "Two", 1.24m, 2 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Third Item", null, null, "Three", 1.25m, 2 },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fourth Item", null, null, "Four", 1.26m, 4 },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fifth Item", null, null, "Five", 1.27m, 4 },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sixth Item", null, null, "Six", 1.28m, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 8, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 7, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2025, 2, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5827));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 6, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2025, 2, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5813));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2025, 4, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5739));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 17, 3, 8, 49, 152, DateTimeKind.Local).AddTicks(5937));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EntityOne",
                keyColumn: "EntityOneId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EntityOne",
                keyColumn: "EntityOneId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EntityOne",
                keyColumn: "EntityOneId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EntityOne",
                keyColumn: "EntityOneId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EntityOne",
                keyColumn: "EntityOneId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2025, 8, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2025, 7, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1791));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2025, 2, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2025, 6, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2025, 2, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1804));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2025, 4, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1919));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1882));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1932));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2024, 10, 15, 14, 46, 51, 621, DateTimeKind.Local).AddTicks(1949));
        }
    }
}
