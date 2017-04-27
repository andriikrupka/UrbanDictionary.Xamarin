using UrbanDictionary.Xamarin.Services;
using Android.Media;
using MvvmCross.Platform.Droid.Platform;
using Plugin.MediaManager;
using System.Threading.Tasks;
using System;
using static Android.Drm.DrmManagerClient;

namespace UrbanDictionary.Xamarin.Droid.Services
{
    public class AndroidSoundService : ISoundService
    {
        private readonly IMvxAndroidCurrentTopActivity _currentTopActivity;

        public AndroidSoundService(IMvxAndroidCurrentTopActivity currentTopActivity)
        {
            _currentTopActivity = currentTopActivity;
        }

        public Task<bool> PlaySoundAsync(string url)
        {
            var mediaPlayerCompletionSource = new TaskCompletionSource<bool>();
            try
            {

                var mediPlayer = new MediaPlayer();
                mediPlayer.SetAudioStreamType(Stream.System);
                mediPlayer.SetDataSource(url);
                mediPlayer.Prepare();
                mediPlayer.Start();
                EventHandler<MediaPlayer.ErrorEventArgs> errorHandler = null;
                EventHandler completionHandler = null;

                errorHandler += (s, e) =>
                {
                    mediaPlayerCompletionSource.TrySetResult(false);
                    mediPlayer.Error -= errorHandler;
                    mediPlayer.Completion -= completionHandler;
                    mediPlayer.Stop();
                    mediPlayer.Dispose();
                    mediPlayer = null;
                };

                completionHandler += (s, e) =>
                {
                    mediaPlayerCompletionSource.TrySetResult(true);
                    mediPlayer.Error -= errorHandler;
                    mediPlayer.Completion -= completionHandler;
                    mediPlayer.Stop();
                    mediPlayer.Dispose();
                    mediPlayer = null;
                };
                mediPlayer.Error += errorHandler;
                mediPlayer.Completion += completionHandler;
            }
            catch (System.Exception ex)
            {
                mediaPlayerCompletionSource.TrySetResult(false);
            }

            return mediaPlayerCompletionSource.Task;
        }
    }
}