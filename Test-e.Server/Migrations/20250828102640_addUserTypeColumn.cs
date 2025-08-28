using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_e.Server.Migrations
{
    /// <inheritdoc />
    public partial class addUserTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OrderAdjustments",
                newName: "AdjustmentType");

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2879), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2881) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2886), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2887) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2888), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2888) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2889), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2891), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2891) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2892), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2893), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3017), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3020) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3024), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3025) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3026), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3026) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3027), new DateTime(2025, 8, 28, 10, 26, 40, 265, DateTimeKind.Utc).AddTicks(3027) });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { 6, "Register Users", "RegisterUsers" },
                    { 7, "Order Discount", "OrderDiscount" },
                    { 8, "View Products", "Products" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "AdjustmentType",
                table: "OrderAdjustments",
                newName: "Type");

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6019), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6021) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6025), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6027), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6027) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6029), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6030), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6031), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6033), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6033) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6171), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6174) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6177), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6177) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6179), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6180), new DateTime(2025, 8, 27, 21, 54, 37, 952, DateTimeKind.Utc).AddTicks(6180) });
        }
    }
}
