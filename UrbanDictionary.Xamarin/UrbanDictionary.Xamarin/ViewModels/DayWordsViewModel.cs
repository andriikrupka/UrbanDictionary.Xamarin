using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Xamarin.Services;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class DayWordsViewModel : BaseViewModel
    {
        private readonly IDayWordsProvider _dayWordsProvider;
        private int pageNumber = 0;
        private IDialogService _dialogService;
        private readonly ISoundService _soundService;

        public DayWordsViewModel(IDayWordsProvider dayWordsProvider, IDialogService dialogService, ISoundService soundService)
        {
            _dayWordsProvider = dayWordsProvider;
            _dialogService = dialogService;
            _soundService = soundService;
            Data = new IncrementalCollection<WordViewModel>(LoadMoreItems);
            RefreshCommand = new MvxCommand(RefreshExecute);
        }

        public IncrementalCollection<WordViewModel> Data { get; private set; }
        public bool IsRefreshing { get; private set; }
        public MvxCommand RefreshCommand { get; private set; }

        private async void RefreshExecute()
        {
            try
            {
                IsRefreshing = true;
                var data = await _dayWordsProvider.LoadPageWordsOfDayAsync(0);
                
                Data.Clear();
                Data.AddRange(data.Select(x=> new WordViewModel(x, _soundService)));
                pageNumber = 0;
            }
            catch (Exception)
            {
                //ShowError();
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async Task<IList<WordViewModel>> LoadMoreItems()
        {
            IList<WordOfDay> data = null;
            try
            {
                IsRefreshing = true;
                data = await _dayWordsProvider.LoadPageWordsOfDayAsync(pageNumber++);

            }
            catch (Exception)
            {
                //ShowError();
            }
            finally
            {
                IsRefreshing = false;
                if (data == null)
                {
                    data = new List<WordOfDay>();
                }
            }

            return data.Select(x=> new WordViewModel(x, _soundService)).ToList();
        }
    }
}
