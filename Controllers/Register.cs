using API_Clever.Models;
using API_Clever.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clever.Controllers;

// [ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    IRegisterService registerService;

    public RegisterController (IRegisterService service){

        registerService = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Register register )
    {
        try
        {
            await registerService.Create(register);
            return Ok("register created");
        }
        catch (ElementoNoEncontradoException ex)
        {
             return NotFound(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await registerService.Delete(id);
            return Ok("register deleted");

        }
        catch (ElementoNoEncontradoException ex)
        {
             return NotFound(ex.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get( Guid id)
    {
        try
        {
            var register = await registerService.Get(id);
            return Ok(register);
        }
        catch (System.Exception ex)
        {
             return NotFound(ex.Message);
        }
    }
}
