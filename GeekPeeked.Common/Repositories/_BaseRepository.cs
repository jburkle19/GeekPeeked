using GeekPeeked.Common.Models;
using GeekPeeked.Common.Configuration;

namespace GeekPeeked.Common.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected GeekPeekedDbContext _context;
        public string TmdbApiKey = TMDbCoreConfiguration.TmdbApiKey;

        public BaseRepository()
        {
        }

        public BaseRepository(GeekPeekedDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
