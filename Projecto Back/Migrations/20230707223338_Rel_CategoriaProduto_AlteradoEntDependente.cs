using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecto_Back.Migrations
{
    /// <inheritdoc />
    public partial class Rel_CategoriaProduto_AlteradoEntDependente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Produtos_produtoId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_produtoId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "produtoId",
                table: "Categorias");

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

            migrationBuilder.AddColumn<int>(
                name: "produtoId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_produtoId",
                table: "Categorias",
                column: "produtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Produtos_produtoId",
                table: "Categorias",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "Id");
        }
    }
}
