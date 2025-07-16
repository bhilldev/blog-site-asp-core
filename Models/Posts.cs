namespace BlogSiteAPI.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }
    }
}
