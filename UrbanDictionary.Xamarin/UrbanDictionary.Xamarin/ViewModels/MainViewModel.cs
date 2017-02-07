using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IDayWordsProvider _dayWordsProvider;
        private int pageNumber = 0;
        public MainViewModel(IDayWordsProvider dayWordsProvider)
        {
            _dayWordsProvider = dayWordsProvider;
            Data = new IncrementalCollection<WordOfDay>(LoadMoreItems);
        }

        private async Task<IList<WordOfDay>> LoadMoreItems()
        {
            //await Task.Delay(250);

            //return new List<WordOfDay>()
            //{
            //    new WordOfDay
            //    {
            //        DayString = "JAN 31",
            //        Word = "Trump Jumped",
            //        Meaning = "Cost of goods paid by consumers after tariff cost increases.",
            //        Example = $"This bumper jack has been Trump Jumped from $49 bucks to almost $60. {Environment.NewLine}This is an ass ripping $10 dollar trump jump.",
            //        Contributor = new Contributor
            //        {
            //            By = "by",
            //            Author = "ClarkKent",
            //            Data = "January 26, 2017"
            //        }
            //    },
            //    new WordOfDay
            //    {
            //        DayString = "JAN 30",
            //        Word = "Twitler",
            //        Meaning = "A fascist twit who overuses their Twitter, and uses it for attention and to indoctrinate the foolish. Synomous with The Orange Snowflake, a.k.a Orange Mussolini, a.ka. Orange Faced Shit-gibbon, a.k.a Donald J. Trump.",
            //        Example = @"""I wish POTUS Trump would stop tweeting already, he's not a winner no matter how many times he says it, man's a real twitler.""",
            //        Contributor = new Contributor
            //        {
            //            By = "by",
            //            Author = "Puppygirl",
            //            Data = "January 29, 2017"
            //        }
            //    },
            //    new WordOfDay
            //    {
            //        DayString = "JAN 29",
            //        Word = "immigrant",
            //        Meaning = "What every inhabitant of the USA is, except the Native Americans.",
            //        Example = $"A: Dude, I fuckin hate them immigrants!{Environment.NewLine}B: Well whaddaya think your great great great grand father was?",
            //        Contributor = new Contributor
            //        {
            //            By = "by",
            //            Author = "rosinbolle",
            //            Data = "October 22, 2006"
            //        }
            //    },
            //};

            var data = await _dayWordsProvider.LoadPageWordsOfDayAsync(pageNumber++);
            return data;
        }

        public override void Start()
        {
            base.Start();
            //Data.LoadMoreItemsAsync();
        }

        public IncrementalCollection<WordOfDay> Data { get; private set; }
    }
}
