namespace InfoBoltWebPage.Models;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private HttpClientWrapper _http;

    public CustomAuthenticationStateProvider(HttpClientWrapper httpClient)
    {
        _http = httpClient;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var response = await _http.Send(HttpMethod.Get, "api/Users/GetUser");
        var content = await response.Content.ReadAsStringAsync();
        User? current = content.Length > 2 ? JsonSerializer.Deserialize<User>(content) : null;

        if (current is not null && current.Email != null)
        {
            var claimEmail = new Claim(ClaimTypes.Name, current.Email);
            var claimId = new Claim(ClaimTypes.NameIdentifier, current.Id.ToString());
            var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, claimId }, "serverAuth");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return new AuthenticationState(new ClaimsPrincipal(claimsPrincipal));
        }
        else
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}

