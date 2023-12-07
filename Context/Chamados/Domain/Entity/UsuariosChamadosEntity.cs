using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chamados.Domain.Entity
{
    /// <summary>
    ///
    /// </summary>
    public class UsuariosChamadosEntity : Entity<UsuariosChamadosEntity>
    {
        /// <summary>
        ///
        /// </summary>
        public UsuariosChamadosEntity()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public int UsReg { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UsSolicitante { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string UsSolicitanteNomeCompleto { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <param name="builder"></param>
        public override void Configure(EntityTypeBuilder<UsuariosChamadosEntity> builder)
        {
            builder.ToSqlQuery("select cast(ROW_NUMBER() OVER(ORDER BY UsSolicitante ASC) as int) as Id, UsuariosChamadosEntity.* from (select distinct UsReg, UsSolicitante, UsSolicitanteNomeCompleto from chamado) as UsuariosChamadosEntity");
        }
    }
}