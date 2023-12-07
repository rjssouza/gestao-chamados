using Chamados.Domain.Entity.Formulario.Opcao;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario.FormularioResposta
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioRespostaOpcaoEntity : Entity<FormularioRespostaOpcaoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public string? Descricao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public virtual FormularioRespostaEntity? FormularioResposta { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormularioResposta { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdOpcao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public int IdQuestao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public virtual FormularioOpcaoEntity? Opcao { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual FormularioQuestaoEntity? Questao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioRespostaOpcaoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FormularioRespostaOpcao");

            builder.HasOne(t => t.Opcao)
                   .WithMany(t => t.Respostas)
                   .HasForeignKey(t => t.IdOpcao);

            builder.HasOne(t => t.Questao)
                   .WithMany(t => t.Respostas)
                   .HasForeignKey(t => t.IdQuestao);

            builder.HasOne(t => t.FormularioResposta)
                   .WithMany(t => t.Respostas)
                   .HasForeignKey(t => t.IdFormularioResposta);
        }
    }
}