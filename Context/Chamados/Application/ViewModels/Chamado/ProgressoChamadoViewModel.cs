namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ProgressoChamadoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public ProgressoChamadoViewModel()
        {
            Comentario = string.Empty;
            UsAtendente = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        public string Comentario { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        public decimal Percentual { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UsAtendente { get; set; }
    }
}