using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.Language;
using Taboo.Exceptions.Word;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements;

public class WordService(TabooDbContext _context,IMapper _mapper) : IWordService
{
    public async Task CreateAsync(WordCreateDto dto)
    {
       
            if (await _context.Words.AnyAsync(w => w.Language == dto.Language && w.Text==dto.Text))
                throw new WordExistException();
            var lang = _mapper.Map<Word>(dto);
            await _context.Words.AddAsync(lang);
            await _context.SaveChangesAsync();
        
    }

    public Task DeleteAsync(string text)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WordGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<WordGetDto> GetByCodeAsync(string text)
    {
        throw new NotImplementedException();
    }

    public Task<WordGetDto> ReadAsync(string text)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(string text, WordUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
