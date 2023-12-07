using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Formulario.FormularioResposta;
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
    public class ChamadoServiceApp : ServiceApp, IChamadoServiceApp
    {
        private readonly IUseCase<AbrirChamadoViewModel, AbrirChamadoResultViewModel> _abrirChamadoUseCase;
        private readonly IUseCase<AdicionarAnexoChamadoViewModel, DetalheChamadosResultViewModel> _adicionarAnexoUseCase;
        private readonly IUseCase<AtendenteChamadoViewModel, DetalheChamadosResultViewModel> _adicionarAtendenteUseCase;
        private readonly IUseCase<AdicionarComentarioChamadoViewModel, DetalheChamadosResultViewModel> _adicionarComentarioUseCase;
        private readonly string? _area;
        private readonly IUseCase<BaixarAnexoChamadoViewModel, BaixarAnexoChamadoViewModel> _baixarAnexoUseCase;
        private readonly ClaimsPrincipal _currentClaimsPrincipal;
        private readonly IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel> _detalheChamadoUseCase;
        private readonly IUseCase<FecharChamadoViewModel, DetalheChamadosResultViewModel> _fecharChamadoUseCase;
        private readonly IUseCase<IniciarAtendimentoChamadoViewModel, DetalheChamadosResultViewModel> _iniciarAtendimentoChamadoUseCase;
        private readonly IUseCase<ChamadoViewModel, DetalheChamadosResultViewModel> _receberChamadoAtendimentoUseCase;
        private readonly IUseCase<RegistrarProgressoChamadoViewModel, RegistrarProgressoResultViewModel> _registrarProgressoUseCase;
        private readonly IUseCase<RemoverAnexoChamadoViewModel, DetalheChamadosResultViewModel> _removerAnexoUseCase;
        private readonly IUseCase<FormularioRespostaViewModel, SalvarFormularioResultViewModel> _salvarFormularioUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public ChamadoServiceApp(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _salvarFormularioUseCase = serviceProvider.GetRequiredService<IUseCase<FormularioRespostaViewModel, SalvarFormularioResultViewModel>>();
            _abrirChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<AbrirChamadoViewModel, AbrirChamadoResultViewModel>>();
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _receberChamadoAtendimentoUseCase = serviceProvider.GetRequiredService<IUseCase<ChamadoViewModel, DetalheChamadosResultViewModel>>();
            _adicionarComentarioUseCase = serviceProvider.GetRequiredService<IUseCase<AdicionarComentarioChamadoViewModel, DetalheChamadosResultViewModel>>();
            _adicionarAtendenteUseCase = serviceProvider.GetRequiredService<IUseCase<AtendenteChamadoViewModel, DetalheChamadosResultViewModel>>();
            _adicionarAnexoUseCase = serviceProvider.GetRequiredService<IUseCase<AdicionarAnexoChamadoViewModel, DetalheChamadosResultViewModel>>();
            _removerAnexoUseCase = serviceProvider.GetRequiredService<IUseCase<RemoverAnexoChamadoViewModel, DetalheChamadosResultViewModel>>();
            _baixarAnexoUseCase = serviceProvider.GetRequiredService<IUseCase<BaixarAnexoChamadoViewModel, BaixarAnexoChamadoViewModel>>();
            _iniciarAtendimentoChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<IniciarAtendimentoChamadoViewModel, DetalheChamadosResultViewModel>>();
            _fecharChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FecharChamadoViewModel, DetalheChamadosResultViewModel>>();
            _registrarProgressoUseCase = serviceProvider.GetRequiredService<IUseCase<RegistrarProgressoChamadoViewModel, RegistrarProgressoResultViewModel>>();
            _currentClaimsPrincipal = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User;
            _area = _currentClaimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role
                && c.Value != UserInfo.ROLE_ADMIN
                && c.Value != UserInfo.ROLE_COLABORADOR)?.FirstOrDefault()?.Value;
        }

        /// <summary>
        /// Abertura de chamados a partir do form de respostas
        /// </summary>
        /// <param name="formularioRespostaViewModel">Form de respostas</param>
        /// <returns>Chamado id</returns>
        public async Task<int> AbrirChamado(FormularioRespostaViewModel formularioRespostaViewModel)
        {
            formularioRespostaViewModel.UsSolicitante = CurrentUser.UserName;
            formularioRespostaViewModel.UsSolicitanteNomeCompleto = $"{CurrentUser.Name} {CurrentUser.Surname}";
            formularioRespostaViewModel.UsEmailSolicitante = CurrentUser.Email;

            var formularioResult = await _salvarFormularioUseCase.Execute(formularioRespostaViewModel);
            var chamadoResult = await _abrirChamadoUseCase.Execute(new AbrirChamadoViewModel()
            {
                FormularioRespostaResult = formularioResult,
                FormularioRespostaRequest = formularioRespostaViewModel
            });

            return chamadoResult.IdChamado;
        }

        /// <summary>
        /// Adicionar anexo(s) ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Anexo para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> AdicionarAnexoChamado(AdicionarAnexoChamadoViewModel modeloEntrada)
        {
            return await _adicionarAnexoUseCase.Execute(modeloEntrada);
        }

        /// <summary>
        /// Adicionar comentário ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Comentário para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> AdicionarComentarioChamado(AdicionarComentarioChamadoViewModel modeloEntrada)
        {
            return await _adicionarComentarioUseCase.Execute(modeloEntrada);
        }

        /// <summary>
        /// Atendente do chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados do atendente</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> AtendenteChamado(AtendenteChamadoViewModel modeloEntrada)
        {
            return await _adicionarAtendenteUseCase.Execute(modeloEntrada);
        }

        /// <summary>
        /// Anexo para baixar
        /// </summary>
        /// <param name="modeloEntrada">Anexo para baixar</param>
        /// <returns>Base 64 do Anexo</returns>
        public async Task<BaixarAnexoChamadoViewModel> BaixarAnexoChamado(BaixarAnexoChamadoViewModel modeloEntrada)
        {
            return await _baixarAnexoUseCase.Execute(modeloEntrada);
        }

        /// <summary>
        /// Detalhe do Chamado
        /// </summary>
        /// <param name="filtroChamado">filtro para buscar o chamado</param>
        /// <returns>Detalhe do Chamado</returns>
        public async Task<DetalheChamadosResultViewModel> DetalheChamado(FiltroChamadoComumViewModel filtroChamado)
        {
            filtroChamado.UsuarioAtual = CurrentUser.UserName;
            filtroChamado.EhColaborador = CurrentUser.Role == UserInfo.ROLE_COLABORADOR;
            filtroChamado.Area = _area;
            return await _detalheChamadoUseCase.Execute(filtroChamado);
        }

        /// <summary>
        /// Fechar chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados fechamento chamado</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> FecharChamado(FecharChamadoViewModel modeloEntrada)
        {
            return await _fecharChamadoUseCase.Execute(modeloEntrada);
        }

        /// <summary>
        /// Iniciar atendimento do chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados chamado para iniciar atendimento</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> IniciarAtendimentoChamado(IniciarAtendimentoChamadoViewModel modeloEntrada)
        {
            await RegistrarProgresso(new RegistrarProgressoChamadoViewModel()
            {
                Comentario = "Início atendimento",
                IdChamado = modeloEntrada.IdChamado,
                Percentual = 1
            });
            return await _iniciarAtendimentoChamadoUseCase.Execute(modeloEntrada);
        }

        /// <summary>
        /// Registrar progresso de atendimento do chamado com comentários
        /// </summary>
        /// <param name="registrarProgressoChamadoViewModel">Registar progresso view model</param>
        /// <returns>Resultado registro de progresso</returns>
        public async Task<RegistrarProgressoResultViewModel> RegistrarProgresso(RegistrarProgressoChamadoViewModel registrarProgressoChamadoViewModel)
        {
            var result = await _registrarProgressoUseCase.Execute(registrarProgressoChamadoViewModel);

            return result;
        }

        /// <summary>
        /// Remover anexo do chamado
        /// </summary>
        /// <param name="idAnexo">Id do Anexo</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> RemoverAnexoChamado(int idAnexo)
        {
            return await _removerAnexoUseCase.Execute(new RemoverAnexoChamadoViewModel { IdAnexo = idAnexo });
        }

        /// <summary>
        /// Salvar edição do chamado
        /// </summary>
        /// <param name="chamado">Dados do Chamado</param>
        /// <returns>Detalhe do chamado</returns>
        public async Task<DetalheChamadosResultViewModel> SalvarEdicaoChamado(ChamadoViewModel chamado)
        {
            return await _receberChamadoAtendimentoUseCase.Execute(chamado);
        }
    }
}