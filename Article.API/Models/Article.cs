namespace Article.API.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastUpdate { get; set; }
        public int WriterId { get; set; }

        public Article()
        {

        }

        public Article(int id, string title, DateTime lastUpdate,int WriterId)
        {
            this.Id = id;
            this.Title = title;
            this.LastUpdate = lastUpdate;
            this.WriterId = WriterId;
        }
    }
}
