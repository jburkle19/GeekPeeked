using System.Collections.Generic;

namespace GeekPeeked.Common.Models.TMDb.Response.JobList
{
    public class ResponseModel
    {
        public List<Job> jobs { get; set; }
    }

    public class Job
    {
        public string department { get; set; }
        public List<string> job_list { get; set; }
    }
}
