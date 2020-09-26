using System;
using Core.Abstract;
using Core.Models;
using Infrastructure.Abstract;
using Infrastructure.Enums;

namespace Core.Concrete
{
    public class ScrapingService : IScrapingService
    {
        private readonly IScraper _scraper;

        public ScrapingService(IScraper scraper)
        {
            _scraper = scraper;
        }
        
        public string ScrapData(ScrapingServiceParameters serviceParameters)
        {
            try
            {
                return _scraper.FindOccurences(
                    serviceParameters.Keywords,
                    serviceParameters.Url,
                    serviceParameters.NumberOfPages,
                    (SearchEngines)Enum.Parse(typeof(SearchEngines), serviceParameters.SearchEngine, true) 
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}