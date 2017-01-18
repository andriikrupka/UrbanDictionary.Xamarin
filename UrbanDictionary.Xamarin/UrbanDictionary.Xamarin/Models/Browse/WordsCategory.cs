using System.Collections.Generic;

namespace UrbanDictionary.Models
{
    public class WordsCategory
    {
        public string Header { get; set; }

        public List<BrowseWord> Words { get; set; }

        public string NextPage { get; set; }
    }
}
