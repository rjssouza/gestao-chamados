using Auth.Application.Interfaces;
using Core.Utils.Extension;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IdentityServer.Quickstart.Account
{
    [ApiController]
    [Route("auth/api/photo")]
    public class UserPhotoController : ControllerBase
    {
        private readonly IUserPhotoAppService _userPhotoAppService;

        public UserPhotoController(IUserPhotoAppService userPhotoAppService)
        {
            _userPhotoAppService = userPhotoAppService;
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(200, Type = typeof(byte[]))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Get(string userName)
        {
            var photo = await _userPhotoAppService.ObterFotoUsuario(userName);

            return File(photo, photo.ObterMimeType());
        }
    }
}