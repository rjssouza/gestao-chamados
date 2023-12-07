using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chamados.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20230320200712_V10 : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadoTipoEmailAviso");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChamadoTipoEmailAviso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChamadoTipo = table.Column<int>(type: "int", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsReg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoTipoEmailAviso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadoTipoEmailAviso_ChamadoTipo_IdChamadoTipo",
                        column: x => x.IdChamadoTipo,
                        principalTable: "ChamadoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoTipoEmailAviso_IdChamadoTipo",
                table: "ChamadoTipoEmailAviso",
                column: "IdChamadoTipo");
        }
    }
}