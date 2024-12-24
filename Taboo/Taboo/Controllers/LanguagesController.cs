using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguagesController(ILanguageService _service) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(LanguageCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Created();
    }
    [HttpPut]
    [Route("{code}")]
    public async Task<IActionResult> Update(string code, LanguageUpdateDto dto)
    {
        await _service.UpdateAsync(code, dto);
        return Ok();
    }
    [HttpDelete]
    [Route("{code}")]
    public async Task<IActionResult> Delete(string code)
    {
        await _service.DeleteAsync(code);
        return NoContent();
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        await _service.GetByCodeAsync(code);
        return NoContent();
    }
    [HttpGet]
    [Route("{code}/read")]
    public async Task<IActionResult> Read(string code)
    {
        var result = await _service.ReadAsync(code);
        return Ok(result);
    }
}





