using System;
using Infrastructure.Abstract;
using Infrastructure.Concrete;
using Infrastructure.Enums;
using NUnit.Framework;

namespace WebScraperTests
{
    public class ScraperTests
    {
        private IScraper _scraper;
            
        [SetUp]
        public void Setup()
        {
            _scraper = new Scraper();
        }

        [Test]
        public void ShouldThrowException_WhenKeywords_IsEmpty()
        {
            var exception = Assert.Throws<Exception>(() => _scraper.FindOccurences("", "", 1, SearchEngines.Bing));
            Assert.AreEqual("Keywords are required", exception.Message);
        }
        
        [Test]
        public void ShouldThrowException_WhenUrl_IsEmpty()
        {
            var exception = Assert.Throws<Exception>(() => _scraper.FindOccurences("test keyword", "", 1, SearchEngines.Bing));
            Assert.AreEqual("Url is required", exception.Message);
        }
        
        [Test]
        public void ShouldThrowException_WhenNumberOfPages_IsLessThanOrEqualToZero()
        {
            var exception = Assert.Throws<Exception>(() => _scraper.FindOccurences("test keyword", "http://www.test.com", -1, SearchEngines.Bing));
            Assert.AreEqual("Search requires at least one page", exception.Message);
        }
    }
}