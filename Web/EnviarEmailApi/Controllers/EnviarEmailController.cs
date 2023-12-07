using EnviarEmail.Application.Interfaces;
using EnviarEmail.Application.ViewModels.Enviar;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnviarEmailApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    //[AllowAnonymous]
    [Authorize]
    [ApiController]
    [Route("api/enviar")]
    public class EnviarEmailController : Controller
    {
        private readonly IEnviarAppService _enviarAppService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        public EnviarEmailController(IServiceProvider serviceProvider)
        {
            _enviarAppService = serviceProvider.GetRequiredService<IEnviarAppService>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public Task<IActionResult> Get()
        {
            var result = Ok($"Test request: {User.FindFirst("aud")?.Value}");

            return Task.FromResult<IActionResult>(result);
        }

        /// <summary>
        /// Evniar email via smtp
        /// </summary>
        /// <returns>Valor de retorno</returns>
        [HttpPost()]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(EnviarViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Post(EnviarViewModel dadosEntrada)
        {
            var result = await _enviarAppService.Enviar(dadosEntrada);

            return Ok(result);
        }
    }
}