using MvvmCross.Core.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.DataAccess;

namespace UrbanDictionary.Xamarin.ViewModels
{
    [AddINotifyPropertyChangedInterfaceAttribute]
    public class WordsCollectionViewModel : BaseViewModel
    {
        private IDayWordsProvider dayWordsProvider;

        public bool IsRefreshing { get; set; }
        public MvxCommand RefreshCommand { get; set; }

        public WordsCollectionViewModel(IDayWordsProvider dayWordsProvider)
        {
            this.dayWordsProvider = dayWordsProvider;
            RefreshCommand = new MvxCommand(RefreshExecute);
            CurrentCharacter = new UrbanCharacter("A");
            ViewDefinitionCommand = new MvxCommand<BrowseWord>(ViewDefinitionExecute);
        }

        private async void RefreshExecute()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            try
            {
                Words = await dayWordsProvider.LoadFromCharacterAsync(CurrentCharacter);
            }
            catch (Exception ex)
            {
                ShowError();
            }
            finally
            {
                IsRefreshing = false;
            }
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
            IsRefreshing = true;
                Words = await dayWordsProvider.LoadFromCharacterAsync(CurrentCharacter);
            }
            catch (Exception ex)
            {
                ShowError();
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
