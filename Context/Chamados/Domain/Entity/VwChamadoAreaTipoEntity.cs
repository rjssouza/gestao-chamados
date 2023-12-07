using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class VwChamadoAreaTipoEntity : Entity<VwChamadoAreaTipoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public string? Area { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public string? ChamadoTipo { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public int? Total { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<VwChamadoAreaTipoEntity> builder)
        {
            builder.ToView("vw_chamadoTipoArea");
        }
    }
}