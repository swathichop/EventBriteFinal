using Microsoft.Extensions.Logging;
using System.Security.Principal;

namespace EventCatalogAPI.Domain
{
    public class EventOrganizer
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public string Desc { get; set; }
    }
}
