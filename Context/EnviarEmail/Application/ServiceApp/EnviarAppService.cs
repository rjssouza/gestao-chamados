using Core.Application;
using Core.Domain.Interfaces;
using Core.Extensions;
using EnviarEmail.Application.Interfaces;
using EnviarEmail.Application.ViewModels.Enviar;

namespace EnviarEmail.Application
{
    /// <summary>
    /// Service para abrir EnviarEmail
    /// </summary>
    public class EnviarAppService : ServiceApp, IEnviarAppService
    {
        private readonly IUseCase<EnviarViewModel, EnviarResultDataViewModel> _enviarUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public EnviarAppService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _enviarUseCase = serviceProvider.GetRequiredService<IUseCase<EnviarViewModel, EnviarResultDataViewModel>>();
        }

        /// <summary>
        /// Enviar Email via smtp
        /// </summary>
        /// <param name="dadosEntrada">Filtro de dados</param>
        /// <returns>EnviarEmail</returns>
        public async Task<EnviarResultDataViewModel> Enviar(EnviarViewModel dadosEntrada)
        {
            dadosEntrada.UsuarioAtual = CurrentUser.UserName;
            var result = await _enviarUseCase.Execute(dadosEntrada);

            return result;
        }
    }
}