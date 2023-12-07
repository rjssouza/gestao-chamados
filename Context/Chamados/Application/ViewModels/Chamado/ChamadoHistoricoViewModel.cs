namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoHistoricoViewModel : ChamadoAuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoViewModel? Chamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? De { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Para { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsHistorico { get; set; }
    }
}