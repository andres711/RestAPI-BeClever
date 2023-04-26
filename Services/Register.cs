using API_Clever.Models;
namespace API_Clever.Services;

public class RegisterService : IRegisterService
{
    private readonly DbLocalContext _context;

    public RegisterService( DbLocalContext context)
    {
        _context = context;
    }

    public async Task CreateRegister(Register register)
    {    

            register.Id = Guid.NewGuid();
            register.Date = DateTime.Now;
            await _context.Registers.AddAsync(register);
            await _context.SaveChangesAsync();
            
    }
}

public interface IRegisterService
{
    Task CreateRegister(Register register);
};
