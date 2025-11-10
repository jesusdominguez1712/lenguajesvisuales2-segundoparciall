using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ArchivoCliente> ArchivosClientes { get; set; }
    public DbSet<LogApi> LogsApi { get; set; }
}
