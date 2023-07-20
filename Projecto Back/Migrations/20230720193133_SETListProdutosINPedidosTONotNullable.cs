using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projecto_Back.Migrations
{
    /// <inheritdoc />
    public partial class SETListProdutosINPedidosTONotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_categoriaId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_categoriaId",
                table: "Produtos",
                column: "categoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_categoriaId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "categoriaId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_categoriaId",
                table: "Produtos",
                column: "categoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }
    }
}
