using System.Threading.Tasks;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> AllGenres();
        void AddGenre(Genre genre);
        void RemoveGenre(Genre genre);
    }
}
