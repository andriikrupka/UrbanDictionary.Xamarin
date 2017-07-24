using UrbanDictionary.Xamarin.Services;

namespace UrbanDictionary.Xamarin.Droid.Services
{
    public class AndroidNetworkService : INetworkService
    {
        public bool IsConnected => Plugin.Connectivity.CrossConnectivity.Current.IsConnected;
    }
}