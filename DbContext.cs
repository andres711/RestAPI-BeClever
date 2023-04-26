using API_Clever.Models;
using Microsoft.EntityFrameworkCore;

public class DbLocalContext : DbContext
{
    public DbLocalContext(DbContextOptions<DbLocalContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Register> Registers { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Employee> employees = new List<Employee>();

        employees.Add(new Employee() { Id = Guid.Parse("e4af117d-8ed0-499f-a666-a112713b7f6d"), Name = "Laura Gomez", Gender = "female" });
        employees.Add(new Employee() { Id = Guid.Parse("f4af117d-8ed0-499f-a666-a112713b7f6c"), Name = "Andres Benitez", Gender = "male" });
        employees.Add(new Employee() { Id = Guid.Parse("3630316a-9c40-45c1-90b2-3c52e591480e"), Name = "Juan Araujo", Gender = "male" });
        employees.Add(new Employee() { Id = Guid.Parse("f01a21d4-5b17-4a49-ae54-d56b73b31d69"), Name = "Maria Casal", Gender = "female" });

        modelBuilder.Entity<Employee>(employee =>
        {
            employee.ToTable("Employee");

            employee.HasKey(p => p.Id);

            employee.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            employee.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10);

            employee.HasData(employees);
        });

        modelBuilder.Entity<Register>(register =>
        {
            register.ToTable("Register");

            register.HasKey(p => p.Id);

            register.Property(e => e.Date);

            register.Property(e => e.RegisterType)
                .IsRequired()
                .HasMaxLength(10);

            register.HasOne(d => d.Employee)
                .WithMany(p => p.Registers)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrosIngresoEgreso_Empleados");

            register.HasOne(d => d.Location)
                .WithMany(p => p.Registers)
                .HasForeignKey(d => d.IdLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrosIngresoEgreso_Sucursales");
        });

        List<Location> locations = new List<Location>();
        locations.Add(new Location(){Id=Guid.Parse("220a7453-ff4f-4af2-ba57-56f7daa08534"),Country="argentina"});
        locations.Add(new Location(){Id=Guid.Parse("f2423a4b-ff4c-4093-827a-407452a5d75a"), Country="españa"});
        locations.Add(new Location(){Id=Guid.Parse("304c5c44-53c1-42bc-bfc2-e0c5731c41d2"),Country = "brasil"});
        modelBuilder.Entity<Location>(location =>
        {
            location.ToTable("Location");

            location.HasKey(p => p.Id);

            location.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(50);
            location.HasData(locations);
        });
    }
}

