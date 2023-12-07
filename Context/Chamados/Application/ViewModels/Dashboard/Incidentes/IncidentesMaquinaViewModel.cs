namespace Chamados.Application.ViewModels.Dashboard.Incidentes
{
    /// <summary>
    ///
    /// </summary>
    public class IncidentesMaquinaViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="total"></param>
        public IncidentesMaquinaViewModel(int total)
        {
            Total = total;
            TotalizadorMaquina = new List<TotalizadorPlantaViewModel>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Total { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<TotalizadorPlantaViewModel> TotalizadorMaquina { get; set; }
    }
}