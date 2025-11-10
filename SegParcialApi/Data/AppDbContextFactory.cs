using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // Leer configuración desde appsettings.json
        var configuration = new ConfigurationBuilder()
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../SegParcialApi");
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            

        // Obtener cadena de conexión
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        // Configurar DbContextOptions
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
