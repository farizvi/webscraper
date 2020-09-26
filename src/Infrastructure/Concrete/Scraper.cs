using System;
using System.Net;
using System.Text.RegularExpressions;
using Infrastructure.Abstract;
using Infrastructure.Enums;
using Infrastructure.Helpers;

namespace Infrastructure.Concrete
{
    public class Scraper : IScraper
    {
        public string FindOccurences(string keywords, string url, int numberofPages, SearchEngines searchEngine)
        {
            if (string.IsNullOrEmpty(keywords) || string.IsNullOrWhiteSpace(keywords))
                throw new Exception("Keywords are required");
            
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url)) 
                throw new Exception("Url is required");
            
            if (numberofPages <= 0) 
                throw new Exception("Search requires at least one page");

            var result = "";
            var occurenceCount = 0;

            var searchUrl = ScraperHelpers.GetSearchUrl(searchEngine);
            var webClient = new WebClient();
		
            for (var i = 1; i <= numberofPages; i++)
            {
                var pageNumber = ScraperHelpers.FormatPageNumber(i);

                var searchUrlWithPageNumber = searchUrl + pageNumber + ".html";
                var htmlData =  webClient.DownloadString(searchUrlWithPageNumber);
			
                var collection = Regex.Matches(htmlData, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);
		
                foreach(Match match in collection)
                {
                    var anchorValue = match.Groups[1].Value;
                    var hrefAttribute = Regex.Match(anchorValue, @"href=\""(.*?)\""", RegexOptions.Singleline);

                    if (!hrefAttribute.Success) continue;
                    
                    var hrefValue = hrefAttribute.Groups[1].Value;
                    var urlValue = Regex.Match(hrefValue, @"^(?:\w+://)?([^/?]*)");
                    var urlFound = urlValue.Groups[0].Value;

                    if (Regex.IsMatch(urlFound, url))
                        occurenceCount++;
                }
			
                result = result.Length == 0 ? occurenceCount.ToString() : result + ", " + occurenceCount;
                occurenceCount = 0;
            }
		
            return result;
        }
    }
}