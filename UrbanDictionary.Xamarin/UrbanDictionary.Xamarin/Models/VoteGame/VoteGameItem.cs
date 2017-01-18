using UrbanDictionary.Models.Core;

namespace UrbanDictionary.Models.VoteGame
{
    public class VoteGameItem : BindableObject
    {
        public string Authenticate { get; set; }
        public string Id { get; set; }

        public string Promt { get; set; }
    }
}
