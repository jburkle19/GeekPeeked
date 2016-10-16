using System.Threading.Tasks;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> AllJobs();
        void AddJob(Job job);
        void RemoveJob(Job job);
    }
}
