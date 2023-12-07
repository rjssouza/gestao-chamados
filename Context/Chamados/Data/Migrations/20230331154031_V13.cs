using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chamados.Data.Migrations
{
    /// <inheritdoc />
    public partial class V13 : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamado_ChamadoTime_IdChamadoTime",
                table: "Chamado");

            migrationBuilder.DropIndex(
                name: "IX_Chamado_IdChamadoTime",
                table: "Chamado");

            migrationBuilder.DropColumn(
                name: "IdChamadoTime",
                table: "Chamado");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdChamadoTime",
                table: "Chamado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_IdChamadoTime",
                table: "Chamado",
                column: "IdChamadoTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamado_ChamadoTime_IdChamadoTime",
                table: "Chamado",
                column: "IdChamadoTime",
                principalTable: "ChamadoTime",
                principalColumn: "Id");
        }
    }
}