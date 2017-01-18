using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.DataAccess
{
    public class DayWordsParser : IParserStrategy<List<WordOfDay>>
    {
        public List<WordOfDay> Parse(string data)
        {
            var result = new List<WordOfDay>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(data);

            var element = htmlDocument.DocumentNode.Descendants("div").Where(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "def-panel").ToList();
            foreach (var htmlNode in element)
            {
                var wordOfDay = new WordOfDay();

                var dayElement = htmlNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "ribbon");
                if (dayElement != null)
                {
                    wordOfDay.DayString = WebUtility.HtmlDecode(dayElement.InnerText.Trim());
                }

                var wordElement = htmlNode.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "word");
                if (wordElement != null)
                {
                    wordOfDay.Word = WebUtility.HtmlDecode(wordElement.InnerText.Trim());

                    if (wordElement.Attributes.Contains("href"))
                    {
                        var hrefValue = wordElement.Attributes["href"].Value;
                        var index = hrefValue.LastIndexOf("defid=", StringComparison.Ordinal);
                        if (index > 0)
                        {
                            wordOfDay.Id = System.Convert.ToInt32(hrefValue.Substring(index + 6));
                        }
                    }
                }
                else
                {
                    continue;
                }

                var soundElement = htmlNode.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "play-sound");
                if (soundElement != null && soundElement.Attributes.Contains("data-urls"))
                {
                    wordOfDay.SoundUrls = soundElement.Attributes["data-urls"].Value;
                }

                var meaningElement = htmlNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "meaning");
                if (meaningElement != null)
                {
                    wordOfDay.Meaning = meaningElement.InnerHtml.Trim();
                }

                var exampleElement = htmlNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "example");
                if (exampleElement != null)
                {
                    wordOfDay.Example = exampleElement.InnerHtml.Trim();
                }

                var contributorElement = htmlNode.Descendants("div").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "contributor");
                if (contributorElement != null)
                {
                    wordOfDay.Contributor = new Contributor();

                    if (contributorElement.ChildNodes.Count == 3)
                    {
                        wordOfDay.Contributor.By = WebUtility.HtmlDecode(contributorElement.ChildNodes[0].InnerText.Trim());
                        wordOfDay.Contributor.Author = WebUtility.HtmlDecode(contributorElement.ChildNodes[1].InnerText.Trim());
                        wordOfDay.Contributor.Data = WebUtility.HtmlDecode(contributorElement.ChildNodes[2].InnerText.Trim());
                    }
                    else
                    {
                        wordOfDay.Contributor.By = WebUtility.HtmlDecode(contributorElement.InnerText.Trim());
                    }
                }

                var upVotesElement = htmlNode.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "up");
                if (upVotesElement != null)
                {
                    wordOfDay.UpVotes = System.Convert.ToInt32(upVotesElement.InnerText);
                }

                var downVotesElement = htmlNode.Descendants("a").FirstOrDefault(x => x.Attributes.Contains("class") && x.Attributes["class"].Value == "down");
                if (downVotesElement != null)
                {
                    wordOfDay.DownVotes = System.Convert.ToInt32(downVotesElement.InnerText);
                }

                result.Add(wordOfDay);
            }


            return result;
        }
    }
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
    }
}
