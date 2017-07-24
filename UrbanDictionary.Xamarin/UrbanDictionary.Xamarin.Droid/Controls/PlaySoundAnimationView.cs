using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Airbnb.Lottie;
using Android.Util;

namespace UrbanDictionary.Xamarin.Droid.Controls
{
    public class PlaySoundAnimationView : LottieAnimationView
    {
        private const string AssetFile = "speaking.json";
        protected PlaySoundAnimationView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PlaySoundAnimationView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Loop(true);
            LottieComposition.Factory.FromAssetFileName(context, AssetFile, (composition) =>
            {
                SetComposition(composition);
            });
        }

        private bool _isPlaying;

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                UpdateAnimation();
            }
        }

        private void UpdateAnimation()
        {
            Progress = 0;

            if (IsPlaying)
            {
                PlayAnimation();
            }
            else
            {
                CancelAnimation();
            }
        }
    }
}