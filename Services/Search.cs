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

    public async Task<List<Register>> Search(DateTime dateFrom, DateTime dateTo, string name, string country)
    {   
        var findCountry = _context.Locations.Where(location => location.Country.Equals(country)).FirstOrDefault();
        var query = _context.Registers.AsQueryable();
        query = query.Where(r => r.Employee.Name.Contains(name));
        query = query.Where(r => r.IdLocation == findCountry.Id);
        query = query.Where(r => r.Date >= dateFrom && r.Date <= dateTo);
        
        var registers = await query.ToListAsync();
        return registers;

    }
}

public interface ISearchService
{
    Task<List<Register>> Search(DateTime dateFrom, DateTime dateTo, string name, string country);
}