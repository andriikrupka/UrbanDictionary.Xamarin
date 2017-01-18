using UrbanDictionary.Models.Core;

namespace UrbanDictionary.Models
{
    public abstract class UrbanSymbol : BindableObject
    {
        private bool _isActive;

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                if (value != _text)
                {
                    _text = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool IsNormal { get; set; }

        public string LinkAddress
        {
            get
            {
                return GetLinkAddress();
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (value != _isActive)
                {
                    _isActive = value;
                    RaisePropertyChanged();
                }
            }
        }

        protected abstract string GetLinkAddress();
    }

    public class UrbanCharacter : UrbanSymbol
    {
        private string _linkAddress;

        public UrbanCharacter(string text, bool isNormal)
        {
            Text = text;
            IsNormal = isNormal;
        }

        public UrbanCharacter(string text, bool isNormal, string linkAddress)
            : this(text, isNormal)
        {
            _linkAddress = linkAddress;
        }

        protected override string GetLinkAddress()
        {
            if (string.IsNullOrEmpty(_linkAddress))
            {
                var address = "http://www.urbandictionary.com/popular.php?character=" + Text;
                if (Text.ToUpperInvariant() == "NEW")
                {
                    address = "http://www.urbandictionary.com/yesterday.php";
                }

                _linkAddress = address;
            }

            return _linkAddress;
        }
    }

    public class UrbanBrowseWord : UrbanSymbol
    {
        public UrbanBrowseWord(string text, bool isNormal)
        {
            Text = text;
            IsNormal = isNormal;
        }

        protected override string GetLinkAddress()
        {
            return "http://www.urbandictionary.com/browse.php?word=" + Text;
        }
    }

}
