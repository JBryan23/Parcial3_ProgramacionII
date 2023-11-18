using Microsoft.EntityFrameworkCore;

public class Contextobd : DbContext
{
    public DbSet<Notas> Notas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-1I3C54GG\\SQLEXPRESS;Database=Parcial3;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
    }
}



