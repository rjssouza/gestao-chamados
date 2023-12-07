using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Evolutivo;
using Chamados.Application.ViewModels.Dashboard.Incidentes;
using Chamados.Application.ViewModels.Dashboard.Totalizadores;
using Chamados.Application.ViewModels.DashboardArea;
using Chamados.Application.ViewModels.Listar;

namespace Chamados.Application.Interfaces
{
    /// <summary>
    /// Interface abertura de chamado
    /// </summary>
    public interface IDashboardAppService : IDisposable
    {
        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <param name="filtro">Filtro de dados</param>
        /// <returns>Lista de chamados</returns>
        Task<ListarChamadosResultViewModel> ListarChamados(ListarChamadosFiltroViewModel filtro);

        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <param name="filtro">Filtro de dados</param>
        /// <returns>Lista de chamados</returns>
        Task<ListarChamadosDashboardPorAreaViewModel> ListarChamadosArea(ListarChamadosFiltroViewModel filtro);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<EvolutivoViewModel> ObterEvolutivo();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<IncidentesPorAreaViewModel> ObterIncidentesPorArea();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<IncidentesPorAreaStatusViewModel> ObterIncidentesPorAreaStatus();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<IncidentesPorAreaTipoViewModel> ObterIncidentesPorAreaTipo();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<TotalizadorViewModel> ObterTotalizadores();

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task<DashboardViewModel> ObterViewModel();

        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <param name="filtro">Filtro de dados</param>
        /// <returns>Lista de chamados</returns>
        Task<ListarTotalizadorMaquinasImpactadasViewModel> SomarMaquinasMaisImpactadas(ListarChamadosFiltroViewModel filtro);
    }
}