using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebMvc.Services;

namespace WebMvc.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService _service;
        public EventCatalogController(IEventCatalogService service)
        {
            _service = service;
        }
    
        public async Task<IActionResult> Index( int? page)
        {
            var itemsOnPage = 6;
            var events = await _service.GetEventsAsync(page ?? 0, itemsOnPage);
        
            return View();
        }
    }
}
