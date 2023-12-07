using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChamadosApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    [Route("api/env")]
    [AllowAnonymous]
    public class EnvController : Controller
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        ///
        /// </summary>
        /// <param name="configuration"></param>
        public EnvController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public IActionResult Get()
        {
            return Ok(_configuration.GetSection("Env")?.Value?.ToString());
        }
    }
}