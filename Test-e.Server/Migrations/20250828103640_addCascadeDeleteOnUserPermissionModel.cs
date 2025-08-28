using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_e.Server.Migrations
{
    /// <inheritdoc />
    public partial class addCascadeDeleteOnUserPermissionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8872), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8875) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8883), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8884), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8886), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8886) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8887), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8887) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8888), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8888) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8889), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(8889) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9044), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9048) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9050), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9051), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9052) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9052), new DateTime(2025, 8, 28, 10, 36, 40, 352, DateTimeKind.Utc).AddTicks(9053) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
