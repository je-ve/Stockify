using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stockify.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAndOrderAuditFieldsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

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
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2705), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2705), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2708), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2709), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2714), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2715), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2716), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2716), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2717), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2717), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2718), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2719), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2719), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2720), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2720), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2721), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2721), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2722), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2722), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2723), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2723), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2724), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2724), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2725), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2725), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2726), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2726), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2727), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2727), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2728), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2728), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2729), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2729), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2730), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2730), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2731), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2731), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2732), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "CreatedById", "UpdatedAt", "UpdatedById" },
                values: new object[] { new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2732), null, new DateTime(2025, 6, 7, 18, 18, 37, 561, DateTimeKind.Utc).AddTicks(2733), null });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UpdatedById",
                table: "Products",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedById",
                table: "Orders",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UpdatedById",
                table: "Orders",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UpdatedById",
                table: "Products",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CreatedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UpdatedById",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UpdatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UpdatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CreatedById",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UpdatedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2467), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2469) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2474), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2474) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2477), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2477) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2479), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2481), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2481) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2482), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2483) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2484), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2485) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2487), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2488), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2489) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2490), new DateTime(2025, 6, 7, 14, 21, 53, 721, DateTimeKind.Utc).AddTicks(2491) });
        }
    }
}
