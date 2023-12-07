using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoTagEntity : AuditoryEntity<ChamadoTagEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoTagEntity()
        {
            Tag = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="tag"></param>
        public ChamadoTagEntity(string tag)
        {
            Tag = tag;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoEntity>? ChamadosEntity { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Tag { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoTagEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("ChamadoTag");
            builder.HasMany(t => t.ChamadosEntity)
                   .WithMany(t => t.ChamadoTag)
                   .UsingEntity(join => join.ToTable("ChamadosTagRelationship"));
        }
    }
}