using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.Models.Browse;

namespace UrbanDictionary.Xamarin.ViewModels
{
    [PropertyChanged.ImplementPropertyChanged]
    public class WordsCollectionViewModel : MvxViewModel
    {
        public WordsCollectionViewModel()
        {
            CurrentCharacter = new CharacterItem("A");
        }

        public string CustomButtonText => "from VM";

        public CharacterItem CurrentCharacter { get; set; }
    }
}
