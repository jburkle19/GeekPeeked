using System.Collections.Generic;

namespace GeekPeeked.Common.Models.TMDb.Response.PersonDetails
{
    public class ResponseModel
    {
        public bool adult { get; set; }
        public List<object> also_known_as { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public string deathday { get; set; }
        public int gender { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string name { get; set; }
        public string place_of_birth { get; set; }
        public double popularity { get; set; }
        public string profile_path { get; set; }
        public MovieCredits movie_credits { get; set; }
        public ExternalIds external_ids { get; set; }
        public Images images { get; set; }
    }

    public class Cast
    {
        public bool adult { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
    }

    public class MovieCredits
    {
        public List<Cast> cast { get; set; }
        public List<object> crew { get; set; }
    }

    public class ExternalIds
    {
        public string facebook_id { get; set; }
        public string freebase_mid { get; set; }
        public string freebase_id { get; set; }
        public string imdb_id { get; set; }
        public string instagram_id { get; set; }
        public int tvrage_id { get; set; }
        public string twitter_id { get; set; }
    }

    public class Profile
    {
        public double aspect_ratio { get; set; }
        public string file_path { get; set; }
        public int height { get; set; }
        public object iso_639_1 { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }

    public class Images
    {
        public List<Profile> profiles { get; set; }
    }
}
