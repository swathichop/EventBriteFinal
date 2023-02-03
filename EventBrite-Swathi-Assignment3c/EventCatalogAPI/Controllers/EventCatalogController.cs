using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        private readonly EventCatalogContext _context;
        private readonly IConfiguration _config;
        public EventCatalogController(EventCatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventOrganizers()
        {
            var eventOrganizers = await _context.EventOrganizers.ToListAsync();
            return Ok(eventOrganizers);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventItems(
            [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6)
        {
            var itemsCount = _context.EventItems.LongCountAsync();
            var items = await _context.EventItems.OrderBy(c => c.Name)
                                            .Skip(pageIndex * pageSize)
                                            .Take(pageSize)
                                             .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count(),
                Data = items,
                Count = itemsCount.Result
            };
            return Ok(model);
        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> EventItems(
            [FromQuery] int? eventCategoryId,
            [FromQuery] int? eventOrganizerId,
           [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6
            )
        {
            var query = (IQueryable<EventItem>)_context.EventItems;
            if(eventCategoryId.HasValue)
            {
                query = query.Where(e => e.EventTypeId == eventCategoryId.Value);
            }
            if(eventOrganizerId.HasValue)
            {
               query =  query.Where(e => e.EventTypeId == eventOrganizerId.Value);
            }
            var itemsCount = query.LongCountAsync();
            var items = await query.OrderBy(c => c.Name)
                                            .Skip(pageIndex * pageSize)
                                            .Take(pageSize)
                                             .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count(),
                Data = items,
                Count = itemsCount.Result
            };
            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item => item.EventImageUrl = item.EventImageUrl
                                     .Replace("http://externalcatalogbaseurltobereplaced",
                                     _config["ExternalBaseUrl"]));
           return items;
        }


       
    }
}

    

