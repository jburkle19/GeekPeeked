﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenreList = GeekPeeked.Common.Models.TMDb.Response.GenreList;
namespace GeekPeeked.Common.Models
{
    public class Genre : ITrackable
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

        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public Genre(GenreList.Genre tmdbGenre)
        {
            this.Id = tmdbGenre.id;
            this.Name = tmdbGenre.name;
        }
    }
}
