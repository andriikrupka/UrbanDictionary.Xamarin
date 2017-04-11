using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace UrbanDictionary.Xamarin.Droid.Resources.values
{
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity, SearchView.IOnQueryTextListener, SearchView.IOnSuggestionListener
    {
        public bool OnQueryTextChange(string newText)
        {
            return false;
        }

        public bool OnQueryTextSubmit(string query)
        {
            return false;
        }

        public bool OnSuggestionClick(int position)
        {
            return false;

        }

        public bool OnSuggestionSelect(int position)
        {
            return false;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.search_layout);
        }
    }
}