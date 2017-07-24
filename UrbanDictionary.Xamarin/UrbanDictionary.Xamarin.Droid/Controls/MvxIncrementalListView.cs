using System;
using Android.Content;
using Android.Runtime;
using MvvmCross.Binding.Droid.Views;
using Android.Util;
using MvvmCross.Droid.Support.V7.RecyclerView;
using UrbanDictionary.Xamarin.Core.Collections;
using System.Collections;
using Android.Support.V7.Widget;
using Java.Lang;
using UrbanDictionary.Xamarin.Droid.Controls;

namespace UrbanDictionary.Xamarin.Droid
{
    public class MvxIncrementalListView : MvxRecyclerView
    {
        private bool _isLoading;

        protected MvxIncrementalListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxIncrementalListView(Context context, IAttributeSet attrs) : this(context, attrs, 0, new IncrementalAdapter()) { }
        public MvxIncrementalListView(Context context, IAttributeSet attrs, int defStyle, IncrementalAdapter adapter) : base(context, attrs, defStyle, adapter)
        {
          
        }


        public async void onLoadMore()
        {
            if (Adapter?.ItemsSource != null)
            {
                if (Adapter?.ItemsSource is ICoreSupportIncrementalLoading source)
                {
                    _isLoading = true;
                    await source.LoadMoreItemsAsync();
                    _isLoading = false;
                }
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