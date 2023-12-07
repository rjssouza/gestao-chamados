using Chamados.Domain.Entity.Chamado;
using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Chamados.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoEntity : AuditoryEntity<ChamadoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoEntity()
        {
            Descricao = string.Empty;
            UsSolicitante = string.Empty;
            UsSolicitanteNomeCompleto = string.Empty;
            UsEmailSolicitante = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [NotMapped]
        public static bool EstahAtrasado
        {
            get
            {
                return (false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoAnexoEntity>? Anexos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Atendimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoClassificacaoEntity? ChamadoClassificacaoEntity { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoHistoricoEntity>? ChamadoHistoricoLista { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoPrioridadeEntity? ChamadoPrioridade { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoTagEntity>? ChamadoTag { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoTimeEntity? ChamadoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoTipoEntity? ChamadoTipo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoComentariosEntity>? Comentarios { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Descricao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DtAtendimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DtFechamento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DtRecebimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        [NotMapped]
        public bool EmAtendimento => this.DtAtendimento.HasValue && !this.DtFechamento.HasValue;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [NotMapped]
        public bool EstahPendente
        {
            get
            {
                return (!this.DtRecebimento.HasValue || !this.DtAtendimento.HasValue);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioRespostaEntity? FormularioResposta { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoClassificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoPai { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoPrioridade { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamadoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoTipo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormularioResposta { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdNorisMaquina { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [NotMapped]
        public double PercentualAtendimento
        {
            get
            {
                var resultado = PercentualAtendimentos?.Select(t => t.Percentual).LastOrDefault() ?? 0;

                return Math.Round(resultado, 2);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ProgressoChamadoEntity>? PercentualAtendimentos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [NotMapped]
        public StatusChamadoEnum Status
        {
            get
            {
                if (this.EmAtendimento) return StatusChamadoEnum.Atendimento;
                if (EstahAtrasado) return StatusChamadoEnum.Atraso;
                if (this.EstahPendente) return StatusChamadoEnum.Novo;
                if (!this.EmAtendimento) return StatusChamadoEnum.Finalizado;

                throw new NullReferenceException("Erro ao obter status do chamado");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        [NotMapped]
        public DateTime UltimaAtualizacao
        {
            get
            {
                if (DtFechamento.HasValue)
                    return DtFechamento.Value;
                else if (DtAtendimento.HasValue)
                    return DtAtendimento.Value;
                else if (DtRecebimento.HasValue)
                    return DtRecebimento.Value;

                return DtReg;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsEmailSolicitante { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsSolicitante { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsSolicitanteNomeCompleto { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Chamado");

            builder.HasMany(t => t.ChamadoTag)
                   .WithMany(t => t.ChamadosEntity)
                   .UsingEntity(join => join.ToTable("ChamadosTagRelationship"));

            builder.HasOne(t => t.ChamadoClassificacaoEntity)
                   .WithMany(t => t.ChamadosLista)
                   .HasForeignKey(t => t.IdChamadoClassificacao);

            builder.HasOne(t => t.ChamadoTipo)
                   .WithMany(t => t.Chamados)
                   .HasForeignKey(t => t.IdChamadoTipo);

            builder.HasOne(t => t.ChamadoPrioridade)
                   .WithMany(t => t.ChamadosLista)
                   .HasForeignKey(t => t.IdChamadoPrioridade);

            builder.HasMany(t => t.ChamadoHistoricoLista)
                   .WithOne(t => t.ChamadoEntity)
                   .HasForeignKey(t => t.IdChamado);

            builder.HasMany(t => t.Comentarios)
                   .WithOne(t => t.ChamadoEntity)
                   .HasForeignKey(t => t.IdChamado);

            builder.HasMany(t => t.Anexos)
                   .WithOne(t => t.ChamadoEntity)
                   .HasForeignKey(t => t.IdChamado);

            builder.HasOne(t => t.FormularioResposta)
                   .WithOne(t => t.Chamado)
                   .HasForeignKey<ChamadoEntity>(t => t.IdFormularioResposta);

            builder.HasMany(t => t.PercentualAtendimentos)
                   .WithOne(t => t.Chamado)
                   .HasForeignKey(t => t.IdChamado);

            builder.HasOne(t => t.ChamadoTime)
                   .WithMany(t => t.Chamados)
                   .HasForeignKey(t => t.IdChamadoTime);
        }
    }
}