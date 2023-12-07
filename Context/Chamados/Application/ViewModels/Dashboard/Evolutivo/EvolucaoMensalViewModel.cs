namespace Chamados.Application.ViewModels.Dashboard.Evolutivo
{
    /// <summary>
    ///
    /// </summary>
    public class EvolucaoMensalViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="mes"></param>
        /// <param name="valor"></param>
        public EvolucaoMensalViewModel(int mes, int valor)
        {
            Mes = mes;
            Valor = valor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Mes { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Valor { get; set; }
    }
}