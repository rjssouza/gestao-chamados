using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chamados.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20230320200712_V11 : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadoAnexo");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamadoAnexo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChamado = table.Column<int>(type: "int", nullable: false),
                    UsAnexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsReg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoAnexo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadoAnexo_Chamado_IdChamado",
                        column: x => x.IdChamado,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoAnexo_IdChamado",
                table: "ChamadoAnexo",
                column: "IdChamado");
        }
    }
}