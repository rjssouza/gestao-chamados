using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Formulario;
using Core.Application;
using Core.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Chamados.Application
{
    /// <summary>
    /// Formulario Service App
    /// </summary>
    public class FormularioServiceApp : ServiceApp, IFormularioServiceApp
    {
        private readonly IUseCase<FormularioRequestViewModel, FormularioResultViewModel> _obterFormularioUseCase;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="serviceProvider">Service provider</param>
        public FormularioServiceApp(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _obterFormularioUseCase = serviceProvider.GetRequiredService<IUseCase<FormularioRequestViewModel, FormularioResultViewModel>>();
        }

        /// <summary>
        /// Obter formulario view model
        /// </summary>
        /// <param name="request">Request view model</param>
        /// <returns>Result view model</returns>
        public async Task<FormularioResultViewModel> ObterFormularioViewModel(FormularioRequestViewModel request)
        {
            var formulario = await _obterFormularioUseCase.Execute(request);

            return formulario;
        }
    }
}