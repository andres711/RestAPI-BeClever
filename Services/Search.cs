using API_Clever.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Clever.Services;

public class SearchService : ISearchService
{
    private readonly DbLocalContext _context;

    public SearchService(DbLocalContext context)
    {
        _context = context;
    }

    public IEnumerable<Register> Search(DateTime dateFrom, DateTime dateTo, string name, string businessLocation)
    {   
        
        var data = _context.Registers.AsQueryable();
        data = data.Where(e => e.Date >= dateFrom && e.Date <= dateTo);
        if(data.Count() == 0)
        {
            throw new ElementoNoEncontradoException("no hay registros en las fechas indicadas");
        }
        data = data.Where(e => e.Employee.Name.Contains(name));
        if(data.Count() == 0)
        {
            throw new ElementoNoEncontradoException("no hay registros para ese nombre en la fecha especificada");
        }
        data = data.Where(e => e.Location.Country.Contains(businessLocation));
        if(data.Count() == 0)
        {
            throw new ElementoNoEncontradoException("no hay registros en esa sucursal para ese nombre en la fecha especificada");
        }
        var registers = data.ToList();
        return registers;
        
    }
}

public interface ISearchService
{
    IEnumerable<Register> Search(DateTime dateFrom, DateTime dateTo, string name, string businessLocation);
}

