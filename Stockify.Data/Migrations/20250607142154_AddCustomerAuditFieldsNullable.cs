using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerAuditFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2467), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2469), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2474), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2474), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2477), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2477), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2479), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2479), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2481), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2481), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2482), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2483), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2484), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2485), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2487), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2487), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2488), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2489), null });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2490), null, new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2491), null });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedById",
                table: "Customers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UpdatedById",
                table: "Customers",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_CreatedById",
                table: "Customers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_UpdatedById",
                table: "Customers",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_CreatedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_UpdatedById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreatedById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UpdatedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Customers");
        }
    }
}
