using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.Droid.Views
{
    public class BrowseCharacterDialog : Android.Support.V4.App.DialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {

            var dialog = base.OnCreateDialog(savedInstanceState);
            dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            return dialog;
        }

        private TaskCompletionSource<UrbanSymbol> taskCompletionSource;
        private bool isClicked;

        public Task<UrbanSymbol> ShowAsync(Android.Support.V4.App.FragmentManager manager, string tag)
        {
            taskCompletionSource = new TaskCompletionSource<UrbanSymbol>();
            Show(manager, tag);
            return taskCompletionSource.Task;
        }

        public override void OnStart()
        {
            base.OnStart();
            Dialog.Window.SetLayout(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var rootView = inflater.Inflate(Resource.Layout.browse_character_dialog, container, false);

            var recyclerView = rootView.FindViewById<MvxRecyclerView>(Resource.Id.characters_recyclerView);
            var adapter = new CharactersAdapter();
            adapter.ItemClick += Adapter_ItemClick;
            recyclerView.SetAdapter(adapter);
            var mLayoutManager = new GridLayoutManager(rootView.Context, 4);
            recyclerView.SetLayoutManager(mLayoutManager);

            return rootView;
        }

        private void Adapter_ItemClick(object sender, UrbanSymbol e)
        {
            isClicked = true;

            taskCompletionSource.TrySetResult(e);
            Dismiss();
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            if (!isClicked)
            {
                taskCompletionSource.TrySetResult(null);
            }

            base.OnDismiss(dialog);
        }
    }

    public class CharactersAdapter : RecyclerView.Adapter
    {
        public event EventHandler<UrbanSymbol> ItemClick;
        private List<UrbanSymbol> items = new List<UrbanSymbol>()
                {
                    new UrbanCharacter("A"),
                    new UrbanCharacter("B"),
                    new UrbanCharacter("C"),
                    new UrbanCharacter("D"),
                    new UrbanCharacter("E"),
                    new UrbanCharacter("F"),
                    new UrbanCharacter("G"),
                    new UrbanCharacter("H"),
                    new UrbanCharacter("I"),
                    new UrbanCharacter("J"),
                    new UrbanCharacter("K"),
                    new UrbanCharacter("L"),
                    new UrbanCharacter("M"),
                    new UrbanCharacter("N"),
                    new UrbanCharacter("O"),
                    new UrbanCharacter("P"),
                    new UrbanCharacter("Q"),
                    new UrbanCharacter("R"),
                    new UrbanCharacter("S"),
                    new UrbanCharacter("T"),
                    new UrbanCharacter("U"),
                    new UrbanCharacter("V"),
                    new UrbanCharacter("W"),
                    new UrbanCharacter("X"),
                    new UrbanCharacter("Y"),
                    new UrbanCharacter("Z"),
                    //new UrbanCharacter("#"),
                    //new UrbanCharacter("new"),
                };

        public List<UrbanSymbol> Items
        {
            get
            {
                return items;
            }
        }

        public override int ItemCount => items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as CharacterViewHolder;
            viewHolder.TextButton.Text = items[position].Text;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.character_item_template, parent, false);
            var viewHolder = new CharacterViewHolder(itemView, (index) => ItemClick?.Invoke(this, items[index]));

            return viewHolder;
        }
    }


}