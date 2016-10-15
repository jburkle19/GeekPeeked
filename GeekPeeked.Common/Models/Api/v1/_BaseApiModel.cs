using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Common.Models.Api
{
    [NotMapped]
    public class ApiVersion
    {
        public const string V1 = "v1";
    }

    [NotMapped]
    public class ApiStatus
    {
        public const string SENT = "SENT";
        public const string SUCCEEDED = "SUCCEEDED";
        public const string FAILED = "FAILED";
    }

    public class BaseApiModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Foreign key to AspNetUser table
        [Column("UserID")]
        public string UserID { get; set; }

        [Required]
        public string ApiVersion { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string RequestJSON { get; set; }

        public DateTime? RequestDate { get; set; }

        [Required]
        public string ResponseJSON { get; set; }

        public DateTime? ResponseDate { get; set; }

        public BaseApiModel()
        {
            this.ApiVersion = Api.ApiVersion.V1;
        }
    }
}