using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;
using System;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public DayWordsViewModel DayWordsViewModel { get; }
        public WordsCollectionViewModel WordsCollectionViewModel { get; }
        public MainViewModel(DayWordsViewModel dayWordsViewModel, WordsCollectionViewModel wordsCollectionViewModel)
        {
            DayWordsViewModel = dayWordsViewModel;
            WordsCollectionViewModel = wordsCollectionViewModel;
        }
    }
}
