using Infrastructure.Enums;

namespace Infrastructure.Abstract
{
    public interface IScraper
    {
        string FindOccurences(string keywords, string url, int numberOfPages, SearchEngines searchEngine);
    }
}