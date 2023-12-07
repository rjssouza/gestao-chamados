using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Chamados.Domain.Enum;
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
    public class ComentarioChamadoUseCase : UseCase<AdicionarComentarioChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<AdicionarComentarioChamadoViewModel, DetalheChamadosResultViewModel>
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
        public ComentarioChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _comentarioRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoComentariosEntity>>();
        }

        /// <summary>
        /// Adicionar comentário ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Comentário para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        protected override async Task<DetalheChamadosResultViewModel> ExecuteInternal(AdicionarComentarioChamadoViewModel modeloEntrada)
        {
            var result = new DetalheChamadosResultViewModel();
            var chamado = _chamadoRepository.GetById(modeloEntrada.IdChamado);
            if (chamado != null)
            {
                var comentario = new ChamadoComentariosEntity
                {
                    Comentario = modeloEntrada.Comentario,
                    IdChamado = chamado.Id,
                    DtReg = DateTime.Now,
                    UsComentario = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName
                };
                _comentarioRepository.Insert(comentario);
                result = await _detalheChamadoUseCase.Execute(new FiltroChamadoComumViewModel { IdChamado = chamado.Id });
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(AdicionarComentarioChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdChamado <= 0)
                AddError("ComentarioChamadoUseCase", "Chamado para associação inválido");
            if (string.IsNullOrEmpty(modeloEntrada.Comentario) || string.IsNullOrWhiteSpace(modeloEntrada.Comentario))
                AddError("ComentarioChamadoUseCase", "Comentário vazio");
            IsValid();

            var chamado = _chamadoRepository.GetById(modeloEntrada.IdChamado);
            if (chamado.Status == StatusChamadoEnum.Finalizado)
                AddError("ComentarioChamadoUseCase", "Este chamado já está fechado, portanto não pode receber mais comentários");

            IsValid();
        }
    }
}