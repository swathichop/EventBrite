using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService _service;
        public EventCatalogController(IEventCatalogService service)
        {
            _service = service;
        }
    
        public async Task<IActionResult> Index( int? page,int? eventorganizerFilterApplied, int? eventtypeFilterApplied)
        {
            var itemsOnPage = 6;
            var events = await _service.GetEventsAsync(page ?? 0, itemsOnPage, eventorganizerFilterApplied, eventtypeFilterApplied);
            var vm = new EventIndexViewModel
            {
                EventOrganizers = await _service.GetEventOrganizersAsync(),
                EventTypes = await _service.GetEventTypesAsync(),
                EventItems = events.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = events.PageIndex,
                    TotalItems = events.Count,
                    ItemsPerPage = events.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)events.Count / itemsOnPage)
                },
                EventOrganizerFilterApplied = eventorganizerFilterApplied,
                EventTypeFilterApplied = eventtypeFilterApplied
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult About()
        {
            return View();
        }
    }
}
