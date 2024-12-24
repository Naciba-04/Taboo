using AutoMapper;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Profiles;

public class WordProfile : Profile
{
    public WordProfile()
    {
        CreateMap<WordCreateDto, Word>();
        CreateMap<WordUpdateDto, Word>();
        CreateMap<Word, WordGetDto>()
            .ForMember(d => d.BannedWords, w => w.MapFrom(s => s.BannedWords.Select(bw => bw.Text)));

    }

}
