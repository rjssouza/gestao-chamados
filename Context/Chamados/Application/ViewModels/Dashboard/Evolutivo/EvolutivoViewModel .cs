namespace Chamados.Application.ViewModels.Dashboard.Evolutivo
{
    /// <summary>
    ///
    /// </summary>
    public class EvolutivoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="evolucaoMensal"></param>
        /// <param name="totalizadores"></param>
        public EvolutivoViewModel(List<EvolutivoMensalTipoViewModel> evolucaoMensal, List<TotalPorcentagem> totalizadores)
        {
            EvolucaoMensal = evolucaoMensal;
            Totalizadores = totalizadores;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<EvolutivoMensalTipoViewModel> EvolucaoMensal { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<TotalPorcentagem> Totalizadores { get; set; }
    }
}