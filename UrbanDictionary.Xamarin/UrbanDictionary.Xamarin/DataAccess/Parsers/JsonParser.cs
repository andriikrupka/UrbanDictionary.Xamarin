using Newtonsoft.Json;

namespace UrbanDictionary.Xamarin.DataAccess.Parsers
{
    public class JsonParser<T> : IParserStrategy<T>
    {
        public T Parse(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
