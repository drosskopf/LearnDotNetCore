using System.Collections.Generic;
using Newtonsoft.Json;

namespace webapp{
    
public class Rating
{
    public string Source { get; set; }
    public string Value { get; set; }
}

public class Movie
{
    public string Title { get; set; }
    [JsonIgnore]
    public string Year { get; set; }
    [JsonIgnore]
    public string Rated { get; set; }
    [JsonIgnore]
    public string Released { get; set; }
    [JsonIgnore]
    public string Runtime { get; set; }
    [JsonIgnore]
    public string Genre { get; set; }
    [JsonIgnore]
    public string Director { get; set; }
    [JsonIgnore]
    public string Writer { get; set; }
    [JsonIgnore]
    public string Actors { get; set; }
    [JsonIgnore]
    public string Plot { get; set; }
    [JsonIgnore]
    public string Language { get; set; }
    [JsonIgnore]
    public string Country { get; set; }
    [JsonIgnore]
    public string Awards { get; set; }
    [JsonIgnore]
    public string Poster { get; set; }
    [JsonIgnore]
    public List<Rating> Ratings { get; set; }
    [JsonIgnore]
    public string Metascore { get; set; }
    [JsonIgnore]
    public string imdbRating { get; set; }
    public string imdbVotes { get; set; }
    public string imdbID { get; set; }
    public string Type { get; set; }
    public string DVD { get; set; }
    public string BoxOffice { get; set; }
    public string Production { get; set; }
    public string Website { get; set; }
    public string Response { get; set; }
}
}