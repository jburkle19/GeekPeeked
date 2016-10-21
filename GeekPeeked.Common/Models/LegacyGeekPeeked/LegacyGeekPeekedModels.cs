using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models.LegacyGeekPeeked
{
    [NotMapped]
    public class LegacyMovie
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImdbUrl { get; set; }
    }
}
