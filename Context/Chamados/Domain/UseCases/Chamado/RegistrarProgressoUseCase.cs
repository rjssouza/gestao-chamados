using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Chamados.Domain.Entity.Chamado;
using Core.Application.Seguranca;
using Core.Application.UseCases;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Chamado
{
    /// <summary>
    ///
    /// </summary>
    public class RegistrarProgressoUseCase : UseCase<RegistrarProgressoChamadoViewModel, RegistrarProgressoResultViewModel>, IUseCase<RegistrarProgressoChamadoViewModel, RegistrarProgressoResultViewModel>
    {
        private readonly IUseCase<AdicionarComentarioChamadoViewModel, DetalheChamadosResultViewModel> _adicionarComentarioUseCase;
        private readonly IEntityRepository<ChamadoHistoricoEntity> _chamadoHistoricoRepository;

        /// <summary>
        ///
        /// </summary>
        private readonly UserInfo _currentUser;

        /// <summary>
        ///
        /// </summary>
        private readonly IEntityRepository<ProgressoChamadoEntity> _progressoChamadoRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        public RegistrarProgressoUseCase(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            _currentUser = new UserInfo(serviceProvider.GetRequiredService<Microsoft.AspNetCore.Http.IHttpContextAccessor>().HttpContext.User);
            _progressoChamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ProgressoChamadoEntity>>();
            _adicionarComentarioUseCase = serviceProvider.GetRequiredService<IUseCase<AdicionarComentarioChamadoViewModel, DetalheChamadosResultViewModel>>();
            _chamadoHistoricoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoHistoricoEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected override async Task<RegistrarProgressoResultViewModel> ExecuteInternal(RegistrarProgressoChamadoViewModel entry)
        {
            await _adicionarComentarioUseCase.Execute(new AdicionarComentarioChamadoViewModel()
            {
                IdChamado = entry.IdChamado,
                Comentario = entry.Comentario
            });
            var progressos = _progressoChamadoRepository.GetAll(t => t.IdChamado == entry.IdChamado);
            var entity = _mapper.Map<ProgressoChamadoEntity>(entry);
            entity.UsAtendente = _currentUser.UserName;
            entity.DtReg = DateTime.Now;
            _progressoChamadoRepository.Insert(entity);
            _chamadoHistoricoRepository.Insert(new ChamadoHistoricoEntity()
            {
                IdChamado = entry.IdChamado,
                Para = entry.Comentario,
                De = progressos.Select(t => t.Comentario).LastOrDefault(),
                DtReg = DateTime.Now
            });

            return new RegistrarProgressoResultViewModel(entity.IdChamado, entity.Id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        protected override void ValidateEntry(RegistrarProgressoChamadoViewModel entry)
        {
            base.ValidateEntry(entry);

            Percentual_PercentualDeveEstarEntre0e100(entry);

            IsValid();
        }

        private void Percentual_PercentualDeveEstarEntre0e100(RegistrarProgressoChamadoViewModel entry)
        {
            if (entry.Percentual < 0 || entry.Percentual > 100)
                AddError("Percentual", "Percentual de atendimento precisa estar entre 0 e 100");
        }
    }
}