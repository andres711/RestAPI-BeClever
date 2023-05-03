using API_Clever.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clever.Controllers;

[Route("api/controller")]
public class AverageController : ControllerBase
{
    
    IAverageService averageService;

    public AverageController(IAverageService service )
    {
        averageService = service;
    }

    [HttpGet]
    public IActionResult Get([FromBody]DateTime dateFrom, DateTime dateTo)
    {
        try
        {
            var data = averageService.GetAverage(dateFrom,dateTo);
            return Ok(data);
        }
        catch (System.Exception ex)
        {
             return NotFound(ex.Message);
        }
    }


}