using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TestRide.Migrations
{
    public partial class CustomerLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Testdrives",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Timestamp",
                table: "Testdrives",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SocialSecurityNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Testdrives_CustomerId",
                table: "Testdrives",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testdrives_Customer_CustomerId",
                table: "Testdrives",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testdrives_Customer_CustomerId",
                table: "Testdrives");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Testdrives_CustomerId",
                table: "Testdrives");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Testdrives");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Testdrives");
        }
    }
}
