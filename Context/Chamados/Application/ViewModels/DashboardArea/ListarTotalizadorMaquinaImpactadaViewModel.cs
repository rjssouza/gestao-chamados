namespace Chamados.Application.ViewModels.DashboardArea
{
    /// <summary>
    /// Totalizador Maquinas
    /// </summary>
    public class ListarTotalizadorMaquinasImpactadasViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public List<TotalizadorMaquinasImpactadasViewModel>? TotalizadorMaquinasImpactadas { get; set; }
    }

    /// <summary>
    /// Totalizador Maquinas
    /// </summary>
    public class TotalizadorMaquinasImpactadasViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Area { get; set; }

        /// <summary>
        /// Nome da maquina
        /// </summary>
        public string? NomeMaquina { get; set; }

        /// <summary>
        /// Quantidade de chamados
        /// </summary>
        public int? QuantidadeChamados { get; set; }
    }
}