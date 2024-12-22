using Taboo.DTOs.Games;

namespace Taboo.Services.Abstracts;

public interface IGameService
{
    Task<Guid> AddAsync(GameCreateDto dto);
}
