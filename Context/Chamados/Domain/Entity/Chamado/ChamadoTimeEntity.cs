using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoTimeEntity : AuditoryEntity<ChamadoTimeEntity>
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoClassificacaoEntity>? ChamadoClassificacao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoEntity>? Chamados { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Email { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? NomeDoTime { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Responsavel { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoTimeEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("ChamadoTime");
            builder.HasMany(t => t.ChamadoClassificacao)
                   .WithOne(t => t.ChamadoTime)
                   .HasForeignKey(t => t.IdChamadoTime);

            builder.HasMany(t => t.Chamados)
                   .WithOne(t => t.ChamadoTime)
                   .HasForeignKey(t => t.IdChamadoTime)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}