using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace UrbanDictionary.Xamarin.Droid.Views
{
    public class CharacterViewHolder : RecyclerView.ViewHolder
    {
        public CharacterViewHolder(View view, System.Action<int> OnClick)
            : base(view)
        {
            TextButton =  view.FindViewById<TextView>(Resource.Id.character_button);
            view.Click += (s, e) => OnClick?.Invoke(AdapterPosition);
        }

        public TextView TextButton { get; private set; }
    }
}