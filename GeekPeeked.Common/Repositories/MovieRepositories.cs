using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using GeekPeeked.Common.Models;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;

namespace GeekPeeked.Common.Repositories
{
    public class JobRepository : BaseRepository, IJobRepository
    {
        public JobRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<Job> AllJobs()
        {
            var jobs = from j in _context.Jobs select j;

            return jobs.ToList();
        }

        public void AddJob(Job job)
        {
            job.CreatedDate = DateTime.Now;
            _context.Jobs.Add(job);
        }
        public void RemoveJob(Job job)
        {
            _context.Jobs.Remove(job);
        }
    }

    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<Genre> AllGenres()
        {
            var genres = from g in _context.Genres select g;

            return genres.ToList();
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

    public class KeywordRepository : BaseRepository, IKeywordRepository
    {
        public KeywordRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<Keyword> AllKeywords()
        {
            var keywords = from k in _context.Keywords select k;

            return keywords.ToList();
        }

        public void AddKeyword(Keyword keyword)
        {
            keyword.CreatedDate = DateTime.Now;
            _context.Keywords.Add(keyword);
        }
        public void RemoveKeyword(Keyword keyword)
        {
            _context.Keywords.Remove(keyword);
        }
    }

    public class CertificationRepository : BaseRepository, ICertificationRepository
    {
        public CertificationRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<Certification> AllCertifications()
        {
            var certifications = from c in _context.Certifications select c;

            return certifications.ToList();
        }

        public void AddCertification(Certification certification)
        {
            certification.CreatedDate = DateTime.Now;
            _context.Certifications.Add(certification);
        }
        public void RemoveCertification(Certification certification)
        {
            _context.Certifications.Remove(certification);
        }
    }

    public class ProductionCompanyRepository : BaseRepository, IProductionCompanyRepository
    {
        public ProductionCompanyRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<ProductionCompany> AllProductionCompanies()
        {
            var productionCompanies = from pc in _context.ProductionCompanies select pc;

            return productionCompanies.ToList();
        }

        public void AddProductionCompany(ProductionCompany productionCompany)
        {
            productionCompany.CreatedDate = DateTime.Now;
            _context.ProductionCompanies.Add(productionCompany);
        }
        public void RemoveProductionCompany(ProductionCompany productionCompany)
        {
            _context.ProductionCompanies.Remove(productionCompany);
        }
    }

    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(GeekPeekedDbContext context) : base(context) { }

        public Movie Find(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            return movie;
        }

        public IEnumerable<Movie> AllMovies()
        {
            var movies = from m in _context.Movies select m;

            return movies.ToList();
        }

        public void AddMovie(Movie movie)
        {
            movie.CreatedDate = DateTime.Now;
            _context.Movies.Add(movie);
        }
        public void AddMovie(MovieDetails.ResponseModel tmdbMovie)
        {
            bool isNewMovie = false;
            var movie =  _context.Movies.FirstOrDefault(m => m.TmdbId == tmdbMovie.id);

            if (movie == null)
            {
                isNewMovie = true;
                movie = new Movie();
            }

            movie.TmdbId = tmdbMovie.id;
            movie.ImdbId = tmdbMovie.imdb_id;
            movie.Title = tmdbMovie.title;
            movie.OriginalTitle = tmdbMovie.original_title;
            movie.Description = tmdbMovie.overview;
            movie.Tagline = tmdbMovie.tagline;
            movie.PosterPath = tmdbMovie.poster_path;
            movie.HomePage = tmdbMovie.homepage;

            int tempRuntime = 0;
            Int32.TryParse(tmdbMovie.runtime, out tempRuntime);
            movie.Runtime = tempRuntime;

            int tempBudget = 0;
            Int32.TryParse(tmdbMovie.budget, out tempBudget);
            movie.Budget = tempBudget;

            int tempRevenue = 0;
            Int32.TryParse(tmdbMovie.revenue, out tempRevenue);
            movie.Revenue = tempRevenue;

            DateTime releaseDate = new DateTime();
            DateTime.TryParse(tmdbMovie.release_date, out releaseDate);
            movie.ReleaseDate = Convert.ToDateTime(releaseDate);

            movie.Status = tmdbMovie.status;

            if (tmdbMovie.vote_count >= 10 ||
                (!string.IsNullOrWhiteSpace(tmdbMovie.poster_path) && tmdbMovie.popularity >= 2) ||
                (!string.IsNullOrWhiteSpace(tmdbMovie.poster_path) && tmdbMovie.original_language == "en" && tmdbMovie.vote_count >= 2))
            {
                movie.IsVisible = true;
            }
            else
                movie.IsVisible = false;

            movie.IsAdult = tmdbMovie.adult;
            movie.IsVideo = tmdbMovie.video;

            #region Set Genres

            foreach (var genre in tmdbMovie.genres)
            {
                var myGenre = _context.Genres.FirstOrDefault(g => g.Id == genre.id);
                if (myGenre == null)
                    movie.Genres.Add(new Genre() { Id = genre.id, Name = genre.name, CreatedDate = DateTime.Now });
                else
                    movie.Genres.Add(myGenre);
            }

            #endregion Set Genres

            #region Set Production Companies

            foreach (var company in tmdbMovie.production_companies)
            {
                var myCompany = _context.ProductionCompanies.FirstOrDefault(pc => pc.Id == company.id);
                if (myCompany == null)
                    movie.ProductionCompanies.Add(new ProductionCompany() { Id = company.id, Name = company.name, CreatedDate = DateTime.Now });
                else
                    movie.ProductionCompanies.Add(myCompany);
            }

            #endregion Set Production Companies

            #region Set Keywords

            foreach (var keyword in tmdbMovie.keywords.keywords)
            {
                var myKeyword = _context.Keywords.FirstOrDefault(k => k.Id == keyword.id);
                if (myKeyword == null)
                    movie.Keywords.Add(new Keyword() { Id = keyword.id, Name = keyword.name, CreatedDate = DateTime.Now });
                else
                    movie.Keywords.Add(myKeyword);
            }

            #endregion Set Keywords

            #region Set Videos

            foreach (var video in tmdbMovie.videos.results)
            {
                var myVideo = _context.Videos.FirstOrDefault(v => v.Id == video.id);
                if (myVideo == null)
                    movie.Videos.Add(new Video() { Id = video.id, Key = video.key, Name = video.name, Site = video.site, Size = video.size, Type = video.type, CreatedDate = DateTime.Now });
                else
                    movie.Videos.Add(myVideo);
            }

            #endregion Set Videos

            #region Set Images

            foreach (var poster in tmdbMovie.images.posters)
            {
                var myPoster = _context.Images.FirstOrDefault(p => p.FilePath == poster.file_path);
                if (myPoster == null)
                    movie.Images.Add(new Image() { IsBackdrop = false, AspectRatio = poster.aspect_ratio, FilePath = poster.file_path, Height = poster.height, Width = poster.width, CreatedDate = DateTime.Now });
                else
                    movie.Images.Add(myPoster);
            }

            foreach (var backDrops in tmdbMovie.images.backdrops)
            {
                var myBackDrop = _context.Images.FirstOrDefault(p => p.FilePath == backDrops.file_path);
                if (myBackDrop == null)
                    movie.Images.Add(new Image() { IsBackdrop = true, AspectRatio = backDrops.aspect_ratio, FilePath = backDrops.file_path, Height = backDrops.height, Width = backDrops.width, CreatedDate = DateTime.Now });
                else
                    movie.Images.Add(myBackDrop);
            }

            #endregion Set Images

            if (isNewMovie)
            {
                movie.CreatedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
                movie.ModifiedDate = DateTime.Now;
        }
        public void RemoveMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
        }
    }

    public class ImageRepository : BaseRepository, IImageRepository
    {
        public ImageRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<Image> AllImages()
        {
            var images = from i in _context.Images select i;

            return images.ToList();
        }

        public void AddImage(Image image)
        {
            image.CreatedDate = DateTime.Now;
            _context.Images.Add(image);
        }
        public void RemoveImage(Image image)
        {
            _context.Images.Remove(image);
        }
    }

    public class VideoRepository : BaseRepository, IVideoRepository
    {
        public VideoRepository(GeekPeekedDbContext context) : base(context) { }

        public IEnumerable<Video> AllVideos()
        {
            var videos = from v in _context.Videos select v;

            return videos.ToList();
        }

        public void AddVideo(Video video)
        {
            video.CreatedDate = DateTime.Now;
            _context.Videos.Add(video);
        }
        public void RemoveVideo(Video video)
        {
            _context.Videos.Remove(video);
        }
    }
}
