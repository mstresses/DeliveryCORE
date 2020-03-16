using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(maxLength: 14, nullable: false),
                    Senha = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RESTAURANTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFantasia = table.Column<string>(maxLength: 60, nullable: false),
                    CNPJ = table.Column<string>(maxLength: 18, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Categoria = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESTAURANTES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Senha = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestauranteID = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 60, nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_RESTAURANTES_RestauranteID",
                        column: x => x.RestauranteID,
                        principalTable: "RESTAURANTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestauranteID = table.Column<int>(nullable: true),
                    ProdutoID = table.Column<int>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    TaxaEntrega = table.Column<bool>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_PRODUTOS_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "PRODUTOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_RESTAURANTES_RestauranteID",
                        column: x => x.RestauranteID,
                        principalTable: "RESTAURANTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_Cpf",
                table: "CLIENTES",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_Email",
                table: "CLIENTES",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_Telefone",
                table: "CLIENTES",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_ProdutoID",
                table: "PEDIDOS",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_RestauranteID",
                table: "PEDIDOS",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_RestauranteID",
                table: "PRODUTOS",
                column: "RestauranteID");

            migrationBuilder.CreateIndex(
                name: "IX_RESTAURANTES_CNPJ",
                table: "RESTAURANTES",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_USUARIO_EMAIL",
                table: "USUARIOS",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "RESTAURANTES");
        }
    }
}
