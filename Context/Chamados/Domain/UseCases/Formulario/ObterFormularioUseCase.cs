using Chamados.Application.ViewModels.Formulario;
using Chamados.Domain.Entity.Formulario;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class ObterFormularioUseCase : UseCase<FormularioRequestViewModel, FormularioResultViewModel>, IUseCase<FormularioRequestViewModel, FormularioResultViewModel>
    {
        private readonly IEntityRepository<FormularioEntity> _formularioRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public ObterFormularioUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _formularioRepository = serviceProvider.GetRequiredService<IEntityRepository<FormularioEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<FormularioResultViewModel> ExecuteInternal(FormularioRequestViewModel entry)
        {
            var formularioEntity = _formularioRepository.GetAll(t => t.IdArea == entry.IdArea)
                                                        .FirstOrDefault();

            var result = this._mapper.Map<FormularioResultViewModel>(formularioEntity);

            return Task.FromResult(result);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        protected override void ValidateEntry(FormularioRequestViewModel entry)
        {
            IdArea_IsRequired(entry);

            base.ValidateEntry(entry);
        }

        private void IdArea_IsRequired(FormularioRequestViewModel entry)
        {
            var message = "Area is required";
            if (entry.IdArea <= 0)
                AddError(message, nameof(entry.IdArea));
        }
    }
}