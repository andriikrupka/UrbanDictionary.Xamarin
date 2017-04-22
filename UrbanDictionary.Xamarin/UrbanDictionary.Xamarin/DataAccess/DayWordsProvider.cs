using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.DataAccess.Parsers;
using UrbanDictionary.Xamarin.Models;

namespace UrbanDictionary.Xamarin.DataAccess
{
   
    public class DayWordsProvider : BaseApiProvider, IDayWordsProvider
    {
        private readonly DayWordsParser _dayWordsParser;
        public DayWordsProvider(HttpClient httpClient) 
            : base(httpClient)
        {
            _dayWordsParser = new DayWordsParser();
        }

        public Task<List<WordOfDay>> LoadPageWordsOfDayAsync(int pageNumber = 0)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri($"http://www.urbandictionary.com/?page={pageNumber}");
            return SendAsync(request, _dayWordsParser);
        }

        public Task<DefinitionsData> LoadDefinitionAsync(string relativePath, int pageNumber = 0)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://www.urbandictionary.com/define.php?term=" + relativePath + "&page=" + pageNumber);
            return SendAsync(request, new DefinitionDayWordsParser());
        }

        public Task<List<BrowseWord>> LoadFromCharacterAsync(UrbanSymbol character)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(character.LinkAddress);
            return SendAsync(request, new BrowseParser());
        }
    }
}
