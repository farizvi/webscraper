using Core.Models;

namespace Core.Abstract
{
    public interface IScrapingService
    {
        string ScrapData(ScrapingServiceParameters serviceParameters);
    }
}