using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoClassificacaoEntity : AuditoryEntity<ChamadoClassificacaoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoClassificacaoEntity()
        {
            Classificacao = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoClassificacaoEntity>? ChamadoFilho { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoClassificacaoEntity? ChamadoPai { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoEntity>? ChamadosLista { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoTimeEntity? ChamadoTime { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoTipoEntity>? ChamadoTipo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Classificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamadoClassPai { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoClassificacaoEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("ChamadoClassificacao");
            builder.HasOne(t => t.ChamadoTime)
                   .WithMany(t => t.ChamadoClassificacao)
                   .HasForeignKey(t => t.IdChamadoTime);

            builder.HasOne(t => t.ChamadoPai)
                   .WithMany(t => t.ChamadoFilho)
                   .HasForeignKey(t => t.IdChamadoClassPai);

            builder.HasMany(t => t.ChamadoTipo)
                   .WithOne(t => t.ChamadoClassificacao)
                   .HasForeignKey(t => t.IdChamadoClassificacao);

            builder.HasMany(t => t.ChamadosLista)
                   .WithOne(t => t.ChamadoClassificacaoEntity)
                   .HasForeignKey(t => t.IdChamadoClassificacao);

            builder.HasOne(t => t.ChamadoTime)
                   .WithMany(t => t.ChamadoClassificacao)
                   .HasForeignKey(t => t.IdChamadoTime);
        }
    }
}