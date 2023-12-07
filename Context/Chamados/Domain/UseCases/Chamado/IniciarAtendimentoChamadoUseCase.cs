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
    public class IniciarAtendimentoChamadoUseCase : UseCase<IniciarAtendimentoChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<IniciarAtendimentoChamadoViewModel, DetalheChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<ChamadoComentariosEntity> _comentarioRepository;
        private readonly UserInfo _currentUser;
        private readonly IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel> _detalheChamadoUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public IniciarAtendimentoChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _comentarioRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoComentariosEntity>>();
        }

        /// <summary>
        /// Iniciar atendimento do chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados chamado para iniciar atendimento</param>
        /// <returns>Detalhe do chamado</returns>
        protected override async Task<DetalheChamadosResultViewModel> ExecuteInternal(IniciarAtendimentoChamadoViewModel modeloEntrada)
        {
            var result = new DetalheChamadosResultViewModel();
            var chamado = _chamadoRepository.GetById(modeloEntrada.IdChamado);
            if (chamado != null)
            {
                var userName = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName;
                var comentario = new ChamadoComentariosEntity
                {
                    Comentario =
                        $"{(string.IsNullOrEmpty(modeloEntrada.ComentarioInicial?.ToString()) ? "Chamado com antendimento iniciado" : modeloEntrada.ComentarioInicial)}{Environment.NewLine}Responsável por iniciar o chamado: {userName}",
                    IdChamado = chamado.Id,
                    DtReg = DateTime.Now,
                    UsComentario = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName
                };
                _comentarioRepository.Insert(comentario);
                chamado.DtAtendimento = DateTime.Now;
                chamado.DtFechamento = null;
                _chamadoRepository.Update(chamado);
                result = await _detalheChamadoUseCase.Execute(new FiltroChamadoComumViewModel { IdChamado = chamado.Id });
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(IniciarAtendimentoChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdChamado <= 0)
                AddError("FecharChamadoUseCase", "Chamado para iniciar atendimento inválido");
            IsValid();
        }
    }
}