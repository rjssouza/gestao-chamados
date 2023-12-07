using Chamados.Application.ViewModels;
using Chamados.Application.ViewModels.DashboardArea;
using Chamados.Application.ViewModels.Listar;
using Chamados.Domain.Entity;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace Chamados.Domain.UseCases.DashboardArea
{
    /// <summary>
    /// Totalizador Maquinas
    /// </summary>
    public class TotalizadorMaquinasImpactadasUseCase : UseCase<ListarChamadosFiltroViewModel, ListarTotalizadorMaquinasImpactadasViewModel>,
    IUseCase<ListarChamadosFiltroViewModel, ListarTotalizadorMaquinasImpactadasViewModel>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<LinhaEntity> _linhaRepository;
        private readonly IEntityRepository<MaquinaEntity> _maquinaRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        public TotalizadorMaquinasImpactadasUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _maquinaRepository = serviceProvider.GetRequiredService<IEntityRepository<MaquinaEntity>>();
            _linhaRepository = serviceProvider.GetRequiredService<IEntityRepository<LinhaEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        protected override Task<ListarTotalizadorMaquinasImpactadasViewModel> ExecuteInternal(ListarChamadosFiltroViewModel filtro)
        {
            var result = new List<TotalizadorMaquinasImpactadasViewModel>();
            var resultChamados = _chamadoRepository.GetAll();
            resultChamados

                ?.OrderByDescending(t => t.DtRecebimento)
                ?.ToList()
                ?.ForEach(item =>
                {
                    var maquinasViewModel = ObterMaquinas();
                    var linhasViewModel = ObterLinhas();

                    var chamadosPorMaquina = new TotalizadorMaquinasImpactadasViewModel
                    {
                        Area = linhasViewModel?.Where(t => t.Id == maquinasViewModel?.Where(t => t.Id == item.IdNorisMaquina)?.FirstOrDefault()?.Liniennummer)?.FirstOrDefault()?.Bezeichnung,
                        NomeMaquina = maquinasViewModel?.Where(t => t.Id == item.IdNorisMaquina)?.FirstOrDefault()?.Bezeichnung,
                        QuantidadeChamados = resultChamados?.Where(t => t.IdNorisMaquina == item.IdNorisMaquina)?.Count(),
                    };
                    result.Add(chamadosPorMaquina);
                });

            return Task.FromResult(new ListarTotalizadorMaquinasImpactadasViewModel
            {
                TotalizadorMaquinasImpactadas = result.GroupBy(t => new
                {
                    t.Area,
                    t.NomeMaquina,
                    t.QuantidadeChamados,
                })
                .Where(t => t.Key.Area != null)
                .Select(t => new TotalizadorMaquinasImpactadasViewModel
                {
                    Area = t.Key.Area,
                    NomeMaquina = t.Key.NomeMaquina,
                    QuantidadeChamados = t.Key.QuantidadeChamados,
                }).OrderByDescending(t => t.QuantidadeChamados).ToList()
            });
        }

        private IEnumerable<LinhaViewModel>? ObterLinhas()
        {
            List<LinhaViewModel> linhasViewModel = new();
            var linhas = _linhaRepository.GetAll();
            linhas?.ToList().ForEach(item =>
            {
                linhasViewModel.Add(new LinhaViewModel
                {
                    Id = item.Id,

                    Bezeichnung = item.Bezeichnung,
                });
            });
            return linhasViewModel;
        }

        private IEnumerable<MaquinaViewModel>? ObterMaquinas()
        {
            List<MaquinaViewModel> maquinasViewModel = new();
            var maquinas = _maquinaRepository.GetAll();
            maquinas?.ToList().ForEach(item =>
            {
                maquinasViewModel.Add(new MaquinaViewModel
                {
                    Id = item.Id,
                    Bezeichnung = item.Bezeichnung,
                    Liniennummer = item.Liniennummer,
                });
            });
            return maquinasViewModel;
        }
    }
}