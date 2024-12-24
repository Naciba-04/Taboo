using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;

namespace Taboo.Services.Abstracts;

public interface IWordService
{
    Task<IEnumerable<WordGetDto>> GetAllAsync();
    Task<int>CreateAsync(WordCreateDto dto);
    Task UpdateAsync(int id, WordUpdateDto dto);
    Task DeleteAsync(int id);
    Task<WordGetDto> GetByIdAsync(int id);
    Task<WordGetDto> ReadAsync(int id);

}
