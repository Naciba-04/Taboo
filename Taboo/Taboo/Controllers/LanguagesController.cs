using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController(ILanguageService _service) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(LanguageCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Created();
        }
        [HttpPut]
        [Route("{code}")]
        public async Task<IActionResult> Update(string code,LanguageCreateDto dto)
        {
            await _service.UpdateAsync(code,dto);
            return Ok();
        }
        [HttpDelete]
        [Route("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            await _service.DeleteAsync(code);
            return NoContent();
        }
    }
    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //   
    //}


}

