using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedisActiveForCustomersAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6133), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6135) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6138), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6138) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6140), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6141) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6142), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6142) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6144), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6144) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6145), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6146) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6147), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6148), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6149) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6150), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6150) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6151), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6293), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6293) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6296), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6296) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6298), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6299), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6301), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6301) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6302), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6303), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6304) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6305), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6305) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6306), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6306) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6307), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6308) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6309), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6309) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6310), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6310) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6311), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6312) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6313), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6313) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6314), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6314) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6315), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6315) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6316), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6317) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6318), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6319), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6319) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "IsActive", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6320), true, new DateTime(2025, 6, 11, 9, 17, 11, 418, DateTimeKind.Utc).AddTicks(6321) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7637), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7643), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7643) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7645), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7646), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7648), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7648) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7649), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7650) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7651), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7651) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7653), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7653) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7654), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7655) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7656), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7656) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7800), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7803), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7803) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7805), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7807), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7808), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7808) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7809), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7810) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7811), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7811) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7812), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7812) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7813), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7814) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7815), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7815) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7816), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7817), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7817) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7818), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7820), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7820) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7821), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7821) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7822), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7824), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7825), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7825) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7826), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7828), new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7828) });
        }
    }
}
