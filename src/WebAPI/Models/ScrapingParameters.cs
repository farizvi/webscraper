namespace WebAPI.Models
{
    public class ScrapingParameters
    {
        public string Keywords { get; set; }

        public string Url { get; set; }

        public int NumberOfPages { get; set; }

        public string SearchEngine { get; set; }
    }
}