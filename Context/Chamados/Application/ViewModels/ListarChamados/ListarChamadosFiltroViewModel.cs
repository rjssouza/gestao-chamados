namespace Chamados.Application.ViewModels.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class ListarChamadosFiltroViewModel
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
        public DateTime? DataFinal { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DataInicial { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool EhColaborador { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Skip { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Take { get; set; } = 20;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsuarioAtual { get; set; }
    }
}