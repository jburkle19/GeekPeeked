using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(GeekPeekedDbContext context) : base(context) { }

        public async Task<IEnumerable<Genre>> AllGenres()
        {
            var genres = from g in _context.Genres select g;

            return await (genres.ToListAsync());
        }

        public void AddGenre(Genre genre)
        {
            genre.CreatedDate = DateTime.Now;
            _context.Genres.Add(genre);
        }

        public void RemoveGenre(Genre genre)
        {
            _context.Genres.Remove(genre);
        }
    }
}
