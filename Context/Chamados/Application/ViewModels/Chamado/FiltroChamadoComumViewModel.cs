namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class FiltroChamadoComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Area { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool EhColaborador { get; set; } = true;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsuarioAtual { get; set; }
    }
}