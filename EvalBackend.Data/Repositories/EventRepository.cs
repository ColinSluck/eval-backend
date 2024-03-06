using EvalBackend.Domain.models;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<IEnumerable<Event>> GetEvents()
    {
        return await _context.Event.ToListAsync();
    }
    
    public void UpdateEvent(Guid eventId, Event updatedEvent)
    {
        updatedEvent.Id = eventId;
        _context.Update(updatedEvent);
        _context.SaveChanges();
    }
}