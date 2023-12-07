using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioEntity : Entity<FormularioEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioEntity()
        {
            Nome = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual AreaEntity? Area { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdArea { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Nome { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioQuestaoEntity>? Questoes { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioRespostaEntity>? Respostas { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Formulario");

            builder.HasMany(t => t.Questoes)
                   .WithOne(t => t.Formulario)
                   .HasForeignKey(t => t.IdFormulario);

            builder.HasMany(t => t.Respostas)
                   .WithOne(t => t.Formulario)
                   .HasForeignKey(t => t.IdFormulario);

            builder.HasOne(t => t.Area)
                   .WithMany(t => t.Formularios)
                   .HasForeignKey(t => t.IdArea);
        }
    }
}