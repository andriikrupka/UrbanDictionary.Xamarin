using UrbanDictionary.Xamarin.Services;
using Android.Media;
using MvvmCross.Platform.Droid.Platform;

namespace UrbanDictionary.Xamarin.Droid.Services
{
    public class AndroidSoundService : ISoundService
    {
        private readonly IMvxAndroidCurrentTopActivity _currentTopActivity;

        public AndroidSoundService(IMvxAndroidCurrentTopActivity currentTopActivity)
        {
            _currentTopActivity = currentTopActivity;
        }

        public void PlaySound(string url)
        {
            var mp = MediaPlayer.Create(_currentTopActivity.Activity, new Android.Net.Uri.Builder().AppendPath(url).Build());
            mp.Start();
        }
    }
}