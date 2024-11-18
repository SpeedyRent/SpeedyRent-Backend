using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Login_back.Migrations
{
    /// <inheritdoc />
    public partial class AddVehiclesAndRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tenants_TenantId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Requests",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "FromDate",
                table: "Requests",
                newName: "From");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vehicles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Vehicles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                table: "Vehicles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Vehicles",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TenantUserId",
                table: "Tenants",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CarId",
                table: "Requests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Contract",
                table: "Requests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Requests",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Requests",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalDays",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Owners",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantUserId",
                table: "Tenants",
                column: "TenantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_OwnerUserId",
                table: "Owners",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Users_OwnerUserId",
                table: "Owners",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tenants_TenantId",
                table: "Requests",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Users_TenantUserId",
                table: "Tenants",
                column: "TenantUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Users_OwnerUserId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Tenants_TenantId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_TenantUserId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantUserId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Owners_OwnerUserId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Contract",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "Requests");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Requests",
                newName: "ToDate");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Requests",
                newName: "FromDate");

            migrationBuilder.AlterColumn<string>(
                name: "TenantUserId",
                table: "Tenants",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerUserId",
                table: "Owners",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Tenants_TenantId",
                table: "Requests",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Owners_OwnerId",
                table: "Vehicles",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
