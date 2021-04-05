using Microsoft.EntityFrameworkCore.Migrations;

namespace DotzAPI.Migrations
{
    public partial class RemovendoRelacionamentoPontoDotz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosDotz_Usuarios_UsuarioId",
                table: "PontosDotz");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "PontosDotz",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDotz_Usuarios_UsuarioId",
                table: "PontosDotz",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PontosDotz_Usuarios_UsuarioId",
                table: "PontosDotz");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "PontosDotz",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PontosDotz_Usuarios_UsuarioId",
                table: "PontosDotz",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
