using AutoMapper;
using Chamados.Application.ViewModels.Formulario;
using Chamados.Application.ViewModels.Formulario.FormularioResposta;
using Chamados.Domain.Entity.Formulario;
using Chamados.Domain.Entity.Formulario.FormularioResposta;
using Chamados.Domain.Entity.Formulario.Opcao;
using Chamados.Domain.Enum;
using Core.Domain.Interfaces;
using Core.Extensions;
using Core.Utils;

namespace Chamados.Application.AutoMapper
{
    /// <summary>
    ///
    /// </summary>
    public class FormularioMapperProfile : Profile
    {
        /// <summary>
        ///
        /// </summary>
        public FormularioMapperProfile(IServiceProvider provider)
        {
            CreateMap<FormularioOpcaoEntity, FormularioOpcaoViewModel>()
                .ForPath(t => t.ProximaQuestao, opt => opt.MapFrom(t => t.ProximaQuestao))
                .ForPath(t => t.ControlType, opt => opt.MapFrom(t => t.Componente == null ? Enumerations.GetEnumDescription(TipoEnum.RadioButton) : Enumerations.GetEnumDescription((TipoEnum)t.Componente.IdTipo)))
                .ForMember(t => t.DropDownOptions, opt => opt.MapFrom((t, v) =>
                {
                    if (t.IdComponente == TipoEnum.DropDown.GetHashCode())
                    {
                        var carregarOpcaoUseCase = provider.GetRequiredService<IUseCase<FormularioOpcaoEntity, FormularioOpcaoDropDownViewModel>>();
                        var result = carregarOpcaoUseCase.Execute(t).Result;

                        return result.Opcoes;
                    }

                    return null;
                }))
                .ReverseMap();

            CreateMap<FormularioQuestaoEntity, FormularioQuestaoViewModel>()
                .ForPath(t => t.Opcoes, opt => opt.MapFrom(t => t.Opcoes))
                .ReverseMap();

            CreateMap<FormularioRespostaItemViewModel, FormularioRespostaOpcaoEntity>()
                .ForMember(t => t.IdOpcao, opt => opt.MapFrom(t => t.IdResposta))
                .ForMember(t => t.IdQuestao, opt => opt.MapFrom(t => t.IdQuestao))
                .ReverseMap();

            CreateMap<FormularioRespostaEntity, FormularioRespostaViewModel>()
                .ForPath(t => t.Respostas, opt => opt.MapFrom(t => t.Respostas))
                .ReverseMap();

            CreateMap<FormularioOpcaoDicionarioEntity, FormularioOpcaoDicionarioViewModel>()
                .ForMember(t => t.Chave, opt => opt.MapFrom(t => (TipoDicionarioEnum)Convert.ToInt32(t.Chave)))
                .ReverseMap();

            CreateMap<FormularioEntity, FormularioResultViewModel>()
                .ForMember(t => t.Area, opt => opt.MapFrom(t => t.Area != null ? t.Area.Nome : string.Empty))
                .ForMember(t => t.IdFormulario, opt => opt.MapFrom(t => t.Id))
                .ForMember(t => t.PrimeiraQuestao, opt => opt.MapFrom((t, v) =>
                {
                    var primeiraQuestao = t.Questoes?.FirstOrDefault();

                    return primeiraQuestao;
                })).ReverseMap();
        }
    }
}