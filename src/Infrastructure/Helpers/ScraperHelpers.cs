using Infrastructure.Enums;

namespace Infrastructure.Helpers
{
    public static class ScraperHelpers
    {
        public static string FormatPageNumber(int pageNumber) =>
            pageNumber < 10 ? ("0" + pageNumber) : pageNumber.ToString();
        
        public static string GetSearchUrl(SearchEngines searchEngine) =>
            searchEngine switch
            {
                SearchEngines.Bing => "https://infotrack-tests.infotrack.com.au/Bing/Page",
                SearchEngines.Google => "https://infotrack-tests.infotrack.com.au/Google/Page",
                _ => ""
            };
    }
}