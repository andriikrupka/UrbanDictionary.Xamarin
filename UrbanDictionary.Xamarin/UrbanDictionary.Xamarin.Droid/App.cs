using System;

using Android.App;
using Android.Runtime;

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