namespace WebMvc.Models
{
    public class EventCatalog
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public long Count { get; set; }

        public IEnumerable<EventItem> Data { get; set; }
    }
}
