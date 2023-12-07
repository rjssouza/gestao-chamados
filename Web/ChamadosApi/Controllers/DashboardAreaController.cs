using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Dashboard.Incidentes;
using Chamados.Application.ViewModels.DashboardArea;
using Chamados.Application.ViewModels.Listar;
using Core.Application.Seguranca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosApi.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as ações do dashboard
    /// </summary>
    [Authorize(Roles = UserInfo.ROLE_COLABORADOR_AUTHORIZE)]
    [ApiController]
    [Route("chamados-area")]
    public class DashboardAreaController : Controller
    {
        private readonly IDashboardAppService _dashboardAppService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        public DashboardAreaController(IServiceProvider serviceProvider)
        {
            _dashboardAppService = serviceProvider.GetRequiredService<IDashboardAppService>();
        }

        /// <summary>
        /// Listar chamados
        /// </summary>
        /// <returns>Lista de chamados</returns>
        [HttpGet()]
        [Authorize(Roles = UserInfo.ROLE_COLABORADOR_AUTHORIZE)]
        [ProducesResponseType(200, Type = typeof(ListarChamadosDashboardPorAreaViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ListarChamados()
        {
            var result = await _dashboardAppService.ListarChamadosArea(new ListarChamadosFiltroViewModel());

            return Ok(result);
        }

        /// <summary>
        /// Totalizador Maquinas
        /// </summary>
        /// <returns>Lista de chamados</returns>
        [HttpGet("totalMaquinasImpactadas")]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        [ProducesResponseType(200, Type = typeof(ListarTotalizadorMaquinasImpactadasViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> ListarChamadosTotalMaquinasImpactadas()
        {
            var result = await _dashboardAppService.SomarMaquinasMaisImpactadas(new ListarChamadosFiltroViewModel());

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
    }
}