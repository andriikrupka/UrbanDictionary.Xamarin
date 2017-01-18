namespace UrbanDictionary.Xamarin.DataAccess
{
    public interface IParserStrategy<out T>
    {
        T Parse(string data);
    }
}
