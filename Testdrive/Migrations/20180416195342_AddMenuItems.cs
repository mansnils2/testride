using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestRide.Migrations
{
    public partial class AddMenuItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowedRoles = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Users");
        }
    }
}
