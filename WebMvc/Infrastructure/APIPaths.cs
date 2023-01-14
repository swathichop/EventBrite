namespace WebMvc.Infrastructure
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

            public static string GetAllEventItems(string baseUrl, int page, int take, int? eventorganizer, int? eventtype
                )
            {
                // return $"{baseUrl}/eventitems?pageIndex={page}&pageSize={take}"; 
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (eventorganizer.HasValue)
                {
                    filterQs = $"eventOrganizerId={eventorganizer.Value}";
                }
                if (eventtype.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"EventTypeId={eventtype.Value}" :
                         $"{filterQs}&eventTypeId={eventtype.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUrl}/eventitems?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseUrl}/eventitems/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri;
            }
        }
        
       
    }
}
