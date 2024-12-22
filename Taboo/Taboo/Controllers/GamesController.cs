using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Games;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGameService _service) : ControllerBase
{

	[HttpGet]
	public async Task<IActionResult> Create(GameCreateDto dto)
	{
		return Ok(await _service.AddAsync(dto));
	}

}
