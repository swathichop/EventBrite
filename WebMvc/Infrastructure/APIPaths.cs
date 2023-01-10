namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class EventCatalog
        {
            public static string GetAllEventTypes(string baseUri)
            {
                return $"{baseUri}/eventTypes";
            }

            public static string GetAllEventOrganizers(string baseUri)
            {
                return $"{baseUri}/eventOrganizers";
            }

            public static string GetAllEventItems(string baseUri, int page, int take, int? organizer, int? type)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if(organizer.HasValue)
                {
                    filterQs = $"eventOrganizerId={organizer.Value}";
                }
                if(type.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"eventCategoryId={type.Value}" :
                        $"{filterQs}&eventCategoryId={type.Value}";
                }
                if(string.IsNullOrEmpty(filterQs))
                {
                    preUri =  $"{baseUri}/eventItems?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseUri}/eventItems/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri;


                
            }
        }
           
    }
}
