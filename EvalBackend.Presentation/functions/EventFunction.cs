using System.Net;
using System.Text;
using System.Text.Json;
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
    public async Task<HttpResponseData> AddEvent([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "events")] HttpRequestData req)
    {
        var entity = await req.ReadFromJsonAsync<Event>();
        _eventRepository.AddEvent(entity);
        return req.CreateResponse(HttpStatusCode.Created);
    }
    
    [Function("UpdateEvent")]
    public async Task<HttpResponseData> UpdateEvent([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "events/{eventId:guid}")] HttpRequestData req, Guid eventId)
    {
        var entity = await req.ReadFromJsonAsync<Event>();
        _eventRepository.UpdateEvent(eventId, entity);
        return req.CreateResponse(HttpStatusCode.OK);
    }
    
    [Function("GetEvents")]
    public async Task<HttpResponseData> GetEvents([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "events")] HttpRequestData req)
    {
        var result = await _eventRepository.GetEvents();
        
        var httpResponseData = req.CreateResponse(HttpStatusCode.OK);

        httpResponseData.Headers.Add("Content-Type", "application/json");
        
        httpResponseData.WriteString(JsonSerializer.Serialize(result), Encoding.UTF8);
        
        return httpResponseData;
    }
    
    
}