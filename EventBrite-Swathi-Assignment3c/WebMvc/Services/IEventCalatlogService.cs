using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface IEventCalatlogService
    {
        Task<EventCatalog> GetEventsAsync(int page, int size,int? organizer,int? type);
        Task<IEnumerable<SelectListItem>> GetEventOrganizersAsync();

        Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();
    }
}
