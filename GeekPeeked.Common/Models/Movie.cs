using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models
{
    public class Movie
    {
    }
    //public class Movie : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    public Guid Id { get; set; }
    //    public int TmdbId { get; set; }                                    // "id"
    //    public string ImdbId { get; set; }                                 // "imdb_id"

    //    [Required]
    //    public string Title { get; set; }                                   // "title"
    //    public string OriginalTitle { get; set; }                           // "original_title"

    //    public string Description { get; set; }                             // "overview"
    //    public string Tagline { get; set; }                                 // "tagline"
    //    public int Runtime { get; set; }                                    // "runtime"
    //    public string PosterPath { get; set; }                              // "poster_path"
    //    public string HomePage { get; set; }                                // "homepage"

    //    public double Budget { get; set; }                                  // "budget"
    //    public double Revenue { get; set; }                                 // "revenue"

    //    [Required]
    //    public DateTime ReleaseDate { get; set; }                           // "release_date"

    //    public string Status { get; set; }                                  // "status"

    //    public bool IsVisible { get; set; }

    //    public bool IsAdult { get; set; }                                   // "adult"
    //    public bool HasVideos { get; set; }                                 // "video"

    //    public bool IsComingSoon { get; set; }
    //    public bool IsInTheaters { get; set; }
    //    public bool IsOnDVD { get; set; }
    //    public bool IsMajorRelease { get; set; }

    //    public Guid? OldMovieId { get; set; }

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    //public virtual ICollection<Genre> Genres { get; set; }                             // "genre_ids" ([12,878])
    //    //public virtual ICollection<Certification> Certifications { get; set; }
    //    //public virtual ICollection<ProductionCompany> ProductionCompanies { get; set; }    // "production_companies": [ { "name": "20th Century Fox", "id": 25 }, { "name": "Fox 2000 Pictures", "id": 711 }, { "name": "Regency Enterprises", "id": 508 } ],
    //    //public virtual ICollection<CastMember> CastMembers { get; set; }
    //    //public virtual ICollection<CrewMember> CrewMembers { get; set; }
    //    //public virtual ICollection<Poster> Posters { get; set; }
    //    //public virtual ICollection<Video> Videos { get; set; }

    //    public Movie()
    //    {
    //        this.Runtime = 0;
    //        this.Budget = 0;
    //        this.Revenue = 0;

    //        this.IsVisible = false;
    //        this.IsAdult = false;
    //        this.HasVideos = false;
    //        this.IsComingSoon = false;
    //        this.IsInTheaters = false;
    //        this.IsOnDVD = false;
    //        this.IsMajorRelease = false;

    //        //this.Genres = new HashSet<Genre>();
    //        //this.Certifications = new HashSet<Certification>();
    //        //this.ProductionCompanies = new HashSet<ProductionCompany>();
    //        //this.CastMembers = new HashSet<CastMember>();
    //        //this.CrewMembers = new HashSet<CrewMember>();
    //        //this.Posters = new HashSet<Poster>();
    //        //this.Videos = new HashSet<Video>();
    //    }
    //}

    //public class Genre : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int Id { get; set; }         // "id"

    //    [Required]
    //    public string Name { get; set; }    // "name"

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public Genre()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}

    //public class Certification : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    public int Id { get; set; }

    //    [Required]
    //    public string Country { get; set; }

    //    [Required]
    //    public int TypeId { get; set; }

    //    [Required]
    //    public string Name { get; set; }

    //    public string Description { get; set; }

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public Certification()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}

    //public class ProductionCompany : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int Id { get; set; }         // "id"

    //    [Required]
    //    public string Name { get; set; }    // "name"

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public ProductionCompany()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}

    //public class CastMember : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int Id { get; set; }                 // "id"

    //    public int CastId { get; set; }            // "cast_id"
    //    public string CreditId { get; set; }       // "credit_id"

    //    [Required]
    //    public string Name { get; set; }            // "name"

    //    public string CharacterName { get; set; }   // "character"
    //    public string ProfilePath { get; set; }     // "profile_path"

    //    public int Sequence { get; set; }           // "order"

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public CastMember()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}

    //public class CrewMember : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public int Id { get; set; }                 // "id"

    //    public string CreditId { get; set; }       // "credit_id"

    //    [Required]
    //    public string Name { get; set; }            // "name"

    //    public string Department { get; set; }      // "department"
    //    public string Job { get; set; }             // "job"
    //    public string ProfilePath { get; set; }     // "profile_path"

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public CrewMember()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}

    //public class Poster : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    public int Id { get; set; }

    //    [Required]
    //    public string FilePath { get; set; }        // "file_path"

    //    public int Width { get; set; }              // "width"
    //    public int Height { get; set; }             // "height"
    //    public double AspectRatio { get; set; }     // "aspect_ratio"

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public Poster()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}

    //public class Video : ITrackable
    //{
    //    [Key]
    //    [Required]
    //    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    //    public string Id { get; set; }      // "id"

    //    public string Key { get; set; }     // "key"
    //    public string Name { get; set; }    // "name"
    //    public string Site { get; set; }    // "site"
    //    public int Size { get; set; }       // "size"
    //    public string Type { get; set; }    // "type"

    //    public DateTime? CreatedDate { get; set; }
    //    public DateTime? ModifiedDate { get; set; }

    //    public virtual ICollection<Movie> Movies { get; set; }

    //    public Video()
    //    {
    //        Movies = new HashSet<Movie>();
    //    }
    //}
}
