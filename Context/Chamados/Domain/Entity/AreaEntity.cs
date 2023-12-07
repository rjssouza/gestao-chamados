using Chamados.Domain.Entity.Formulario;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class AreaEntity : Entity<AreaEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public AreaEntity()
        {
            Nome = String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioEntity>? Formularios { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Nome { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<AreaEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("Area");

            builder.HasMany(t => t.Formularios)
                   .WithOne(t => t.Area)
                   .HasForeignKey(t => t.IdArea);
        }
    }
}