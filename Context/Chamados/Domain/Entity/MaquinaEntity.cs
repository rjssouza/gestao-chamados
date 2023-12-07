using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class MaquinaEntity : Entity<MaquinaEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public MaquinaEntity()
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
        public int Liniennummer { get; private set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<MaquinaEntity> builder)
        {
            builder.ToView("Maquina");
        }
    }
}