using System.Text.Json.Serialization;

namespace API_Clever.Models;

public class Register
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string RegisterType { get; set; }
    // public string UbicacionEmpresa { get; set; }
    public Guid IdEmployee { get; set; }
    public Guid IdLocation { get; set; }
    [JsonIgnore]
    public virtual Employee Employee { get; set; }
    [JsonIgnore]
    public virtual Location Location { get; set; }
}


