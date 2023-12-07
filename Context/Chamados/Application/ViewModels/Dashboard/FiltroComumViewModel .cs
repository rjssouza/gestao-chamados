using Core.Application.Seguranca;

namespace Chamados.Application.ViewModels.Dashboard
{
    /// <summary>
    ///
    /// </summary>
    public class FiltroComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userInfo"></param>
        public FiltroComumViewModel(UserInfo userInfo)
        {
            NomeUsuario = userInfo.UserName;
            DataCorrente = DateTime.Now;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Area { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime DataCorrente { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? NomeUsuario { get; set; }
    }
}