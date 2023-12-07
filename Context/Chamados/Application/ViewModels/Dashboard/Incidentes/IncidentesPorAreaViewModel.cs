namespace Chamados.Application.ViewModels.Dashboard.Incidentes
{
    /// <summary>
    ///
    /// </summary>
    public class IncidentesPorAreaViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="totalIncidentes"></param>
        /// <param name="comParagem"></param>
        /// <param name="semParagem"></param>
        public IncidentesPorAreaViewModel(int totalIncidentes, int comParagem, int semParagem)
        {
            TotalizadorPlanta = new List<TotalizadorPlantaViewModel>();
            //TODO Dados FAKE
            ComParagem = new TotalPorcentagem(totalIncidentes, comParagem, "Com paragem", "");
            SemParagem = new TotalPorcentagem(totalIncidentes, semParagem, "Sem paragem", "");
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalPorcentagem ComParagem { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IncidentesMaquinaViewModel? CoreShop { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IncidentesMaquinaViewModel? HPDC { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalPorcentagem SemParagem { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IncidentesMaquinaViewModel? SPM { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<TotalizadorPlantaViewModel> TotalizadorPlanta { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IncidentesMaquinaViewModel? Usinagem { get; set; }
    }
}