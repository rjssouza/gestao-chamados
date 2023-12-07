using Chamados.Application.ViewModels;
using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Listar;
using Chamados.Domain.Entity;
using Chamados.Domain.Enum;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;
using Microsoft.Extensions.Configuration;

namespace Chamados.Domain.UseCases.Listar
{
    /// <summary>
    /// UseCase responsável por listar os chamados do dashboard por área
    /// </summary>
    public class ListarChamadosDashboardAreaUseCase : UseCase<ListarChamadosFiltroViewModel, ListarChamadosDashboardPorAreaViewModel>,
    IUseCase<ListarChamadosFiltroViewModel, ListarChamadosDashboardPorAreaViewModel>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<LinhaEntity> _linhaRepository;
        private readonly IEntityRepository<MaquinaEntity> _maquinaRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ListarChamadosDashboardAreaUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _linhaRepository = serviceProvider.GetRequiredService<IEntityRepository<LinhaEntity>>();
            _maquinaRepository = serviceProvider.GetRequiredService<IEntityRepository<MaquinaEntity>>();
        }

        /// <summary>
        /// Método responsável por executar o caso de uso
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        protected override Task<ListarChamadosDashboardPorAreaViewModel> ExecuteInternal(ListarChamadosFiltroViewModel filtro)
        {
            var result = new List<ChamadosDashboardPorAreaViewModel>();
            var randomStatus = new Random(5);
            var randomAvatar = new Random(1);
            var resultChamados = _chamadoRepository.GetAll();
            var maquinaViewModel = ObterMaquinas();
            var linhasViewModel = ObterLinhas();

            resultChamados
            ?.Where(t => (t.IdNorisMaquina != null && t.Status != StatusChamadoEnum.Finalizado))
            ?.OrderByDescending(t => t.DtRecebimento)
            ?.ToList()
            ?.ForEach(item =>
            {
                var IdArea = maquinaViewModel?.FirstOrDefault(t => t.Id == item.IdNorisMaquina)?.Liniennummer;
                var chamadoPorArea = new ChamadosDashboardPorAreaViewModel
                {
                    Area = linhasViewModel?.FirstOrDefault(l => l.Id == IdArea)?.Bezeichnung,
                    IdChamado = item.Id,
                    IdTime = item.IdChamadoTime,
                    IdMaquina = item.IdNorisMaquina.HasValue ? _maquinaRepository.GetById(item.IdNorisMaquina.Value)?.Liniennummer : null,
                    Maquina = maquinaViewModel?.FirstOrDefault(t => t.Id == item.IdNorisMaquina)?.Bezeichnung,
                    RegistradoEm = item.DtRecebimento?.ToString("MMM d, yyyy HH:mm"),
                    Status = item.Status.ToString(),
                    Responsavel = item.ChamadoTime?.NomeDoTime ?? item.ChamadoClassificacaoEntity?.ChamadoTime?.Responsavel ?? string.Empty,
                    UsReg = item.UsReg,
                    UsSolicitanteNomeCompleto = string.IsNullOrWhiteSpace(item.UsSolicitanteNomeCompleto) ? item.UsSolicitante : item.UsSolicitanteNomeCompleto
                };
                result.Add(chamadoPorArea);
            });
            return Task.FromResult(new ListarChamadosDashboardPorAreaViewModel
            {
                Chamados = result,
                Filtro = filtro,
                Total = result.Count
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