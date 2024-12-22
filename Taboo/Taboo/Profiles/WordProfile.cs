using AutoMapper;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Profiles;

public class WordProfile:Profile
{
    public WordProfile()
    {  
    CreateMap<Word,WordGetDto>();
    }

}
