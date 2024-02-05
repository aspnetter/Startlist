namespace Api.Models;

public record EntryFilterCriteria
{
    public string EventId { get; init; }
    public string RaceId { get; init; }
    
    // Packed this in a type as we might want more parameters that way
    public ParticipantFilter ParticipantInfo { get; init; }
}

public record ParticipantFilter
{
    // TODO: attributes
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? EmailAddress { get; init; }
}

public record ParticipantFieldCriteria
{
    
}