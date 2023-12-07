namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class AtendenteChamadoViewModel : FiltroChamadoComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? IdUsusario { get; set; }

        /// <summary>
        /// Opções
        /// Time
        /// </summary>
        /// <value></value>
        public string? TipoAtendente { get; set; } = "Time";

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsPrimeiroCombate { get; set; }
    }
}