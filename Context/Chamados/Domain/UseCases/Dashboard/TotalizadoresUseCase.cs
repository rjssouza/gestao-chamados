using Chamados.Application.ViewModels.Dashboard;
using Chamados.Application.ViewModels.Dashboard.Evolutivo;
using Chamados.Application.ViewModels.Dashboard.Totalizadores;
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
    public class TotalizadoresUseCase : DashboardUseCase<TotalizadorViewModel>, IUseCase<FiltroComumViewModel, TotalizadorViewModel>
    {
        private const string INFO = "info";
        private readonly ClaimsPrincipal _currentClaimsPrincipal;
        private readonly IEntityRepository<LinhaEntity> _linhaRepository;
        private readonly IEntityRepository<MaquinaEntity> _maquinaRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public TotalizadoresUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
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
        protected override Task<TotalizadorViewModel> ProcessarChamados(IEnumerable<ChamadoEntity> chamados, FiltroComumViewModel entry)
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

            var qtdChamadosGeral = chamados.Count();

            var chamadosGeral = new TotalizadorInfoViewModel(qtdChamadosGeral, qtdChamadosGeral, "Geral", INFO, "cilArrowBottom")
            {
                ValorMensal = ObterEvolucaoMensal(chamados.Where(t => true)),
                Encerrados = new TotalPorcentagem(qtdChamadosGeral, chamados.Count(t => t.Status == Enum.StatusChamadoEnum.Finalizado), INFO, "Encerrados"),
                Pendentes = new TotalPorcentagem(qtdChamadosGeral, chamados.Count(t => t.Status == Enum.StatusChamadoEnum.Novo || t.Status == Enum.StatusChamadoEnum.Atendimento), INFO, "Pendentes"),
                EmAtraso = new TotalPorcentagem(qtdChamadosGeral, chamados.Count(t => t.Status == Enum.StatusChamadoEnum.Atraso), INFO, "Em Atraso"),
            };

            //HPDC
            var chamadosHpdc = (from c in chamados
                                join m in _maquinaRepository.GetAll() on c.IdNorisMaquina equals m.Id
                                join l in _linhaRepository.GetAll() on m.Liniennummer equals l.Id
                                where l.Id == 2
                                select c).ToList();

            var qtdChamadosHpdc = chamadosHpdc.Count;
            var chamadosHpdcView = new TotalizadorInfoViewModel(qtdChamadosHpdc, qtdChamadosHpdc, "HPDC", INFO, "cilArrowBottom")
            {
                ValorMensal = ObterEvolucaoMensal(chamados.Where(t => true)),
                Encerrados = new TotalPorcentagem(qtdChamadosHpdc, chamadosHpdc.Count(t => t.Status == Enum.StatusChamadoEnum.Finalizado), INFO, "Encerrados"),
                Pendentes = new TotalPorcentagem(qtdChamadosHpdc, chamadosHpdc.Count(t => t.Status == Enum.StatusChamadoEnum.Novo || t.Status == Enum.StatusChamadoEnum.Atendimento), INFO, "Pendentes"),
                EmAtraso = new TotalPorcentagem(qtdChamadosHpdc, chamadosHpdc.Count(t => t.Status == Enum.StatusChamadoEnum.Atraso), INFO, "Em Atraso"),
            };

            //SPM
            var chamadosSpm = (from c in chamados
                               join m in _maquinaRepository.GetAll() on c.IdNorisMaquina equals m.Id
                               join l in _linhaRepository.GetAll() on m.Liniennummer equals l.Id
                               where l.Id == 1
                               select c).ToList();

            var qtdChamadosSpm = chamadosSpm.Count;
            var chamadosSpmView = new TotalizadorInfoViewModel(qtdChamadosSpm, qtdChamadosSpm, "SPM", INFO, "cilArrowBottom")
            {
                ValorMensal = ObterEvolucaoMensal(chamados.Where(t => true)),
                Encerrados = new TotalPorcentagem(qtdChamadosSpm, chamadosSpm.Count(t => t.Status == Enum.StatusChamadoEnum.Finalizado), INFO, "Encerrados"),
                Pendentes = new TotalPorcentagem(qtdChamadosSpm, chamadosSpm.Count(t => t.Status == Enum.StatusChamadoEnum.Novo || t.Status == Enum.StatusChamadoEnum.Atendimento), INFO, "Pendentes"),
                EmAtraso = new TotalPorcentagem(qtdChamadosSpm, chamadosSpm.Count(t => t.Status == Enum.StatusChamadoEnum.Atraso), INFO, "Em Atraso"),
            };

            //Usinagem
            var chamadosUsi = (from c in chamados
                               join m in _maquinaRepository.GetAll() on c.IdNorisMaquina equals m.Id
                               join l in _linhaRepository.GetAll() on m.Liniennummer equals l.Id
                               where l.Id == 4
                               select c).ToList();

            var qtdChamadosUsi = chamadosUsi.Count;
            var chamadosUsiView = new TotalizadorInfoViewModel(qtdChamadosUsi, qtdChamadosUsi, "Usinagem", INFO, "cilArrowBottom")
            {
                ValorMensal = ObterEvolucaoMensal(chamados.Where(t => true)),
                Encerrados = new TotalPorcentagem(qtdChamadosUsi, chamadosUsi.Count(t => t.Status == Enum.StatusChamadoEnum.Finalizado), INFO, "Encerrados"),
                Pendentes = new TotalPorcentagem(qtdChamadosUsi, chamadosUsi.Count(t => t.Status == Enum.StatusChamadoEnum.Novo || t.Status == Enum.StatusChamadoEnum.Atendimento), INFO, "Pendentes"),
                EmAtraso = new TotalPorcentagem(qtdChamadosUsi, chamadosUsi.Count(t => t.Status == Enum.StatusChamadoEnum.Atraso), INFO, "Em Atraso"),
            };

            //Outras Areas
            var chamadosOutras = (from c in chamados
                                  from m in _maquinaRepository.GetAll(x => x.Id == c.IdNorisMaquina).DefaultIfEmpty()
                                  from l in _linhaRepository.GetAll(x => x.Id == (m != null ? m.Liniennummer : 0)).DefaultIfEmpty()
                                  where c.IdNorisMaquina is null || !(new int[] { 1, 4, 2 }).Contains(l.Id)
                                  select c).ToList();

            var qtdChamadosOutras = chamadosOutras.Count;
            var chamadosOutrasView = new TotalizadorInfoViewModel(qtdChamadosOutras, qtdChamadosOutras, "Outras Áreas", INFO, "cilArrowBottom")
            {
                ValorMensal = ObterEvolucaoMensal(chamados.Where(t => true)),
                Encerrados = new TotalPorcentagem(qtdChamadosOutras, chamadosOutras.Count(t => t.Status == Enum.StatusChamadoEnum.Finalizado), INFO, "Encerrados"),
                Pendentes = new TotalPorcentagem(qtdChamadosOutras, chamadosOutras.Count(t => t.Status == Enum.StatusChamadoEnum.Novo || t.Status == Enum.StatusChamadoEnum.Atendimento), INFO, "Pendentes"),
                EmAtraso = new TotalPorcentagem(qtdChamadosOutras, chamadosOutras.Count(t => t.Status == Enum.StatusChamadoEnum.Atraso), INFO, "Em Atraso"),
            };

            return Task.FromResult(new TotalizadorViewModel(chamadosGeral, chamadosHpdcView, chamadosSpmView, chamadosUsiView, chamadosOutrasView));
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