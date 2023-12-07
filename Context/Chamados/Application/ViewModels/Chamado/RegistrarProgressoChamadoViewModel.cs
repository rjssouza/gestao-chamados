namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class RegistrarProgressoChamadoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public RegistrarProgressoChamadoViewModel()
        {
            Comentario = string.Empty;
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
        public double Percentual { get; set; }
    }
}