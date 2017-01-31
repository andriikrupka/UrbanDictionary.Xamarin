using System;

using Android.App;
using Android.Runtime;
using ModernHttpClient;
using System.Net.Http;
using UrbanDictionary.Xamarin.DataAccess;
using MvvmCross.Core.ViewModels;

namespace UrbanDictionary.Xamarin.Droid
{
    [Application(Label = "Urban Dictionary")]
    public class App : Application
    {
        App(IntPtr handle, JniHandleOwnership owner) : base(handle, owner) { }

        public override void OnCreate()
        {
            base.OnCreate();
        }
    }
}