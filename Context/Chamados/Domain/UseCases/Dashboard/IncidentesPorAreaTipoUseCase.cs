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
    public class IncidentesPorAreaTipoUseCase : DashboardUseCase<IncidentesPorAreaTipoViewModel>, IUseCase<FiltroComumViewModel, IncidentesPorAreaTipoViewModel>
    {
        private readonly IEntityRepository<VwChamadoAreaTipoEntity> _vwChamadoAreaTipoRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public IncidentesPorAreaTipoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _vwChamadoAreaTipoRepository = serviceProvider.GetRequiredService<IEntityRepository<VwChamadoAreaTipoEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chamados"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<IncidentesPorAreaTipoViewModel> ProcessarChamados(IEnumerable<ChamadoEntity> chamados, FiltroComumViewModel entry)
        {
            var tipos = _vwChamadoAreaTipoRepository.GetAll().Select(x => new ChamadosPorAreaTipo
            {
                Id = x.Id,
                Area = x.Area,
                ChamadoTipo = x.ChamadoTipo,
                Total = x.Total
            }).ToList();

            var incidentes = new IncidentesPorAreaTipoViewModel(tipos);

            return Task.FromResult(incidentes);
        }
    }
}