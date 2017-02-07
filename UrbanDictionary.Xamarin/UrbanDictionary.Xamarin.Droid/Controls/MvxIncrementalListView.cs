using System;
using Android.Content;
using Android.Runtime;
using MvvmCross.Binding.Droid.Views;
using Android.Util;
using MvvmCross.Droid.Support.V7.RecyclerView;
using UrbanDictionary.Xamarin.Core.Collections;

namespace UrbanDictionary.Xamarin.Droid
{
    public class MvxIncrementalListView : MvxRecyclerView, Paginate.Droid.Paginate.Callbacks
    {
        private bool _isLoading;

        protected MvxIncrementalListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxIncrementalListView(Context context, IAttributeSet attrs) : this(context, attrs, 0, new MvxRecyclerAdapter()) { }
        public MvxIncrementalListView(Context context, IAttributeSet attrs, int defStyle) : this(context, attrs, defStyle, new MvxRecyclerAdapter()) { }
        public MvxIncrementalListView(Context context, IAttributeSet attrs, int defStyle, IMvxRecyclerAdapter adapter) : base(context, attrs, defStyle, adapter)
        {

            Paginate.Droid.Paginate.With(this, this)
                .SetLoadingTriggerThreshold(5)
                .AddLoadingListItem(true)
                .Build();
        }

        public async void onLoadMore()
        {
            var source = Adapter.ItemsSource as ICoreSupportIncrementalLoading;
            if (source != null)
            {
                _isLoading = true;
                await source.LoadMoreItemsAsync();
                _isLoading = false;
            }
        }

        public bool isLoading()
        {
            return _isLoading;
        }

        public bool hasLoadedAllItems()
        {
            return false;
        }
    }
}