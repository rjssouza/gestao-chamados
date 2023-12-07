using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chamados.Data.Migrations
{
    /// <inheritdoc />
    public partial class V9 : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsHistorico",
                table: "ChamadoHistorico");

            migrationBuilder.DropColumn(
                name: "UsComentario",
                table: "ChamadoComentarios");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsHistorico",
                table: "ChamadoHistorico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsComentario",
                table: "ChamadoComentarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}