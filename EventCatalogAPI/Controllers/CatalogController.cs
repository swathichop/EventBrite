using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly EventCatalogContext _context;
        private readonly IConfiguration _config;
        public CatalogController(EventCatalogContext context, IConfiguration config)
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
            var Organizers = await _context.EventOrganizers.ToListAsync();
            return Ok(Organizers);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 2)
        {
            var itemsCount = _context.EventItems.LongCountAsync();
            var items = await _context.EventItems
                .OrderBy(e => e.Name)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();
            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Data = items,
                Count = itemsCount.Result
            };

            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item => item.EventImageUrl = item.EventImageUrl.Replace("http://externalcatalogbaseurltobereplaced",
                _config["ExternalBaseUrl"]));
            return items;
        }
    }
}
