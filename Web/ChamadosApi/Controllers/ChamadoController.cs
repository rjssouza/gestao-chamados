using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Formulario;
using Chamados.Application.ViewModels.Formulario.FormularioResposta;
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
    [Route("api/chamado")]
    public class ChamadoController : Controller
    {
        private readonly IChamadoServiceApp _chamadoServiceApp;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        public ChamadoController(IServiceProvider serviceProvider)
        {
            _chamadoServiceApp = serviceProvider.GetRequiredService<IChamadoServiceApp>();
        }

        /// <summary>
        /// Remover anexo do chamado
        /// </summary>
        /// <param name="idAnexo">Id do Anexo</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpDelete("anexo")]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        public async Task<IActionResult> DeleteAnexo(int idAnexo)
        {
            var result = await _chamadoServiceApp.RemoverAnexoChamado(idAnexo);

            return Ok(result);
        }

        /// <summary>
        /// Detalhe do chamado
        /// </summary>
        /// <param name="idChamado">Id do Chamado</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Get(int idChamado)
        {
            var result = await _chamadoServiceApp.DetalheChamado(new FiltroChamadoComumViewModel { IdChamado = idChamado });

            return Ok(result);
        }

        /// <summary>
        /// Anexo para baixar
        /// </summary>
        /// <param name="idAnexo">Anexo para baixar</param>
        /// <returns>Base 64 do Anexo</returns>
        [HttpGet("anexo"), DisableRequestSizeLimit]
        [Authorize(Roles = UserInfo.ROLE_COLABORADOR_AUTHORIZE)]
        public async Task<IActionResult> GetAnexoAsync(int idAnexo)
        {
            var anexo = await _chamadoServiceApp.BaixarAnexoChamado(new BaixarAnexoChamadoViewModel { IdAnexo = idAnexo });
            if (!string.IsNullOrEmpty(anexo?.Anexo?.Trim()))
            {
                var indexOf = 0;
                if (anexo.Anexo.IndexOf(";") > -1)
                    indexOf = anexo.Anexo.IndexOf(";") + 1;
                var base64 = anexo.Anexo[indexOf..];
                var array = Convert.FromBase64String(base64);

                MemoryStream stream = new();
                stream.Write(array, 0, array.Length);
                if (stream == null)
                    return NotFound();
                stream.Position = 0;
                return File(stream, Utils.GetContentType(anexo.NomeArquivo), $"{anexo.NomeArquivo}");
            }
            return NotFound();
        }

        /// <summary>
        /// Abre chamado a partir de um formulario de resposta
        /// </summary>
        /// <param name="formularioRespostaViewModel">Formulario de resposta</param>
        /// <returns>Id do chamado</returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(FormularioResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Post(FormularioRespostaViewModel formularioRespostaViewModel)
        {
            var result = await _chamadoServiceApp.AbrirChamado(formularioRespostaViewModel);

            return Ok(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="registrarProgressoChamadoViewModel"></param>
        /// <returns></returns>
        [HttpPost("progresso")]
        [ProducesResponseType(200, Type = typeof(RegistrarProgressoResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        public async Task<IActionResult> Post(RegistrarProgressoChamadoViewModel registrarProgressoChamadoViewModel)
        {
            var result = await _chamadoServiceApp.RegistrarProgresso(registrarProgressoChamadoViewModel);

            return Ok(result);
        }

        /// <summary>
        /// Adicionar anexo(s) ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Anexo para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpPost("anexo")]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        public async Task<IActionResult> PostAnexo(AdicionarAnexoChamadoViewModel modeloEntrada)
        {
            var result = await _chamadoServiceApp.AdicionarAnexoChamado(modeloEntrada);

            return Ok(result);
        }

        /// <summary>
        /// Atendente do chamado
        /// </summary>
        /// <param name="modeloEntrada">Atendente para o chamado</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpPost("atendente")]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        public async Task<IActionResult> PostAtendente(AtendenteChamadoViewModel modeloEntrada)
        {
            var result = await _chamadoServiceApp.AtendenteChamado(modeloEntrada);

            return Ok(result);
        }

        /// <summary>
        /// Adicionar comentário ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Comentário para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpPost("comentario")]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> PostComentario(AdicionarComentarioChamadoViewModel modeloEntrada)
        {
            var result = await _chamadoServiceApp.AdicionarComentarioChamado(modeloEntrada);

            return Ok(result);
        }

        /// <summary>
        /// Fechar chamado
        /// </summary>
        /// <param name="idChamado">Id do chamado</param>
        /// <param name="atendimento">Sobre o atendimento realizado</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpPost("fechar")]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        public async Task<IActionResult> PostFechar(int idChamado, string atendimento)
        {
            var result = await _chamadoServiceApp.FecharChamado(new FecharChamadoViewModel { IdChamado = idChamado, ComentarioFinal = atendimento });

            return Ok(result);
        }

        /// <summary>
        /// Iniciar atendimento do chamado
        /// </summary>
        /// <param name="idChamado">Id do chamado</param>
        /// <returns>Detalhe do chamado</returns>
        [HttpPost("iniciaratendimento")]
        [ProducesResponseType(200, Type = typeof(DetalheChamadosResultViewModel))]
        [ProducesResponseType(400, Type = typeof(JsonResult))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        [Authorize(Roles = UserInfo.ROLE_ADMIN)]
        public async Task<IActionResult> PostIniciarAtendimento(int idChamado)
        {
            var result = await _chamadoServiceApp.IniciarAtendimentoChamado(new IniciarAtendimentoChamadoViewModel { IdChamado = idChamado });

            return Ok(result);
        }
    }
}