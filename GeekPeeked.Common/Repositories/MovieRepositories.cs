using System;
using System.Linq;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

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
