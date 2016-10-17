using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public interface IJobRepository
    {
        IEnumerable<Job> AllJobs();

        void AddJob(Job job);
        void RemoveJob(Job job);
    }

    public interface IGenreRepository
    {
        IEnumerable<Genre> AllGenres();

        void AddGenre(Genre genre);
        void RemoveGenre(Genre genre);
    }

    public interface IKeywordRepository
    {
        IEnumerable<Keyword> AllKeywords();

        void AddKeyword(Keyword keyword);
        void RemoveKeyword(Keyword keyword);
    }

    public interface ICertificationRepository
    {
        IEnumerable<Certification> AllCertifications();

        void AddCertification(Certification certification);
        void RemoveCertification(Certification certification);
    }

    public interface IProductionCompanyRepository
    {
        IEnumerable<ProductionCompany> AllProductionCompanies();

        void AddProductionCompany(ProductionCompany productCompany);
        void RemoveProductionCompany(ProductionCompany productCompany);
    }

    public interface IMovieRepository : IBaseRepository
    {
        Movie Find(int id);

        IEnumerable<Movie> AllMovies();

        void AddMovie(Movie movie);
        void RemoveMovie(Movie movie);
    }

    public interface IImageRepository : IBaseRepository
    {
        IEnumerable<Image> AllImages();

        void AddImage(Image image);
        void RemoveImage(Image image);
    }

    public interface IVideoRepository : IBaseRepository
    {
        IEnumerable<Video> AllVideos();

        void AddVideo(Video video);
        void RemoveVideo(Video video);
    }
}
