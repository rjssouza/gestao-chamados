using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario.Opcao
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioComponenteEntity : Entity<FormularioComponenteEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioComponenteEntity()
        {
            Label = String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdTipo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Label { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioOpcaoEntity>? Opcoes { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioComponenteEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FormularioComponente");

            builder.HasMany(t => t.Opcoes)
                   .WithOne(t => t.Componente)
                   .HasForeignKey(t => t.IdComponente);
        }
    }
}