using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Chamados.Domain.Entity.Formulario.Opcao;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioQuestaoEntity : Entity<FormularioQuestaoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioQuestaoEntity()
        {
            Titulo = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioEntity? Formulario { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormulario { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdProximaQuestao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioOpcaoEntity>? Opcoes { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioOpcaoEntity>? OpcoesAnteriores { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Ordem { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioRespostaOpcaoEntity>? Respostas { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? TextoComplementar { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Titulo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioQuestaoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FormularioQuestao");

            builder.HasOne(t => t.Formulario)
                   .WithMany(t => t.Questoes)
                   .HasForeignKey(t => t.IdFormulario);

            builder.HasMany(t => t.Opcoes)
                   .WithOne(t => t.Questao)
                   .HasForeignKey(t => t.IdQuestao);

            builder.HasMany(t => t.OpcoesAnteriores)
                   .WithOne(t => t.ProximaQuestao)
                   .HasForeignKey(t => t.IdProximaQuestao);

            builder.HasMany(t => t.Respostas)
                   .WithOne(t => t.Questao)
                   .HasForeignKey(t => t.IdQuestao)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(t => t.Ordem)
                   .IsRequired()
                   .HasDefaultValue(1);
        }
    }
}