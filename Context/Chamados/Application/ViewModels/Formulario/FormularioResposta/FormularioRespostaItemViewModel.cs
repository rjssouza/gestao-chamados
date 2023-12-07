namespace Chamados.Application.ViewModels.Formulario.FormularioResposta
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioRespostaItemViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioRespostaItemViewModel()
        {
            Descricao = string.Empty;
        }

        /// <summary>
        ///
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdQuestao { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdResposta { get; set; }
    }
}