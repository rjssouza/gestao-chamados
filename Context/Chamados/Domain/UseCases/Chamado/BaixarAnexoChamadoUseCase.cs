using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class BaixarAnexoChamadoUseCase : UseCase<BaixarAnexoChamadoViewModel, BaixarAnexoChamadoViewModel>
        , IUseCase<BaixarAnexoChamadoViewModel, BaixarAnexoChamadoViewModel>
    {
        private readonly IEntityRepository<ChamadoAnexoEntity> _chamadoAnexoRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public BaixarAnexoChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chamadoAnexoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoAnexoEntity>>();
        }

        /// <summary>
        /// Anexo para baixar
        /// </summary>
        /// <param name="modeloEntrada">Anexo para baixar</param>
        /// <returns>Base 64 do Anexo</returns>
        protected override async Task<BaixarAnexoChamadoViewModel> ExecuteInternal(BaixarAnexoChamadoViewModel modeloEntrada)
        {
            var anexo = _chamadoAnexoRepository.GetById(modeloEntrada.IdAnexo);
            modeloEntrada.Anexo = anexo.Anexo;
            modeloEntrada.NomeArquivo = anexo.NomeArquivo;
            return await Task.FromResult(modeloEntrada);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modeloEntrada"></param>
        protected override void ValidateEntry(BaixarAnexoChamadoViewModel modeloEntrada)
        {
            base.ValidateEntry(modeloEntrada);
            if (modeloEntrada.IdAnexo <= 0)
                AddError("BaixarAnexoChamadoUseCase", "Nenhum anexo informado");
            var anexo = _chamadoAnexoRepository.GetById(modeloEntrada.IdAnexo);
            if (anexo == null)
                AddError("BaixarAnexoChamadoUseCase", "O arquivo não existe no chamado");
            IsValid();
        }
    }
}