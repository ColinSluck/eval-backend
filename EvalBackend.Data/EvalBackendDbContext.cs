using EvalBackend.Domain.models;
using Microsoft.EntityFrameworkCore;

namespace EvalBackend.Data;

public class EvalBackendDbContext : DbContext
{
    public EvalBackendDbContext(DbContextOptions<EvalBackendDbContext> options) : base(options)
    {
    }
    
    public DbSet<Event> Event { get; set; }
}