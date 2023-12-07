using EnviarEmail.Application.ViewModels.Enviar;

namespace EnviarEmail.Application.Interfaces
{
    /// <summary>
    /// Interface abertura de EnviarEmail
    /// </summary>
    public interface IEnviarAppService : IDisposable
    {
        /// <summary>
        /// Enviar Email via smtp
        /// </summary>
        /// <param name="dadosEntrada">Entrada dos dados a serem enviados via email</param>
        /// <returns>Lista de EnviarEmail</returns>
        Task<EnviarResultDataViewModel> Enviar(EnviarViewModel dadosEntrada);
    }
}