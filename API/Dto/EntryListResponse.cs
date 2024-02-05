using Api.Models;

namespace Api.Dto;

public record EntryListResponse
{
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public IEnumerable<EntryListResponseItem> Items 
    {
        get => _items ?? new List<EntryListResponseItem>();
        init => _items = value;
    }

    private readonly IEnumerable<EntryListResponseItem>? _items;
}