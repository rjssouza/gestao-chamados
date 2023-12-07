using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoPrioridadeEntity : AuditoryEntity<ChamadoPrioridadeEntity>
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool Ativo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<ChamadoEntity>? ChamadosLista { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Prioridade { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int SlaAtendimentoHoras { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int SlaRecebimentoHoras { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoPrioridadeEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("ChamadoPrioridade");

            builder.HasMany(t => t.ChamadosLista)
                   .WithOne(t => t.ChamadoPrioridade)
                   .HasForeignKey(t => t.IdChamadoPrioridade);
        }
    }
}