using Android.Content;
using Android.Views;
using MvvmCross.Binding.Droid.Views;
using System.Collections;
using UrbanDictionary.Xamarin.Core.Collections;
using System.Threading.Tasks;
using MvvmCross.Droid.Support.V7.RecyclerView;

namespace UrbanDictionary.Xamarin.Droid
{
    public class MvxIncrementalAdapter : MvxRecyclerAdapter
    {
        private int _lastCount;
        private int _maxPositionReached;

        public MvxIncrementalAdapter()
            : base()
        {
        }

        public override object GetItem(int position)
        {
            if ((position >= _maxPositionReached) && (position >= _lastCount))
            {
                _maxPositionReached = position;
                LoadMoreItemsAsync();
            }

            return base.GetItem(position);
        }

        protected override void SetItemsSource(IEnumerable value)
        {
            base.SetItemsSource(value);
            _lastCount = 0;
            _maxPositionReached = 0;
            LoadMoreItemsAsync();
        }

        public async Task LoadMoreItemsAsync()
        {
            ICoreSupportIncrementalLoading source = ItemsSource as ICoreSupportIncrementalLoading;

            if (source != null)
            {
                _lastCount = ItemCount;
                await source.LoadMoreItemsAsync();
            }
        }
    }
}