namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoTipoViewModel : AuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool? Ativo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoClassificacaoViewModel? ChamadoClassificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? ChamadoTipo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Cor { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamadoClassificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? Ordem { get; set; } = 0;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsPrimeiroCombate { get; set; } = string.Empty;
    }
}