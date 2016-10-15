using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekPeeked.Common.Models
{
    public class Person //: ITrackable
    {
    }
}

// CAST MEMEMBER
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

// CREW MEMBER
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