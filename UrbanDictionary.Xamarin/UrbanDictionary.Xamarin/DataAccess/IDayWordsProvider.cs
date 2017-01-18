using System.Collections.Generic;
using System.Threading.Tasks;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.DataAccess
{
    public interface IDayWordsProvider
    {
        Task<List<WordOfDay>> LoadPageWordsOfDayAsync(int pageNumber = 0);
    }
}
