﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;

namespace GeekPeeked.Common.Models
{
    public class ProductionCompany : ITrackable
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

        public ProductionCompany()
        {
            this.CreatedDate = DateTime.Now;

            this.Movies = new HashSet<Movie>();
        }

        public ProductionCompany(MovieDetails.ProductionCompany tmdbProductionCompany)
        {
            this.Id = tmdbProductionCompany.id;
            this.Name = tmdbProductionCompany.name;
            this.CreatedDate = DateTime.Now;

            this.Movies = new HashSet<Movie>();
        }
    }
}
