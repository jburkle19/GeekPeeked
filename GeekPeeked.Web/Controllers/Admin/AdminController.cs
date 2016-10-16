using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using GeekPeeked.Web.App_Start;
using GeekPeeked.Web.ViewModels;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;
using GeekPeeked.Common.Configuration;

namespace GeekPeeked.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        private TmdbRepository _tmdbMovieRepo;
        private JobRepository _dbJobRepo;
        private GenreRepository _dbGenreRepo;

        public AdminController()
        {
            _tmdbMovieRepo = new TmdbRepository();
            _dbJobRepo = new JobRepository(new GeekPeekedDbContext());
            _dbGenreRepo = new GenreRepository(new GeekPeekedDbContext());
        }

        // GET: Admin
        [Authorization(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Jobs
        public async Task<ActionResult> Jobs()
        {
            // TODO - Import Jobs from Tmdb
            // TODO - Import Jobs from Tmdb

            JobsViewModel viewModel = new JobsViewModel();

            var response = await _tmdbMovieRepo.AllJobs();

            foreach (var department in response.jobs)
            {
                foreach (var job in department.job_list)
                {
                    viewModel.TMDbJobs.Add(new Job()
                    {
                        Department = department.department,
                        JobTitle = job
                    });
                }
            }

            var jobs = await _dbJobRepo.AllJobs();

            foreach (var job in jobs)
            {
                viewModel.GeekPeekedJobs.Add(job);
            }

            return View(viewModel);
        }

        // GET: Admin/Genres
        public async Task<ActionResult> Genres()
        {
            // TODO - Import Genres from Tmdb
            // TODO - Import Genres from Tmdb

            GenresViewModel viewModel = new GenresViewModel();

            var response = await _tmdbMovieRepo.AllGenres();

            foreach (var genre in response.genres)
            {
                viewModel.TMDbGenres.Add(new Genre()
                {
                    Id = genre.id,
                    Name = genre.name
                });
            }

            var genres = await _dbGenreRepo.AllGenres();

            foreach (var genre in genres)
            {
                viewModel.GeekPeekedGenres.Add(genre);
            }

            return View(viewModel);
        }

        //// GET: Admin/Movies
        //public async Task<ActionResult> Movies(MoviesViewModel viewModel)
        //{
        //    if (string.IsNullOrWhiteSpace(viewModel.StartDate))
        //    {
        //        DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 14);
        //        viewModel.StartDate = startDate.ToShortDateString();
        //        viewModel.EndDate = startDate.ToShortDateString();

        //        //DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        //        //viewModel.StartDate = startDate.ToShortDateString();

        //        //DateTime endDate = startDate.AddMonths(1).AddDays(-1);
        //        //viewModel.EndDate = endDate.ToShortDateString();
        //    }

        //    var movies = await _tmdbMovieRepo.AllMovies(Convert.ToDateTime(viewModel.StartDate), Convert.ToDateTime(viewModel.EndDate));

        //    foreach (var movie in movies)
        //    {
        //        foreach (var result in movie.results)
        //        {
        //            if (viewModel.TMDbMovies.FirstOrDefault(m => m.Id == result.id) == null)
        //            {
        //                if (result.popularity >= 2 ||
        //                    result.vote_count >= 10 ||
        //                    (!string.IsNullOrWhiteSpace(result.poster_path) && result.original_language == "en" && result.vote_count >= 2))
        //                {
        //                    viewModel.TMDbMovies.Add(new SimpleMovieViewModel()
        //                    {
        //                        Id = result.id,
        //                        PosterUrl = (string.IsNullOrWhiteSpace(result.poster_path) ? string.Empty : string.Format("{0}{1}", CoreConfiguration.TmdbImageBaseUrl, result.poster_path)),
        //                        Title = result.title,
        //                        ReleaseDate = Convert.ToDateTime(result.release_date),
        //                        Popularity = result.popularity,
        //                        AverageVote = result.vote_average,
        //                        VoteCount = result.vote_count
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return View(viewModel);
        //}

        //// GET: Admin/NowPlaying
        //public async Task<ActionResult> NowPlaying()
        //{
        //    NowPlayingViewModel viewModel = new NowPlayingViewModel();

        //    var movies = await _tmdbMovieRepo.AllNowPlayingMovies();

        //    foreach (var movie in movies)
        //    {
        //        foreach (var result in movie.results)
        //        {
        //            if (viewModel.TMDbMovies.FirstOrDefault(m => m.Id == result.id) == null)
        //            {
        //                if (result.popularity >= 2 ||
        //                    result.vote_count >= 10 ||
        //                    (!string.IsNullOrWhiteSpace(result.poster_path) && result.original_language == "en" && result.vote_count >= 2))
        //                {
        //                    viewModel.TMDbMovies.Add(new SimpleMovieViewModel()
        //                    {
        //                        Id = result.id,
        //                        PosterUrl = (string.IsNullOrWhiteSpace(result.poster_path) ? string.Empty : string.Format("{0}{1}", CoreConfiguration.TmdbImageBaseUrl, result.poster_path)),
        //                        Title = result.title,
        //                        ReleaseDate = Convert.ToDateTime(result.release_date),
        //                        Popularity = result.popularity,
        //                        AverageVote = result.vote_average,
        //                        VoteCount = result.vote_count
        //                    });
        //                }
        //            }
        //        }
        //    }

        //    return View(viewModel);
        //}

        //// GET: Admin/Certifications
        //public async Task<ActionResult> Certifications()
        //{
        //    CertificationsViewModel viewModel = new CertificationsViewModel();

        //    var response = await _tmdbMovieRepo.AllCertifications();

        //    foreach (var certification in response.certifications.AU)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "AU",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.BG)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "BG",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.BR)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "BR",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.CA)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "CA",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.DE)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "DE",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.ES)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "ES",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.FI)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "FI",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.FR)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "FR",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.GB)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "GB",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.IN)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "IN",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.NL)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "NL",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.NZ)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "NZ",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.PH)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "PH",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.PT)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "PT",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }
        //    foreach (var certification in response.certifications.US)
        //    {
        //        viewModel.TMDbCertifications.Add(new Certification()
        //        {
        //            Country = "US",
        //            TypeId = certification.order,
        //            Name = certification.certification,
        //            Description = certification.meaning
        //        });
        //    }

        //    var certifications = await _dbMovieRepo.AllCertifications();

        //    foreach (var certification in certifications)
        //    {
        //        viewModel.GeekPeekedCertifications.Add(certification);
        //    }

        //    return View(viewModel);
        //}

        //// GET: Admin/Details/[id]
        //public async Task<ActionResult> Details(string id)
        //{
        //    var result = await _tmdbMovieRepo.Find(id);

        //    Movie viewModel = new Movie()
        //    {
        //        Id = Guid.NewGuid(),
        //        TmdbId = result.id,
        //        ImdbId = result.imdb_id,
        //        Title = result.title,
        //        OriginalTitle = result.original_title,
        //        Description = result.overview,
        //        Tagline = result.tagline,
        //        Runtime = result.runtime,
        //        PosterPath = (string.IsNullOrWhiteSpace(result.poster_path) ? string.Empty : string.Format("{0}{1}", CoreConfiguration.TmdbImageBaseUrl, result.poster_path)),
        //        HomePage = result.homepage,
        //        Budget = result.budget,
        //        Revenue = result.revenue,
        //        ReleaseDate = Convert.ToDateTime(result.release_date),
        //        Status = result.status,
        //        IsAdult = result.adult,
        //        HasVideos = result.video
        //    };

        //    return View(viewModel);
        //}

        //// POST: Admin/AddMovie/[id]
        //[HttpPost]
        //public async Task<ActionResult> AddMovie(string id)
        //{
        //    var tmdbMovie = await _tmdbMovieRepo.Find(id);

        //    try
        //    {
        //        Movie movie = await _dbMovieRepo.CreateMovie(tmdbMovie);
        //        _dbMovieRepo.Save();

        //        return Json(string.Format("Successfully created GeekPeeked Db Movie {0}", movie.Id));
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.ToString());
        //    }
        //}
    }
}