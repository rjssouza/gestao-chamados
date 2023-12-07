namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoComentariosViewModel : ChamadoAuditoriaComumViewModel
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
        public string? Comentario { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool EhAtualSolicitante { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsComentario { get; set; }
    }
}