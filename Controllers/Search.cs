using API_Clever.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clever.Controllers;

// [ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    ISearchService searchService;

    public SearchController(ISearchService service){

        searchService = service;
    }

    [HttpGet]
    public IActionResult Search([FromBody]DateTime dateFrom, DateTime dateTo, string name, string businessLocation)
    {
       
        Console.WriteLine(name);

        try
        {
            var registers = searchService.Search(dateFrom, dateTo, name, businessLocation);
            return Ok(registers);
        }
        catch (System.Exception ex)
        {
             return NotFound(ex.Message);
        }
    }
}
