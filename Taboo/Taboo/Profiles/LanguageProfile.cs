using AutoMapper;
using Taboo.DTOs.Languages;
using Taboo.Entities;

namespace Taboo.Profiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<LanguageCreateDto, Language>()
            .ForMember(l => l.Icon, d => d.MapFrom(t => t.IconUrl));
        CreateMap<Language, LanguageGetDto>();

    }
}
