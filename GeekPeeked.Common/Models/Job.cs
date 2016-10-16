using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models
{
    public class Job : ITrackable
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        //public virtual ICollection<CrewCredit> CrewCredits { get; set; }

        public Job()
        {
            //CrewCredits = new HashSet<CrewCredit>();
        }
    }
}
