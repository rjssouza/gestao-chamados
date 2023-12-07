using Chamados.Application.Interfaces;
using Chamados.Application.ViewModels.Chamado;
using Core.Application;
using Core.Domain.Interfaces;
using Core.Extensions;

namespace Chamados.Application
{
    /// <summary>
    /// Service para abrir chamados
    /// </summary>
    public class NotificarServiceApp : ServiceApp, INotificarServiceApp
    {
        private readonly IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel> _notificarUseCase;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public NotificarServiceApp(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _notificarUseCase = serviceProvider.GetRequiredService<IUseCase<FiltroNotifcarViewModel, NotificarResultViewModel>>();
        }

        /// <summary>
        /// Notificar
        /// </summary>
        /// <param name="filtro">filtro para envio da notificacao</param>
        /// <returns>Detalhe do Chamado</returns>
        public async Task<NotificarResultViewModel> NotificarChamado(FiltroNotifcarViewModel filtro)
        {
            return await _notificarUseCase.Execute(filtro);
        }
    }
}