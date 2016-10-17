using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models
{
    public class Person : ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }                         // "id"

        [Required]
        public string Name { get; set; }                    // "name"

        public DateTime Birthday { get; set; }              // "birthday"
        public DateTime Deathday { get; set; }              // "deathday"

        public string Biography { get; set; }               // "biography"
        public int Gender { get; set; }                     // "gender"
        public string HomePage { get; set; }                // "homepage"

        public string ImdbId { get; set; }                  // "imdb_id"
        public string FacebookId { get; set; }              // "facebook_id"
        public string InstagramId { get; set; }             // "instagram_id"
        public string TwitterId { get; set; }               // "twitter_id"

        public string BirthPlace { get; set; }              // "place_of_birth"
        public string ProfilePath { get; set; }             // "profile_path"

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Image> Images { get; set; }     // "images -> profiles"

        public virtual ICollection<CastCredit> CastCredits { get; set; }        // "movie_credits -> cast"
        public virtual ICollection<CrewCredit> CrewCredits { get; set; }        // "movie_credits -> crew"

        public Person()
        {
            Images = new HashSet<Image>();

            CastCredits = new HashSet<CastCredit>();
            CrewCredits = new HashSet<CrewCredit>();
        }
    }
}