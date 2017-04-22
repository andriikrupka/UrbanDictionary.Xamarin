using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.DataAccess.Parsers
{
    public abstract class DayWordsBaseParser<T> : IParserStrategy<T>
    {
        public abstract T Parse(string data);

        protected List<WordOfDay> ParseWordsOfDay(List<HtmlNode> element)
        {
            var result = new List<WordOfDay>();

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
}
