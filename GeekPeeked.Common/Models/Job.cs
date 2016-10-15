using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekPeeked.Common.Models
{
    public class Job : ITrackable
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

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
