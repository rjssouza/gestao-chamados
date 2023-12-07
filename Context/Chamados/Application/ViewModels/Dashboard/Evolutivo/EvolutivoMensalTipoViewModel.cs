namespace Chamados.Application.ViewModels.Dashboard.Evolutivo
{
    /// <summary>
    ///
    /// </summary>
    public class EvolutivoMensalTipoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="descricao"></param>
        /// <param name="cor"></param>
        /// <param name="evolutivoMensal"></param>
        public EvolutivoMensalTipoViewModel(string descricao, string cor, List<EvolucaoMensalViewModel> evolutivoMensal)
        {
            Descricao = descricao;
            EvolutivoMensal = evolutivoMensal;
            Cor = cor;
        }

        /// <summary>
        ///
        /// </summary>
        public EvolutivoMensalTipoViewModel()
        {
            Descricao = string.Empty;
            EvolutivoMensal = new List<EvolucaoMensalViewModel>();
            Cor = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Cor { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Descricao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<EvolucaoMensalViewModel> EvolutivoMensal { get; set; }
    }
}