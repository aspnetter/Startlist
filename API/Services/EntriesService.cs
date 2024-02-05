using Api.Models;
using Api.Repository;

namespace Api.Services;

public interface IEntriesService
{
    (IEnumerable<Entry>, int) ListEntriesByCriteria(EntryFilterCriteria filter, int pageSize, int pageNumber);
    
    // only these two parameters as usually one participant would only do one race per event, and their email is always required and unique
    bool EntryExists(string eventId, string emailAddress);
    void AddEntry(Entry entry);
}

public class EntriesService: IEntriesService
{
    private readonly IEntriesRepository _repository;

    public EntriesService(IEntriesRepository repository)
    {
        _repository = repository;
    }
    public (IEnumerable<Entry>, int) ListEntriesByCriteria(EntryFilterCriteria filter, int pageSize, int pageNumber)
    {
        return _repository.ListEntries(filter.EventId, filter.RaceId, filter.ParticipantInfo, pageSize, pageNumber);
    }

    public bool EntryExists(string eventId, string emailAddress)
    {
        var entry = _repository.GetEntry(eventId, emailAddress);

        return entry != null;
    }

    public void AddEntry(Entry entry)
    {
        _repository.AddEntry(entry);
    }
}