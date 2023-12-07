namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoClassificacaoViewModel : ChamadoAuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoClassificacaoViewModel? ChamadoPai { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Classificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamadoClassPai { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamadoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoTimeViewModel? Time { get; set; }
    }
}