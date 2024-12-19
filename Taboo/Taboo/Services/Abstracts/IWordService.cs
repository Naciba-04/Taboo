using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;

namespace Taboo.Services.Abstracts;

public interface IWordService
{
    Task<IEnumerable<WordGetDto>> GetAllAsync();
    Task<WordGetDto> GetByCodeAsync(string text);
    Task CreateAsync(WordCreateDto dto);
    Task UpdateAsync(string text, WordUpdateDto dto);
    Task DeleteAsync(string text);
    Task<WordGetDto> ReadAsync(string text);
}
