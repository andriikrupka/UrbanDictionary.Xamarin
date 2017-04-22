using UrbanDictionary.Models.Core;

namespace UrbanDictionary.Models
{
    public abstract class UrbanSymbol 
    {
        public string Text { get; set; }

        public string LinkAddress
        {
            get
            {
                return GetLinkAddress();
            }
        }

        protected abstract string GetLinkAddress();
    }

    public class UrbanCharacter : UrbanSymbol
    {
        private string _linkAddress;

        public UrbanCharacter(string text)
        {
            Text = text;
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
        public UrbanBrowseWord(string text)
        {
            Text = text;
        }

        protected override string GetLinkAddress()
        {
            return "http://www.urbandictionary.com/browse.php?word=" + Text;
        }
    }

}
