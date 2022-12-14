using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventCatalogAPI.Data
{
    public class EventCatalogSeed
    {
        public static void Seed(EventCatalogContext context)
        {
            context.Database.Migrate();//tables get created and set up migration by using this line.This is important
            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetEventTypes());
                context.SaveChanges();//after adding data its mandatory to save changes
            }
            if (!context.EventOrganizers.Any())
            {
                context.EventOrganizers.AddRange(GetEventOrganizers());
                context.SaveChanges();
            }
            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetEventItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            {
                new EventItem{EventTypeId= 1 ,
                          EventOrganizerId = 1 ,
                          Name = "Kids Winter Concert",
                          Desc = "2023 Season Winter concert for kids ages 8-13" ,
                          Price = 22.50 ,
                          Address = "1213 Disneyland Dr",
                          City = "Anaheim" ,
                          State = "CA" ,
                          EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" ,
                          
                          //EventStartDateTime=
                          //EventEndDateTime=
                          TicketsAvailable = 20 } ,
                new EventItem{EventTypeId = 2 ,
                           EventOrganizerId = 2 ,
                           Name = "Real Estate and Investment",
                          Desc = "Getting ideas and plan for future investments" ,
                          Price = 15.50 ,
                          Address = "Seattle Center",
                          City = "Seattle" ,
                          State = "WA" ,
                          EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" ,
                          //EventStartDate="12/15/2022",
                          
                          TicketsAvailable = 25 } ,
                new EventItem{EventTypeId = 3 ,
                          EventOrganizerId = 3 ,
                          Name = "Art classes",
                          Desc = "Online art classes for kids to learn abstract painting" ,
                          Price = 0 ,
                          Address = "Art for kids hub",
                          City = "Austin" ,
                          State = "Texas" ,
                          EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" ,
                         
                          TicketsAvailable = 25 } ,

                new EventItem{ EventTypeId = 3 ,
                          EventOrganizerId = 1 ,
                          Name = "Enchanted disney show",
                          Desc = "Experience the disney characters live and performing" ,
                          Price = 0 ,
                          Address = "Renton",
                          City = "Renton" ,
                          State = "WA" ,
                          EventImageUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" ,
                         
                          TicketsAvailable = 25 } ,
            };
        }

        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>()
           {
               new EventOrganizer{Name="Disney"},
               new EventOrganizer{Name="Seattle Expo"},
               new EventOrganizer{Name="Theater Arts"}
           };
        }

        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>()
           {
               new EventType{Type="Music"},
               new EventType{Type="Business"},
               new EventType{Type="Performing & Visual Arts"}
           };
        }
    }
}
