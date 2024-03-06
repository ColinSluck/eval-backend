using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EvalBackend.Data;

public class EvalBackendDbContextFactory : IDesignTimeDbContextFactory<EvalBackendDbContext>
{
    private readonly string _connectionString = "Server=localhost,1433;Database=eval;User Id=SA;Password=MyPass@word;TrustServerCertificate=True;";

    public EvalBackendDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EvalBackendDbContext>();
        optionsBuilder.UseSqlServer(_connectionString);
        return new EvalBackendDbContext(optionsBuilder.Options);
    }
}