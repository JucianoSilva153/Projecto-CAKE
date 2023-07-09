using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Projecto_Back.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true),
                    email = table.Column<string>(type: "longtext", nullable: true),
                    password = table.Column<string>(type: "longtext", nullable: true),
                    contacto = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true),
                    descricao = table.Column<string>(type: "longtext", nullable: true),
                    preco = table.Column<double>(type: "double", nullable: false),
                    imagem = table.Column<string>(type: "longtext", nullable: true),
                    disponivel = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    data = table.Column<string>(type: "longtext", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true),
                    produtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Produtos_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produtos",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PedidoProduto",
                columns: table => new
                {
                    pedidosId = table.Column<int>(type: "int", nullable: false),
                    produtosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduto", x => new { x.pedidosId, x.produtosId });
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Pedidos_pedidosId",
                        column: x => x.pedidosId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Produtos_produtosId",
                        column: x => x.produtosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_produtoId",
                table: "Categorias",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_produtosId",
                table: "PedidoProduto",
                column: "produtosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteId",
                table: "Pedidos",
                column: "clienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "PedidoProduto");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
