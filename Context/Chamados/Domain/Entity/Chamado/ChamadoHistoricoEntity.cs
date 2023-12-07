using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoHistoricoEntity : AuditoryEntity<ChamadoHistoricoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoHistoricoEntity()
        {
            UsHistorico = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoEntity? ChamadoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? De { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Para { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsHistorico { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoHistoricoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("ChamadoHistorico");

            builder.HasOne(t => t.ChamadoEntity)
                   .WithMany(t => t.ChamadoHistoricoLista)
                   .HasForeignKey(t => t.IdChamado);
        }
    }
}