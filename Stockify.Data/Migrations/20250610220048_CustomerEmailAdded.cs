using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class CustomerEmailAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7579), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7583), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7585), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7586) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7587), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7587) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7588), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7588) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7589), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7589) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7590), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7590) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7592), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7592) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7593), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7593) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Email", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7594), "test@test.test", new DateTime(2025, 6, 10, 22, 0, 48, 594, DateTimeKind.Utc).AddTicks(7594) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

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
    }
}
