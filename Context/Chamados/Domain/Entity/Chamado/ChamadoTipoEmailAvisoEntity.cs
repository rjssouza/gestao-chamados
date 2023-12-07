using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoTipoEmailAvisoEntity : AuditoryEntity<ChamadoTipoEmailAvisoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoTipoEmailAvisoEntity()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool Ativo { get; set; } = false;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoTipoEntity? ChamadoTipo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoTipo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string NomeResponsavel { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoTipoEmailAvisoEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("ChamadoTipoEmailAviso");

            builder.HasOne(t => t.ChamadoTipo)
                   .WithMany(t => t.ChamadoTipoEmailAvisos)
                   .HasForeignKey(t => t.IdChamadoTipo);
        }
    }
}