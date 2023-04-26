namespace API_Clever.Models;

public class Employee
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }

    public virtual ICollection<Register> Registers { get; set; }
}

public enum Gender
{
    male,
    female
}
