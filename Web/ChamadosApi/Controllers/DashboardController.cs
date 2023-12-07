using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Evolutivo;
using Chamados.Application.ViewModels.Dashboard.Incidentes;
using Chamados.Application.ViewModels.Dashboard.Totalizadores;
using Chamados.Application.ViewModels.Listar;
using Core.Application.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Authorize(Roles = UserInfo.ROLE_COLABORADOR_AUTHORIZE)]
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : Controller
    {
        private readonly IDashboardAppService _dashboardAppService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        public DashboardController(IServiceProvider serviceProvider)
        {
            _dashboardAppService = serviceProvider.GetRequiredService<IDashboardAppService>();
        }

        /// <summary>
        /// Obter view model da tela de dashboard
        /// </summary>
        /// <returns>Dashboard</returns>
        [HttpGet()]
        [Authorize(Roles = UserInfo.ROLE_COLABORADOR_AUTHORIZE)]
        [ProducesResponseType(200, Type = typeof(DashboardViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Get()
        {
            var result = await _dashboardAppService.ObterViewModel();

            return Ok(result);
        }

        /// <summary>
        /// Listar chamados por usuario, ou administrador
        /// </summary>
        /// <param name="skip">Pagina atual</param>
        /// <param name="take">Itens por pagina</param>
        /// <returns>Lista de chamados</returns>
        [HttpGet("chamados/{skip}/{take}")]
        [ProducesResponseType(200, Type = typeof(ListarChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ListarChamados(int skip, int take)
        {
            var result = await _dashboardAppService.ListarChamados(new ListarChamadosFiltroViewModel { Skip = skip < 0 ? 0 : skip, Take = take <= 0 ? 5 : take });

            return Ok(result);
        }

        /// <summary>
        /// Obter evolutivo mensal
        /// </summary>
        /// <returns>Evolutivo mensal</returns>
        [HttpGet("evolutivo")]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        [ProducesResponseType(200, Type = typeof(EvolutivoViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ObterEvolutivo()
        {
            var result = await _dashboardAppService.ObterEvolutivo();

            return Ok(result);
        }

        /// <summary>
        /// Obter contador de incidentes por area
        /// </summary>
        /// <returns>Incidentes por area</returns>
        [HttpGet("incidentes")]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        [ProducesResponseType(200, Type = typeof(IncidentesPorAreaViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ObterIncidentesPorArea()
        {
            var result = await _dashboardAppService.ObterIncidentesPorArea();

            return Ok(result);
        }

        /// <summary>
        /// Obter contador de incidentes por area status
        /// </summary>
        /// <returns>Incidentes por area status</returns>
        [HttpGet("incidentesPorAreaStatus")]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        [ProducesResponseType(200, Type = typeof(IncidentesPorAreaStatusViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ObterIncidentesPorAreaStatus()
        {
            var result = await _dashboardAppService.ObterIncidentesPorAreaStatus();

            return Ok(result);
        }

        /// <summary>
        /// Obter contador de incidentes por area status
        /// </summary>
        /// <returns>Incidentes por area status</returns>
        [HttpGet("incidentesPorAreaTipo")]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        [ProducesResponseType(200, Type = typeof(IncidentesPorAreaTipoViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ObterIncidentesPorAreaTipo()
        {
            var result = await _dashboardAppService.ObterIncidentesPorAreaTipo();

            return Ok(result);
        }

        /// <summary>
        /// Obter totalizadores de chamados
        /// </summary>
        /// <returns>Lista de totalizadores</returns>
        [HttpGet("totalizadores")]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        [ProducesResponseType(200, Type = typeof(TotalizadorViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ObterTotalizadores()
        {
            var result = await _dashboardAppService.ObterTotalizadores();

            return Ok(result);
        }
    }
}