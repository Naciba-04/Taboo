using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordsController(IWordService _service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(WordCreateDto dto)
    {
        await _service.CreateAsync(dto);
        return Ok();
    }
    [HttpPost("AddRange")]
    public async Task<IActionResult> PostMany(IEnumerable<WordCreateDto> dto)
    {
        foreach (var item in dto)
        {

            await _service.CreateAsync(item);
        }
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, WordUpdateDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)

    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();

        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            await _service.GetByIdAsync(id);
            return NoContent();

        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }
    [HttpGet]
    [Route("{id}/read")]
    public async Task<IActionResult> Read(int id)
    {
        try
        {
            var result = await _service.ReadAsync(id);
            return Ok(result);

        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {
                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }

}
