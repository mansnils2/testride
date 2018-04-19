using Microsoft.EntityFrameworkCore.Migrations;

namespace TestRide.Migrations
{
    public partial class RemoveExplicitColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Cars_CarId",
                table: "Testdrives");

            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Customers_CustomerId",
                table: "Testdrives");

            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Users_UserId",
                table: "Testdrives");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Testdrives",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Testdrives",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Testdrives",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Cars_CarId",
                table: "Testdrives",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Customers_CustomerId",
                table: "Testdrives",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Users_UserId",
                table: "Testdrives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Cars_CarId",
                table: "Testdrives");

            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Customers_CustomerId",
                table: "Testdrives");

            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Users_UserId",
                table: "Testdrives");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Testdrives",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Testdrives",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CarId",
                table: "Testdrives",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Cars_CarId",
                table: "Testdrives",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Customers_CustomerId",
                table: "Testdrives",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Users_UserId",
                table: "Testdrives",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
