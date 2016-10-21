using System.Collections.Generic;
using GeekPeeked.Common.Models.LegacyGeekPeeked;

namespace GeekPeeked.Common.LegacyGeekPeeked.Repositories
{
    public interface ILegacyMovieRepository
    {
        ICollection<LegacyMovie> AllMovies();
    }
}
