﻿using Core.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ChamadosApi.Filter
{
    /// <summary>
    /// Filtro de exceção
    /// </summary>
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger _customLogger;

        /// <summary>
        /// Construtor de exceção utilizando logger registrado no modulo ioc
        /// </summary>
        /// <param name="logger">Logger</param>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this._customLogger = logger;
        }

        /// <summary>
        /// Método disparado quando a api estoura uma exceção
        /// </summary>
        /// <param name="context">Contexto da exceção</param>
        /// <returns>Resposta http</returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var excecao = context.Exception;
            var excecaoMensagem = ObterMensagem(excecao);
            var codigoErro = ObterCodigoHttp(excecao);

            var error = new
            {
                StatusCode = codigoErro,
                Message = excecaoMensagem,
                excecao.StackTrace
            };
            context.HttpContext.Response.StatusCode = codigoErro.GetHashCode();
            context.Result = new JsonResult(error);
            this.WriteLog(excecao);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Efetua notificação do time de desenvolvimento
        /// </summary>
        private static void NotifyDev()
        {
            // TODO implementar metodo para envio de erro ao desenvolvedor
        }

        /// <summary>
        /// Obtem código http da exceção de acordo com o tipo retornado da exceção
        /// </summary>
        /// <param name="excecao">Exceção</param>
        /// <returns>Http Status Code</returns>
        private static HttpStatusCode ObterCodigoHttp(Exception excecao)
        {
            var codigoErro = HttpStatusCode.InternalServerError;

            if (excecao is ValidationException excecao1)
            {
                codigoErro = excecao1.HttpStatusCode;
            }

            return codigoErro;
        }

        /// <summary>
        /// Obtém mensagem da exeção da mensagem de forma legível na resposta http
        /// </summary>
        /// <param name="excecao">Eceção retornada</param>
        /// <returns>Texto da mensagem</returns>
        private static string ObterMensagem(Exception excecao)
        {
            var mensagem = excecao.Message;
            while (excecao.InnerException != null)
            {
                excecao = excecao.InnerException;
                mensagem += Environment.NewLine + excecao.Message;
            }

            if (excecao is ValidationException exception)
            {
                mensagem = exception.Message;
            }

            return mensagem;
        }

        /// <summary>
        /// Método para escrever log utilizando o logger customizado
        /// </summary>
        /// <param name="ex">Exceção</param>
        private void WriteLog(Exception ex)
        {
            _customLogger.LogError("Error message {message}", ex.Message);

            NotifyDev();
        }
    }
}