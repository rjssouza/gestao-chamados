using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoComentariosEntity : AuditoryEntity<ChamadoComentariosEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoComentariosEntity()
        {
            UsComentario = string.Empty;
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
        public string? Comentario { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsComentario { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoComentariosEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("ChamadoComentarios");

            builder.HasOne(t => t.ChamadoEntity)
                   .WithMany(t => t.Comentarios)
                   .HasForeignKey(t => t.IdChamado);
        }
    }
}