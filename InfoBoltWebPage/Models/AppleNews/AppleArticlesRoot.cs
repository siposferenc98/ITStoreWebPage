namespace InfoBoltWebPage.Models.AppleNews
{
    public class AppleArticlesRoot
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}
