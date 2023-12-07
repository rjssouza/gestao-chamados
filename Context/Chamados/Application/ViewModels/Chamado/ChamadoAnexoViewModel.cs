using Chamados.Domain.Enum;

namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoAnexoViewModel : ChamadoAuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Anexo { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Icone { get; set; } = TipoIconeEnum.Doc;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

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

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string UsAnexo { get; set; } = string.Empty;
    }
}