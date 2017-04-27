using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.IoC;
using UrbanDictionary.Xamarin.Droid.Converters;
using UrbanDictionary.Xamarin.Droid.Services;
using UrbanDictionary.Xamarin.Services;

namespace UrbanDictionary.Xamarin.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, AndroidDialogService>();
            Mvx.LazyConstructAndRegisterSingleton<INetworkService, AndroidNetworkService>();
            Mvx.LazyConstructAndRegisterSingleton<ISoundService, AndroidSoundService>();
            return new AppBase();
        }

        protected override IMvxIocOptions CreateIocOptions()
        {
            return new MvxIocOptions()
            {
                PropertyInjectorOptions = MvxPropertyInjectorOptions.MvxInject
            };
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("EmptyToVisibilityConverter", new EmptyToVisibilityConverter());
        }
    }
}