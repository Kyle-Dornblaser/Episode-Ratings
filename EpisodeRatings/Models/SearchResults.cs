using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodeRatings.Models
{
    public class SearchResults
    {
        [JsonProperty(PropertyName = "Search")]
        public List<SearchResult> SearchResult { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
