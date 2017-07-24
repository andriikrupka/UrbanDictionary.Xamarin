using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UrbanDictionary.Xamarin.Core.Collections
{
    public class IncrementalCollection<T> : ObservableRangeCollection<T>, ICoreSupportIncrementalLoading
    {
        private Func<Task<IList<T>>> _loadMoreFunc;

        public IncrementalCollection(Func<Task<IList<T>>> loadMoreFunc)
        {
            _loadMoreFunc = loadMoreFunc;
        }

        public IncrementalCollection(Func<Task<IList<T>>> loadMoreFunc, IEnumerable<T> source)
            : base(source)
        {
            _loadMoreFunc = loadMoreFunc;
        }

        public bool HasMoreItems { get; set; } = true;

        public async Task LoadMoreItemsAsync()
        {
            var newItems = await _loadMoreFunc();
            AddRange(newItems);
        }
    }
}
