using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai.Senatur.WebApi.Migrations
{
    public partial class SenaturV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosIdUsuario",
                table: "TiposUsuario",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 1,
                column: "Titulo",
                value: "ADMINISTRADOR");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "IdUsuario",
                keyValue: 2,
                column: "Titulo",
                value: "CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_TiposUsuario_UsuariosIdUsuario",
                table: "TiposUsuario",
                column: "UsuariosIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposUsuario_Usuarios_UsuariosIdUsuario",
                table: "TiposUsuario",
                column: "UsuariosIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TiposUsuario_Usuarios_UsuariosIdUsuario",
                table: "TiposUsuario");

            migrationBuilder.DropIndex(
                name: "IX_TiposUsuario_UsuariosIdUsuario",
                table: "TiposUsuario");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuariosIdUsuario",
                table: "TiposUsuario");
        }
    }
}
