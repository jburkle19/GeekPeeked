//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace GeekPeeked.Common.Models
//{
//    public class CastCredit : Credit
//    {
//        [Required]
//        public string CharacterName { get; set; }            // "character"

//        public int Sequence { get; set; }
//    }

//    public class CrewCredit : Credit
//    {
//        public int JobId { get; set; }

//        [ForeignKey("JobId")]
//        public virtual Job Job { get; set; }
//    }

//    public abstract class Credit : ITrackable
//    {
//        [Key]
//        [Required]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }

//        [Required]
//        public string CreditId { get; set; }            // "credit_id"

//        public int PersonId { get; set; }

//        [ForeignKey("PersonId")]
//        public virtual Person Person { get; set; }

//        public int TmdbId { get; set; }

//        [ForeignKey("TmdbId")]
//        public virtual Movie Movie { get; set; }

//        public DateTime? CreatedDate { get; set; }
//        public DateTime? ModifiedDate { get; set; }

//        public Credit()
//        {
//        }
//    }
//}
