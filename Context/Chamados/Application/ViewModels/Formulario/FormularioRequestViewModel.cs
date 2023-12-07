namespace Chamados.Application.ViewModels.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioRequestViewModel
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioRequestViewModel(int idArea)
        {
            IdArea = idArea;
        }

        /// <summary>
        /// Identificador da área (default 1)
        /// </summary>
        public int IdArea { get; set; }
    }
}