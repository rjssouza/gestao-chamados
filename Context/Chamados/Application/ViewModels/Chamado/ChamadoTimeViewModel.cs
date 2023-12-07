namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoTimeViewModel : AuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? NomeDoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Responsavel { get; set; }
    }
}