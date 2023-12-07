using Chamados.Application.ViewModels.Dashboard;
using Chamados.Domain.Entity;
using Core.Application.UseCases;
using Core.Domain.Interfaces.Repositories;
using Core.Extensions;

namespace Chamados.Domain.UseCases.Dashboard
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class DashboardUseCase<TResult> : UseCase<FiltroComumViewModel, TResult>
    {
        private readonly IEntityRepository<ChamadoEntity> _chamadoRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        protected DashboardUseCase(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _chamadoRepository = serviceProvider.GetRequiredService<IEntityRepository<ChamadoEntity>>();
        }

        /// <summary>
        ///
        /// </summary>
        protected IEntityRepository<ChamadoEntity> ChamadoRepository => _chamadoRepository;

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected override async Task<TResult> ExecuteInternal(FiltroComumViewModel entry)
        {
            var chamados = this.ChamadoRepository.GetAll(t => t.DtReg.Year == entry.DataCorrente.Year);

            return await ProcessarChamados(chamados, entry);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="chamados"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        protected abstract Task<TResult> ProcessarChamados(IEnumerable<ChamadoEntity> chamados, FiltroComumViewModel entry);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entry"></param>
        protected override void ValidateEntry(FiltroComumViewModel entry)
        {
            base.ValidateEntry(entry);
        }
    }
}