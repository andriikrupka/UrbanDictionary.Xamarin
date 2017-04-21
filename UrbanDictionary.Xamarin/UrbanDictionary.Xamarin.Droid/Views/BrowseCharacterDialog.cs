using System;
using System.Collections.Generic;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.Models.Browse;

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

        private TaskCompletionSource<CharacterItem> taskCompletionSource;
        private bool isClicked;

        public Task<CharacterItem> ShowAsync(Android.Support.V4.App.FragmentManager manager, string tag)
        {
            taskCompletionSource = new TaskCompletionSource<CharacterItem>();
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

        private void Adapter_ItemClick(object sender, CharacterItem e)
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
        public event EventHandler<CharacterItem> ItemClick;
        private List<CharacterItem> items = new List<CharacterItem>()
                {
                    new CharacterItem("A"),
                    new CharacterItem("B"),
                    new CharacterItem("C"),
                    new CharacterItem("D"),
                    new CharacterItem("E"),
                    new CharacterItem("F"),
                    new CharacterItem("G"),
                    new CharacterItem("H"),
                    new CharacterItem("I"),
                    new CharacterItem("J"),
                    new CharacterItem("K"),
                    new CharacterItem("L"),
                    new CharacterItem("M"),
                    new CharacterItem("N"),
                    new CharacterItem("O"),
                    new CharacterItem("P"),
                    new CharacterItem("Q"),
                    new CharacterItem("R"),
                    new CharacterItem("S"),
                    new CharacterItem("T"),
                    new CharacterItem("U"),
                    new CharacterItem("V"),
                    new CharacterItem("W"),
                    new CharacterItem("X"),
                    new CharacterItem("Y"),
                    new CharacterItem("Z"),
                    new CharacterItem("#"),
                    new CharacterItem("new"),
                };

        public List<CharacterItem> Items
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
            viewHolder.TextButton.Text = items[position].CharacterText;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.character_item_template, parent, false);
            var viewHolder = new CharacterViewHolder(itemView, (index) => ItemClick?.Invoke(this, items[index]));

            return viewHolder;
        }
    }


}