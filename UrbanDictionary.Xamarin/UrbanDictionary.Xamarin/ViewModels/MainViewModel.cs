using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;
using System;

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
            var data = await _dayWordsProvider.LoadPageWordsOfDayAsync(pageNumber++);
            return data;
        }

        public override async void Start()
        {
            base.Start();
            //var loadedData = await LoadMoreItems();
        }

        public IncrementalCollection<WordOfDay> Data { get; private set; }
    }
}
