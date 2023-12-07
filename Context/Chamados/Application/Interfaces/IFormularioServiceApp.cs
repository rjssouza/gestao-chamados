using Chamados.Application.ViewModels.Formulario;

namespace Chamados.Application.Interfaces
{
    /// <summary>
    ///
    /// </summary>
    public interface IFormularioServiceApp : IDisposable
    {
        /// <summary>
        /// Obter formulario view model
        /// </summary>
        /// <param name="request">Request view model</param>
        /// <returns>Result view model</returns>
        Task<FormularioResultViewModel> ObterFormularioViewModel(FormularioRequestViewModel request);
    }
}