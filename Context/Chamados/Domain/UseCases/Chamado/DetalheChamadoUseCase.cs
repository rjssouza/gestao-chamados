using Chamados.Application.ViewModels;
using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Chamados.Domain.Entity.Chamado;
using Chamados.Domain.Enum;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Chamados
{
    /// <summary>
    ///
    /// </summary>
    public class DetalheChamadoUseCase : UseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>
        , IUseCase<FiltroChamadoComumViewModel, DetalheChamadosResultViewModel>
    {
        private readonly IEntityRepository<ChamadoAnexoArquivoEntity> _chamadoAnexoArquivoEntity;
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly UserInfo _currentUser;
        private readonly IEntityRepository<MaquinaEntity> _maquinaEntity;
        private readonly IEntityRepository<ProgressoChamadoEntity> _progressoChamadoRepository;
        private readonly IEntityRepository<ChamadoTimeEntity> _timeRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public DetalheChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _chamadoAnexoArquivoEntity = serviceProvider.GetRequiredService<IEntityRepository<ChamadoAnexoArquivoEntity>>();
            _timeRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoTimeEntity>>();
            _maquinaEntity = serviceProvider.GetRequiredService<IEntityRepository<MaquinaEntity>>();
            _progressoChamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ProgressoChamadoEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filtroChamado">filtro para buscar o chamado</param>
        /// <returns>Detalhe do Chamado</returns>
        protected override Task<DetalheChamadosResultViewModel> ExecuteInternal(FiltroChamadoComumViewModel filtroChamado)
        {
            var result = new List<ChamadoViewModel>();
            var chamado = _chamadoRepository.GetById(filtroChamado.IdChamado);
            if (chamado != null &&
                   ((!filtroChamado.EhColaborador && (string.IsNullOrEmpty(filtroChamado.Area) || chamado.ChamadoTag == null || chamado.ChamadoTag.Any(ct => ct.Tag == filtroChamado.Area)))
                    ||
                    (filtroChamado.EhColaborador && chamado.UsSolicitante == filtroChamado.UsuarioAtual)
                   )
                )
            {
                var chamadoPaiViewModel = DetalheChamadoPai(chamado);
                var classificacaoViewModel = DetalheChamadoClassificacao(chamado);
                var maquinaViewModel = DetalheMaquina(chamado);
                var tipoViewModel = DetalheChamadoTipo(chamado);
                var prioridadeViewModel = DetalheChamadoPrioridade(chamado);
                var tagViewModel = DetalheChamadoTag(chamado);
                var comentariosViewModel = DetalheChamadoComentarios(chamado);
                var historicoViewModel = DetalheChamadoHistorico(chamado);
                var anexosViewModel = DetalheChamadoAnexo(chamado);
                var progressoChamadoViewModel = DetalheChamadoProgressos(chamado);
                var chamadoTimeViewModel = ChamadoTimeViewModel(chamado);

                var chamadoViewModel = new ChamadoViewModel
                {
                    Id = chamado.Id,
                    Atendimento = chamado.Atendimento,
                    Descricao = chamado.Descricao,
                    DtAtendimento = chamado.DtAtendimento,
                    DtFechamento = chamado.DtFechamento,
                    DtRecebimento = chamado.DtRecebimento,
                    DtReg = chamado.DtReg,
                    UsReg = chamado.UsReg.ToString(),
                    IdChamadoClassificacao = chamado.IdChamadoClassificacao,
                    IdChamadoPrioridade = chamado.IdChamadoClassificacao,
                    IdChamadoTipo = chamado.IdChamadoTipo,
                    IdChamadoTime = chamado.IdChamadoTime,
                    IdFormularioResposta = chamado.IdFormularioResposta,
                    IdNorisMaquina = chamado.IdNorisMaquina,
                    Maquina = maquinaViewModel,
                    UsSolicitante = chamado.UsSolicitante,
                    UsSolicitanteNomeCompleto = chamado.UsSolicitanteNomeCompleto,
                    IdChamadoPai = chamado.IdChamadoPai,
                    Anexos = anexosViewModel,
                    ChamadoPai = chamadoPaiViewModel,
                    Classificacao = classificacaoViewModel,
                    Tag = tagViewModel,
                    Prioridade = prioridadeViewModel,
                    Comentarios = comentariosViewModel,
                    Historico = historicoViewModel,
                    PercentualAtendimentos = progressoChamadoViewModel,
                    ChamadoTime = chamadoTimeViewModel,
                    Tipo = tipoViewModel
                };

                result.Add(chamadoViewModel);
            }

            List<ChamadoTimeViewModel>? times = new();
            var ehAdministrador = _currentUser.Role == UserInfo.ROLE_ADMIN;
            if (ehAdministrador)
            {
                _timeRepository.GetAll()
                    ?.ToList()
                    .ForEach(s =>
                    {
                        var time = DetalheChamadoTime(s);
                        if (time != null)
                            times.Add(time);
                    });
            }

            return Task.FromResult(new DetalheChamadosResultViewModel
            {
                Times = times,
                Result = result,
                EhAdministrador = ehAdministrador
            });
        }

        private static IEnumerable<ChamadoAnexoViewModel>? DetalheChamadoAnexo(IEnumerable<ChamadoAnexoArquivoEntity>? entity)
        {
            IEnumerable<ChamadoAnexoViewModel>? anexoViewModel = new List<ChamadoAnexoViewModel>();
            anexoViewModel = entity?.OrderByDescending(t => t.DtReg)?.Select(t =>
            {
                var icone = TipoIconeEnum.File;
                var tipoArquivo = t.TipoArquivo?.Trim()?.ToLower()?.Replace(".", "") ?? string.Empty;
                if (!string.IsNullOrEmpty(tipoArquivo) && TipoIconeEnum.ListaIcone.ContainsKey(tipoArquivo))
                    icone = TipoIconeEnum.ListaIcone[tipoArquivo];
                return new ChamadoAnexoViewModel
                {
                    Id = t.Id,
                    NomeArquivo = t.NomeArquivo,
                    TipoArquivo = tipoArquivo,
                    Icone = icone,
                    DtReg = t.DtReg,
                    UsReg = t.UsReg.ToString(),
                    UsAnexo = t.UsAnexo,
                    Anexo = string.Empty,
                };
            });
            return anexoViewModel;
        }

        private static ChamadoClassificacaoViewModel? DetalheChamadoClassificacao(ChamadoEntity entity)
        {
            ChamadoClassificacaoViewModel? classificacaoViewModel = null;
            if (entity.ChamadoClassificacaoEntity != null)
                classificacaoViewModel = new ChamadoClassificacaoViewModel
                {
                    Id = entity.IdChamadoClassificacao,
                    Classificacao = entity.ChamadoClassificacaoEntity?.Classificacao,
                    Time = DetalheChamadoTime(entity.ChamadoClassificacaoEntity?.ChamadoTime)
                };
            return classificacaoViewModel;
        }

        private static IEnumerable<ChamadoComentariosViewModel>? DetalheChamadoComentarios(IEnumerable<ChamadoComentariosEntity>? entity)
        {
            IEnumerable<ChamadoComentariosViewModel>? comentariosViewModel = new List<ChamadoComentariosViewModel>();
            comentariosViewModel = entity?.OrderByDescending(t => t.DtReg)?.Select(t => new ChamadoComentariosViewModel
            {
                Id = t.Id,
                Comentario = t.Comentario,
                DtReg = t.DtReg,
                UsReg = t.UsReg.ToString(),
                UsComentario = t.UsComentario,
                EhAtualSolicitante = t.UsComentario == t.ChamadoEntity?.UsSolicitante
            });
            return comentariosViewModel;
        }

        private static IEnumerable<ChamadoComentariosViewModel>? DetalheChamadoComentarios(ChamadoEntity entity)
        {
            return DetalheChamadoComentarios(entity?.Comentarios);
        }

        private static IEnumerable<ChamadoHistoricoViewModel>? DetalheChamadoHistorico(IEnumerable<ChamadoHistoricoEntity>? entity)
        {
            IEnumerable<ChamadoHistoricoViewModel>? historicoViewModel = new List<ChamadoHistoricoViewModel>();
            historicoViewModel = entity?.OrderByDescending(t => t.DtReg)?.Select(t => new ChamadoHistoricoViewModel
            {
                Id = t.Id,
                De = t.De,
                Para = t.Para,
                DtReg = t.DtReg,
                UsHistorico = t.UsHistorico
            });
            return historicoViewModel;
        }

        private static IEnumerable<ChamadoHistoricoViewModel>? DetalheChamadoHistorico(ChamadoEntity entity)
        {
            return DetalheChamadoHistorico(entity?.ChamadoHistoricoLista);
        }

        private static ChamadoPrioridadeViewModel? DetalheChamadoPrioridade(ChamadoEntity entity)
        {
            ChamadoPrioridadeViewModel? prioridadeViewModel = null;
            if (entity.ChamadoPrioridade != null)
                prioridadeViewModel = new ChamadoPrioridadeViewModel
                {
                    Id = entity.IdChamadoPrioridade,
                    Prioridade = entity.ChamadoPrioridade?.Prioridade,
                    SlaAtendimentoHoras = entity.ChamadoPrioridade?.SlaAtendimentoHoras,
                    SlaRecebimentoHoras = entity.ChamadoPrioridade?.SlaRecebimentoHoras,
                    UsReg = entity.ChamadoPrioridade?.UsReg.ToString(),
                    DtReg = entity.ChamadoPrioridade?.DtReg
                };
            return prioridadeViewModel;
        }

        private static IEnumerable<ChamadoTagViewModel>? DetalheChamadoTag(IEnumerable<ChamadoTagEntity>? entity)
        {
            IEnumerable<ChamadoTagViewModel>? tagViewModel = new List<ChamadoTagViewModel>();
            tagViewModel = entity?.OrderBy(t => t.Tag)?.Select(t =>
            {
                var badge = TagBadgeConst.Outros;
                if (TagBadgeConst.ListaTagBadge.ContainsKey(t.Tag))
                    badge = TagBadgeConst.ListaTagBadge[t.Tag];
                return new ChamadoTagViewModel
                {
                    Id = t.Id,
                    Tag = t.Tag,
                    Badge = badge
                };
            });
            return tagViewModel;
        }

        private static IEnumerable<ChamadoTagViewModel>? DetalheChamadoTag(ChamadoEntity entity)
        {
            return DetalheChamadoTag(entity?.ChamadoTag);
        }

        private static ChamadoTimeViewModel? DetalheChamadoTime(ChamadoTimeEntity? entity)
        {
            ChamadoTimeViewModel? chamadoTimeViewModel = null;
            if (entity != null)
                chamadoTimeViewModel = new ChamadoTimeViewModel
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    NomeDoTime = entity.NomeDoTime,
                    Responsavel = entity.Responsavel,
                };
            return chamadoTimeViewModel;
        }

        private static ChamadoTipoViewModel? DetalheChamadoTipo(ChamadoEntity entity)
        {
            ChamadoTipoViewModel? tipoViewModel = null;
            if (entity.ChamadoTipo != null)
                tipoViewModel = new ChamadoTipoViewModel
                {
                    Id = entity.IdChamadoTipo,
                    Ordem = entity.ChamadoTipo?.Ordem,
                    Ativo = entity.ChamadoTipo?.Ativo,
                    Cor = entity.ChamadoTipo?.Cor,
                    ChamadoTipo = entity.ChamadoTipo?.ChamadoTipo,
                    UsPrimeiroCombate = entity.ChamadoTipo?.UsPrimeiroCombate,
                    IdChamadoClassificacao = entity.ChamadoTipo?.IdChamadoClassificacao
                };
            return tipoViewModel;
        }

        private ChamadoTimeViewModel? ChamadoTimeViewModel(ChamadoEntity entity)
        {
            return _mapper.Map<ChamadoTimeViewModel>(entity.ChamadoTime);
        }

        private IEnumerable<ChamadoAnexoViewModel>? DetalheChamadoAnexo(ChamadoEntity entity)
        {
            return DetalheChamadoAnexo(_chamadoAnexoArquivoEntity.GetAll(a => a.IdChamado == entity.Id));
        }

        private ChamadoViewModel? DetalheChamadoPai(ChamadoEntity entity)
        {
            ChamadoViewModel? chamadoPaiViewModel = null;
            var chamadoPai = entity.IdChamadoPai > 0 ? _chamadoRepository.GetById(entity.IdChamadoPai) : null;
            if (chamadoPai != null)
                chamadoPaiViewModel = new ChamadoViewModel
                {
                    Id = chamadoPai.Id,
                    Descricao = chamadoPai.Descricao
                };
            return chamadoPaiViewModel;
        }

        private IEnumerable<ProgressoChamadoViewModel> DetalheChamadoProgressos(ChamadoEntity chamado)
        {
            var progressoChamados = _progressoChamadoRepository.GetAll(t => t.IdChamado == chamado.Id);
            var result = _mapper.Map<IEnumerable<ProgressoChamadoViewModel>>(progressoChamados);

            return result;
        }

        private MaquinaViewModel? DetalheMaquina(ChamadoEntity entity)
        {
            MaquinaViewModel? maquinaViewModel = null;
            if (entity.IdNorisMaquina.HasValue && entity.IdNorisMaquina.Value > 0)
            {
                var maquina = _maquinaEntity.GetById(entity.IdNorisMaquina.Value);
                maquinaViewModel = new MaquinaViewModel
                {
                    Id = maquina.Id,
                    Bezeichnung = maquina.Bezeichnung,
                    Liniennummer = maquina.Liniennummer
                };
            }
            return maquinaViewModel;
        }
    }
}