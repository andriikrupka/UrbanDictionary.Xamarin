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
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using UrbanDictionary.Xamarin.ViewModels;

namespace UrbanDictionary.Xamarin.Droid.Views
{
    public class WordsCollectionFragment : MvxFragment<WordsCollectionViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var rootView = this.BindingInflate(Resource.Layout.words_collection, null);

            var button = rootView.FindViewById<TextView>(Resource.Id.characterView);
            button.Click += Button_Click;
            return rootView;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var dialog = new BrowseCharacterDialog();
            var result = await dialog.ShowAsync(FragmentManager, "dialog");
            if (result != null)
            {
                ViewModel.CurrentCharacter = result;
            }
        }
    }
}