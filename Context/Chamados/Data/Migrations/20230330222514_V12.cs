using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chamados.Data.Migrations
{
    /// <inheritdoc />
    public partial class V12 : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PercentualAtendimento");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PercentualAtendimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChamado = table.Column<int>(type: "int", nullable: false),
                    Percentual = table.Column<double>(type: "float", nullable: false),
                    UsAtendente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsReg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentualAtendimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PercentualAtendimento_Chamado_IdChamado",
                        column: x => x.IdChamado,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PercentualAtendimento_IdChamado",
                table: "PercentualAtendimento",
                column: "IdChamado");
        }
    }
}