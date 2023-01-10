namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri, string authorization = null,
            string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PostAsync<T>( string uri, T item,
             string authorization = null,string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item,
             string authorization = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> DeleteAsync(string uri,   string authorization = null, string authorizationMethod = "Bearer");
    }
}
