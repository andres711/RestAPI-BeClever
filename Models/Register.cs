namespace API_Clever.Models;

public class Register
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public RegisterType RegisterType { get; set; }
    // public string UbicacionEmpresa { get; set; }
    public Guid IdEmployee { get; set; }
    public Guid IdLocation { get; set; }

    public virtual Employee Employee { get; set; }
    public virtual Location Location { get; set; }
}

public enum RegisterType
{
    checkIn,
    checkOut
}
