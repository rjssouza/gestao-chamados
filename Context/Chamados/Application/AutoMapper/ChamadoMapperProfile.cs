using AutoMapper;
using Chamados.Application.ViewModels.Chamado;
using Chamados.Domain.Entity;
using Chamados.Domain.Entity.Chamado;

namespace Chamados.Application.AutoMapper
{
    /// <summary>
    ///
    /// </summary>
    public class ChamadoMapperProfile : Profile
    {
        /// <summary>
        ///
        /// </summary>
        public ChamadoMapperProfile()
        {
            CreateMap<ProgressoChamadoEntity, RegistrarProgressoChamadoViewModel>()
                .ReverseMap();

            CreateMap<ProgressoChamadoEntity, ProgressoChamadoViewModel>()
                .ReverseMap();

            CreateMap<ChamadoTimeEntity, ChamadoTimeViewModel>()
                .ReverseMap();
        }
    }
}