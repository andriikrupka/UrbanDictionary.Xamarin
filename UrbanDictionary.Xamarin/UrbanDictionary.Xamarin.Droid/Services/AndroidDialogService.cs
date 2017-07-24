using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Droid.Platform;

namespace UrbanDictionary.Xamarin.Droid.Services
{
    public class AndroidDialogService : Java.Lang.Object, IDialogService
    {
        private readonly IMvxAndroidCurrentTopActivity _currentTopActivity;

        public AndroidDialogService(IMvxAndroidCurrentTopActivity currentTopActivity)
        {
            _currentTopActivity = currentTopActivity;
        }

        public Task<bool> ShowDialogAsync(string title, string message, string okButton)
        {
            var tcs = new TaskCompletionSource<bool>();
            var dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener();
            dialogInterfaceOnDismissListener.Dismissed += (s, e) => tcs.TrySetResult(false);
            var alertDialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(_currentTopActivity.Activity);
            alertDialogBuilder.SetTitle(title)
                              .SetMessage(message)
                              .SetPositiveButton(okButton, (s, args) => { tcs.TrySetResult(true); })
                              .SetOnDismissListener(dialogInterfaceOnDismissListener);

            alertDialogBuilder.Show();

            return tcs.Task;
        }

        public Task<bool> ShowDialogAsync(string title, string message, string okButton, string cancelButton)
        {
            var tcs = new TaskCompletionSource<bool>();
            var dialogInterfaceOnDismissListener = new DialogInterfaceOnDismissListener();
            dialogInterfaceOnDismissListener.Dismissed += (s, e) => tcs.TrySetResult(false);
            var alertDialogBuilder = new Android.Support.V7.App.AlertDialog.Builder(Android.App.Application.Context);
            alertDialogBuilder.SetTitle(title)
                              .SetMessage(message)
                              .SetPositiveButton(okButton, (s, args) => { tcs.TrySetResult(true); })
                              .SetNegativeButton(cancelButton, (s, args) => tcs.TrySetResult(false))
                              .SetOnDismissListener(dialogInterfaceOnDismissListener);

            alertDialogBuilder.Show();
            return tcs.Task;
        }
    }
}