using System.Threading.Tasks;
using Core.Abstract;
using Infrastructure.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Utilities.Mappers;

namespace WebAPI.Controllers
{
    public class ScrapingController : ApiController
    {
        private readonly IScrapingService _scrapingService;
        // private readonly IScraper _scraper;

        public ScrapingController(IScrapingService scrapingService)
        {
            _scrapingService = scrapingService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(ScrapingParameters parameters)
        {
            var result = await Task.Run(() => 
                _scrapingService.ScrapData(ScraperParametersMappers.ToServiceParameters(parameters))
                );

            return Ok(result);
        }
    }
}