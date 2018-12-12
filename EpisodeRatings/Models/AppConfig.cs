using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpisodeRatings.Models
{
    public class AppConfig
    {
        public string AllowedHosts {get; set;}
        public OmdbSettings OmdbSettings { get; set; }
    }
}
