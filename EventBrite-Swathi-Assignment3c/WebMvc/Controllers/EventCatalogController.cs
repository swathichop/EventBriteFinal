using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCalatlogService _service;
        public EventCatalogController(IEventCalatlogService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page, int? categoriesFilterApplied, int? organizersFilterapplied)
        {
            var itemsOnPage = 6;
           var events= await  _service.GetEventsAsync(page ?? 0, itemsOnPage,organizersFilterapplied, categoriesFilterApplied);
            var vm = new EventCatalogIndexViewModel
            {
                Categories = await _service.GetEventCategoriesAsync(),
                Organizers = await _service.GetEventOrganizersAsync(),
                Events = events.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = events.PageIndex,
                    TotalItems = events.Count,
                    ItemsPerPage = events.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)events.Count / itemsOnPage)
                },
                CategoriesFilterApplied = categoriesFilterApplied,
                OrganizersFilterApplied = organizersFilterapplied
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
