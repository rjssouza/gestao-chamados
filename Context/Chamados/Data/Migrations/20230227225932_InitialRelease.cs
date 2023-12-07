using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chamados.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialRelease : Migration
    {
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamadoComentarios");

            migrationBuilder.DropTable(
                name: "ChamadoHistorico");

            migrationBuilder.DropTable(
                name: "ChamadosTagRelationship");

            migrationBuilder.DropTable(
                name: "FormularioOpcaoDicionario");

            migrationBuilder.DropTable(
                name: "FormularioRespostaOpcao");

            migrationBuilder.DropTable(
                name: "ChamadoTag");

            migrationBuilder.DropTable(
                name: "FormularioOpcao");

            migrationBuilder.DropTable(
                name: "FormularioResposta");

            migrationBuilder.DropTable(
                name: "FormularioComponente");

            migrationBuilder.DropTable(
                name: "FormularioQuestao");

            migrationBuilder.DropTable(
                name: "Chamado");

            migrationBuilder.DropTable(
                name: "Formulario");

            migrationBuilder.DropTable(
                name: "ChamadoPrioridade");

            migrationBuilder.DropTable(
                name: "ChamadoTipo");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "ChamadoClassificacao");

            migrationBuilder.DropTable(
                name: "ChamadoTime");
        }

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoPrioridade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Prioridade = table.Column<int>(type: "int", nullable: false),
                    SlaAtendimentoHoras = table.Column<int>(type: "int", nullable: false),
                    SlaRecebimentoHoras = table.Column<int>(type: "int", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoPrioridade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoTag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChamado = table.Column<int>(type: "int", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeDoTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormularioComponente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipo = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioComponente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formulario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArea = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Formulario_Area_IdArea",
                        column: x => x.IdArea,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoClassificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classificacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChamadoClassPai = table.Column<int>(type: "int", nullable: true),
                    IdChamadoTime = table.Column<int>(type: "int", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoClassificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadoClassificacao_ChamadoClassificacao_IdChamadoClassPai",
                        column: x => x.IdChamadoClassPai,
                        principalTable: "ChamadoClassificacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChamadoClassificacao_ChamadoTime_IdChamadoTime",
                        column: x => x.IdChamadoTime,
                        principalTable: "ChamadoTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormularioQuestao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFormulario = table.Column<int>(type: "int", nullable: false),
                    IdProximaQuestao = table.Column<int>(type: "int", nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TextoComplementar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioQuestao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioQuestao_Formulario_IdFormulario",
                        column: x => x.IdFormulario,
                        principalTable: "Formulario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: true),
                    ChamadoTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChamadoClassificacao = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: true),
                    UsPrimeiroCombate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoTipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadoTipo_ChamadoClassificacao_IdChamadoClassificacao",
                        column: x => x.IdChamadoClassificacao,
                        principalTable: "ChamadoClassificacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormularioOpcao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComponente = table.Column<int>(type: "int", nullable: false),
                    IdProximaQuestao = table.Column<int>(type: "int", nullable: true),
                    IdQuestao = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioOpcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioOpcao_FormularioComponente_IdComponente",
                        column: x => x.IdComponente,
                        principalTable: "FormularioComponente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormularioOpcao_FormularioQuestao_IdProximaQuestao",
                        column: x => x.IdProximaQuestao,
                        principalTable: "FormularioQuestao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormularioOpcao_FormularioQuestao_IdQuestao",
                        column: x => x.IdQuestao,
                        principalTable: "FormularioQuestao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chamado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atendimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtAtendimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DtRecebimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdChamadoClassificacao = table.Column<int>(type: "int", nullable: false),
                    IdChamadoPai = table.Column<int>(type: "int", nullable: false),
                    IdChamadoPrioridade = table.Column<int>(type: "int", nullable: false),
                    IdChamadoTipo = table.Column<int>(type: "int", nullable: false),
                    IdFormularioResposta = table.Column<int>(type: "int", nullable: true),
                    IdNorisMaquina = table.Column<int>(type: "int", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chamado_ChamadoClassificacao_IdChamadoClassificacao",
                        column: x => x.IdChamadoClassificacao,
                        principalTable: "ChamadoClassificacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamado_ChamadoPrioridade_IdChamadoPrioridade",
                        column: x => x.IdChamadoPrioridade,
                        principalTable: "ChamadoPrioridade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamado_ChamadoTipo_IdChamadoTipo",
                        column: x => x.IdChamadoTipo,
                        principalTable: "ChamadoTipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormularioOpcaoDicionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdFormularioOpcao = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioOpcaoDicionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioOpcaoDicionario_FormularioOpcao_IdFormularioOpcao",
                        column: x => x.IdFormularioOpcao,
                        principalTable: "FormularioOpcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoComentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChamado = table.Column<int>(type: "int", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoComentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadoComentarios_Chamado_IdChamado",
                        column: x => x.IdChamado,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamadoHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    De = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdChamado = table.Column<int>(type: "int", nullable: false),
                    Para = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamadoHistorico_Chamado_IdChamado",
                        column: x => x.IdChamado,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamadosTagRelationship",
                columns: table => new
                {
                    ChamadoTagId = table.Column<int>(type: "int", nullable: false),
                    ChamadosEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadosTagRelationship", x => new { x.ChamadoTagId, x.ChamadosEntityId });
                    table.ForeignKey(
                        name: "FK_ChamadosTagRelationship_ChamadoTag_ChamadoTagId",
                        column: x => x.ChamadoTagId,
                        principalTable: "ChamadoTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChamadosTagRelationship_Chamado_ChamadosEntityId",
                        column: x => x.ChamadosEntityId,
                        principalTable: "Chamado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormularioResposta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChamado = table.Column<int>(type: "int", nullable: true),
                    IdFormulario = table.Column<int>(type: "int", nullable: false),
                    UsSolicitante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtReg = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsReg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioResposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioResposta_Chamado_IdChamado",
                        column: x => x.IdChamado,
                        principalTable: "Chamado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormularioResposta_Formulario_IdFormulario",
                        column: x => x.IdFormulario,
                        principalTable: "Formulario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormularioRespostaOpcao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdFormularioResposta = table.Column<int>(type: "int", nullable: false),
                    IdOpcao = table.Column<int>(type: "int", nullable: false),
                    IdQuestao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioRespostaOpcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormularioRespostaOpcao_FormularioOpcao_IdOpcao",
                        column: x => x.IdOpcao,
                        principalTable: "FormularioOpcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormularioRespostaOpcao_FormularioQuestao_IdQuestao",
                        column: x => x.IdQuestao,
                        principalTable: "FormularioQuestao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormularioRespostaOpcao_FormularioResposta_IdFormularioResposta",
                        column: x => x.IdFormularioResposta,
                        principalTable: "FormularioResposta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_IdChamadoClassificacao",
                table: "Chamado",
                column: "IdChamadoClassificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_IdChamadoPrioridade",
                table: "Chamado",
                column: "IdChamadoPrioridade");

            migrationBuilder.CreateIndex(
                name: "IX_Chamado_IdChamadoTipo",
                table: "Chamado",
                column: "IdChamadoTipo");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoClassificacao_IdChamadoClassPai",
                table: "ChamadoClassificacao",
                column: "IdChamadoClassPai");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoClassificacao_IdChamadoTime",
                table: "ChamadoClassificacao",
                column: "IdChamadoTime");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoComentarios_IdChamado",
                table: "ChamadoComentarios",
                column: "IdChamado");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoHistorico_IdChamado",
                table: "ChamadoHistorico",
                column: "IdChamado");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadosTagRelationship_ChamadosEntityId",
                table: "ChamadosTagRelationship",
                column: "ChamadosEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoTipo_IdChamadoClassificacao",
                table: "ChamadoTipo",
                column: "IdChamadoClassificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Formulario_IdArea",
                table: "Formulario",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioOpcao_IdComponente",
                table: "FormularioOpcao",
                column: "IdComponente");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioOpcao_IdProximaQuestao",
                table: "FormularioOpcao",
                column: "IdProximaQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioOpcao_IdQuestao",
                table: "FormularioOpcao",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioOpcaoDicionario_IdFormularioOpcao",
                table: "FormularioOpcaoDicionario",
                column: "IdFormularioOpcao");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioQuestao_IdFormulario",
                table: "FormularioQuestao",
                column: "IdFormulario");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioResposta_IdChamado",
                table: "FormularioResposta",
                column: "IdChamado",
                unique: true,
                filter: "[IdChamado] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioResposta_IdFormulario",
                table: "FormularioResposta",
                column: "IdFormulario");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioRespostaOpcao_IdFormularioResposta",
                table: "FormularioRespostaOpcao",
                column: "IdFormularioResposta");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioRespostaOpcao_IdOpcao",
                table: "FormularioRespostaOpcao",
                column: "IdOpcao");

            migrationBuilder.CreateIndex(
                name: "IX_FormularioRespostaOpcao_IdQuestao",
                table: "FormularioRespostaOpcao",
                column: "IdQuestao");
        }
    }
}