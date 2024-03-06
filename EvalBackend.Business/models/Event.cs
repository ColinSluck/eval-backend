using System.ComponentModel.DataAnnotations;

namespace EvalBackend.Domain.models;

public class Event
{
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime Date { get; set; }
    public string Location { get; set; } = default!;
}