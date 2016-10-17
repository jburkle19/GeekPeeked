using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;
using PersonDetails = GeekPeeked.Common.Models.TMDb.Response.PersonDetails;

namespace GeekPeeked.Common.Models
{
    public class Image : ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public bool IsBackdrop { get; set; }

        [Required]
        public string FilePath { get; set; }        // "file_path"

        public int Width { get; set; }              // "width"
        public int Height { get; set; }             // "height"
        public double AspectRatio { get; set; }     // "aspect_ratio"

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public Image()
        {
            this.IsBackdrop = false;

            Movies = new HashSet<Movie>();
            People = new HashSet<Person>();
        }

        public Image(MovieDetails.Backdrop tmdbBackdrop)
        {
            this.IsBackdrop = true;
            this.FilePath = tmdbBackdrop.file_path;
            this.Width = tmdbBackdrop.width;
            this.Height = tmdbBackdrop.height;
            this.AspectRatio = tmdbBackdrop.aspect_ratio;
        }

        public Image(MovieDetails.Poster tmdbPoster)
        {
            this.IsBackdrop = false;
            this.FilePath = tmdbPoster.file_path;
            this.Width = tmdbPoster.width;
            this.Height = tmdbPoster.height;
            this.AspectRatio = tmdbPoster.aspect_ratio;
        }

        public Image(PersonDetails.Profile tmdbProfile)
        {
            this.IsBackdrop = false;
            this.FilePath = tmdbProfile.file_path;
            this.Width = tmdbProfile.width;
            this.Height = tmdbProfile.height;
            this.AspectRatio = tmdbProfile.aspect_ratio;
        }
    }
}
