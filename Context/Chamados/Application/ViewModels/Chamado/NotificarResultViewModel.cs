namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class NotificarMensagemResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? MesagemRetorno { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class NotificarResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public NotificarMensagemResultViewModel? Result { get; set; }
    }
}