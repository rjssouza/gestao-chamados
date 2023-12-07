using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario.Opcao
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioOpcaoEntity : Entity<FormularioOpcaoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioOpcaoEntity()
        {
            Texto = String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioComponenteEntity? Componente { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioOpcaoDicionarioEntity>? Dicionario { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdComponente { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdProximaQuestao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdQuestao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioQuestaoEntity? ProximaQuestao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioQuestaoEntity? Questao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<FormularioRespostaOpcaoEntity>? Respostas { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Texto { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioOpcaoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FormularioOpcao");

            builder.HasOne(t => t.Questao)
                   .WithMany(t => t.Opcoes)
                   .HasForeignKey(t => t.IdQuestao);

            builder.HasOne(t => t.Componente)
                   .WithMany(t => t.Opcoes)
                   .HasForeignKey(t => t.IdComponente);

            builder.HasMany(t => t.Dicionario)
                   .WithOne(t => t.Opcao)
                   .HasForeignKey(t => t.IdFormularioOpcao);

            builder.HasMany(t => t.Respostas)
                   .WithOne(t => t.Opcao)
                   .HasForeignKey(t => t.IdOpcao);

            builder.HasOne(t => t.ProximaQuestao)
                   .WithMany(t => t.OpcoesAnteriores)
                   .HasForeignKey(t => t.IdProximaQuestao);
        }
    }
}