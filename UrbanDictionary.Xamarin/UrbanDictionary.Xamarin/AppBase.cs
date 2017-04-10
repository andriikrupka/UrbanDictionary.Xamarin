using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Xamarin.ViewModels;

namespace UrbanDictionary.Xamarin
{
    public class AppBase : MvxApplication
    {
        private HttpClient httpClient = new HttpClient();

        public override void Initialize()
        {
            base.Initialize();

            Mvx.LazyConstructAndRegisterSingleton<IDayWordsProvider>(()=> new DayWordsProvider(httpClient));
            Mvx.LazyConstructAndRegisterSingleton<DayWordsViewModel, DayWordsViewModel>();
            Mvx.LazyConstructAndRegisterSingleton<WordsCollectionViewModel, WordsCollectionViewModel>();
            Mvx.LazyConstructAndRegisterSingleton<MainViewModel, MainViewModel>();
        }
    }
}
