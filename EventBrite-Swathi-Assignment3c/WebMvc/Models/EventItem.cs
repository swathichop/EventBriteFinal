namespace WebMvc.Models
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }

        public Double Price { get; set; }
        public string EventImageUrl { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public DateTime EventStartDateTime { get; set; }

        public DateTime EventEndDateTime { get; set; }

        public int TicketsAvailable { get; set; }
        public int EventTypeId { get; set; }
        public int EventOrganizerId { get; set; }
        public string EventType { get; set; }
        public string EventOrganizer  { get; set; }

    }
}
