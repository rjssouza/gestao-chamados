using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoAnexoEntity : AuditoryEntity<ChamadoAnexoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoAnexoEntity()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Anexo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public virtual ChamadoEntity? ChamadoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string NomeArquivo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string TipoArquivo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsAnexo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<ChamadoAnexoEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("ChamadoAnexo");
        }
    }
}