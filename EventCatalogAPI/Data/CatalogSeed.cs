using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Data
{
    public class CatalogSeed
    {

        public static void Seed(EventCatalogContext context)
        {
            context.Database.Migrate();

            if(!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetEventTypes());
                context.SaveChanges();
            }

            if(!context.EventOrganizers.Any())
            {
                context.EventOrganizers.AddRange(GetEventOrganizers());
                context.SaveChanges();
            }

            if(!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetEventItems());
                context.SaveChanges();
            }
        }

        private static IEnumerable<EventItem> GetEventItems()
        {
            return new List<EventItem>
            { new EventItem {EventTypeId = 1, EventOrganizerId = 2, 
                Name ="FreeForm Dance Dance",Desc = "Freeform Dance Dance is an open dance for everyone and anyone who wants to move to music. No steps, skill, or choreography is required.", Price = 0, TicketsAvailable =  50, EventStartDateTime = new DateTime(2022,12,26,16,30,0), EventEndDateTime = new DateTime(2022,12,26,17,30,0) , EventImageUrl  = "http://externalcatalogbaseurltobereplaced/api/pic/1" , Address = "Redmond City Hall" , City = "Redmond" , State = "WA", Zipcode = 98052  }
            };
        }

        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>
            { new EventOrganizer {Name = "Yoga School", Desc = "Yoga and meditaition school"},
            new EventOrganizer {Name = "Starbucks", Desc = "Seattle's coffee"}
            
            };
            
        }

        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            { new EventType {Type = "Health"},
            new EventType {Type = "Food & Drink"}
            };
            
        }
    }

}
