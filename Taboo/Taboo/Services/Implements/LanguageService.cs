using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Entities;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements;

public class LanguageService(TabooDbContext _context, IMapper _mapper) : ILanguageService
{
    public async Task CreateAsync(LanguageCreateDto dto)
    {
        var lang = _mapper.Map<Language>(dto);
        await _context.Languages.AddAsync(lang);
        await _context.SaveChangesAsync();  
    }
    public async Task UpdateAsync(string code, LanguageCreateDto dto)
    {
        var lang = await _context.Languages.FirstOrDefaultAsync(l => l.Code == code);

        if (lang == null)
        {
            throw new Exception($"Language with code {code} not found.");
        }
        lang.Name = dto.Name;
        lang.Icon = dto.IconUrl;

        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string code)
    {
        var lang = await _context.Languages.FirstOrDefaultAsync(l => l.Code == code);

        
        if (lang == null)
        {
            throw new Exception($"Language with code {code} not found.");
        }

        _context.Languages.Remove(lang);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
    {
        var lang = await _context.Languages.ToListAsync();

        var langDto = _mapper.Map<IEnumerable<LanguageGetDto>>(lang);

        return langDto;
    }

    public Task<LanguageGetDto> GetByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<LanguageGetDto> ReadAsync(string code)
    {
        throw new NotImplementedException();
    }

    
}
