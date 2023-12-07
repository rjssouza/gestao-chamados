using Chamados.Application.ViewModels.Chamado;

namespace Chamados.Application.ViewModels.Formulario.FormularioResposta
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioRespostaViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioRespostaViewModel()
        {
            Respostas = new List<FormularioRespostaItemViewModel>();
            Anexos = new List<AnexoChamadoArquivoViewModel>();
        }

        /// <summary>
        /// Lista de arquivos anexados
        /// </summary>
        public IEnumerable<AnexoChamadoArquivoViewModel> Anexos { get; set; }

        /// <summary>
        /// Identificador do formulario
        /// </summary>
        public int IdFormulario { get; set; }

        /// <summary>
        /// Dicionario de dados, IdQuestao - IdOpcao selecionada
        /// </summary>
        public IEnumerable<FormularioRespostaItemViewModel> Respostas { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsEmailSolicitante { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsSolicitante { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UsSolicitanteNomeCompleto { get; set; }
    }
}