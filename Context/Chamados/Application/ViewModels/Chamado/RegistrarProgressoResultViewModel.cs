namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class RegistrarProgressoResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="idChamado"></param>
        /// <param name="idProgresso"></param>
        public RegistrarProgressoResultViewModel(int idChamado, int idProgresso)
        {
            IdChamado = idChamado;
            IdProgresso = idProgresso;
        }

        /// <summary>
        ///
        /// </summary>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int IdProgresso { get; set; }
    }
}