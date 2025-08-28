using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test_e.Server.Migrations
{
    /// <inheritdoc />
    public partial class addUserPermissionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "OrderDiscounts");

            migrationBuilder.AddColumn<string>(
                name: "AdministratorNote",
                table: "OrderDiscounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "OrderDiscounts",
                type: "int",
                maxLength: 20,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "OrderDiscounts",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumOrderTotalPrice",
                table: "OrderDiscounts",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfUsage",
                table: "OrderDiscounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { 1, "View dashboard", "Dashboard.View" },
                    { 2, "View products", "Products.View" },
                    { 3, "Edit products", "Products.Edit" },
                    { 4, "View orders", "Orders.View" },
                    { 5, "Edit orders", "Orders.Edit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropColumn(
                name: "AdministratorNote",
                table: "OrderDiscounts");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "OrderDiscounts");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "OrderDiscounts");

            migrationBuilder.DropColumn(
                name: "MinimumOrderTotalPrice",
                table: "OrderDiscounts");

            migrationBuilder.DropColumn(
                name: "NumberOfUsage",
                table: "OrderDiscounts");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercent",
                table: "OrderDiscounts",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3638), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3646), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3647), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3649), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3649) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3650), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3651), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "OrderStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3652), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3653) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3789), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3791) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3794), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3794) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3795), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3796) });

            migrationBuilder.UpdateData(
                table: "PaymentStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3796), new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3797) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FacebookId", "FirstName", "GoogleId", "LastName", "Password", "Phone", "Photo", "Role" },
                values: new object[] { 1, new DateTime(2025, 8, 26, 20, 56, 7, 193, DateTimeKind.Utc).AddTicks(3822), "admin@teste.com", null, "Admin", null, "User", "admin123", null, null, "Admin" });
        }
    }
}
