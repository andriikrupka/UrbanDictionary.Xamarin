using System;

namespace UrbanDictionary.Models.VoteGame
{
    public class SoundItem : VoteGameItem
    {
        private bool _isPlaying;

        public Uri Url { get; set; }

        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }

            set
            {
                if (_isPlaying != value)
                {
                    _isPlaying = value;
                    base.RaisePropertyChanged();
                }
            }
        }
    }
}
