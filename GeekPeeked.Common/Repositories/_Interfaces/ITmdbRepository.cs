using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using GenreList = GeekPeeked.Common.Models.TMDb.Response.GenreList;

namespace GeekPeeked.Common.Repositories
{
    public interface ITmdbRepository
    {
        Task<GenreList.ResponseModel> AllGenres();

        //Task<IEnumerable<DiscoverMovie.ResponseModel>> AllMovies(int year);
        //Task<IEnumerable<DiscoverMovie.ResponseModel>> AllMovies(DateTime startDate, DateTime endDate);
        //Task<IEnumerable<Upcoming.ResponseModel>> AllUpcomingMovies();
        //Task<IEnumerable<NowPlaying.ResponseModel>> AllNowPlayingMovies();

        //Task<Movie.ResponseModel> Find(string id);

        //Task<CertificationList.ResponseModel> AllCertifications();
    }
}
