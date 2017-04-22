using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;

namespace UrbanDictionary.Xamarin.Models
{
    public class DefinitionsData : List<WordOfDay>
    {
        public bool HasMoreItems { get; set; }
    }
}
