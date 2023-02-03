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


Assignment3b:

Integrated Webmvc client with EventCatalogAPI where we can see all the list of Events and prices, which can be filtered based on the Event Organizer and Event Type drop downs.
Created TokenServiceAPI for authentication and authorization , integrated with Webmvc client
A database is created to storage user names and passwords and we seed it with the user me@myemail.com.
URL to be used for testing the website that shows the list of Events and the prices: http://localhost:7502
On click of About on the home page it will authenticate and take us to the login page to provide the credentials where it will show the details related to the Token(shows the access token)
Assignment 3c:

Created Cart, Order Microservices and integrated with web MVC client.
We used Redis for in - memory database for CartApi to store items in cart.
For payments in order we used Stripe.
RabbitMq is used for sending messages between microservices. In our project Order is the publisher of the message and Cart is the subscriber.
Url for testing our Event website : http://localhost:7502. After logging in we can add events to the Cart. Followed by check out to place an order payment. we enter user shipping details followed by testing credit card details.
Once the payment is completed, we can check the same in your stripe account. The cart will be empty as well.
Here is the short video about our project: https://www.youtube.com/watch?v=M7FwYyBjY2g
