using Chamados.Application.ViewModels.Formulario.FormularioResposta;

namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class AbrirChamadoViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public AbrirChamadoViewModel()
        {
            FormularioRespostaResult = new SalvarFormularioResultViewModel();
            FormularioRespostaRequest = new FormularioRespostaViewModel();
        }

        /// <summary>
        ///
        /// </summary>
        public FormularioRespostaViewModel FormularioRespostaRequest { get; set; }

        /// <summary>
        ///
        /// </summary>
        public SalvarFormularioResultViewModel FormularioRespostaResult { get; set; }
    }
}