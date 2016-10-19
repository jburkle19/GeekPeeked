using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        protected GeekPeekedDbContext _context;
        
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
