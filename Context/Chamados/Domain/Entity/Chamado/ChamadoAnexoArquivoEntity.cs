using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoAnexoArquivoEntity : AuditoryEntity<ChamadoAnexoArquivoEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoAnexoArquivoEntity()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string NomeArquivo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
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
        public override void Configure(EntityTypeBuilder<ChamadoAnexoArquivoEntity> builder)
        {
            builder.ToSqlQuery("select Id, NomeArquivo, TipoArquivo, IdChamado, DtReg, UsReg, UsAnexo  from ChamadoAnexo as ChamadoAnexoArquivoEntity");
        }
    }
}