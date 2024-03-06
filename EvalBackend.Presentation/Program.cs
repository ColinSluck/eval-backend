using EvalBackend.Data;
using EvalBackend.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(builder =>
    {
        string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        builder.AddDbContext<EvalBackendDbContext>(
            options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
        
        builder.AddScoped<EventRepository>();
    })
    .Build();

host.Run();