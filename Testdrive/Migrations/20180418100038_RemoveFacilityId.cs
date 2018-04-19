using Microsoft.EntityFrameworkCore.Migrations;

namespace TestRide.Migrations
{
    public partial class RemoveFacilityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacilityId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilityId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }
    }
}
