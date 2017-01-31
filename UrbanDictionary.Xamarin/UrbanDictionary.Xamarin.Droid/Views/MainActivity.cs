using Android.App;
using Android.OS;
using UrbanDictionary.Xamarin.ViewModels;
using MvvmCross.Droid.Views;

namespace UrbanDictionary.Xamarin.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
        }
    }
}