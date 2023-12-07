namespace Chamados.Application.ViewModels.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioResultViewModel()
        {
            Nome = string.Empty;
            Area = string.Empty;
        }

        /// <summary>
        /// Nome da área do formulário
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Identificador do formulario
        /// </summary>
        public int IdFormulario { get; set; }

        /// <summary>
        /// Nome do formulario
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Primeira questão, deve ser exibida no formulario
        /// </summary>
        public FormularioQuestaoViewModel? PrimeiraQuestao { get; set; }
    }
}