namespace InfoBoltWebPage.ViewModels;

public class LoginVM
{
    public User User = new();
    HttpClientWrapper _http;

    public LoginVM(HttpClientWrapper httpClient)
    {
        _http = httpClient;
    }

    public async Task<HttpResponseMessage> LoginUser()
    {
        return await _http.SendWithContent(HttpMethod.Post,"api/Users/Login",User);
    }
}

