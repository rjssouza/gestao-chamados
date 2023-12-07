namespace Chamados.Application.ViewModels.Dashboard.Incidentes
{
    /// <summary>
    ///
    /// </summary>
    public class TotalizadorPlantaViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public TotalizadorPlantaViewModel()
        {
            Descricao = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int DentroSla { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Descricao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int ForaSla { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Total => DentroSla + ForaSla;
    }
}