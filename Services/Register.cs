using API_Clever.Models;
namespace API_Clever.Services;

public class RegisterService : IRegisterService
{
    private readonly DbLocalContext _context;

    public RegisterService( DbLocalContext context)
    {
        _context = context;
    }

    public async Task<Register> CreateRegister(Register register)
    {
         var employee = _context.Employees.Find(register.IdEmployee);
         var location = _context.Locations.Find(register.IdLocation);

        
            var nuevoRegistro = new Register()
            {
                IdEmployee = employee.Id,
                Date = DateTime.Now,
                RegisterType = register.RegisterType,
                IdLocation = location.Id
            };
            _context.Registers.Add(nuevoRegistro);
            await _context.SaveChangesAsync();
            return nuevoRegistro;
      
       

    }
}

public interface IRegisterService
{
    Task<Register> CreateRegister(Register register);
};
