using System.Collections.Generic;

namespace UrbanDictionary.Models
{
    public class WordsCategoryResponse
    {
        public List<WordsCategory> WordsCategories { get; set; }

        public string NextPage { get; set; }
    }
}
