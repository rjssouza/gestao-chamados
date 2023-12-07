using Chamados.Application.ViewModels.Chamado;
using Core.Application.UseCases;
using Core.Domain.Interfaces;

namespace Chamados.Domain.UseCases.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class ReceberChamadoAtendimentoUseCase : UseCase<ChamadoViewModel, DetalheChamadosResultViewModel>
        , IUseCase<ChamadoViewModel, DetalheChamadosResultViewModel>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public ReceberChamadoAtendimentoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        /// <summary>
        /// Salvar edição do chamado
        /// </summary>
        /// <param name="chamado">Dados do Chamado</param>
        /// <returns>Detalhe do chamado</returns>
        protected override Task<DetalheChamadosResultViewModel> ExecuteInternal(ChamadoViewModel chamado)
        {
            var result = new List<ChamadoViewModel>();
            return Task.FromResult(new DetalheChamadosResultViewModel { Result = result });
        }
    }
}