using API_Clever.Models;

namespace API_Clever.Services;

public class AverageService : IAverageService
{
    private readonly DbLocalContext _context;

    public AverageService(DbLocalContext context)
    {
        _context = context;
    }

    public List<DataGender> GetAverage(DateTime dateFrom, DateTime dateTo)
    {
        var data = _context.Registers.AsQueryable();
        data = data.Where(e => e.Date >= dateFrom && e.Date<= dateTo);
        if(data.Count() == 0)
        {
            throw new ElementoNoEncontradoException("no hay registros para fecha especificada");
        }
        var total = data.Count();
        var female = data.Where(e => e.Employee.Gender == "female");
        var male = data.Where(e => e.Employee.Gender == "male");
        var femaleAverage = total / female.Count();
        var maleAverage = total / male.Count();

        return new List<DataGender>
        {
            new DataGender(){Gender= "male", Average =femaleAverage},
            new DataGender(){Gender= "female", Average= maleAverage}
        };

    }
}

public interface IAverageService
{
    List<DataGender> GetAverage(DateTime dateFrom, DateTime dateTo);
}

public class DataGender
{
    public string Gender {get;set;}
    public int Average {get;set;}
}