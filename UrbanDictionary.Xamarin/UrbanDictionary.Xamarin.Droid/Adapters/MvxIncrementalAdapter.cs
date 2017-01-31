using Android.Content;
using Android.Views;
using MvvmCross.Binding.Droid.Views;
using System.Collections;
using UrbanDictionary.Xamarin.Core.Collections;
using System.Threading.Tasks;

namespace UrbanDictionary.Xamarin.Droid
{
    public class MvxIncrementalAdapter : MvxAdapter
    {
        private int _lastCount;
        private int _maxPositionReached;

        public MvxIncrementalAdapter(Context context)
            : base(context)
        {
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if ((position >= _maxPositionReached) && (position >= _lastCount))
            {
                _maxPositionReached = position;
                LoadMoreItemsAsync();
            }

            return base.GetView(position, convertView, parent);
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
                _lastCount = Count;
                await source.LoadMoreItemsAsync();
            }
        }
    }
}