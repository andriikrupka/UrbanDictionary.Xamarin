using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.DataAccess.Parsers
{
    public class BrowseParser : IParserStrategy<List<BrowseWord>>
    {
        public List<BrowseWord> Parse(string data)
        {
            var list = new List<BrowseWord>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(data);

            var wordsListNode = htmlDocument.DocumentNode.Descendants("ul").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "no-bullet");
            if (wordsListNode != null)
            {
                foreach (var liNode in wordsListNode.Descendants("li"))
                {
                    list.Add(new BrowseWord() { Word = WebUtility.HtmlDecode(liNode.InnerText.Trim()) });
                }
            }

            return list;
        }
    }
}
