using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UrbanDictionary.Xamarin.DataAccess
{


    public abstract class BaseApiProvider
    {
        private readonly HttpClient _httpClient;

        protected BaseApiProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<T> SendAsync<T>(HttpRequestMessage request, IParserStrategy<T> parser)
        {
            using (var httpResponseMessage = await _httpClient.SendAsync(request))
            {
                var data = await httpResponseMessage.Content.ReadAsStringAsync();
                return parser.Parse(data);
            }
        }  
    }
}
