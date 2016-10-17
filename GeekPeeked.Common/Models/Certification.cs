using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CertificationList = GeekPeeked.Common.Models.TMDb.Response.CertificationList;
namespace GeekPeeked.Common.Models
{
    public class Certification : ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public Certification()
        {
            Movies = new HashSet<Movie>();
        }

        public Certification(CertificationList.US tmdbUSCertifiction)
        {
            this.Country = "US";
            this.TypeId = tmdbUSCertifiction.order;
            this.Name = tmdbUSCertifiction.certification;
            this.Description = tmdbUSCertifiction.meaning;
        }
    }
}
