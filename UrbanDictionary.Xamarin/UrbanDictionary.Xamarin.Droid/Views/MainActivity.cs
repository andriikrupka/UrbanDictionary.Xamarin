using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V4;
using System;
using UrbanDictionary.Xamarin.Droid.Views;
using UrbanDictionary.Xamarin.ViewModels;
using Android.Widget;
using Android.Views;
using Android.Support.V7.App;

namespace UrbanDictionary.Xamarin.Droid
{
    [Activity(MainLauncher = true)]
    public class MainActivity : MvxTabsAppCompatActivity
    {
        public MainViewModel MainViewModel => (MainViewModel)ViewModel;
        public MainActivity()
             : base(Resource.Layout.Main, Resource.Id.actualtabcontent)
        {
        
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.search_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<DayWordFragment>("One", "One", args, MainViewModel.DayWordsViewModel);
            AddTab<WordsCollectionFragment>("Two", "Two", args, MainViewModel.WordsCollectionViewModel);
        }
    }
}