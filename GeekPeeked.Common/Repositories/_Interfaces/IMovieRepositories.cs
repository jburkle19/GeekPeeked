using System.Threading.Tasks;
using System.Collections.Generic;
using GeekPeeked.Common.Models;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;

namespace GeekPeeked.Common.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> AllJobs();
        void AddJob(Job job);
        void RemoveJob(Job job);
    }

    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> AllGenres();
        void AddGenre(Genre genre);
        void RemoveGenre(Genre genre);
    }

    public interface ICertificationRepository
    {
        Task<IEnumerable<Certification>> AllCertifications();
        void AddCertification(Certification certification);
        void RemoveCertification(Certification certification);
    }

    public interface IMovieRepository : IBaseRepository
    {
        Task<IEnumerable<Movie>> AllMovies();
        Task<Movie> Find(int id);
        void AddMovie(MovieDetails.ResponseModel tmdbMovie);
        void RemoveMovie(Movie movie);
    }

    //Task<IEnumerable<Certification>> AllCertifications();
    //void AddCertification(Certification genre);
    //void RemoveCertification(Certification genre);

    //Task<IEnumerable<ProductionCompany>> AllProductionCompanies();
    //void AddProductionCompany(ProductionCompany productCompany);
    //void RemoveProductionCompany(ProductionCompany productCompany);

    ////Task<IEnumerable<CastMember>> AllCastMembers();
    ////void AddCastMember(CastMember castMember);
    ////void RemoveCastMember(CastMember castMember);

    ////Task<IEnumerable<CrewMember>> AllCrewMembers();
    ////void AddCrewMember(CrewMember crewMember);
    ////void RemoveCrewMember(CrewMember crewMember);

    //Task<IEnumerable<Poster>> AllPosters();
    //void AddPoster(Poster poster);
    //void RemovePoster(Poster poster);

    //Task<IEnumerable<Video>> AllVideos();
    //void AddVideo(Video video);
    //void RemoveVideo(Video video);
}
