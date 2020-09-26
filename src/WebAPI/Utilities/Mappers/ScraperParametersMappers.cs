using Core.Models;
using WebAPI.Models;

namespace WebAPI.Utilities.Mappers
{
    public static class ScraperParametersMappers
    {
        public static ScrapingServiceParameters ToServiceParameters(ScrapingParameters parameters) =>
            new ScrapingServiceParameters
            {
                Keywords = parameters.Keywords,
                Url = parameters.Url,
                NumberOfPages = parameters.NumberOfPages,
                SearchEngine = parameters.SearchEngine
            };
    }
}