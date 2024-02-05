namespace Api.Dto;

public record EntryFilterParams
{
    public string? EventTitle { get; init; }
    public string? RaceTitle { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? EmailAddress { get; init; }
    
    public int PageNumber
    {
        get => _pageNumber ?? DefaultPage;
        init => _pageNumber = value;
    }
    public int PageSize
    {
        get => _pageSize ?? DefaultPageSize;
        init => _pageSize = value;
    }
    
    private const int DefaultPage = 1;
    private const int DefaultPageSize = 20;
    
    private readonly int? _pageNumber;
    private readonly int? _pageSize;
}