using Microsoft.EntityFrameworkCore;

namespace virtualization.Data;

public class MyDbContext: DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     var POSTGRES_USER = Environment.GetEnvironmentVariable("POSTGRES_USER");
    //     var POSTGRES_PASSWORD = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    //     var POSTGRES_DB = Environment.GetEnvironmentVariable("POSTGRES_DB");
    //     Console.WriteLine(POSTGRES_PASSWORD + "  ++++++++++++++++");
    //     optionsBuilder.UseNpgsql($"Host=db;Port=5432;Database={POSTGRES_DB};Username={POSTGRES_USER};Password={POSTGRES_PASSWORD};");
    // }

    public DbSet<User> Users => Set<User>();   
}