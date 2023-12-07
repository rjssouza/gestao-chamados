using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Evolutivo;
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
    public class EvolutivoUseCase : DashboardUseCase<EvolutivoViewModel>, IUseCase<FiltroComumViewModel, EvolutivoViewModel>
    {
        private readonly ClaimsPrincipal _currentClaimsPrincipal;
        private readonly IEntityRepository<LinhaEntity> _linhaRepository;
        private readonly IEntityRepository<MaquinaEntity> _maquinaRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public EvolutivoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
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
        protected override Task<EvolutivoViewModel> ProcessarChamados(IEnumerable<ChamadoEntity> chamados, FiltroComumViewModel entry)
        {
            entry.Area = _currentClaimsPrincipal.Claims.Where(c => c.Type == ClaimTypes.Role
               && c.Value != UserInfo.ROLE_ADMIN
               && c.Value != UserInfo.ROLE_COLABORADOR)?.FirstOrDefault()?.Value;
            //GERAL
            if (!string.IsNullOrEmpty(entry.Area))
                chamados = (from c in chamados
                            join m in _maquinaRepository.GetAll() on c.IdNorisMaquina equals m.Id
                            join l in _linhaRepository.GetAll() on m.Liniennummer equals l.Id
                            where l.Bezeichnung == entry.Area
                            select c).ToList();
            var evoMensalAberto = new EvolutivoMensalTipoViewModel
            {
                Cor = "info",
                Descricao = "Abertos"
            };
            var emAberto = new List<EvolucaoMensalViewModel>();
            for (int i = 1; i <= 12; i++)
            {
                int mes = i;
                emAberto.Add(new EvolucaoMensalViewModel(mes, chamados.Count(x => x.DtReg.Month == mes)));
            }
            evoMensalAberto.EvolutivoMensal = emAberto;

            var evoMensalFechado = new EvolutivoMensalTipoViewModel
            {
                Cor = "success",
                Descricao = "Fechados"
            };
            var emFechado = new List<EvolucaoMensalViewModel>();
            for (int i = 1; i <= 12; i++)
            {
                int mes = i;
                emFechado.Add(new EvolucaoMensalViewModel(mes, chamados.Count(x => x.DtFechamento?.Month == mes)));
            }
            evoMensalFechado.EvolutivoMensal = emFechado;

            var lstEvoMensal = new List<EvolutivoMensalTipoViewModel>
            {
                evoMensalAberto,
                evoMensalFechado
            };

            var evolucaoMensalAbertos = ObterEvolucaoMensal(chamados);

            var totalizadores = chamados.GroupBy(t => t.ChamadoTipo)
                                        .Select(t => new TotalPorcentagem(chamados.Count(), t.Count(), t.Key?.Cor ?? string.Empty, t.Key?.ChamadoTipo ?? string.Empty))
                                        .ToList();

            var chamadosAgrupados = totalizadores.Select(t => new EvolutivoMensalTipoViewModel(t.Descricao, t.Cor, ObterEvolucaoMensal(chamados.Where(c => c.ChamadoTipo?.ChamadoTipo == t.Descricao))))
                                                 .ToList();

            return Task.FromResult(new EvolutivoViewModel(lstEvoMensal, totalizadores));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chamados"></param>
        /// <returns></returns>
        private static List<EvolucaoMensalViewModel> ObterEvolucaoMensal(IEnumerable<ChamadoEntity> chamados)
        {
            var meses = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }.Select(t => new EvolucaoMensalViewModel(t, 0));
            var evolucaoMensal = chamados.GroupBy(t => t.DtReg.Month)
                                         .Select(t => new EvolucaoMensalViewModel(t.Key, t.Count()))
                                         .ToList();
            var filteredMeses = meses.Where(t => !evolucaoMensal.Any(c => c.Mes == t.Mes)).ToList();
            var resultado = evolucaoMensal.Union(filteredMeses).OrderBy(t => t.Mes).ToList();

            return resultado;
        }
    }
}