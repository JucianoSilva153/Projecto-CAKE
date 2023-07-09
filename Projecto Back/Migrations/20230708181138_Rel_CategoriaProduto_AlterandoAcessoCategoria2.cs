using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecto_Back.Migrations
{
    /// <inheritdoc />
    public partial class Rel_CategoriaProduto_AlterandoAcessoCategoria2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoriaId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_categoriaId",
                table: "Produtos",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_categoriaId",
                table: "Produtos",
                column: "categoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_categoriaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_categoriaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "categoriaId",
                table: "Produtos");
        }
    }
}
