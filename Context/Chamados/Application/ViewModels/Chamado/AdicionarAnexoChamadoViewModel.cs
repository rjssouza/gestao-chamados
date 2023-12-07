namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class AdicionarAnexoChamadoViewModel : FiltroChamadoComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public AnexoChamadoArquivoViewModel[]? AnexoChamadoArquivoViewModel { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class AnexoChamadoArquivoViewModel
    {
        /// <summary>
        /// Base64 do arquivo
        /// </summary>
        /// <value></value>
        public string Anexo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string NomeArquivo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string TipoArquivo { get; set; } = string.Empty;
    }
}