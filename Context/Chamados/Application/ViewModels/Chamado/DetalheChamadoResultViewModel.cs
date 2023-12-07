namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class DetalheChamadosResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool EhAdministrador { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public FiltroChamadoComumViewModel? Filtro { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoViewModel>? Result { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoTimeViewModel>? Times { get; set; }
    }
}