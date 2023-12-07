using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Listar;
using Chamados.Domain.Entity;
using Chamados.Domain.Enum;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;
using Core.Utils;
using Microsoft.Extensions.Configuration;

namespace Chamados.Domain.UseCases.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class ListarChamadosUseCase : UseCase<ListarChamadosFiltroViewModel, ListarChamadosResultViewModel>
        , IUseCase<ListarChamadosFiltroViewModel, ListarChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<ChamadoTimeEntity> _chamadoTimeRepository;
        private readonly IConfiguration _configuration;
        private readonly IEntityRepository<UsuariosChamadosEntity> _usuariosRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public ListarChamadosUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _chamadoTimeRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoTimeEntity>>();
            _usuariosRepository = serviceProvider.GetRequiredService<IEntityRepository<UsuariosChamadosEntity>>();
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        protected override Task<ListarChamadosResultViewModel> ExecuteInternal(ListarChamadosFiltroViewModel filtro)
        {
            var result = new List<ChamadosResultViewModel>();
            var randomStatus = new Random(5);
            var randomAvatar = new Random(1);
            var resultChamados = _chamadoRepository.GetAll();
            resultChamados?.Where(t =>
                        (!filtro.EhColaborador && (string.IsNullOrEmpty(filtro.Area) || t.ChamadoTag == null || t.ChamadoTag.Any(ct => ct.Tag == filtro.Area)))
                        ||
                        (filtro.EhColaborador && t.UsSolicitante == filtro.UsuarioAtual)
                    )
                ?.OrderByDescending(o => o.DtReg)
                ?.ToList()
                ?.ForEach(item =>
                {
                    var chamado = new ChamadosResultViewModel
                    {
                        IdChamado = item.Id,
                        UsReg = item.UsReg,
                        IdTime = item.IdChamadoTime ?? item.ChamadoClassificacaoEntity?.IdChamadoTime,
                        Time = item.ChamadoTime?.NomeDoTime ?? item.ChamadoClassificacaoEntity?.ChamadoTime?.NomeDoTime,
                        UsSolicitante = string.IsNullOrWhiteSpace(item.UsSolicitante) ? item.UsSolicitanteNomeCompleto : item.UsSolicitante,
                        UsSolicitanteNomeCompleto = string.IsNullOrWhiteSpace(item.UsSolicitanteNomeCompleto) ? item.UsSolicitante : item.UsSolicitanteNomeCompleto,
                        RegistradoEm = item.DtRecebimento?.ToString("MMM d, yyyy HH:mm"),
                        PlantaNome = item.FormularioResposta?.Formulario?.Area?.Nome,
                        UltimaAtividade = !string.IsNullOrEmpty(item.Descricao) ? item.Descricao : item.Comentarios?.OrderByDescending(c => c.DtReg)?.FirstOrDefault()?.Comentario ?? "Em andamento...",
                        Status = item.Status.ToString(),
                        StatusCor = Enumerations.GetEnumDescription(item.Status),
                        StatusFlag = item.ChamadoClassificacaoEntity?.Classificacao,
                        PercentualAtendimento = item.PercentualAtendimento,
                        UltimaAtualizacao = item.UltimaAtualizacao.ToString("MMM d, yyyy HH:mm"),
                        PeriodoBase = $"{item.DtReg:MMM d, yyyy} - {item.DtReg.Add(new TimeSpan(item.ChamadoPrioridade?.SlaAtendimentoHoras ?? 0)):MMM d, yyyy}",
                        Planta = $"./assets/img/areas/brasil.png",
                        Avatar = $"{_configuration.GetSection("Authority").Value}/auth/api/photo/{item.UsSolicitante}"
                    };

                    result.Add(chamado);
                });

            return Task.FromResult(new ListarChamadosResultViewModel
            {
                Filtro = filtro,
                Status = ObterChamadoStatus(),
                Tags = ObterChamadoTags(),
                Times = ObterChamadoTimes(),
                Usuarios = ObterUsuariosChamados(),
                Result = result
            });
        }

        private static IEnumerable<ChamadoStatusViewModel>? ObterChamadoStatus()
        {
            List<ChamadoStatusViewModel> statusViewModel = new();
            foreach (StatusChamadoEnum enumItem in Enum.StatusChamadoEnum.GetValues(typeof(StatusChamadoEnum)))
            {
                statusViewModel.Add(new ChamadoStatusViewModel
                {
                    Id = (int)enumItem,
                    Status = enumItem.ToString()
                });
            }
            return statusViewModel;
        }

        private static IEnumerable<ChamadoTagViewModel>? ObterChamadoTags()
        {
            List<ChamadoTagViewModel> tagViewModel = new();
            TagBadgeConst.ListaTagBadge.ToList().ForEach(tag =>
            {
                tagViewModel.Add(new ChamadoTagViewModel
                {
                    Badge = tag.Key,
                    Tag = tag.Value,
                });
            });
            return tagViewModel;
        }

        private IEnumerable<ChamadoTimeViewModel>? ObterChamadoTimes()
        {
            List<ChamadoTimeViewModel> chamadoTimeViewModel = new();
            var chamadoTimeEntity = _chamadoTimeRepository.GetAll();
            chamadoTimeEntity?.ToList().ForEach(time =>
            {
                chamadoTimeViewModel.Add(new ChamadoTimeViewModel
                {
                    Id = time.Id,
                    Email = time.Email,
                    NomeDoTime = time.NomeDoTime,
                    Responsavel = time.Responsavel,
                });
            });
            return chamadoTimeViewModel;
        }

        private IEnumerable<UsuarioViewModel>? ObterUsuariosChamados()
        {
            List<UsuarioViewModel> usuariosViewModel = new();
            var usuarios = _usuariosRepository.GetAll();
            usuarios?.ToList().ForEach(item =>
            {
                usuariosViewModel.Add(new UsuarioViewModel
                {
                    UsReg = item.UsReg,
                    UsSolicitante = item.UsSolicitante,
                    UsSolicitanteNomeCompleto = string.IsNullOrWhiteSpace(item.UsSolicitanteNomeCompleto) ? item.UsSolicitante : item.UsSolicitanteNomeCompleto
                });
            });
            return usuariosViewModel;
        }
    }
}