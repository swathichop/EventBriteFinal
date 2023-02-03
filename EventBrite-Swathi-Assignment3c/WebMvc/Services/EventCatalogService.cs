using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class EventCatalogService : IEventCalatlogService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;

        public EventCatalogService(IConfiguration config,IHttpClient client)
        {
            _httpClient = client;
            _baseUrl = $"{config["EventCatalogUrl"]}/api/EventCatalog";
        }

        public async Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync()
        {
            var eventCategoriesUri = APIPaths.EventCatalog.GetAllEventTypes(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(eventCategoriesUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true,
                }
            };
            var categories = JArray.Parse(dataString);
            foreach(var item in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("type"),
                });

            }
            return items;
        }


        public async Task<IEnumerable<SelectListItem>> GetEventOrganizersAsync()
        {
            var organizersUri = APIPaths.EventCatalog.GetAllEventOrganizers(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(organizersUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected= true,

                }
            };
            var eventOrganizers = JArray.Parse(dataString);
            foreach (var item in eventOrganizers)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("name"),
                });
            }
            return items;
        
        }

        public async Task<EventCatalog> GetEventsAsync(int page, int size, int? organizer, int? type)
        {
           var eventsItemsUri =  APIPaths.EventCatalog.GetAllEventItems(_baseUrl,page,size,organizer,type);
            var datastring = await _httpClient.GetStringAsync(eventsItemsUri);
            return JsonConvert.DeserializeObject<EventCatalog>(datastring);
        }
    }
}
