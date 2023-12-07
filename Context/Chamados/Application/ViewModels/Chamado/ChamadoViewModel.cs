using Chamados.Domain.Enum;

namespace Chamados.Application.ViewModels.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoViewModel : AuditoriaComumViewModel
    {
        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoAnexoViewModel>? Anexos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Atendimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoViewModel? ChamadoPai { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoTimeViewModel? ChamadoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoClassificacaoViewModel? Classificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoComentariosViewModel>? Comentarios { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string? Descricao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DtAtendimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DtFechamento { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? DtRecebimento { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool EmAtendimento => this.DtAtendimento.HasValue && !this.DtFechamento.HasValue;

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool EstahAtrasado
        {
            get
            {
                return (!this.DtAtendimento.HasValue)
                    && (this.Prioridade?.SlaAtendimentoHoras < DateTime.Now.Subtract(this.DtReg ?? DateTime.Now).TotalHours);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public bool EstahPendente
        {
            get
            {
                return (!this.DtRecebimento.HasValue || !this.DtAtendimento.HasValue)
                    && (this.Prioridade?.SlaAtendimentoHoras >= DateTime.Now.Subtract(this.DtReg ?? DateTime.Now).TotalHours);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoHistoricoViewModel>? Historico { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoClassificacao { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoPai { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoPrioridade { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdChamadoTime { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdChamadoTipo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int IdFormularioResposta { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public int? IdNorisMaquina { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public MaquinaViewModel? Maquina { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string NovoComentario { get; set; } = "";

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public double PercentualAtendimento
        {
            get
            {
                var resultado = PercentualAtendimentos?.Select(t => t.Percentual).LastOrDefault() ?? 0;

                return (double)Math.Round(resultado, 2);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<ProgressoChamadoViewModel>? PercentualAtendimentos { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoPrioridadeViewModel? Prioridade { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public StatusChamadoEnum Status
        {
            get
            {
                if (this.EmAtendimento) return StatusChamadoEnum.Atendimento;
                if (this.EstahAtrasado) return StatusChamadoEnum.Atraso;
                if (this.EstahPendente) return StatusChamadoEnum.Novo;
                if (!this.EmAtendimento) return StatusChamadoEnum.Finalizado;

                throw new NullReferenceException("Erro ao obter status do chamado");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public IEnumerable<ChamadoTagViewModel>? Tag { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public ChamadoTipoViewModel? Tipo { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public DateTime? UltimaAtualizacao
        {
            get
            {
                if (DtFechamento.HasValue)
                    return DtFechamento.Value;
                else if (DtAtendimento.HasValue)
                    return DtAtendimento.Value;
                else if (DtRecebimento.HasValue)
                    return DtRecebimento.Value;

                return DtReg;
            }
        }

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