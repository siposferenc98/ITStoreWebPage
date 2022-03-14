namespace InfoBoltWebPage.ViewModels;

public class ProfileVM
{
    public User User { get; set; }
    HttpClientWrapper _http;
    public ProfileVM(HttpClientWrapper httpClientWrapper)
    {
        _http = httpClientWrapper;
        User = new();
    }

    public async Task GetProfile()
    {
        var result = await _http.Send(HttpMethod.Get, $"/api/Users/Profile/{User.Id}");
        if (result is not null)
        {
            User? u = JsonSerializer.Deserialize<User>(await result.Content.ReadAsStringAsync());
            if (u is not null)
            {
                SetValues(u);
            }
        }
    }

    public async Task<HttpResponseMessage> UpdateProfile()
    {
        return await _http.SendWithContent(HttpMethod.Put, $"/api/Users/Profile/{User.Id}",User);
    }

    public async Task<bool> CheckCurrentPassword(string pw)
    {
        if(User.Email is not "")
        {
            var result = await _http.SendWithContent(HttpMethod.Post, $"api/Users/CheckPassword/{User.Email}", pw);
            return bool.Parse(await result.Content.ReadAsStringAsync());
        }
        return false;
    }


    private void SetValues(User u)
    {
        User.Email = u.Email;
        User.Pw = u.Pw;
        User.Role = u.Role;
    }
}

