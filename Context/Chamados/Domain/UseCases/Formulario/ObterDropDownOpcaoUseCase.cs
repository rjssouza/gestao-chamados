using Chamados.Application.ViewModels.Formulario;
using Chamados.Domain.Entity;
using Chamados.Domain.Entity.Formulario.Opcao;
using Chamados.Domain.Enum;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Formulario
{
    /// <summary>
    /// Caso de uso obter dropdown
    /// </summary>
    public class ObterDropDownOpcaoUseCase : UseCase<FormularioOpcaoEntity, FormularioOpcaoDropDownViewModel>, IUseCase<FormularioOpcaoEntity, FormularioOpcaoDropDownViewModel>
    {
        /// <summary>
        /// Repositório maqunia entity
        /// </summary>
        public readonly IEntityRepository<MaquinaEntity> _maquinaEntity;

        /// <summary>
        /// Repositorio formulário opção
        /// </summary>
        public readonly IEntityRepository<FormularioOpcaoEntity> _opcaoEntityRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public ObterDropDownOpcaoUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _maquinaEntity = serviceProvider.GetRequiredService<IEntityRepository<MaquinaEntity>>();
            _opcaoEntityRepository = serviceProvider.GetRequiredService<IEntityRepository<FormularioOpcaoEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<FormularioOpcaoDropDownViewModel> ExecuteInternal(FormularioOpcaoEntity entry)
        {
            var result = new FormularioOpcaoDropDownViewModel();
            var questaoAnterior = _opcaoEntityRepository.GetAll(t => t.IdProximaQuestao == entry.IdQuestao).FirstOrDefault();
            var maquinas = _maquinaEntity.GetAll(t => t.Liniennummer == GetLineFromText(questaoAnterior?.Texto));
            result.Opcoes = maquinas.Select(t => new Pair(t.Id.ToString(), t.Bezeichnung));

            return Task.FromResult(result);
        }

        /// <summary>
        /// Validação de formulário opção
        /// </summary>
        /// <param name="entry">FormularioOpcaoEntity</param>
        protected override void ValidateEntry(FormularioOpcaoEntity entry)
        {
            base.ValidateEntry(entry);

            if (entry.IdComponente != TipoEnum.DropDown.GetHashCode())
                AddError("IdComponente", "Tipo de componente nao e dropdown");
        }

        private static int GetLineFromText(string? texto)
        {
            return texto switch
            {
                "SPM" => 1,
                "HPDC" => 2,
                "Core Shop" => 3,
                _ => 4,
            };
        }
    }
}