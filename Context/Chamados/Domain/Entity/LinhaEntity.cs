using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class LinhaEntity : Entity<LinhaEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public LinhaEntity()
        {
            Bezeichnung = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        public string Bezeichnung { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<LinhaEntity> builder)
        {
            builder.ToView("Linha");
        }
    }
}