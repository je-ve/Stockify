using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class removedOrderActionsFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderActions_Orders_OrderId",
                table: "OrderActions");

            migrationBuilder.DropIndex(
                name: "IX_OrderActions_OrderId",
                table: "OrderActions");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrderActions",
                newName: "ActionType");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActionType",
                table: "OrderActions",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2558), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2560) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2563), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2565), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2565) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2566), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2568), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2568) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2569), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2569) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2570), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2571) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2571), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2572) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2573), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2574), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2574) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2705), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2705) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2708), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2714), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2716), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2716) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2717), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2717) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2718), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2719) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2719), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2720), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2721) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2721), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2722) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2722), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2723) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2723), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2724) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2724), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2725) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2725), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2726) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2726), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2727) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2727), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2728) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2728), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2729) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2729), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2730), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2731) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2731), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2732) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2732), new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2733) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderActions_OrderId",
                table: "OrderActions",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderActions_Orders_OrderId",
                table: "OrderActions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
