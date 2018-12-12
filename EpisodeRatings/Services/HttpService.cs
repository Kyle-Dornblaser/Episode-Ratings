using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EpisodeRatings.Services
{
    public class HttpService
    {
        public async Task<T> GetRequestAsync<T>(Uri uri)
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync(uri);
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(result));
            }
        }
    }
}
