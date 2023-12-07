using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario.FormularioResposta
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioRespostaEntity : AuditoryEntity<FormularioRespostaEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioRespostaEntity()
        {
            UsSolicitante = String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoEntity? Chamado { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioEntity? Formulario { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormulario { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioRespostaOpcaoEntity>? Respostas { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsSolicitante { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioRespostaEntity> builder)
        {
            base.Configure(builder);

            builder.ToTable("FormularioResposta");

            builder.HasOne(t => t.Formulario)
                   .WithMany(t => t.Respostas)
                   .HasForeignKey(t => t.IdFormulario);

            builder.HasOne(t => t.Chamado)
                   .WithOne(t => t.FormularioResposta)
                   .HasForeignKey<FormularioRespostaEntity>(t => t.IdChamado);

            builder.HasMany(t => t.Respostas)
                   .WithOne(t => t.FormularioResposta)
                   .HasForeignKey(t => t.IdFormularioResposta)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}