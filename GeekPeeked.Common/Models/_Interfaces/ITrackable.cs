using System;

namespace GeekPeeked.Common.Models
{
    public interface ITrackable
    {
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}