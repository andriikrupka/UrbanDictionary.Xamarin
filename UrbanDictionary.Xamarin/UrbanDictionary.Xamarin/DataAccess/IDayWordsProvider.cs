using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Models;

namespace UrbanDictionary.Xamarin.DataAccess
{
    public interface IDayWordsProvider
    {
        Task<List<WordOfDay>> LoadPageWordsOfDayAsync(int pageNumber = 0);
        Task<DefinitionsData> LoadDefinitionAsync(string relativePath, int pageNumber = 0);
        Task<List<BrowseWord>> LoadFromCharacterAsync(UrbanSymbol character);
    }
}
