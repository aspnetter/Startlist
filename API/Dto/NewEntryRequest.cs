namespace Api.Models;

public record NewEntryRequest
{
    public string EventId { get; set; }
    public string EmailAddress { get; }
}