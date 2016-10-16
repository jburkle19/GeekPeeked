using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public JobRepository(GeekPeekedDbContext context) : base(context) { }

        public async Task<IEnumerable<Job>> AllJobs()
        {
            var jobs = from j in _context.Jobs select j;

            return await (jobs.ToListAsync());
        }

        public void AddJob(Job job)
        {
            job.CreatedDate = DateTime.Now;
            _context.Jobs.Add(job);
        }

        public void RemoveJob(Job job)
        {
            _context.Jobs.Remove(job);
        }
    }
}
