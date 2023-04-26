using API_Clever.Models;
using API_Clever.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clever.Controllers;

// [ApiController]
[Route("api/register")]
public class ControllerRegister : ControllerBase
{
    IRegisterService registerService;

    public ControllerRegister (IRegisterService service){

        registerService = service;
    }

    [HttpPost]
    public IActionResult Post([FromBody] Register register )
    {
        var newRegister = registerService.CreateRegister(register);   
        return Ok(newRegister);
    }
}
