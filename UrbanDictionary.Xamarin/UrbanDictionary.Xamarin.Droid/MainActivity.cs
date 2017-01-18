using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using ModernHttpClient;
using UrbanDictionary.Xamarin.DataAccess;
using UrbanDictionary.Xamarin.ViewModels;
using System.Reactive.Linq;
using MvvmCross.Droid.Views;

namespace UrbanDictionary.Xamarin.Droid
{
	[Activity (Label = "UrbanDictionary.Xamarin.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : MvxActivity<MainViewModel>
	{
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
        }
    }
}


