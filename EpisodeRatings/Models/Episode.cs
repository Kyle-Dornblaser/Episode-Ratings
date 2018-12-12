using Newtonsoft.Json;

public class Episode
{
    public string Title { get; set; }
    public string Released { get; set; }
    [JsonProperty(PropertyName = "Episode")]
    public string EpisodeNumber { get; set; }
    public string ImdbRating { get; set; }
    public string ImdbID { get; set; }
}