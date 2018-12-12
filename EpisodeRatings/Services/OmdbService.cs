using EpisodeRatings.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodeRatings.Services
{
    public class OmdbService: HttpService
    {
        private readonly IOptions<AppConfig> _config;
        private readonly string _apiKey;

        public OmdbService(IOptions<AppConfig> config)
        {
            _config = config;
            _apiKey = _config.Value.OmdbSettings.ApiKey;
        }

        public async Task<SearchResults> SearchAsync(string query)
        {
            return await GetRequestAsync<SearchResults>(BuildUri($"?s={query}&type=series"));
        }

        public async Task<SearchResult> FirstSearchResultAsync(string query)
        {
            var result = await SearchAsync(query);
            return result?.SearchResult?.FirstOrDefault();
        }

        public async Task<Show> GetShowByIdAsync(string id)
        {
            return await GetRequestAsync<Show>(BuildUri($"?i={id}&type=series"));
        }

        public async Task<Season> GetSeasonAsync(string id, string season)
        {
            return await GetRequestAsync<Season>(BuildUri($"?i={id}&type=series&season={season}"));
        }

        public async Task<List<Season>> GetAllSeasonsAsync(string id)
        {
            var results = new List<Season>
            {
                await GetSeasonAsync(id, "1")
            };
            int.TryParse(results[0].TotalSeasons, out int totalSeasons);

            var tasks = new List<Task<Season>>();
            for (var i = 2; i <= totalSeasons; i++)
            {
                tasks.Add(GetSeasonAsync(id, i.ToString()));
            }
                                        
            await Task.WhenAll(tasks);
            tasks.ForEach(x => results.Add(x.Result));
            return results.OrderBy(x => int.Parse(x.SeasonNumber)).ToList();
        }

        public Uri BuildUri(string query)
        {
            var uriBuilder = new UriBuilder()
            {
                Host = "www.omdbapi.com",
                Query = $"{query}&apiKey={_apiKey}"
            };
            return uriBuilder.Uri;
        }
    }
}
