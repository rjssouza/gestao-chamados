using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity.Formulario.Opcao
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioOpcaoDicionarioEntity : Entity<FormularioOpcaoDicionarioEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioOpcaoDicionarioEntity()
        {
            Chave = String.Empty;
            Valor = String.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Chave { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormularioOpcao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual FormularioOpcaoEntity? Opcao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Valor { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<FormularioOpcaoDicionarioEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("FormularioOpcaoDicionario");

            builder.HasOne(t => t.Opcao)
                   .WithMany(t => t.Dicionario)
                   .HasForeignKey(t => t.IdFormularioOpcao);
        }
    }
}