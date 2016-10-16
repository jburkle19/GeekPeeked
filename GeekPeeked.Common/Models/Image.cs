using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            Movies = new HashSet<Movie>();
            People = new HashSet<Person>();
        }
    }
}
