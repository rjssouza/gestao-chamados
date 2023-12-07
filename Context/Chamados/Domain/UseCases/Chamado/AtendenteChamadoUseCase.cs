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
    public class AtendenteChamadoUseCase : UseCase<AtendenteChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<AtendenteChamadoViewModel, DetalheChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly UserInfo _currentUser;
        private readonly IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel> _detalheChamadoUseCase;
        private readonly IEntityRepository<ChamadoHistoricoEntity> _historicoRepository;
        private readonly IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel> _notificarUseCase;
        private readonly IEntityRepository<ChamadoTimeEntity> _timeRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public AtendenteChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _notificarUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel>>();
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _timeRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoTimeEntity>>();
            _historicoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoHistoricoEntity>>();
        }

        /// <summary>
        /// Modificar atendente do chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados do atendente</param>
        /// <returns>Detalhe do chamado</returns>
        protected override async Task<DetalheChamadosResultViewModel> ExecuteInternal(AtendenteChamadoViewModel modeloEntrada)
        {
            var result = new DetalheChamadosResultViewModel();
            var chamado = _chamadoRepository.GetById(modeloEntrada.IdChamado);
            if (chamado != null)
            {
                var timeAnterior = chamado.IdChamadoTime.HasValue
                    ? _timeRepository.GetById(chamado.IdChamadoTime.Value)
                    : null;
                if (string.IsNullOrEmpty(modeloEntrada.TipoAtendente) || modeloEntrada.TipoAtendente == "Time")
                {
                    _ = int.TryParse(modeloEntrada.IdUsusario, out int idUsuario);
                    var time = _timeRepository
                        .GetAll(t => (t.UsReg == idUsuario && idUsuario > 0) ||
                        t.Responsavel?.ToUpper() == modeloEntrada.UsPrimeiroCombate?.ToUpper() ||
                        t.Email?.ToUpper() == modeloEntrada.UsPrimeiroCombate?.ToUpper())
                        ?.ToList()
                        ?.FirstOrDefault();
                    if (time != null)
                    {
                        if (time.Id != chamado.IdChamadoTime)
                        {
                            var historico = new ChamadoHistoricoEntity
                            {
                                De = timeAnterior?.Responsavel,
                                Para = time.Responsavel,
                                DtReg = DateTime.Now,
                                IdChamado = chamado.Id,
                                UsHistorico = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName
                            };

                            chamado.IdChamadoTime = time.Id;
                            _chamadoRepository.Update(chamado);
                            _historicoRepository.Insert(historico);

                            await _notificarUseCase.Execute(new FiltroNotifcarViewModel
                            {
                                EmailChamadoEnviado = false,
                                EmailChamadoEnviadoParaGrupo = false,
                                EmailChamadoRecebido = true,
                                EmailChamadoRecebidoParaGrupo = true,
                                IdChamado = chamado.Id
                            });
                        }
                        result = await _detalheChamadoUseCase.Execute(new FiltroChamadoComumViewModel { IdChamado = chamado.Id });
                    }
                }
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(AtendenteChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdChamado <= 0)
                AddError("AtendenteChamadoUseCase", "Chamado para associação inválido");
            if (string.IsNullOrEmpty(modeloEntrada.IdUsusario) && string.IsNullOrWhiteSpace(modeloEntrada.IdUsusario) &&
                string.IsNullOrEmpty(modeloEntrada.UsPrimeiroCombate) && string.IsNullOrWhiteSpace(modeloEntrada.UsPrimeiroCombate))
                AddError("AtendenteChamadoUseCase", "Id ou Nome do usuário atendente inválido");
            IsValid();
        }
    }
}