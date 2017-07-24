using System.Threading.Tasks;

namespace UrbanDictionary.Xamarin.Services
{
    public interface ISoundService
    {
        Task<bool> PlaySoundAsync(string url);
    }
}
