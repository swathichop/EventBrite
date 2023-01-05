namespace WebMvc.Infrastructure
{
    public class APIPaths
    {
        public static string GetAllEventTypes(string baseUrl)
        {
            return $"{baseUrl}/eventtypes";
        }
        public static string GetAllEventOrganizers(string baseUrl)
        {
            return $"{baseUrl}/eventorganizers";
        }

        public static string GetAllEventItems(string baseUrl,int page,int take)
        {
            return $"{baseUrl}/items?pageIndex={page}&pageSize={take}"; ;
        }
       
    }
}
