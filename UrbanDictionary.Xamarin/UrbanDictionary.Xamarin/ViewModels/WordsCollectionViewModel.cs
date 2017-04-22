using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.DataAccess;

namespace UrbanDictionary.Xamarin.ViewModels
{
    [PropertyChanged.ImplementPropertyChanged]
    public class WordsCollectionViewModel : BaseViewModel
    {
        private IDayWordsProvider dayWordsProvider;

        public WordsCollectionViewModel(IDayWordsProvider dayWordsProvider)
        {
            this.dayWordsProvider = dayWordsProvider;
            CurrentCharacter = new UrbanCharacter("A");
            ViewDefinitionCommand = new MvxCommand<BrowseWord>(ViewDefinitionExecute);
        }

        private void ViewDefinitionExecute(BrowseWord word)
        {
            var bundle = new MvxBundle();
            bundle.Data.Add(DefinitionViewModel.DefinitionWord, word.Word);

            ShowViewModel<DefinitionViewModel>(bundle);
        }

        public MvxCommand<BrowseWord> ViewDefinitionCommand { get; }
        public UrbanSymbol CurrentCharacter { get; set; }
        public List<BrowseWord> Words { get; set; }
        private async void OnCurrentCharacterChanged()
        {
            try
            {
                Words = await dayWordsProvider.LoadFromCharacterAsync(CurrentCharacter);
            }
            catch (Exception)
            {
                ShowError();
            }
        }
    }
}
