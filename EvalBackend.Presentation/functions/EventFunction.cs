using System.Net;
using EvalBackend.Data.Repositories;
using EvalBackend.Domain.models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace EvalBackend.Presentation.functions;

public class EventFunction
{
    private readonly EventRepository _eventRepository;
    public EventFunction(EventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    [Function("AddEvent")]
    public async Task<HttpResponseData> AddEvent([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "event")] HttpRequestData req)
    {
        var entity = await req.ReadFromJsonAsync<Event>();
        _eventRepository.AddEvent(entity);
        return req.CreateResponse(HttpStatusCode.Created);
    }
}