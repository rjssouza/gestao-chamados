namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class FiltroNotifcarViewModel : FiltroChamadoComumViewModel
    {
        /// <summary>
        /// Padrão 'false'
        /// </summary>
        /// <value></value>
        public bool EmailChamadoEncerrado { get; set; } = false;

        /// <summary>
        /// Padrão 'true'
        /// </summary>
        /// <value></value>
        public bool EmailChamadoEncerradoParaGrupo { get; set; } = true;

        /// <summary>
        /// Padrão 'true'
        /// </summary>
        /// <value></value>
        public bool EmailChamadoEnviado { get; set; } = true;

        /// <summary>
        /// Padrão 'true'
        /// </summary>
        /// <value></value>
        public bool EmailChamadoEnviadoParaGrupo { get; set; } = true;

        /// <summary>
        /// Padrão 'true'
        /// </summary>
        /// <value></value>
        public bool EmailChamadoRecebido { get; set; } = true;

        /// <summary>
        /// Padrão 'false'
        /// </summary>
        /// <value></value>
        public bool EmailChamadoRecebidoParaGrupo { get; set; } = false;
    }
}