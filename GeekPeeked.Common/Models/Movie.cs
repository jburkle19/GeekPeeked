using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models
{
    public class Movie : ITrackable
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public int TmdbId { get; set; }                                    // "id"
        public string ImdbId { get; set; }                                 // "imdb_id"

        [Required]
        public string Title { get; set; }                                   // "title"
        public string OriginalTitle { get; set; }                           // "original_title"

        public string Description { get; set; }                             // "overview"
        public string Tagline { get; set; }                                 // "tagline"
        public int Runtime { get; set; }                                    // "runtime"
        public string PosterPath { get; set; }                              // "poster_path"
        public string HomePage { get; set; }                                // "homepage"

        public double Budget { get; set; }                                  // "budget"
        public double Revenue { get; set; }                                 // "revenue"

        [Required]
        public DateTime ReleaseDate { get; set; }                           // "release_date"

        public string Status { get; set; }                                  // "status"

        public bool IsVisible { get; set; }

        public bool IsAdult { get; set; }                                   // "adult"
        public bool IsVideo { get; set; }                                   // "video"

        public Guid? OldMovieId { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public virtual ICollection<Genre> Genres { get; set; }                             // "genre_ids" ([12,878])
        //public virtual ICollection<Certification> Certifications { get; set; }
        //public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; }    // "production_companies": [ { "name": "20th Century Fox", "id": 25 }, { "name": "Fox 2000 Pictures", "id": 711 }, { "name": "Regency Enterprises", "id": 508 } ],
        //public virtual ICollection<CastMember> CastMembers { get; set; }
        //public virtual ICollection<CrewMember> CrewMembers { get; set; }
        //public virtual ICollection<Poster> Posters { get; set; }
        //public virtual ICollection<Video> Videos { get; set; }

        public Movie()
        {
            this.Runtime = 0;
            this.Budget = 0;
            this.Revenue = 0;

            this.IsVisible = false;
            this.IsAdult = false;
            this.IsVideo = false;
            
            //this.Genres = new HashSet<Genre>();
            //this.Certifications = new HashSet<Certification>();
            //this.ProductionCompanies = new HashSet<ProductionCompany>();
            //this.CastMembers = new HashSet<CastMember>();
            //this.CrewMembers = new HashSet<CrewMember>();
            //this.Posters = new HashSet<Poster>();
            //this.Videos = new HashSet<Video>();
        }
    }
}
