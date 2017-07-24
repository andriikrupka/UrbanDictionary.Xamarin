using System.Threading.Tasks;

namespace UrbanDictionary.Xamarin.Core.Collections
{
    public interface ICoreSupportIncrementalLoading
    {
        Task LoadMoreItemsAsync();
        bool HasMoreItems { get; }
    }
}
