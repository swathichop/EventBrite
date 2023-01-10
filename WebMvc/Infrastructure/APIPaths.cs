﻿namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class EventCatalog
        {
            public static string GetAllEventTypes(string baseUrl)
            {
                return $"{baseUrl}/eventtypes";
            }
            public static string GetAllEventOrganizers(string baseUrl)
            {
                return $"{baseUrl}/eventorganizers";
            }

            public static string GetAllEventItems(string baseUrl, int page, int take)
            {
                return $"{baseUrl}/eventitems?pageIndex={page}&pageSize={take}"; 
            }
        }
        
       
    }
}
