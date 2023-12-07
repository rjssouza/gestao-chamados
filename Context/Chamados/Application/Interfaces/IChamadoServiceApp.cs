using Chamados.Application.ViewModels.Chamado;
using Chamados.Application.ViewModels.Formulario.FormularioResposta;

namespace Chamados.Application.Interfaces
{
    /// <summary>
    /// Interface abertura de chamado
    /// </summary>
    public interface IChamadoServiceApp : IDisposable
    {
        /// <summary>
        /// Abertura de chamados a partir do form de respostas
        /// </summary>
        /// <param name="formularioRespostaViewModel">Form de respostas</param>
        /// <returns>Chamado id</returns>
        Task<int> AbrirChamado(FormularioRespostaViewModel formularioRespostaViewModel);

        /// <summary>
        /// Adicionar anexo(s) ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Anexo para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> AdicionarAnexoChamado(AdicionarAnexoChamadoViewModel modeloEntrada);

        /// <summary>
        /// Adicionar comentário ao chamado
        /// </summary>
        /// <param name="modeloEntrada">Comentário para inclusão</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> AdicionarComentarioChamado(AdicionarComentarioChamadoViewModel modeloEntrada);

        /// <summary>
        /// Atendente do chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados do atendente</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> AtendenteChamado(AtendenteChamadoViewModel modeloEntrada);

        /// <summary>
        /// Anexo para baixar
        /// </summary>
        /// <param name="modeloEntrada">Anexo para baixar</param>
        /// <returns>Base 64 do Anexo</returns>
        Task<BaixarAnexoChamadoViewModel> BaixarAnexoChamado(BaixarAnexoChamadoViewModel modeloEntrada);

        /// <summary>
        /// Detalhe do Chamado
        /// </summary>
        /// <param name="filtroChamado">filtro para buscar o chamado</param>
        /// <returns>Detalhe do Chamado</returns>
        Task<DetalheChamadosResultViewModel> DetalheChamado(FiltroChamadoComumViewModel filtroChamado);

        /// <summary>
        /// Fechar chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados fechamento chamado</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> FecharChamado(FecharChamadoViewModel modeloEntrada);

        /// <summary>
        /// Iniciar atendimento do chamado
        /// </summary>
        /// <param name="modeloEntrada">Dados chamado para iniciar atendimento</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> IniciarAtendimentoChamado(IniciarAtendimentoChamadoViewModel modeloEntrada);

        /// <summary>
        /// Registrar progresso de atendimento do chamado com comentários
        /// </summary>
        /// <param name="registrarProgressoChamadoViewModel">Registar progresso view model</param>
        /// <returns>Resultado registro de progresso</returns>
        Task<RegistrarProgressoResultViewModel> RegistrarProgresso(RegistrarProgressoChamadoViewModel registrarProgressoChamadoViewModel);

        /// <summary>
        /// Remover anexo do chamado
        /// </summary>
        /// <param name="idAnexo">Id do Anexo</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> RemoverAnexoChamado(int idAnexo);

        /// <summary>
        /// Salvar edição do chamado
        /// </summary>
        /// <param name="chamado">Dados do Chamado</param>
        /// <returns>Detalhe do chamado</returns>
        Task<DetalheChamadosResultViewModel> SalvarEdicaoChamado(ChamadoViewModel chamado);
    }
}