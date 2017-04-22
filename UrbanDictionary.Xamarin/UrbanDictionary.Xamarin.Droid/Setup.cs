using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using MvvmCross.Droid.Views;

namespace UrbanDictionary.Xamarin.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
           return new AppBase();
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            

            return base.CreateViewPresenter();
        }
    }
}