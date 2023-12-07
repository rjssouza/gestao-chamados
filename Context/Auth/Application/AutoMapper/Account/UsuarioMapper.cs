using Auth.Application.ViewModels.Account;
using AutoMapper;
using Security.Domain.Entities;

namespace Auth.Application.AutoMapper.Account
{
    internal class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            this.CreateMap<ApplicationUser, RegisterViewModel>()
                .ReverseMap();

            this.CreateMap<LoginInputModel, RegisterViewModel>()
                .ForMember(t => t.ConfirmPassword, opt => opt.MapFrom(t => t.Password));
        }
    }
}