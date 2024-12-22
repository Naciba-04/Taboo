using AutoMapper;
using Taboo.DAL;
using Taboo.DTOs.Games;
using Taboo.Entities;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements;

public class GameService(TabooDbContext _context,IMapper _mapper) : IGameService
{
    public async Task<Guid> AddAsync(GameCreateDto dto)
    {
        var entity=_mapper.Map<Game>(dto);
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }
}
