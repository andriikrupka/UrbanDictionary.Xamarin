using Android.App;
using Android.OS;
using UrbanDictionary.Xamarin.Droid.Views;
using UrbanDictionary.Xamarin.ViewModels;
using Android.Views;
using System.Collections.Generic;
using System.Linq;
using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

namespace UrbanDictionary.Xamarin.Droid
{
    [Activity(MainLauncher = true)]
    public class MainActivity : MvxAppCompatActivity<MainViewModel>
    {
        private TabLayout tabLayout;
        private ViewPager viewPager;

        public MainActivity()
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            viewPager = FindViewById<ViewPager>(Resource.Id.view_pager);
            tabLayout = FindViewById<TabLayout>(Resource.Id.tab_layout);
            SetupViewPager(viewPager);
        }

        private void SetupViewPager(ViewPager viewPager)
        {
            var list = new List<ViewPagerAdapter.FragmentInfo>
            {
                new ViewPagerAdapter.FragmentInfo
                {
                    IconDrawable = Resource.Drawable.day_word_icon,
                    FragmentType = typeof(DayWordFragment),
                    ViewModel = ViewModel.DayWordsViewModel
                },

                new ViewPagerAdapter.FragmentInfo
                {
                    IconDrawable = Resource.Drawable.browse_icon,
                    FragmentType = typeof(WordsCollectionFragment),
                    ViewModel = ViewModel.WordsCollectionViewModel
                }
            };

            var viewPagerAdapter = new ViewPagerAdapter(this, SupportFragmentManager, list, tabLayout);
            viewPager.Adapter = viewPagerAdapter;
            tabLayout.SetupWithViewPager(viewPager);
            viewPagerAdapter.SetupIcons();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.search_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.action_search)
            {
                ViewModel.NavigateToSearchCommand.Execute(null);
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}