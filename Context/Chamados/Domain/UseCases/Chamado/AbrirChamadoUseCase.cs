using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Formulario;
using Chamados.Application.ViewModels.Formulario.FormularioResposta;
using Chamados.Domain.Entity;
using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Chamados.Domain.Enum;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Chamados
{
    /// <summary>
    ///
    /// </summary>
    public class AbrirChamadoUseCase : UseCase<AbrirChamadoViewModel, AbrirChamadoResultViewModel>, IUseCase<AbrirChamadoViewModel, AbrirChamadoResultViewModel>
    {
        private readonly IUseCase<AdicionarAnexoChamadoViewModel, DetalheChamadosResultViewModel> _adicionarAnexoUseCase;
        private readonly IEntityRepository<ChamadoClassificacaoEntity> _chamadoClassificacaoRepository;
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<ChamadoTagEntity> _chamadoTagEntity;
        private readonly IEntityRepository<FormularioRespostaEntity> _formularioRespostaEntityRepository;
        private readonly IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel> _notificarUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public AbrirChamadoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _formularioRespostaEntityRepository = serviceProvider.GetRequiredService<IEntityRepository<FormularioRespostaEntity>>();
            _chamadoTagEntity = serviceProvider.GetRequiredService<IEntityRepository<ChamadoTagEntity>>();
            _notificarUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel>>();
            _adicionarAnexoUseCase = serviceProvider.GetRequiredService<IUseCase<AdicionarAnexoChamadoViewModel, DetalheChamadosResultViewModel>>();
            _chamadoClassificacaoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoClassificacaoEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<AbrirChamadoResultViewModel> ExecuteInternal(AbrirChamadoViewModel entry)
        {
            var result = new AbrirChamadoResultViewModel();
            var formularioResposta = _formularioRespostaEntityRepository.GetById(entry.FormularioRespostaResult.IdFormularioResposta);
            var dicionario = new
            {
                IdMaquina = ObterIdMaquina(entry.FormularioRespostaResult.Dicionario?.Where(t => t.Chave == TipoDicionarioEnum.Maquina).FirstOrDefault(), entry.FormularioRespostaRequest),
                IdChamadoTipo = ObterValorDicionario(entry.FormularioRespostaResult.Dicionario, TipoDicionarioEnum.Tipo),
                IdChamadoPrioridade = ObterValorDicionario(entry.FormularioRespostaResult.Dicionario, TipoDicionarioEnum.Prioridade),
                IdChamadoClassificacao = ObterValorDicionario(entry.FormularioRespostaResult.Dicionario, TipoDicionarioEnum.Classificacao)
            };
            var descricao = string.Join(" | ", entry.FormularioRespostaRequest
                                                    .Respostas
                                                    .Where(t => t.Descricao.Split("|").Length == 3 && (t.Descricao.Split("|")[1] == "textarea" || t.Descricao.Split("|")[1] == "textbox"))
                                                    .Select(t => t.Descricao.Split("|")[2]));

            var classificacao = _chamadoClassificacaoRepository.GetById(Convert.ToInt32(dicionario.IdChamadoClassificacao));

            var entity = new ChamadoEntity()
            {
                Descricao = descricao,
                IdFormularioResposta = entry.FormularioRespostaResult.IdFormularioResposta,
                IdNorisMaquina = dicionario.IdMaquina,
                IdChamadoPrioridade = Convert.ToInt32(dicionario.IdChamadoPrioridade),
                IdChamadoTipo = Convert.ToInt32(dicionario.IdChamadoTipo),
                IdChamadoClassificacao = Convert.ToInt32(dicionario.IdChamadoClassificacao),
                IdChamadoTime = classificacao.IdChamadoTime,
                UsSolicitante = entry.FormularioRespostaRequest.UsSolicitante ?? string.Empty,
                UsSolicitanteNomeCompleto = entry.FormularioRespostaRequest.UsSolicitanteNomeCompleto ?? string.Empty,
                UsEmailSolicitante = entry.FormularioRespostaRequest.UsEmailSolicitante ?? string.Empty,
                ChamadoTag = ObterTags(entry.FormularioRespostaResult.Dicionario),
                DtReg = DateTime.Now,
                DtRecebimento = DateTime.Now
            };

            _chamadoRepository.Insert(entity);

            result.IdChamado = entity.Id;
            formularioResposta.IdChamado = entity.Id;
            _formularioRespostaEntityRepository.Update(formularioResposta);

            if (entry.FormularioRespostaRequest.Anexos?.Count() > 0)
            {
                _adicionarAnexoUseCase.Execute(new AdicionarAnexoChamadoViewModel
                {
                    IdChamado = entity.Id,
                    AnexoChamadoArquivoViewModel = entry.FormularioRespostaRequest.Anexos.ToArray()
                });
            }

            _notificarUseCase.Execute(new FiltroNotifcarViewModel
            {
                EmailChamadoEnviado = true,
                EmailChamadoEnviadoParaGrupo = true,
                EmailChamadoRecebido = true,
                EmailChamadoRecebidoParaGrupo = false,
                IdChamado = entity.Id
            });

            return Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        protected override void ValidateEntry(AbrirChamadoViewModel entry)
        {
            base.ValidateEntry(entry);
            Dicionario_ChamadoTipoEhObrigatorio(entry);
            Dicionario_ChamadoPrioridadeEhObrigatorio(entry);
            Dicionario_ChamadoClassificacaoEhObrigatorio(entry);

            IsValid();
        }

        private static int? ObterIdMaquina(FormularioOpcaoDicionarioViewModel? formularioDicionario, FormularioRespostaViewModel request)
        {
            if (formularioDicionario == null)
                return null;

            var resposta = request.Respostas.Where(t => t.IdResposta == formularioDicionario.IdFormularioOpcao).FirstOrDefault();
            if (resposta == null)
                return null;

            return Convert.ToInt32(resposta?.Descricao.Split("|")[2]);
        }

        private static string ObterValorDicionario(IEnumerable<FormularioOpcaoDicionarioViewModel>? formularioDicionario, TipoDicionarioEnum tipoDicionarioEnum)
        {
            var result = formularioDicionario?.Where(t => t.Chave == tipoDicionarioEnum).LastOrDefault();
            if (result == null)
                return string.Empty;

            return result.Valor;
        }

        private void Dicionario_ChamadoClassificacaoEhObrigatorio(AbrirChamadoViewModel entry)
        {
            var mensagem = "Necessário configurar classificação";
            if (string.IsNullOrEmpty(ObterValorDicionario(entry.FormularioRespostaResult.Dicionario, TipoDicionarioEnum.Classificacao)))
                AddError("Dicionario", mensagem);
        }

        private void Dicionario_ChamadoPrioridadeEhObrigatorio(AbrirChamadoViewModel entry)
        {
            var mensagem = "Necessário selecionar prioridade";
            if (string.IsNullOrEmpty(ObterValorDicionario(entry.FormularioRespostaResult.Dicionario, TipoDicionarioEnum.Prioridade)))
                AddError("Dicionario", mensagem);
        }

        private void Dicionario_ChamadoTipoEhObrigatorio(AbrirChamadoViewModel entry)
        {
            var mensagem = "Necessário selecionar tipo";
            if (string.IsNullOrEmpty(ObterValorDicionario(entry.FormularioRespostaResult.Dicionario, TipoDicionarioEnum.Tipo)))
                AddError("Dicionario", mensagem);
        }

        private List<ChamadoTagEntity>? ObterTags(IEnumerable<FormularioOpcaoDicionarioViewModel>? dicionario)
        {
            var result = dicionario?.Where(t => t.Chave == TipoDicionarioEnum.Tag)
            .Select((dic) =>
            {
                var tag = _chamadoTagEntity.GetAll(t => t.Tag == dic.Valor).FirstOrDefault() ?? new ChamadoTagEntity(dic.Valor)
                {
                    DtReg = DateTime.Now
                };

                return tag;
            }).ToList();

            return result;
        }
    }
}