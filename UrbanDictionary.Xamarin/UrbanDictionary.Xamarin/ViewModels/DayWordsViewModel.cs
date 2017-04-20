using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;
using UrbanDictionary.Xamarin.DataAccess;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class DayWordsViewModel : MvxViewModel
    {
        private readonly IDayWordsProvider _dayWordsProvider;
        private int pageNumber = 0;

        public MvxCommand RefreshCommand { get; private set; }

        public DayWordsViewModel(IDayWordsProvider dayWordsProvider)
        {
            _dayWordsProvider = dayWordsProvider;
            Data = new IncrementalCollection<WordOfDay>(LoadMoreItems);

            RefreshCommand = new MvxCommand(RefreshExecute);
        }

        private async void RefreshExecute()
        {
            try
            {
                IsRefreshing = true;
                var data = await _dayWordsProvider.LoadPageWordsOfDayAsync(0);
                Data.Clear();
                Data.AddRange(data);
                pageNumber = 0;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                IsRefreshing = false;
            }

            RaisePropertyChanged(nameof(IsRefreshing));
        }

        private async Task<IList<WordOfDay>> LoadMoreItems()
        {
            var data = await _dayWordsProvider.LoadPageWordsOfDayAsync(pageNumber++);
            return data;
        }

        public override async void Start()
        {
            base.Start();
        }

        public IncrementalCollection<WordOfDay> Data { get; private set; }
        public bool IsRefreshing { get; private set; }
    }
}
