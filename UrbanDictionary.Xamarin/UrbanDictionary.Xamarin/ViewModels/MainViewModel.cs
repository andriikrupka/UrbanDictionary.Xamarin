using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IDayWordsProvider _dayWordsProvider;

        public MainViewModel(IDayWordsProvider dayWordsProvider)
        {
            _dayWordsProvider = dayWordsProvider;
        }

        public List<WordOfDay> Data { get; private set; }

        public override async void Start()
        {
            base.Start();

            Data = await _dayWordsProvider.LoadPageWordsOfDayAsync();
            RaisePropertyChanged(nameof(Data));
        }
    }
}
