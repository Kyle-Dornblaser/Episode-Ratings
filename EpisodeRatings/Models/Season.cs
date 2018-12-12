using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodeRatings.Models
{
    public class Season
    {
        public string Title { get; set; }
        [JsonProperty(PropertyName = "Season")]
        public string SeasonNumber { get; set; }
        public string TotalSeasons { get; set; }
        public List<Episode> Episodes { get; set; }
        public string Response { get; set; }
    }
}
