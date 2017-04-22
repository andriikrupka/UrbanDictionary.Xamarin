using System.Collections;
using System.Threading.Tasks;
using Android.Content;
using Android.Views;
using MvvmCross.Binding.Droid.Views;
using UrbanDictionary.Xamarin.Core.Collections;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace UrbanDictionary.Xamarin.Droid.Controls
{
    public class IncrementalAdapter : MvxRecyclerAdapter
    {
        private int _lastCount;
        private int _maxPositionReached;

        public IncrementalAdapter()
        {
        }

        public override object GetItem(int position)
        {
            if ((position >= _maxPositionReached) && (position >= _lastCount))
            {
                _maxPositionReached = position;
                LoadMoreItems();
            }

            return base.GetItem(position);
        }

        protected override void SetItemsSource(IEnumerable value)
        {
            base.SetItemsSource(value);
            _lastCount = 0;
            _maxPositionReached = 0;
            LoadMoreItems();
        }

        private void LoadMoreItems()
        {
            LoadMoreItemsAsync();
        }

        public async Task LoadMoreItemsAsync()
        {

            if (ItemsSource is ICoreSupportIncrementalLoading source && source.HasMoreItems)
            {
                _lastCount = ItemCount;
                await source.LoadMoreItemsAsync();
            }
        }
    }
}