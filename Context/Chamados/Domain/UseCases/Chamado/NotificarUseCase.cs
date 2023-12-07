using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Templates;
using Chamados.Domain.Entity;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;
using EnviarEmail.Application.ViewModels.Enviar;
using Microsoft.Extensions.Configuration;

namespace Chamados.Domain.UseCases.Chamados
{
    /// <summary>
    /// Caso de uso para notificação e envio de emails
    /// </summary>
    public class NotificarUseCase : UseCase<FiltroNotifcarViewModel, NotificarResultViewModel>
        , IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel>
    {
        private readonly IEntityRepository<ChamadoClassificacaoEntity> _chamadoClassificacaoEntity;
        private readonly IEntityRepository<ChamadoPrioridadeEntity> _chamadoPrioridadeEntity;
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;
        private readonly IEntityRepository<ChamadoTipoEntity> _chamadoTipoEntity;
        private readonly UserInfo _currentUser;
        private readonly IUseCase<EnviarViewModel, EnviarResultDataViewModel> _enviarUseCase;
        private readonly IEntityRepository<MaquinaEntity> _maquinaEntity;
        private readonly IConfiguration configuration;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public NotificarUseCase(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
            _chamadoTipoEntity = serviceProvider.GetRequiredService<IEntityRepository<ChamadoTipoEntity>>();
            _chamadoClassificacaoEntity = serviceProvider.GetRequiredService<IEntityRepository<ChamadoClassificacaoEntity>>();
            _chamadoPrioridadeEntity = serviceProvider.GetRequiredService<IEntityRepository<ChamadoPrioridadeEntity>>();
            _enviarUseCase = serviceProvider.GetRequiredService<IUseCase<EnviarViewModel, EnviarResultDataViewModel>>();
            _maquinaEntity = serviceProvider.GetRequiredService<IEntityRepository<MaquinaEntity>>();
            this.configuration = configuration;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="filtroChamado">filtro para buscar o chamado</param>
        /// <returns>Detalhe do Chamado</returns>
        protected override Task<NotificarResultViewModel> ExecuteInternal(FiltroNotifcarViewModel filtroChamado)
        {
            var chamado = _chamadoRepository.GetById(filtroChamado.IdChamado);
            if (filtroChamado.EmailChamadoEnviado)
                DispararEmailChamadoEnviado(chamado, filtroChamado.EmailChamadoEnviadoParaGrupo);
            if (filtroChamado.EmailChamadoRecebido)
                DispararEmailChamadoRecebido(chamado, filtroChamado.EmailChamadoRecebidoParaGrupo);
            if (filtroChamado.EmailChamadoEncerrado)
                DispararEmailChamadoEncerrado(chamado, filtroChamado.EmailChamadoEncerradoParaGrupo);
            IsValid();
            return Task.FromResult(new NotificarResultViewModel
            {
                Result = new NotificarMensagemResultViewModel
                {
                    MesagemRetorno = "Notificação enviada com sucesso"
                }
            });
        }

        private static string TempoDecorrido(DateTime? dataEntrada)
        {
            if (!dataEntrada.HasValue)
                return "--";
            var total = DateTime.Now.Subtract(dataEntrada.Value);
            if (total.TotalDays >= 31)
                return "Mais de um mês";
            else if (total.TotalDays >= 1)
                return $"{Math.Truncate(total.TotalDays)} dia(s)";
            else if (total.TotalHours >= 1)
                return $"{Math.Truncate(total.TotalHours)} hora(s)";
            if (total.Minutes >= 1)
                return $"{Math.Truncate(total.TotalMinutes)} minuto(s)";
            else
                return "Agora a pouco";
        }

        private void DispararEmailChamadoEncerrado(ChamadoEntity entity, bool paraGrupo)
        {
            try
            {
                var emailPara = new List<string>() { entity.UsEmailSolicitante };
                var emailCc = new List<string>();
                var nome = entity.UsSolicitanteNomeCompleto ?? entity.UsSolicitante ?? "Usuário Não indentificado";
                var chamado = $"Número {entity.Id}";
                var classificacaoDesc = entity.ChamadoClassificacaoEntity?.Classificacao ?? "--";
                var maquinaDesc = entity.IdNorisMaquina.HasValue ? _maquinaEntity.GetById(entity.IdNorisMaquina.Value)?.Bezeichnung : "--";
                var chamadoDesc = entity.Descricao?.Replace("\n\r", " ").Replace("\n", " ");
                var chamadoPrioridade = _chamadoPrioridadeEntity.GetById(entity.IdChamadoPrioridade);
                var chamadoDescAtendimento = entity.Atendimento?.Replace("\n\r", " ").Replace("\n", " ");
                var tempoAtendimento = TempoDecorrido(entity.DtAtendimento);

                var chamadoTipo = _chamadoTipoEntity.GetById(entity.IdChamadoTipo);
                var servicoDesc = chamadoTipo?.ChamadoTipo ?? "--";
                if (paraGrupo)
                {
                    chamadoTipo?.ChamadoTipoEmailAvisos
                        ?.Where(e => !string.IsNullOrEmpty(e.Email?.Trim()))
                        ?.ToList()?.ForEach(e => emailCc.Add(e.Email));
                }

                var enviarEmail = new EnviarViewModel
                {
                    Titulo = "Chamado Encerrado",
                    Corpo = TemplateEmailChamadoEncerrado.Corpo
                        .Replace("[NOME]", nome)
                        .Replace("[CHAMADO]", chamado)
                        .Replace("[ID_CHAMADO]", entity.Id.ToString())
                        .Replace("[URL_DETALHE_CHAMADO]", configuration.GetSection("HttpClients:EnviarEmail:UrlDetalheChamado").Value)
                        .Replace("[SERVICO]", servicoDesc)
                        .Replace("[CLASSIFICACAO]", classificacaoDesc)
                        .Replace("[DATA_ENCERRAMENTO]", entity.DtFechamento.HasValue ? entity.DtFechamento?.ToString("dd/MM/yyyy HH:mm") : "--")
                        .Replace("[PRIORIDADE]", chamadoPrioridade?.Prioridade.ToString())
                        .Replace("[TEMPO_ATENDIMENTO]", tempoAtendimento)
                        .Replace("[MAQUINA]", maquinaDesc)
                        .Replace("[DESCRICAO ATENDIMENTO]", chamadoDescAtendimento)
                        .Replace("[UrlAssetsForTemplates]", configuration.GetSection("HttpClients:EnviarEmail:UrlAssetsForTemplates").Value),
                    NomeAmigavel = nome,
                    Para = emailPara.ToList(),
                    Cc = emailCc.ToList()
                };
                _enviarUseCase.Execute(enviarEmail);
            }
            catch (Exception exEnviarEmail)
            {
                AddError("NotificarUseCase", exEnviarEmail.Message);
                IsValid();
            }
        }

        private void DispararEmailChamadoEnviado(ChamadoEntity entity, bool paraGrupo)
        {
            try
            {
                var emailPara = new List<string>() { _currentUser.Email };
                var emailCc = new List<string>();
                var nome = entity.UsSolicitanteNomeCompleto ?? entity.UsSolicitante ?? "Usuário Não indentificado";
                var chamado = $"Número {entity.Id}";
                var classificacaoDesc = _chamadoClassificacaoEntity.GetById(entity.IdChamadoClassificacao)?.Classificacao ?? "--";
                var maquinaDesc = entity.IdNorisMaquina.HasValue ? _maquinaEntity.GetById(entity.IdNorisMaquina.Value)?.Bezeichnung : "--";
                var chamadoDesc = entity.Descricao?.Replace("\n\r", " ").Replace("\n", " ");

                var chamadoTipo = _chamadoTipoEntity.GetById(entity.IdChamadoTipo);
                var servicoDesc = chamadoTipo?.ChamadoTipo ?? "--";
                if (paraGrupo)
                {
                    chamadoTipo?.ChamadoTipoEmailAvisos
                        ?.Where(e => !string.IsNullOrEmpty(e.Email?.Trim()))
                        ?.ToList()?.ForEach(e => emailCc.Add(e.Email));
                }

                var enviarEmail = new EnviarViewModel
                {
                    Titulo = "Confirmação da Abertura do chamado",
                    Corpo = TemplateEmailChamadoEnviado.Corpo
                        .Replace("[NOME]", nome)
                        .Replace("[ID_CHAMADO]", entity.Id.ToString())
                        .Replace("[URL_DETALHE_CHAMADO]", configuration.GetSection("HttpClients:EnviarEmail:UrlDetalheChamado").Value)
                        .Replace("[CHAMADO]", chamado)
                        .Replace("[SERVICO]", servicoDesc)
                        .Replace("[CLASSIFICACAO]", classificacaoDesc)
                        .Replace("[MAQUINA]", maquinaDesc)
                        .Replace("[DESCRICAO]", chamadoDesc)
                        .Replace("[UrlAssetsForTemplates]", configuration.GetSection("HttpClients:EnviarEmail:UrlAssetsForTemplates").Value),
                    NomeAmigavel = nome,
                    Para = emailPara.ToList(),
                    Cc = emailCc.ToList()
                };
                _enviarUseCase.Execute(enviarEmail);
            }
            catch (Exception exEnviarEmail)
            {
                AddError("NotificarUseCase", exEnviarEmail.Message);
                IsValid();
            }
        }

        private void DispararEmailChamadoRecebido(ChamadoEntity entity, bool paraGrupo)
        {
            try
            {
                var chamadoPrioridade = _chamadoPrioridadeEntity.GetById(entity.IdChamadoPrioridade);
                var emailPara = new List<string>();
                var emailCc = new List<string>();
                if (!string.IsNullOrEmpty(entity.ChamadoTime?.Email))
                    emailPara.Add(entity.ChamadoTime.Email);
                var nome = entity.ChamadoTime?.Responsavel;
                var chamado = $"Número {entity.Id}";

                var classificacaoDesc = entity.ChamadoClassificacaoEntity?.Classificacao ?? "--";
                var maquinaDesc = entity.IdNorisMaquina.HasValue ? _maquinaEntity.GetById(entity.IdNorisMaquina.Value)?.Bezeichnung : "--";
                var chamadoDesc = entity.Descricao?.Replace("\n\r", " ").Replace("\n", " ");
                var tempoRecibimento = TempoDecorrido(entity.DtRecebimento);
                var tempoAtendimento = TempoDecorrido(entity.DtAtendimento);

                var chamadoTipo = _chamadoTipoEntity.GetById(entity.IdChamadoTipo);
                var servicoDesc = chamadoTipo?.ChamadoTipo ?? "--";
                if (paraGrupo)
                {
                    chamadoTipo?.ChamadoTipoEmailAvisos
                        ?.Where(e => !string.IsNullOrEmpty(e.Email?.Trim()))
                        ?.ToList()?.ForEach(e => emailCc.Add(e.Email));
                }

                var enviarEmail = new EnviarViewModel
                {
                    Titulo = "Recebimento do chamado",
                    Corpo = TemplateEmailChamadoRecebido.Corpo
                        .Replace("[NOME]", nome)
                        .Replace("[CHAMADO]", chamado)
                        .Replace("[ID_CHAMADO]", entity.Id.ToString())
                        .Replace("[URL_DETALHE_CHAMADO]", configuration.GetSection("HttpClients:EnviarEmail:UrlDetalheChamado").Value)
                        .Replace("[SERVICO]", servicoDesc)
                        .Replace("[CLASSIFICACAO]", classificacaoDesc)
                        .Replace("[PRIORIDADE]", chamadoPrioridade?.Prioridade.ToString())
                        .Replace("[DATA_ABERTURA]", entity.DtReg.ToString("dd/MM/yyyy HH:mm"))
                        .Replace("[TEMPO_RECEBIMENTO]", tempoRecibimento)
                        .Replace("[TEMPO_ATENDIMENTO]", tempoAtendimento)
                        .Replace("[MAQUINA]", maquinaDesc)
                        .Replace("[DESCRICAO]", chamadoDesc)
                        .Replace("[UrlAssetsForTemplates]", configuration.GetSection("HttpClients:EnviarEmail:UrlAssetsForTemplates").Value),
                    NomeAmigavel = nome,
                    Para = emailPara.ToList(),
                    Cc = emailCc.ToList()
                };
                _enviarUseCase.Execute(enviarEmail);
            }
            catch (Exception exEnviarEmail)
            {
                AddError("NotificarUseCase", exEnviarEmail.Message);
                IsValid();
            }
        }
    }
}