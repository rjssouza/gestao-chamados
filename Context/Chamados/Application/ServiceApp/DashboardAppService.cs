using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Evolutivo;
using Chamados.Application.ViewModels.Dashboard.Incidentes;
using Chamados.Application.ViewModels.Dashboard.Totalizadores;
using Chamados.Application.ViewModels.DashboardArea;
using Chamados.Application.ViewModels.Listar;
using Core.Application;
using Core.Application.Seguranca;
using Core.Domain.Interfaces;
using Core.Extensions;
using System.Security.Claims;

namespace Chamados.Application
{
    /// <summary>
    /// Service para abrir chamados
    /// </summary>
    public class DashboardAppService : ServiceApp, IDashboardAppService
    {
        private readonly ClaimsPrincipal _currentClaimsPrincipal;
        private readonly IUseCase<FiltroComumViewModel, EvolutivoViewModel> _evolutivoUseCase;
        private readonly IUseCase<FiltroComumViewModel, IncidentesPorAreaStatusViewModel> _incidentesAreaStatusViewModel;
        private readonly IUseCase<FiltroComumViewModel, IncidentesPorAreaTipoViewModel> _incidentesAreaTipoViewModel;
        private readonly IUseCase<FiltroComumViewModel, IncidentesPorAreaViewModel> _incidentesAreaViewModel;
        private readonly IUseCase<ListarChamadosFiltroViewModel, ListarChamadosDashboardPorAreaViewModel> _listarChamadosAreaUseCase;
        private readonly IUseCase<ListarChamadosFiltroViewModel, ListarChamadosResultViewModel> _listarChamadosUseCase;
        private readonly IUseCase<ListarChamadosFiltroViewModel, ListarTotalizadorMaquinasImpactadasViewModel> _listarTotalizadorMaquinasImpactadasUseCase;
        private readonly IUseCase<FiltroComumViewModel, TotalizadorViewModel> _totalizadoresUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public DashboardAppService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _listarChamadosUseCase = serviceProvider.GetRequiredService<IUseCase<ListarChamadosFiltroViewModel, ListarChamadosResultViewModel>>();
            _evolutivoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroComumViewModel, EvolutivoViewModel>>();
            _incidentesAreaViewModel = serviceProvider.GetRequiredService<IUseCase<FiltroComumViewModel, IncidentesPorAreaViewModel>>();
            _incidentesAreaStatusViewModel = serviceProvider.GetRequiredService<IUseCase<FiltroComumViewModel, IncidentesPorAreaStatusViewModel>>();
            _incidentesAreaTipoViewModel = serviceProvider.GetRequiredService<IUseCase<FiltroComumViewModel, IncidentesPorAreaTipoViewModel>>();
            _totalizadoresUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroComumViewModel, TotalizadorViewModel>>();
            _listarChamadosAreaUseCase = serviceProvider.GetRequiredService<IUseCase<ListarChamadosFiltroViewModel, ListarChamadosDashboardPorAreaViewModel>>();
            _listarTotalizadorMaquinasImpactadasUseCase = serviceProvider.GetRequiredService<IUseCase<ListarChamadosFiltroViewModel, ListarTotalizadorMaquinasImpactadasViewModel>>();
            _currentClaimsPrincipal = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User;
        }

        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <param name="filtro">Filtro de dados</param>
        /// <returns>Lista de chamados</returns>
        public async Task<ListarChamadosResultViewModel> ListarChamados(ListarChamadosFiltroViewModel filtro)
        {
            filtro.UsuarioAtual = CurrentUser.UserName;
            filtro.EhColaborador = CurrentUser.Role == UserInfo.ROLE_COLABORADOR;
            filtro.Area = _currentClaimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role
                && c.Value != UserInfo.ROLE_ADMIN
                && c.Value != UserInfo.ROLE_COLABORADOR)?.FirstOrDefault()?.Value;
            var result = await _listarChamadosUseCase.Execute(filtro);
            return result;
        }

        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <param name="filtro">Filtro de dados</param>
        /// <returns>Lista de chamados</returns>
        public async Task<ListarChamadosDashboardPorAreaViewModel> ListarChamadosArea(ListarChamadosFiltroViewModel filtro)
        {
            filtro.UsuarioAtual = CurrentUser.UserName;
            filtro.EhColaborador = CurrentUser.Role == UserInfo.ROLE_COLABORADOR;
            var result = await _listarChamadosAreaUseCase.Execute(filtro);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<EvolutivoViewModel> ObterEvolutivo()
        {
            var result = await _evolutivoUseCase.Execute(new FiltroComumViewModel(CurrentUser));

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IncidentesPorAreaViewModel> ObterIncidentesPorArea()
        {
            var result = await _incidentesAreaViewModel.Execute(new FiltroComumViewModel(CurrentUser));

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IncidentesPorAreaStatusViewModel> ObterIncidentesPorAreaStatus()
        {
            var result = await _incidentesAreaStatusViewModel.Execute(new FiltroComumViewModel(CurrentUser));

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IncidentesPorAreaTipoViewModel> ObterIncidentesPorAreaTipo()
        {
            var result = await _incidentesAreaTipoViewModel.Execute(new FiltroComumViewModel(CurrentUser));

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<TotalizadorViewModel> ObterTotalizadores()
        {
            var result = await _totalizadoresUseCase.Execute(new FiltroComumViewModel(CurrentUser));

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Task<DashboardViewModel> ObterViewModel()
        {
            return Task.FromResult(new DashboardViewModel(CurrentUser));
        }

        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <param name="filtro">Filtro de dados</param>
        /// <returns>Lista de chamados</returns>
        public async Task<ListarTotalizadorMaquinasImpactadasViewModel> SomarMaquinasMaisImpactadas(ListarChamadosFiltroViewModel filtro)
        {
            filtro.UsuarioAtual = CurrentUser.UserName;
            filtro.EhColaborador = CurrentUser.Role == UserInfo.ROLE_COLABORADOR;
            var result = await _listarTotalizadorMaquinasImpactadasUseCase.Execute(filtro);

            return result;
        }
    }
}