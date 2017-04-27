using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Services;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class WordViewModel : BaseViewModel
    {
        private readonly ISoundService _soundService;

        public WordViewModel(WordOfDay wordOfDay, ISoundService soundService)
        {
            WordOfDay = wordOfDay;
            _soundService = soundService;
            PlaySoundCommand = new MvxCommand(PlayExecute);
            ViewDefinitionCommand = new MvxCommand<string>(ViewDefinitionExecute);
        }

        private void PlayExecute()
        {
            _soundService.PlaySound(WordOfDay.SoundUrls);
        }

        public MvxCommand PlaySoundCommand { get; }

        private void ViewDefinitionExecute(string wordLink)
        {
            Regex regex = new Regex(@"(?<=\=).*");
            var match = regex.Match(wordLink);
            var word = match.Success ? match.Groups[0].Value : wordLink;
            var bundle = new MvxBundle();
            bundle.Data.Add(DefinitionViewModel.DefinitionWord, word);
            ShowViewModel<DefinitionViewModel>(bundle);
        }

        public MvxCommand<string> ViewDefinitionCommand { get; }
        public WordOfDay WordOfDay { get; }
    }
}
