namespace EventCatalogAPI.Domain
{
    public class EventItem
    {
        /*
         *   Event { Id Not null Identity, Name string(100), Desc string(500) ,
         *   Price double, Location Address string(100) ,City string (50), 
         *   state string(50), Zipcode int, ImageUrl , Event Start Date - Date , 
         *   Event End Date – Date, Event StartTime – Datetime, EndTime – Datetime, 
         *   Recurring – String(1), EventDuration – int, TicketsAvailable – int, 
         *   Organizer Id – Foreign key to Event Organizer table,Category Id – Foreign key to Category table*/

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
        public virtual EventType EventType { get; set; }
        public virtual EventOrganizer EventOrganizer { get; set; }


    }
}
