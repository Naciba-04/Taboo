using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Entities;
using Taboo.Exceptions.Language;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements;

public class LanguageService(TabooDbContext _context, IMapper _mapper) : ILanguageService
{
    public async Task CreateAsync(LanguageCreateDto dto)
    {
        if (await _context.Languages.AnyAsync(x => x.Code == dto.Code))
            throw new LanguageExistException();
        var lang = _mapper.Map<Language>(dto);
        await _context.Languages.AddAsync(lang);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
    {
        var langs = await _context.Languages.ToListAsync();

        return _mapper.Map<IEnumerable<LanguageGetDto>>(langs);

    }

    async Task<Language?> _getByCode(string code)
        => await _context.Languages.FindAsync(code);
    public async Task UpdateAsync(string code, LanguageUpdateDto dto)
    {
        var data = await _getByCode(code);
        if (data == null) throw new LanguageNotFoundException();
         _mapper.Map(dto,data);       
        await _context.SaveChangesAsync();

    }
    public async Task DeleteAsync(string code)
    {
        var data = await _getByCode(code);
        if (data == null) throw new LanguageNotFoundException();

        _context.Languages.Remove(data);

        await _context.SaveChangesAsync();
    }

    public async Task<LanguageGetDto> GetByCodeAsync(string code)
    {
        var data = await _getByCode(code);
        if (data == null) throw new LanguageNotFoundException();
        return  _mapper.Map<LanguageGetDto>(data);
    }

    public async Task<LanguageGetDto> ReadAsync(string code)
    {
        var data = await _getByCode(code);
        if (data == null) throw new LanguageNotFoundException();
        return _mapper.Map<LanguageGetDto>(data);
    }
}
