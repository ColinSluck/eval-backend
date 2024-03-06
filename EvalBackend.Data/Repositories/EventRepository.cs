using EvalBackend.Domain.models;

namespace EvalBackend.Data.Repositories;

public class EventRepository
{
    private readonly EvalBackendDbContext _context;
    public EventRepository(EvalBackendDbContext context)
    {
        _context = context;
    }
    
    public void AddEvent(Event newEvent)
    {
        _context.Event.Add(newEvent);
        _context.SaveChanges();
    }
}