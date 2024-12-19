using Taboo.DTOs.Languages;

namespace Taboo.Services.Abstracts;

public interface ILanguageService
{
    Task <IEnumerable<LanguageGetDto>>GetAllAsync();
    Task<LanguageGetDto> GetByCodeAsync(string code);
    Task CreateAsync(LanguageCreateDto dto);
    Task UpdateAsync(string code, LanguageUpdateDto dto);
    Task DeleteAsync(string code);
    Task<LanguageGetDto> ReadAsync(string code);

}
