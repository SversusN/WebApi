namespace CustomerService.Helpers;

using Microsoft.EntityFrameworkCore;
using CustomerService.Entities;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration) => Configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<ServiceSal> Services { get; set; }
    public DbSet<Filial> Filials { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Shedule> Shedules  { get; set; }
    public DbSet<ServiceSal> ServiceSal { get; set; }

}