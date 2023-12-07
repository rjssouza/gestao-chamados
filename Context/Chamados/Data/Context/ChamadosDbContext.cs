using Chamados.Domain.Entity;
using Chamados.Domain.Entity.Formulario;
using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Chamados.Domain.Entity.Formulario.Opcao;
using Core.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chamados.Data.Context
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadosDbContext : CoreDbContext
    {
        private const string DB_NAME = "BDCHNORIS";

        /// <summary>
        ///
        /// </summary>
        /// <param name="configuration"></param>
        public ChamadosDbContext(IConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<AreaEntity>? AreaEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoClassificacaoEntity>? CartItem { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoAnexoEntity>? ChamadoAnexoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoComentariosEntity>? ChamadoComentariosEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoEntity>? ChamadoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoHistoricoEntity>? ChamadoHistoricoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoPrioridadeEntity>? ChamadoPrioridadeEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoTagEntity>? ChamadoTagEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoTimeEntity>? ChamadoTimeEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoTipoEmailAvisoEntity>? ChamadoTipoEmailAvisoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<ChamadoTipoEntity>? ChamadoTipoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioComponenteEntity>? FormularioComponenteEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioEntity>? FormularioEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioOpcaoDicionarioEntity>? FormularioOpcaoDicionarioEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioOpcaoEntity>? FormularioOpcaoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioQuestaoEntity>? FormularioQuestaoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioRespostaEntity>? FormularioRespostaEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<FormularioRespostaOpcaoEntity>? FormularioRespostaOpcaoEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<LinhaEntity>? LinhaEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DbSet<MaquinaEntity>? MaquinaEntity { get; set; }

        /// <summary>
        ///
        /// </summary>
        protected override string DbName => DB_NAME;
    }
}