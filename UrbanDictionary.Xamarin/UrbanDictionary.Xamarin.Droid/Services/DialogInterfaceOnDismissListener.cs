using System;
using Android.Content;

namespace UrbanDictionary.Xamarin.Droid.Services
{
    public class DialogInterfaceOnDismissListener : Java.Lang.Object, IDialogInterfaceOnDismissListener
    {
        public void OnDismiss(IDialogInterface dialog)
        {
            Dismissed?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Dismissed;
    }
}