using Chamados.Application.ViewModels.Formulario;
using Chamados.Application.ViewModels.Formulario.FormularioResposta;
using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Chamados.Domain.Entity.Formulario.Opcao;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Formulario
{
    /// <summary>
    ///
    /// </summary>
    public class SalvarFormularioUseCase : UseCase<FormularioRespostaViewModel, SalvarFormularioResultViewModel>, IUseCase<FormularioRespostaViewModel, SalvarFormularioResultViewModel>
    {
        private readonly IEntityRepository<FormularioOpcaoDicionarioEntity> _formularioOpcaoDicionarioRepository;
        private readonly IEntityRepository<FormularioRespostaEntity> _formularioRespostaRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public SalvarFormularioUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _formularioRespostaRepository = serviceProvider.GetRequiredService<IEntityRepository<FormularioRespostaEntity>>();
            _formularioOpcaoDicionarioRepository = serviceProvider.GetRequiredService<IEntityRepository<FormularioOpcaoDicionarioEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override Task<SalvarFormularioResultViewModel> ExecuteInternal(FormularioRespostaViewModel entry)
        {
            var dicionarioFormularioEntity = this._formularioOpcaoDicionarioRepository.GetAll(t => entry.Respostas.Any(r => r.IdResposta == t.IdFormularioOpcao));
            var entity = this._mapper.Map<FormularioRespostaEntity>(entry);
            entity.DtReg = DateTime.Now;
            this._formularioRespostaRepository.Insert(entity);

            return Task.FromResult(new SalvarFormularioResultViewModel()
            {
                IdFormularioResposta = entity.Id,
                Dicionario = this._mapper.Map<IEnumerable<FormularioOpcaoDicionarioViewModel>>(dicionarioFormularioEntity)
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        protected override void ValidateEntry(FormularioRespostaViewModel entry)
        {
            base.ValidateEntry(entry);

            FormularioId_EhObrigatorio(entry);
            IsValid();
        }

        private void FormularioId_EhObrigatorio(FormularioRespostaViewModel entry)
        {
            var mensagem = "Formulario Id é Obrigatório";
            if (entry.IdFormulario <= 0)
                AddError(mensagem, "IdFormulario");
        }
    }
}