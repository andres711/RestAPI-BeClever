using API_Clever.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Clever.Controllers;

// [ApiController]
[Route("api/search")]
public class ControllerSearch : ControllerBase
{
    ISearchService searchService;

    public ControllerSearch(ISearchService service){

        searchService = service;
    }

    [HttpGet]
    public IActionResult Post([FromBody] DateTime dateFrom, DateTime dateTo, string name, string country)
    {
           
        return Ok(searchService.Search(dateFrom,dateTo,name,country));
    }
}
