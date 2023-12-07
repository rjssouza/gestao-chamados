using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnviarEmail.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class EnviarEmailEntity : Entity<EnviarEmailEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public EnviarEmailEntity()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<EnviarEmailEntity> builder)
        {
            base.Configure(builder);

            builder.ToView("EnviarEmail");
        }
    }
}