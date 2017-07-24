using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private IDayWordsProvider _dayWordsProvider;

        public SearchViewModel(IDayWordsProvider dayWordsProvider)
        {
            _dayWordsProvider = dayWordsProvider;

            LoadSuggestionCommand = new MvxCommand<string>(LoadSuggestionExecute);
        }

        public MvxCommand<string> LoadSuggestionCommand { get; }
        public List<string> Suggestions { get; private set; }

        private async void LoadSuggestionExecute(string query)
        {
            try
            {
                Suggestions = await _dayWordsProvider.LoadAutoCompleteAsync(query);
            }
            catch (Exception)
            {
                ShowError();
            }
        }
    }
}
