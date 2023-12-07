namespace Chamados.Application.ViewModels.Dashboard.Incidentes
{
    /// <summary>
    ///
    /// </summary>
    public class IncidentesPorAreaTipoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public IncidentesPorAreaTipoViewModel(List<ChamadosPorAreaTipo> tipos)
        {
            Tipos = tipos;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadosPorAreaTipo> Tipos { get; set; }
    }
}