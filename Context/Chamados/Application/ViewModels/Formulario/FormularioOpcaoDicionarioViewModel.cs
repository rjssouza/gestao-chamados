using Chamados.Domain.Enum;

namespace Chamados.Application.ViewModels.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioOpcaoDicionarioViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioOpcaoDicionarioViewModel()
        {
            this.Valor = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        public TipoDicionarioEnum Chave { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdFormularioOpcao { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Valor { get; set; }
    }
}