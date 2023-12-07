using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class VwChamadoAreaStatusEntity : Entity<VwChamadoAreaStatusEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public string? Area { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public string? Situacao { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public int? Total { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<VwChamadoAreaStatusEntity> builder)
        {
            builder.ToView("vw_chamadoAreaStatus");
        }
    }
}