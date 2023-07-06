using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecto_Back.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Clientes",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Clientes");
        }
    }
}
