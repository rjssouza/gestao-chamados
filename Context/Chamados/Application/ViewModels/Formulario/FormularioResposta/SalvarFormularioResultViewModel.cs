namespace Chamados.Application.ViewModels.Formulario.FormularioResposta
{
    /// <summary>
    ///
    /// </summary>
    public class SalvarFormularioResultViewModel
    {
        /// <summary>
        /// Formulario opcao dicionario
        /// </summary>
        public IEnumerable<FormularioOpcaoDicionarioViewModel>? Dicionario { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormularioResposta { get; set; }
    }
}