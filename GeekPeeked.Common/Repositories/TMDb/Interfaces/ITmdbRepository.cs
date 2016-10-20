using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using GenreList = GeekPeeked.Common.Models.TMDb.Response.GenreList;
using ImdbDetails = GeekPeeked.Common.Models.TMDb.Response.ImdbDetails;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;
using PersonDetails = GeekPeeked.Common.Models.TMDb.Response.PersonDetails;
using DiscoverMovies = GeekPeeked.Common.Models.TMDb.Response.DiscoverMovies;
using CertificationList = GeekPeeked.Common.Models.TMDb.Response.CertificationList;

namespace GeekPeeked.Common.TMDb.Repositories
{
    public interface ITmdbRepository
    {
        Task<GenreList.ResponseModel> AllGenres();
        Task<CertificationList.ResponseModel> AllCertifications();

        Task<IEnumerable<DiscoverMovies.ResponseModel>> AllMovies(int year);
        Task<IEnumerable<DiscoverMovies.ResponseModel>> AllMovies(DateTime startDate, DateTime endDate);

        Task<MovieDetails.ResponseModel> MovieDetails(int id);
        Task<ImdbDetails.ResponseModel> MovieDetailsByImdbId(string imdbId);

        Task<PersonDetails.ResponseModel> PersonDetails(int personId);
    }
}
