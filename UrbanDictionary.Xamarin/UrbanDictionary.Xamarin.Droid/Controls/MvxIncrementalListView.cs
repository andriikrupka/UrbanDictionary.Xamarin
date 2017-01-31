using System;
using Android.Content;
using Android.Runtime;
using MvvmCross.Binding.Droid.Views;
using Android.Util;

namespace UrbanDictionary.Xamarin.Droid
{
    public class MvxIncrementalListView : MvxListView
    {
        protected MvxIncrementalListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MvxIncrementalListView(Context context, IAttributeSet attrs)
            : base(context, attrs, new MvxIncrementalAdapter(context))
        {

        }
    }
}