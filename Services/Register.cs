using API_Clever.Models;
namespace API_Clever.Services;

public class RegisterService : IRegisterService
{
    private readonly DbLocalContext _context;

    public RegisterService( DbLocalContext context)
    {
        _context = context;
    }

    public async Task Create(Register register)
    {    

            Console.WriteLine(register.IdEmployee);
            var employee = await _context.Employees.FindAsync(register.IdEmployee);
            
            var location = await _context.Locations.FindAsync(register.IdLocation);

            if( employee == null || location == null)
            {
                throw new ElementoNoEncontradoException("Location or employee are not registered in database");
            }
            else
            {
                register.Date = DateTime.Now;
                await _context.Registers.AddAsync(register);
                await _context.SaveChangesAsync();
               
            }
            
    }
    public async Task<Register> Get(Guid id)
    {
        var regsiter = await _context.Registers.FindAsync(id);

        if(regsiter == null)
        {
            throw new ElementoNoEncontradoException("regsiter not found");
        }
        else
        {
            return regsiter;
        }
    }
    public async Task Delete(Guid id)
    {
        var register = await _context.Registers.FindAsync(id);

        if(register == null)
        {
            throw new ElementoNoEncontradoException("register not found");
        }
        else
        {
            _context.Registers.Remove(register);
            await _context.SaveChangesAsync();
        }

    }
}

public interface IRegisterService
{
    Task Create(Register register);
    Task Delete(Guid id);
    Task<Register> Get(Guid id);
};

public class ElementoNoEncontradoException : Exception
{
    public ElementoNoEncontradoException(string message) : base(message)
    {
    }
}