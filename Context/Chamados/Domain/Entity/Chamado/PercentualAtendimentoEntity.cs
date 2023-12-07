using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ProgressoChamadoEntity : AuditoryEntity<ProgressoChamadoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ProgressoChamadoEntity()
        {
            Comentario = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoEntity? Chamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Comentario { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public double Percentual { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsAtendente { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ProgressoChamadoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("PercentualAtendimento");
            builder.HasOne(t => t.Chamado)
                   .WithMany(t => t.PercentualAtendimentos)
                   .HasForeignKey(t => t.IdChamado);
        }
    }
}