using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;

namespace GeekPeeked.Common.Models
{
    public class Keyword : ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }         // "id"

        [Required]
        public string Name { get; set; }    // "name"

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Keyword()
        {
            this.CreatedDate = DateTime.Now;

            this.Movies = new HashSet<Movie>();
        }

        public Keyword(MovieDetails.Keyword tmdbKeyword)
        {
            this.Id = tmdbKeyword.id;
            this.Name = tmdbKeyword.name;
            this.CreatedDate = DateTime.Now;

            this.Movies = new HashSet<Movie>();
        }
    }
}
