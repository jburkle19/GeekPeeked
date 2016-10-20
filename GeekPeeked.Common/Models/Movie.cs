using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;

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
        public DateTime? ReleaseDate { get; set; }                           // "release_date"

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

        public virtual ICollection<Keyword> Keywords { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }

        public virtual ICollection<Credit> Credits { get; set; }        // "movie_credits -> cast" && "movie_credits -> crew"

        public Movie()
        {
            this.CreatedDate = DateTime.Now;

            this.Genres = new HashSet<Genre>();
            this.Images = new HashSet<Image>();
            this.Videos = new HashSet<Video>();
            this.Keywords = new HashSet<Keyword>();
            this.Certifications = new HashSet<Certification>();
            this.ProductionCompanies = new HashSet<ProductionCompany>();

            this.Credits = new HashSet<Credit>();
        }

        public Movie(MovieDetails.ResponseModel tmdbMovie)
        {
            this.Runtime = 0;
            this.Budget = 0;
            this.Revenue = 0;

            this.IsVisible = false;
            this.IsAdult = false;
            this.IsVideo = false;

            this.TmdbId = tmdbMovie.id;
            this.ImdbId = tmdbMovie.imdb_id;
            this.Title = tmdbMovie.title;
            this.OriginalTitle = tmdbMovie.original_title;
            this.Description = tmdbMovie.overview;
            this.Tagline = tmdbMovie.tagline;
            this.PosterPath = tmdbMovie.poster_path;
            this.HomePage = tmdbMovie.homepage;

            int tempRuntime = 0;
            Int32.TryParse(tmdbMovie.runtime, out tempRuntime);
            this.Runtime = tempRuntime;

            int tempBudget = 0;
            Int32.TryParse(tmdbMovie.budget, out tempBudget);
            this.Budget = tempBudget;

            int tempRevenue = 0;
            Int32.TryParse(tmdbMovie.revenue, out tempRevenue);
            this.Revenue = tempRevenue;

            DateTime releaseDate = new DateTime();
            if (DateTime.TryParse(tmdbMovie.release_date, out releaseDate))
                this.ReleaseDate = releaseDate;

            this.Status = tmdbMovie.status;

            if (tmdbMovie.vote_count >= 10 ||
                (!string.IsNullOrWhiteSpace(tmdbMovie.poster_path) && tmdbMovie.popularity >= 2) ||
                (!string.IsNullOrWhiteSpace(tmdbMovie.poster_path) && tmdbMovie.original_language == "en" && tmdbMovie.vote_count >= 5))
            {
                this.IsVisible = true;
            }
            else
                this.IsVisible = false;

            this.IsAdult = tmdbMovie.adult;
            this.IsVideo = tmdbMovie.video;

            this.CreatedDate = DateTime.Now;

            this.Genres = new HashSet<Genre>();
            this.Images = new HashSet<Image>();
            this.Videos = new HashSet<Video>();
            this.Keywords = new HashSet<Keyword>();
            this.Certifications = new HashSet<Certification>();
            this.ProductionCompanies = new HashSet<ProductionCompany>();

            this.Credits = new HashSet<Credit>();
        }
    }
}
