using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.Language;
using Taboo.Exceptions.Word;
using Taboo.Services.Abstracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Taboo.Services.Implements;

public class WordService(TabooDbContext _context, IMapper _mapper) : IWordService
{

    public async Task<int> CreateAsync(WordCreateDto dto)
    {

        if (await _context.Words.AnyAsync(w => w.LanguageCode == dto.Language && w.Text == dto.Text))
            throw new WordExistException();
        if (dto.BannedWords.Count() != 6)
            throw new InvalidBannedWordCountException();
        Word word = new Word
        {
            LanguageCode = dto.Language,
            Text = dto.Text,
            BannedWords = dto.BannedWords.Select(x => new BannedWord
            {
                Text = x
            }).ToList()
        };

        await _context.Words.AddAsync(word);
        await _context.SaveChangesAsync();
        return word.Id;
    }

    public async Task<IEnumerable<WordGetDto>> GetAllAsync()
    {
        var words = await _context.Words.Include(x=>x.BannedWords).ToListAsync();

        return _mapper.Map<IEnumerable<WordGetDto>>(words);
    }
    
    async Task<Word?> _getById(int id)
        => await _context.Words.FindAsync(id);

    public async Task DeleteAsync(int id)
    {
        var data = await _getById(id);
        if (data == null) throw new WordNotFoundException();

        _context.Words.Remove(data);

        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(int id, WordUpdateDto dto)
    {
        var data = await _getById(id);
        if (data == null) throw new WordNotFoundException();
        _mapper.Map(dto, data);
        await _context.SaveChangesAsync();
    }

    public async Task<WordGetDto> GetByIdAsync(int id)
    {
        var data = await _getById(id);
        if (data == null) throw new WordNotFoundException();
        return _mapper.Map<WordGetDto>(data);

    }

    public async Task<WordGetDto> ReadAsync(int id)
    {
        var data = await _getById(id);
        if (data == null) throw new WordNotFoundException();
        return _mapper.Map<WordGetDto>(data);
    }
}
