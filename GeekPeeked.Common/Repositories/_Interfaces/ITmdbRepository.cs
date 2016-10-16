using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using JobList = GeekPeeked.Common.Models.TMDb.Response.JobList;
using GenreList = GeekPeeked.Common.Models.TMDb.Response.GenreList;
using ImdbDetails = GeekPeeked.Common.Models.TMDb.Response.ImdbDetails;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;
using PersonDetails = GeekPeeked.Common.Models.TMDb.Response.PersonDetails;
using DiscoverMovie = GeekPeeked.Common.Models.TMDb.Response.DiscoverMovie;
using CertificationList = GeekPeeked.Common.Models.TMDb.Response.CertificationList;

namespace GeekPeeked.Common.Repositories
{
    public interface ITmdbRepository
    {
        Task<JobList.ResponseModel> AllJobs();
        Task<GenreList.ResponseModel> AllGenres();
        //Task<CertificationList.ResponseModel> AllCertifications();

        //Task<MovieDetails.ResponseModel> MovieDetails(string tmdbId);
        //Task<ImdbDetails.ResponseModel> MovieDetailsByImdbId(string imdbId);

        //Task<IEnumerable<DiscoverMovie.ResponseModel>> AllMovies(int year);
        //Task<IEnumerable<DiscoverMovie.ResponseModel>> AllMovies(DateTime startDate, DateTime endDate);

        //Task<PersonDetails.ResponseModel> PersonDetails(string personId);
    }
}
