using Api.Dto;
using Api.Models;
using Api.Services;

namespace Api;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("startlist/entries")]
public class StartlistController: ControllerBase
{
    private readonly IEntriesService _entriesService;
    private readonly ILogger _logger;

    public StartlistController(IEntriesService entriesService, ILogger logger)
    {
        _entriesService = entriesService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult ListEntries([FromQuery]EntryFilterParams filterParams)
    {
        try
        {
            var filterCriteria = DtoMapper.FilterFromParams(filterParams);
            var (entries, totalCount) = _entriesService.ListEntriesByCriteria(filterCriteria, filterParams.PageSize, filterParams.PageNumber);

            var pageEntries = entries.ToList();

            if (!pageEntries.Any())
            {
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            }

            return Ok(new EntryListResponse
            {
                Page = filterParams.PageNumber,
                PageSize = filterParams.PageSize,
                TotalCount = totalCount,
                Items = pageEntries.Select(DtoMapper.EntryListItemToResponse)
            });
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e.ToString());

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public IActionResult AddEntry(NewEntryRequest entryRequest)
    {
        try
        {
            if (_entriesService.EntryExists(entryRequest.EventId, entryRequest.EmailAddress))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            var entry = DtoMapper.EntryFromRequest(entryRequest);
            _entriesService.AddEntry(entry);
            
            return new StatusCodeResult(StatusCodes.Status201Created);
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e.ToString());

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}

