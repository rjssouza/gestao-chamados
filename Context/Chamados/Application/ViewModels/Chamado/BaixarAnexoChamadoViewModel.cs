namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class BaixarAnexoChamadoViewModel : FiltroChamadoComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public string Anexo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public int IdAnexo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string NomeArquivo { get; set; } = string.Empty;
    }
}