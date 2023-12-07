namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoPrioridadeViewModel : AuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool Ativo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? Prioridade { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? SlaAtendimentoHoras { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? SlaRecebimentoHoras { get; set; }
    }
}