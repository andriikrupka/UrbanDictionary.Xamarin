using System.Collections.Generic;
using UrbanDictionary.Models.Core;

namespace UrbanDictionary.Models
{
    public class WordOfDay : BindableObject
    {
        private int _downVotes;
        private bool _isPlaying;
        private int _upVotes;
        public int Id { get; set; }
        public string DayString { get; set; }
        public string Word { get; set; }
        public List<string> SoundUrls { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }

        public int UpVotes
        {
            get { return _upVotes; }
            set
            {
                if (value != _upVotes)
                {
                    _upVotes = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int DownVotes
        {
            get { return _downVotes; }
            set
            {
                if (value != _downVotes)
                {
                    _downVotes = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Contributor Contributor { get; set; }
    }
}