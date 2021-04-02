using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotzAPI.Migrations
{
    public partial class AdicionarProdutosCategoriasSubCategoriasAtualizarPontosDotz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontoDotz_Usuarios_UsuarioId",
                table: "PontoDotz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PontoDotz",
                table: "PontoDotz");

            migrationBuilder.RenameTable(
                name: "PontoDotz",
                newName: "PontosDotz");

            migrationBuilder.RenameIndex(
                name: "IX_PontoDotz_UsuarioId",
                table: "PontosDotz",
                newName: "IX_PontosDotz_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontosDotz",
                table: "PontosDotz",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Descricao = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    SubcategoriaId = table.Column<int>(type: "int", nullable: true),
                    QuantidadePontosDotzParaResgate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produtos_SubCategorias_SubcategoriaId",
                        column: x => x.SubcategoriaId,
                        principalTable: "SubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_SubcategoriaId",
                table: "Produtos",
                column: "SubcategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDotz_Usuarios_UsuarioId",
                table: "PontosDotz",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosDotz_Usuarios_UsuarioId",
                table: "PontosDotz");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "SubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PontosDotz",
                table: "PontosDotz");

            migrationBuilder.RenameTable(
                name: "PontosDotz",
                newName: "PontoDotz");

            migrationBuilder.RenameIndex(
                name: "IX_PontosDotz_UsuarioId",
                table: "PontoDotz",
                newName: "IX_PontoDotz_UsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PontoDotz",
                table: "PontoDotz",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PontoDotz_Usuarios_UsuarioId",
                table: "PontoDotz",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
