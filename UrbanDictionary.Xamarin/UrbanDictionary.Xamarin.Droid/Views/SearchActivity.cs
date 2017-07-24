using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using UrbanDictionary.Xamarin.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace UrbanDictionary.Xamarin.Droid.Resources.values
{
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : MvxAppCompatActivity<SearchViewModel>, Android.Support.V7.Widget.SearchView.IOnCloseListener, Android.Support.V7.Widget.SearchView.IOnQueryTextListener, Android.Support.V7.Widget.SearchView.IOnSuggestionListener
    {
        private Android.Support.V7.Widget.Toolbar toolBar;
        private Android.Support.V7.Widget.SearchView searchView;

        public bool OnQueryTextChange(string newText)
        {
            if (newText?.Trim()?.Length > 3)
                ViewModel.LoadSuggestionCommand.Execute(newText);

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

            toolBar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.search_view_toolbar);
            toolBar.SetNavigationIcon(Resource.Drawable.ic_back_white);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetHomeButtonEnabled(true);

            searchView = FindViewById<Android.Support.V7.Widget.SearchView>(Resource.Id.search_view);
            searchView.SetOnQueryTextListener(this);
            searchView.SetOnSuggestionListener(this);
            var adapter = new SearchSuggestionAdapter(this);
            searchView.SuggestionsAdapter = adapter;
            var set = this.CreateBindingSet<SearchActivity, SearchViewModel>();
            set.Bind(adapter).To(x => x.Suggestions).For(w => w.Suggestions).Apply();

        }

        public List<string> MirrorProperty { get; set; }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.search_menu, menu);
            var menuItem = menu.FindItem(Resource.Id.action_search);
            //menuItem.SetActionView(searchView);

            return base.OnCreateOptionsMenu(menu);
        }

        public bool OnClose()
        {
            Finish();
            return true;
        }
    }

    public class SearchSuggestionAdapter : Android.Support.V4.Widget.CursorAdapter
    {
        private static readonly string[] Columns = {
            "Definition",
        };


        private static readonly MatrixCursor EmptyCursor = new MatrixCursor(Columns);

        public SearchSuggestionAdapter(Context context)
            : base(context, null, true)
        {

        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            throw new NotImplementedException();
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            var view = LayoutInflater.From(context).Inflate(global::Android.Resource.Layout.SimpleListItem1, null);
            return view;
        }

        public void PopulateData(List<string> data)
        {
            var cursor = new MatrixCursor(Columns);
            Converter<string, Java.Lang.Object> func = s => new Java.Lang.String(s);
            foreach (var item in data)
            {
                cursor.AddRow(Array.ConvertAll(new[]
                            {item }, func));
            }

            SwapCursor(cursor);
        }

        private List<string> suggestions;

        public List<string> Suggestions
        {
            get { return suggestions; }
            set
            {
                suggestions = value;
                PopulateData(suggestions);
            }
        }

    }
}