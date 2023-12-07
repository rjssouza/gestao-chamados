using Core.Application.UseCases;
using Core.Domain.Interfaces;
using EnviarEmail.Application.ViewModels.Enviar;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace EnviarEmail.Domain.UseCases.Enviar
{
    /// <summary>
    ///
    /// </summary>
    public class EnviarUseCase : UseCase<EnviarViewModel, EnviarResultDataViewModel>, IUseCase<EnviarViewModel, EnviarResultDataViewModel>
    {
        private readonly IConfiguration configuration;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public EnviarUseCase(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            this.configuration = configuration;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dadosEntrada"></param>
        /// <returns></returns>
        protected override Task<EnviarResultDataViewModel> ExecuteInternal(EnviarViewModel dadosEntrada)
        {
            var result = new EnviarResultDataViewModel
            {
                Result = new List<EnviarResultViewModel>()
            };

            var host = configuration.GetSection("EnviarEmail:Host").Value;
            var usuario = configuration.GetSection("EnviarEmail:Usuario").Value;
            var senha = configuration.GetSection("EnviarEmail:Senha").Value;
            var porta = configuration.GetSection("EnviarEmail:Porta").Value;
            var emailDeAviso = configuration.GetSection("EnviarEmail:EmailDeAviso").Value;
            var usaSSL = configuration.GetSection("EnviarEmail:UsaSSL").Value;
            var emailDe = configuration.GetSection("EnviarEmail:De").Value;
            var nomeAmigavel = configuration.GetSection("EnviarEmail:NomeAmigavel").Value;
            var tituloPadrao = configuration.GetSection("EnviarEmail:TituloPadrao").Value;

            if (string.IsNullOrEmpty(dadosEntrada.Titulo))
                dadosEntrada.Titulo = tituloPadrao ?? "Abertura de chamado";
            if (string.IsNullOrEmpty(dadosEntrada.NomeAmigavel))
                dadosEntrada.NomeAmigavel = nomeAmigavel ?? "Suporte Nemak";
            if (string.IsNullOrEmpty(dadosEntrada.Corpo))
                dadosEntrada.Corpo = $"Seu chamado foi criado com sucesso às {DateTime.Now:dd \\de\\ MMMM \\de\\ yyyy HH:mm:ss}";

            using (var client = new SmtpClient())
            {
                var email = new MimeMessage();
                var mailFrom = new MailboxAddress(dadosEntrada.NomeAmigavel, emailDe ?? emailDeAviso);
                email.From.Add(mailFrom);
                if (!string.IsNullOrWhiteSpace(emailDeAviso) && !string.IsNullOrEmpty(emailDeAviso))
                {
                    email.Cc.Add(MailboxAddress.Parse(emailDeAviso));
                }
                dadosEntrada.Para
                    ?.Where(para => !string.IsNullOrEmpty(para?.Trim()))
                    ?.ToList()
                    ?.ForEach(para => email.To.Add(MailboxAddress.Parse(para)));
                dadosEntrada.Cc
                    ?.Where(cc => !string.IsNullOrEmpty(cc?.Trim()))
                    ?.ToList()
                    ?.ForEach(cc => email.Cc.Add(MailboxAddress.Parse(cc)));
                email.Subject = dadosEntrada.Titulo;
                email.Body = new TextPart(TextFormat.Html) { Text = dadosEntrada.Corpo };

                if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha))
                {
                    client.Connect(host, Convert.ToInt32(porta), SecureSocketOptions.Auto);
                    client.Authenticate(usuario, senha);
                }
                else
                {
                    client.Connect(host, Convert.ToInt32(porta), MailKit.Security.SecureSocketOptions.None);
                }
                client.Send(email);
                client.Disconnect(true);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dadosEntrada"></param>
        protected override void ValidateEntry(EnviarViewModel dadosEntrada)
        {
            var host = configuration.GetSection("EnviarEmail:Host").Value;
            var porta = configuration.GetSection("EnviarEmail:Porta").Value;
            var emailDeAviso = configuration.GetSection("EnviarEmail:EmailDeAviso").Value;
            var usaSSL = configuration.GetSection("EnviarEmail:UsaSSL").Value;
            var emailDe = configuration.GetSection("EnviarEmail:De").Value;

            if (dadosEntrada == null)
                AddError("EnviarEmail", "Nenhum contrato de envio de email definido");
            else if ((dadosEntrada.Para == null || dadosEntrada.Para.Count == 0) && (string.IsNullOrWhiteSpace(emailDeAviso) || string.IsNullOrEmpty(emailDeAviso)))
                AddError("EnviarEmail", "Nenhum email de destino ou Email de Aviso foi informado");
            else if (string.IsNullOrWhiteSpace(host) || string.IsNullOrEmpty(host))
                AddError("EnviarEmail", "Host de envio não definido nas configurações do serviço de envio de email");
            else if (string.IsNullOrWhiteSpace(emailDe) || string.IsNullOrEmpty(emailDe))
                AddError("EnviarEmail", "Email padrão de envio não definido nas configurações do serviço de envio de email");
            else if (string.IsNullOrWhiteSpace(porta) || string.IsNullOrEmpty(porta))
                AddError("EnviarEmail", "Portão padrão de envio não definido nas configurações do serviço de envio de email");
            else if (usaSSL?.ToLower() != "false" && usaSSL?.ToLower() != "true")
                AddError("EnviarEmail", "A configuração para 'usaSSL' deve ser apenas: 'true' ou 'false'");

            IsValid();
        }
    }
}