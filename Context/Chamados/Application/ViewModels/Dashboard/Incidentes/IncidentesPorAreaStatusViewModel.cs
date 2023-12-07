namespace Chamados.Application.ViewModels.Dashboard.Incidentes
{
    /// <summary>
    ///
    /// </summary>
    public class IncidentesPorAreaStatusViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public IncidentesPorAreaStatusViewModel(List<ChamadosPorAreaStatus> situacoes)
        {
            Situacoes = situacoes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadosPorAreaStatus> Situacoes { get; set; }
    }
}