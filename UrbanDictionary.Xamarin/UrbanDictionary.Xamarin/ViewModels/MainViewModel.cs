using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IDayWordsProvider _dayWordsProvider;

        public MainViewModel(IDayWordsProvider dayWordsProvider)
        {
            _dayWordsProvider = dayWordsProvider;
            Data = new IncrementalCollection<WordOfDay>(LoadMoreItems);
        }

        private async Task<IList<WordOfDay>> LoadMoreItems()
        {
            await Task.Delay(250);

            return new List<WordOfDay>()
            {
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                },
                new WordOfDay
                {
                    Word = "word",
                    Meaning = "sasdadsasadsad"
                }
            };
        }

        public IncrementalCollection<WordOfDay> Data { get; private set; }

        public override async void Start()
        {
            base.Start();

            //Data = await _dayWordsProvider.LoadPageWordsOfDayAsync();
            //RaisePropertyChanged(nameof(Data));
        }
    }
}
