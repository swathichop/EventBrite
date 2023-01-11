using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventCatalogService
    {
        Task<EventCatalog> GetEventsAsync(int page, int size);
        Task<IEnumerable<SelectListItem>> GetEventOrganizersAsync();

        Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();

    }
}
