namespace InfoBoltWebPage.Models;

public class HttpClientWrapper
{
    private HttpClient _httpClient;

    /// <summary>
    /// Wrapper for Httprequest SetBrowserRequestCredentials
    /// </summary>
    /// <param name="method"></param>
    /// <param name="path"></param>
    /// <param name="content"></param>
    public HttpClientWrapper()
    {
        _httpClient = new() { BaseAddress = new Uri("https://localhost:7117") };
    }

    public async Task<HttpResponseMessage> SendWithContent<T>(HttpMethod method, string path, T content)
    {
        try
        {
            HttpRequestMessage request = new(method,path);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            request.Content = new StringContent(JsonSerializer.Serialize(content),Encoding.UTF8,"application/json");
            
            return await _httpClient.SendAsync(request);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
            return new HttpResponseMessage();
        }
    }

    public async Task<HttpResponseMessage> Send(HttpMethod method, string path)
    {
        try
        {
            HttpRequestMessage request = new(method, path);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            return await _httpClient.SendAsync(request);
        }
        catch(HttpRequestException ex)
        {
            Console.WriteLine(ex.Message);
            return new HttpResponseMessage();
        }
    }
}

