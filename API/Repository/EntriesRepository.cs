using System.Text.Json;
using Api.Models;

namespace Api.Repository;

public interface IEntriesRepository
{
    Entry? GetEntry(string eventId, string emailAddress);
    (IEnumerable<Entry>, int) ListEntries(string? eventId, string? raceId, ParticipantFilter? participantFilter, int pageSize, int pageNumber);
    void AddEntry(Entry entry);
}

public class EntriesRepository: IEntriesRepository
{
    private static readonly List<Entry> Entries;
    
    private const string EmailFieldId = "emailAddress";
    private const string DataFilePath = "Data\\startlists.json";
    
    static EntriesRepository()
    {
        var startListJson = File.ReadAllText(DataFilePath);
        Entries =  JsonSerializer.Deserialize<List<Entry>>(startListJson) ?? new List<Entry>();
    }
    public Entry? GetEntry(string eventId, string emailAddress)
    {
        return Entries.FirstOrDefault(e => e.EventId == eventId && GetFieldValue(e, EmailFieldId) == emailAddress);
    }

    public (IEnumerable<Entry>, int) ListEntries(string? eventId, string? raceId, ParticipantFilter? participantFilter, int pageSize, int pageNumber)
    {
        var filtered = Entries.Where(
            e => !string.IsNullOrWhiteSpace(eventId) && e.EventId == eventId &&
                 !string.IsNullOrWhiteSpace(raceId) && e.RaceId == raceId
        ).ToList();

       /* if (participantFilter != null && participantFilter.Fields.Any())
        {
            
        }*/
       
       var filteredCount = filtered.Count();
       var skip = (pageNumber - 1) * pageSize;
       
       filtered = filtered.Skip(skip).Take(pageSize).ToList();

       return (filtered, filteredCount);
    }

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
        
        var json = JsonSerializer.Serialize(Entries);
        File.WriteAllText(DataFilePath, json);
    }

    private string GetFieldValue(Entry e, string fieldId)
    {
        return e.Fields.FirstOrDefault(f => f.Id == fieldId)?.Value;
    }
}