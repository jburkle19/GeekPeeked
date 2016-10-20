using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models
{
    public class Credit : ITrackable
    {
        [Key, Column(Order = 0)]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [Required]
        public string CreditId { get; set; }            // "credit_id"

        public string Department { get; set; }          // "department"
        public string JobTitle { get; set; }            // "job"

        public string CharacterName { get; set; }       // "character"
        public int Sequence { get; set; }               // "order"

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Credit()
        {
            this.Sequence = 0;
            this.CreatedDate = DateTime.Now;
        }
    }
}
