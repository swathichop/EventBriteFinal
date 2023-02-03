# EventBrite
EventCatalogAPI Microservice - To build the website http://eventbrite.com
1. It has 3 domains - EventItems, EventOrganizer, EventTypes:
 a) EventType  - This is to to store the type of Event details like Music, Kids etc 
 b) Event Organizer - This is to to store the Event Organizer details
 c) Event Item - This is to store the Event details like Event Name, Location, Duration,date and time of the event
2. It has 2 controllers - EventCatalogController , EventPicController
    a) EventCatalogController - that fetches the details from each of the above domains
    b) EventPicController - that fetches the image related to the event based on the id
    
3. The above APIs can be tested using the below URLS in POSTMAN:
http://localhost:7044/api/EventCatalog/EventTypes
http://localhost:7044/api/EventCatalog/EventOrganizers
http://localhost:7044/api/EventCatalog/EventItems
http://localhost:7044/api/Eventpic/2
