namespace API_Clever.Models;

public class Location
{
    public Guid Id { get; set; }
    // public string Nombre { get; set; }
    public string Country { get; set; }

    public virtual ICollection<Register> Registers { get; set; }
}

