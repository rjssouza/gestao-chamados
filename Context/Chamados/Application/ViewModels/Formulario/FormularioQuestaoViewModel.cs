namespace Chamados.Application.ViewModels.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioQuestaoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioQuestaoViewModel()
        {
            Titulo = string.Empty;
        }

        /// <summary>
        /// Indica se e o ultimo
        /// </summary>
        public bool EhUltimo => !Opcoes?.Any(t => t.ProximaQuestao != null) ?? true;

        /// <summary>
        ///Identificador do formulario
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdFormulario { get; set; }

        /// <summary>
        /// Opções para o questionario
        /// </summary>
        public List<FormularioOpcaoViewModel>? Opcoes { get; set; }

        /// <summary>
        /// Texto complementar da questão
        /// </summary>
        public string? TextoComplementar { get; set; }

        /// <summary>
        /// Enunciado da questão
        /// </summary>
        public string Titulo { get; set; }
    }
}