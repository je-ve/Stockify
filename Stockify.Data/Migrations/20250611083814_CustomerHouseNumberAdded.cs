using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerHouseNumberAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Customers",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7637), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7639) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7643), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7643) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7645), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7646), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7648), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7648) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7649), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7650) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7651), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7651) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7653), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7653) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7654), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7655) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "HouseNumber", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7656), "2", new DateTime(2025, 6, 11, 8, 38, 14, 83, DateTimeKind.Utc).AddTicks(7656) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7579), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7583), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7585), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7586) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7587), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7587) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7588), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7589), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7589) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7590), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7592), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7592) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7593), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7594), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7594) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7705), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7706) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7708), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7708) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7709), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7709) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7710), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7711) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7712), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7712) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7713), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7713) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7714), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7715), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7715) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7716), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7716) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7717), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7717) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7718), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7719), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7720), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7720) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7721), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7721) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7722), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7722) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7723), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7723) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7724), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7724) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7725), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7725) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7726), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7726) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7727), new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7727) });
        }
    }
}
