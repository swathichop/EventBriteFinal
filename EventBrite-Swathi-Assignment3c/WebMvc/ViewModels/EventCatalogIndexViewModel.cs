using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventCatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Organizers { get; set; }

        public IEnumerable<EventItem> Events { get; set; }

        public PaginationInfo PaginationInfo { get; set; }

        public int? OrganizersFilterApplied { get; set; }

        public int? CategoriesFilterApplied { get; set; }
    }
}
