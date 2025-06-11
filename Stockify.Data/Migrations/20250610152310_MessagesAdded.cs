using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class MessagesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighPriority = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipientId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6404), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6406) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6409), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6409) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6411), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6411) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6412), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6412) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6413), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6415), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6415) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6416), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6416) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6417), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6417) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6418), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6419) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6420), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6420) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6553), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6553) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6555), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6557), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6557) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6558), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6558) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6559), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6560), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6561), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6561) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6562), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6647), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6648) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6649), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6649) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6650), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6651) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6651), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6652) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6652), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6653) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6654), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6654) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6655), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6655) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6656), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6657), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6657) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6658), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6658) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6659), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6659) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6660), new DateTime(2025, 6, 10, 15, 23, 10, 316, DateTimeKind.Utc).AddTicks(6660) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(653), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(656) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(661), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(661) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(663), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(664) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(666), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(666) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(668), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(668) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(670), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(670) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(672), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(673) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(675), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(675) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(677), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(677) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(679), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(679) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(885), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(890), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(890) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(892), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(894), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(896), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(896) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(897), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(898) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(899), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(900) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(901), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(901) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(903), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(903) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(904), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(905) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(906), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(907) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(908), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(908) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(910), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(910) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(911), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(912) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(913), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(914) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(915), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(915) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(917), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(917) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(918), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(920), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(921) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(922), new DateTime(2025, 6, 9, 8, 39, 8, 662, DateTimeKind.Utc).AddTicks(922) });
        }
    }
}
