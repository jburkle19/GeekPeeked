using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models
{
    public class Movie : ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
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

        public virtual ICollection<Genre> Genres { get; set; }                             // "genre_ids" ([12,878])
        public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; }    // "production_companies": [ { "name": "20th Century Fox", "id": 25 }, { "name": "Fox 2000 Pictures", "id": 711 }, { "name": "Regency Enterprises", "id": 508 } ],

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Video> Videos { get; set; }

        public virtual ICollection<Certification> Certifications { get; set; }

        //public virtual ICollection<CastCredit> Cast { get; set; }
        //public virtual ICollection<CrewCredit> Crew { get; set; }

        public Movie()
        {
            this.Runtime = 0;
            this.Budget = 0;
            this.Revenue = 0;

            this.IsVisible = false;
            this.IsAdult = false;
            this.IsVideo = false;
            
            this.Genres = new HashSet<Genre>();
            this.ProductionCompanies = new HashSet<ProductionCompany>();

            this.Images = new HashSet<Image>();
            this.Videos = new HashSet<Video>();

            this.Certifications = new HashSet<Certification>();

            //this.Cast = new HashSet<CastCredit>();
            //this.Crew = new HashSet<CrewCredit>();
        }
    }
}
