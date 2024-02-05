using System.Text.Json.Serialization;

namespace Api.Models;

public record Entry
{
    public string Id { get; init; }
    public string EventId { get; init; }
    public string RaceId { get; init; }
    public string TicketId { get; init; }
    public string EventTitle { get; init; }
    public string RaceTitle { get; init; }
    public string TicketTitle { get; init; }

    public List<Field> Fields
    {
        get => _fields ?? new List<Field>();
        init => _fields = value;
    }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }

    private readonly List<Field>? _fields;
}

public record Field
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Value { get; init; }
}