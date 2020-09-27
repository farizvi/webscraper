using System;
using System.Threading.Tasks;
using Core.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Utilities.Mappers;

namespace WebAPI.Controllers
{
    public class ScrapingController : ApiController
    {
        private readonly IScrapingService _scrapingService;

        public ScrapingController(IScrapingService scrapingService)
        {
            _scrapingService = scrapingService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post(ScrapingParameters parameters)
        {
            try
            {
                var result = await Task.Run(() => 
                    _scrapingService.ScrapData(ScraperParametersMappers.ToServiceParameters(parameters))
                );

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}