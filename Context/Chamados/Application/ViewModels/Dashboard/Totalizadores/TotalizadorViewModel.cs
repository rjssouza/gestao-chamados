namespace Chamados.Application.ViewModels.Dashboard.Totalizadores
{
    /// <summary>
    ///
    /// </summary>
    public class TotalizadorViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="totalChamados"></param>
        /// <param name="chamadosEncerrados"></param>
        /// <param name="chamadosPendentes"></param>
        /// <param name="chamadosAtraso"></param>
        /// <param name="outrasAreas"></param>
        public TotalizadorViewModel(TotalizadorInfoViewModel totalChamados, TotalizadorInfoViewModel chamadosEncerrados, TotalizadorInfoViewModel chamadosPendentes, TotalizadorInfoViewModel chamadosAtraso, TotalizadorInfoViewModel outrasAreas)
        {
            ChamadosAbertos = totalChamados;
            ChamadosEncerrados = chamadosEncerrados;
            ChamadosPendentes = chamadosPendentes;
            ChamadosEmAtraso = chamadosAtraso;
            OutrasAreas = outrasAreas;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalizadorInfoViewModel ChamadosAbertos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalizadorInfoViewModel ChamadosEmAtraso { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalizadorInfoViewModel ChamadosEncerrados { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalizadorInfoViewModel ChamadosPendentes { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public TotalizadorInfoViewModel OutrasAreas { get; set; }
    }
}