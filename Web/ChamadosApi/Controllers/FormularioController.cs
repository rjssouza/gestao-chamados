using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Formulario;
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
    [Route("api/formulario")]
    public class FormularioController : Controller
    {
        private readonly IFormularioServiceApp _formularioServiceApp;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        public FormularioController(IServiceProvider serviceProvider)
        {
            _formularioServiceApp = serviceProvider.GetRequiredService<IFormularioServiceApp>();
        }

        /// <summary>
        /// Obtem formulario para montar a interface angular
        /// </summary>
        /// <param name="idArea">Identificador da área (default 1)</param>
        /// <returns>Objeto de formulario</returns>
        /// [AllowAnonymous]
        [HttpGet("{idArea}")]
        [ProducesResponseType(200, Type = typeof(FormularioResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Get(int idArea)
        {
            var result = await _formularioServiceApp.ObterFormularioViewModel(new FormularioRequestViewModel(idArea));

            return Ok(result);
        }
    }
}