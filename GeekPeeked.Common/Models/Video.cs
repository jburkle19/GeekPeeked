using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;

namespace GeekPeeked.Common.Models
{
    public class Video //: ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }      // "id"

        public string Key { get; set; }     // "key"
        public string Name { get; set; }    // "name"
        public string Site { get; set; }    // "site"
        public int Size { get; set; }       // "size"
        public string Type { get; set; }    // "type"

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Video()
        {
            Movies = new HashSet<Movie>();
        }

        public Video(MovieDetails.VideoResult tmdbVideo)
        {
            this.Id = tmdbVideo.id;
            this.Key = tmdbVideo.key;
            this.Name = tmdbVideo.name;
            this.Site = tmdbVideo.site;
            this.Size = tmdbVideo.size;
            this.Type = tmdbVideo.type;
        }
    }
}
