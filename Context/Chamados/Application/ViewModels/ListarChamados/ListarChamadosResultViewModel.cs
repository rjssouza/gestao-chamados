using Chamados.Application.ViewModels.Chamado;

namespace Chamados.Application.ViewModels.Listar
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadosResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Avatar { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamado { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public double PercentualAtendimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? PeriodoBase { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Planta { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? PlantaNome { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? RegistradoEm { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? StatusCor { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? StatusFlag { get; set; } = "success";

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Time { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UltimaAtividade { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? UltimaAtualizacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? UsReg { get; set; }

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

    /// <summary>
    ///
    /// </summary>
    public class ListarChamadosResultViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ListarChamadosFiltroViewModel? Filtro { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadosResultViewModel>? Result { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoStatusViewModel>? Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoTagViewModel>? Tags { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoTimeViewModel>? Times { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<UsuarioViewModel>? Usuarios { get; set; }
    }
}