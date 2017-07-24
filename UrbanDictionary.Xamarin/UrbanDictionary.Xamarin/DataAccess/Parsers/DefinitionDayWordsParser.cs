using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.Models;

namespace UrbanDictionary.Xamarin.DataAccess.Parsers
{
    public class DefinitionDayWordsParser : DayWordsBaseParser<DefinitionsData>
    {
        public override DefinitionsData Parse(string data)
        {
            var result = new DefinitionsData();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(data);
            var element = htmlDocument.DocumentNode.Descendants("div").Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "def-panel").ToList();
            var words = ParseWordsOfDay(element);
            result.AddRange(words);

            var paginationNode = htmlDocument.DocumentNode.Descendants("ul").Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "pagination").FirstOrDefault();
            result.HasMoreItems = paginationNode?.InnerText.ToUpperInvariant().Contains("NEXT") ?? false;

            return result;
        }
    }
}
