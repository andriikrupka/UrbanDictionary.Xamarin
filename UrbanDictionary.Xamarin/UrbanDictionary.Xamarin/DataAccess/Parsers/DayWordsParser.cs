using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.DataAccess.Parsers
{
    public class DayWordsParser : DayWordsBaseParser<List<WordOfDay>>
    {
        public override List<WordOfDay> Parse(string data)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(data);
            var element = htmlDocument.DocumentNode.Descendants("div").Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "def-panel").ToList();
            return ParseWordsOfDay(element);
        }
    }
}
