using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Incidentes;
using Chamados.Domain.Entity;
using Core.Application.Seguranca;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;
using System.Security.Claims;

namespace Chamados.Domain.UseCases.Dashboard
{
    /// <summary>
    ///
    /// </summary>
    public class IncidentesPorAreaUseCase : DashboardUseCase<IncidentesPorAreaViewModel>, IUseCase<FiltroComumViewModel, IncidentesPorAreaViewModel>
    {
        private readonly ClaimsPrincipal _currentClaimsPrincipal;
        private readonly IEntityRepository<LinhaEntity> _linhaRepository;
        private readonly IEntityRepository<MaquinaEntity> _maquinaRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        public IncidentesPorAreaUseCase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _maquinaRepository = serviceProvider.GetRequiredService<IEntityRepository<MaquinaEntity>>();
            _linhaRepository = serviceProvider.GetRequiredService<IEntityRepository<LinhaEntity>>();
            _currentClaimsPrincipal = serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chamados"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<IncidentesPorAreaViewModel> ProcessarChamados(IEnumerable<ChamadoEntity> chamados, FiltroComumViewModel entry)
        {
            entry.Area = _currentClaimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role
               && c.Value != UserInfo.ROLE_ADMIN
               && c.Value != UserInfo.ROLE_COLABORADOR)?.FirstOrDefault()?.Value;

            if (!string.IsNullOrEmpty(entry.Area))
                chamados = (from c in chamados
                            join m in _maquinaRepository.GetAll() on c.IdNorisMaquina equals m.Id
                            join l in _linhaRepository.GetAll() on m.Liniennummer equals l.Id
                            where l.Bezeichnung == entry.Area
                            select c).ToList();

            var areas = new List<string>() { "HPDC", "Usinagem", "SPM", "Core Shop" };
            var totalIncidentes = chamados.Where(c => c.ChamadoTag?.Any(t => areas.Contains(t.Tag)) ?? false);
            var totalHPDC = totalIncidentes.Where(c => c.ChamadoTag?.Any(t => t.Tag == areas[0]) ?? false);
            var totalUsinagem = totalIncidentes.Where(c => c.ChamadoTag?.Any(t => t.Tag == areas[1]) ?? false);
            var totalSPM = totalIncidentes.Where(c => c.ChamadoTag?.Any(t => t.Tag == areas[2]) ?? false);
            var totalCoreShop = totalIncidentes.Where(c => c.ChamadoTag?.Any(t => t.Tag == areas[3]) ?? false);
            var result = totalIncidentes.GroupBy(c => c.ChamadoTag?.Where(t => areas.Contains(t.Tag)).Select(t => t.Tag).FirstOrDefault());

            return Task.FromResult(new IncidentesPorAreaViewModel(totalIncidentes.Count(), totalIncidentes.Count(), 0)
            {
                HPDC = ObterIncidentesMaquina(totalHPDC),
                Usinagem = ObterIncidentesMaquina(totalUsinagem),
                SPM = ObterIncidentesMaquina(totalSPM),
                CoreShop = ObterIncidentesMaquina(totalCoreShop),
                TotalizadorPlanta = result.Select(t => new TotalizadorPlantaViewModel()
                {
                    Descricao = t.Key ?? string.Empty,
                    DentroSla = t.Where(c => !ChamadoEntity.EstahAtrasado).Count()
                })
            });
        }

        private IncidentesMaquinaViewModel ObterIncidentesMaquina(IEnumerable<ChamadoEntity> chamados)
        {
            return new IncidentesMaquinaViewModel(chamados.Count())
            {
                TotalizadorMaquina = chamados.GroupBy(t => t.IdNorisMaquina)
                                             .Select(t => new TotalizadorPlantaViewModel()
                                             {
                                                 Descricao = _maquinaRepository.GetById(t.Key ?? 0).Bezeichnung,
                                                 DentroSla = t.Where(t => !ChamadoEntity.EstahAtrasado).Count(),
                                                 ForaSla = t.Where(t => ChamadoEntity.EstahAtrasado).Count()
                                             })
            };
        }
    }
}