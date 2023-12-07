using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class FecharChamadoUseCase : UseCase<FecharChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<FecharChamadoViewModel, DetalheChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<ChamadoComentariosEntity> _comentarioRepository;
        private readonly UserInfo _currentUser;
        private readonly IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel> _detalheChamadoUseCase;
        private readonly IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel> _notificarUseCase;
        private readonly IUseCase<RegistrarProgressoChamadoViewModel, RegistrarProgressoResultViewModel> _registrarProgressoUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public FecharChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _notificarUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel>>();
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _comentarioRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoComentariosEntity>>();
            _registrarProgressoUseCase = serviceProvider.GetRequiredService<IUseCase<RegistrarProgressoChamadoViewModel,RegistrarProgressoResultViewModel>>();
        }

        /// <summary>
        /// Fechar chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados fechamento chamado</param>
        /// <returns>Detalhe do chamado</returns>
        protected override async Task<DetalheChamadosResultViewModel> ExecuteInternal(FecharChamadoViewModel modeloEntrada)
        {
            var result = new DetalheChamadosResultViewModel();
            var chamado = _chamadoRepository.GetById(modeloEntrada.IdChamado);
            if (chamado != null)
            {
                var userName = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName;
                var comentario = new ChamadoComentariosEntity
                {
                    Comentario =
                        $"Chamado Fechado{Environment.NewLine}Responsável por fechar o chamado: {userName}",
                    IdChamado = chamado.Id,
                    DtReg = DateTime.Now,
                    UsComentario = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName
                };
               
               // fechar o chamado com 100% de atendimento
                var percentual = new RegistrarProgressoChamadoViewModel
                {
                Comentario = $"Atendimento alterado para 100% pelo fechamento",
                IdChamado = chamado.Id,
                Percentual = 100
                };
                var resultPercentual = await _registrarProgressoUseCase.Execute(percentual);

                _comentarioRepository.Insert(comentario);
                chamado.DtFechamento = DateTime.Now;
                chamado.Atendimento = modeloEntrada.ComentarioFinal;

                if (!chamado.DtAtendimento.HasValue)
                    chamado.DtAtendimento = chamado.DtRecebimento.HasValue ? chamado.DtRecebimento : chamado.DtReg;
                _chamadoRepository.Update(chamado);

                await _notificarUseCase.Execute(new FiltroNotifcarViewModel
                {
                    EmailChamadoEnviado = false,
                    EmailChamadoEnviadoParaGrupo = false,
                    EmailChamadoRecebido = false,
                    EmailChamadoRecebidoParaGrupo = false,
                    EmailChamadoEncerrado = true,
                    EmailChamadoEncerradoParaGrupo = true,
                    IdChamado = chamado.Id
                });

                result = await _detalheChamadoUseCase.Execute(new FiltroChamadoComumViewModel { IdChamado = chamado.Id });
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(FecharChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdChamado <= 0)
                AddError("FecharChamadoUseCase", "Chamado para finalizar/fechar inválido");
            IsValid();
        }
    }
}