using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestRide.Migrations
{
    public partial class RemoveFacility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Facilities_FacilityId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropIndex(
                name: "IX_Users_FacilityId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FacilityId",
                table: "Users",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Facilities_FacilityId",
                table: "Users",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
