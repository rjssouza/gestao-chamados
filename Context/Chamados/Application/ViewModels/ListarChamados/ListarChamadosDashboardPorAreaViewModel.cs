using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Dashboard.Incidentes;

namespace Chamados.Application.ViewModels.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadosDashboardPorAreaViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Area { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdLinha { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdMaquina { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Maquina { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? RegistradoEm { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Responsavel { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? UsReg { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsSolicitanteNomeCompleto { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class ListarChamadosDashboardPorAreaViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadosDashboardPorAreaViewModel>? Chamados { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ListarChamadosFiltroViewModel? Filtro { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<IncidentesPorAreaViewModel>? IncidentesAreas { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<LinhaViewModel>? Linhas { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<MaquinaViewModel>? Maquinas { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoStatusViewModel>? Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoTagViewModel>? Tags { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoTimeViewModel>? Times { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Total { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<UsuarioViewModel>? Usuarios { get; set; }
    }
}