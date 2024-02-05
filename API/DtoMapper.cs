using Api.Dto;
using Api.Models;
using Api.Services;

namespace Api;

public static class DtoMapper
{
    public static EntryFilterCriteria FilterFromParams(EntryFilterParams filterParams)
    {
        return new EntryFilterCriteria {};
    }

    public static EntryListResponseItem EntryListItemToResponse(Entry entry)
    {
        return new EntryListResponseItem();
    }

    public static Entry EntryFromRequest(NewEntryRequest entryRequest)
    {
        throw new NotImplementedException();
    }
}

