using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Incidentes;
using Chamados.Domain.Entity;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Dashboard
{
    /// <summary>
    ///
    /// </summary>
    public class IncidentesPorAreaStatusUseCase : DashboardUseCase<IncidentesPorAreaStatusViewModel>, IUseCase<FiltroComumViewModel, IncidentesPorAreaStatusViewModel>
    {
        private readonly IEntityRepository<VwChamadoAreaStatusEntity> _vwChamadoAreaStatusRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public IncidentesPorAreaStatusUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _vwChamadoAreaStatusRepository = serviceProvider.GetRequiredService<IEntityRepository<VwChamadoAreaStatusEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chamados"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<IncidentesPorAreaStatusViewModel> ProcessarChamados(IEnumerable<ChamadoEntity> chamados, FiltroComumViewModel entry)
        {
            var situacoes = _vwChamadoAreaStatusRepository.GetAll().Select(x => new ChamadosPorAreaStatus
            {
                Id = x.Id,
                Area = x.Area,
                Situacao = x.Situacao,
                Total = x.Total
            }).ToList();

            var incidentes = new IncidentesPorAreaStatusViewModel(situacoes);

            return Task.FromResult(incidentes);
        }
    }
}