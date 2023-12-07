using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoTipoEntity : AuditoryEntity<ChamadoTipoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoTipoEntity()
        {
            ChamadoTipo = string.Empty;
            Cor = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool? Ativo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoClassificacaoEntity? ChamadoClassificacao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoEntity>? Chamados { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string ChamadoTipo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoTipoEmailAvisoEntity>? ChamadoTipoEmailAvisos { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Cor { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoClassificacao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? Ordem { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsPrimeiroCombate { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoTipoEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("ChamadoTipo");

            builder.HasOne(t => t.ChamadoClassificacao)
                   .WithMany(t => t.ChamadoTipo)
                   .HasForeignKey(t => t.IdChamadoClassificacao);

            builder.HasMany(t => t.Chamados)
                   .WithOne(t => t.ChamadoTipo)
                   .HasForeignKey(t => t.IdChamadoTipo)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(t => t.ChamadoTipoEmailAvisos)
                   .WithOne(t => t.ChamadoTipo)
                   .HasForeignKey(t => t.IdChamadoTipo)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}