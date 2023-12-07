namespace Chamados.Application.ViewModels.Dashboard
{
    /// <summary>
    ///
    /// </summary>
    public class TotalPorcentagem
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="qtdTotalChamados"></param>
        /// <param name="total"></param>
        /// <param name="cor"></param>
        /// <param name="descricao"></param>
        public TotalPorcentagem(int qtdTotalChamados, int total, string cor, string descricao)
        {
            var totalChamados = total * 100;
            Total = total;
            Descricao = descricao;
            Porcentagem = (qtdTotalChamados <= 0 || total <= 0) ? 0 : MathF.Round((float)totalChamados / (float)qtdTotalChamados, 0, MidpointRounding.AwayFromZero);
            Cor = cor;
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
        public double Porcentagem { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Total { get; set; }
    }
}