namespace BlogWebsite.Models
{
    public class Article : BasicModel
    {
        public int ArticleID { get; set; }

        public string ArticleTitle { get; set; } = null!;

        public string ArticleContent { get; set; } = null!;

        public string? ArticleImage { get; set; }
    }
}
