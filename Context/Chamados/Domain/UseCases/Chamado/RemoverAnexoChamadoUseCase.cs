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
    public class RemoverAnexoChamadoUseCase : UseCase<RemoverAnexoChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<RemoverAnexoChamadoViewModel, DetalheChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoAnexoEntity> _chamadoAnexoRepository;
        private readonly IEntityRepository<ChamadoComentariosEntity> _comentarioRepository;
        private readonly UserInfo _currentUser;
        private readonly IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel> _detalheChamadoUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public RemoverAnexoChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _detalheChamadoUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>>();
            _chamadoAnexoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoAnexoEntity>>();
            _comentarioRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoComentariosEntity>>();
        }

        /// <summary>
        /// Remover anexo(s) ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Anexo para remoção</param>
        /// <returns>Detalhe do chamado</returns>
        protected override async Task<DetalheChamadosResultViewModel> ExecuteInternal(RemoverAnexoChamadoViewModel modeloEntrada)
        {
            var result = new DetalheChamadosResultViewModel();
            var anexo = _chamadoAnexoRepository.GetById(modeloEntrada.IdAnexo);
            if (anexo != null)
            {
                _chamadoAnexoRepository.Delete(anexo);
                var userName = !string.IsNullOrEmpty(_currentUser.Name?.ToString()) ? _currentUser.Name : _currentUser.UserName;
                var comentario = new ChamadoComentariosEntity
                {
                    Comentario = $"Arquivo removido:{Environment.NewLine}-> {anexo.NomeArquivo}",
                    IdChamado = anexo.IdChamado,
                    DtReg = DateTime.Now,
                    UsComentario = userName
                };
                _comentarioRepository.Insert(comentario);
                result = await _detalheChamadoUseCase.Execute(new FiltroChamadoComumViewModel { IdChamado = anexo.IdChamado });
            }
            return await Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(RemoverAnexoChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdAnexo <= 0)
                AddError("RemoverAnexoChamadoUseCase", "Nenhum anexo informado");
            var anexo = _chamadoAnexoRepository.GetById(modeloEntrada.IdAnexo);
            if (anexo == null)
                AddError("RemoverAnexoChamadoUseCase", "O arquivo não existe no chamado");
            IsValid();
        }
    }
}