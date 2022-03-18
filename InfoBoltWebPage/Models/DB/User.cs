namespace InfoBoltWebPage.Models.DB;

public class User
{
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Pw { get; set; }
    public int Role { get; set; }
    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

}

