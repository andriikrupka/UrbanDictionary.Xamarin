using System.Collections.Generic;

namespace UrbanDictionary.Models
{
    public class WordOfDayEqualityComparer : IEqualityComparer<WordOfDay>
    {
        public bool Equals(WordOfDay x, WordOfDay y)
        {
            var isEquals = false;

            if (x != null && y != null)
            {
                isEquals = x.Id == y.Id;
            }

            return isEquals;
        }

        public int GetHashCode(WordOfDay obj)
        {
            var hashCode = 0;

            if (obj != null)
            {
                hashCode = obj.Id.GetHashCode();
            }

            return hashCode;
        }
    }
}