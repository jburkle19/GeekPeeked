using System.Collections.Generic;

namespace GeekPeeked.Common.Models.TMDb.Response.GenreList
{
    public class ResponseModel
    {
        public List<Genre> genres { get; set; }
    }

    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}