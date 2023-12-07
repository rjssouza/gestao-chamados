using Chamados.Application.ViewModels.Chamado;

namespace Chamados.Application.Interfaces
{
    /// <summary>
    /// Interface abertura de chamado
    /// </summary>
    public interface INotificarServiceApp : IDisposable
    {
        /// <summary>
        /// Notificar
        /// </summary>
        /// <param name="filtro">filtro para envio da notificacao</param>
        /// <returns>Detalhe do Chamado</returns>
        Task<NotificarResultViewModel> NotificarChamado(FiltroNotifcarViewModel filtro);
    }
}