using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventIndexViewModel
    {

        public IEnumerable<SelectListItem> EventOrganizers { get; set; }

        public IEnumerable<SelectListItem> EventTypes { get; set; }

        public IEnumerable<EventItem> EventItems { get; set; }

        public PaginationInfo PaginationInfo { get; set; }

        public int? EventOrganizerFilterApplied { get; set; }

        public int? EventTypeFilterApplied { get; set; }
    }
}
