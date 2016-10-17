using System.Web.Mvc;
using GeekPeeked.Web.App_Start;
using GeekPeeked.Web.ViewModels;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;

namespace GeekPeeked.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        private JobRepository _dbJobRepo;
        private GenreRepository _dbGenreRepo;
        private CertificationRepository _dbCertificationRepo;
        private MovieRepository _dbMovieRepo;

        public AdminController()
        {
            _dbJobRepo = new JobRepository(new GeekPeekedDbContext());
            _dbGenreRepo = new GenreRepository(new GeekPeekedDbContext());
            _dbCertificationRepo = new CertificationRepository(new GeekPeekedDbContext());
            _dbMovieRepo = new MovieRepository(new GeekPeekedDbContext());
        }

        // GET: Admin
        [Authorization(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Jobs
        public ActionResult Jobs()
        {
            JobsViewModel viewModel = new JobsViewModel();

            var jobs = _dbJobRepo.AllJobs();

            foreach (var job in jobs)
            {
                viewModel.GeekPeekedJobs.Add(job);
            }

            return View(viewModel);
        }

        // GET: Admin/Genres
        public ActionResult Genres()
        {
            GenresViewModel viewModel = new GenresViewModel();

            var genres = _dbGenreRepo.AllGenres();

            foreach (var genre in genres)
            {
                viewModel.GeekPeekedGenres.Add(genre);
            }

            return View(viewModel);
        }

        // GET: Admin/Certifications
        public ActionResult Certifications()
        {
            CertificationsViewModel viewModel = new CertificationsViewModel();

            var certifications = _dbCertificationRepo.AllCertifications();

            foreach (var certification in certifications)
            {
                viewModel.GeekPeekedCertifications.Add(certification);
            }

            return View(viewModel);
        }

        // GET: Admin/Movies
        public ActionResult Movies(MoviesViewModel viewModel)
        {
            var movies = _dbMovieRepo.AllMovies();

            foreach (var movie in movies)
            {
                viewModel.GeekPeekedMovies.Add(movie);
            }

            return View(viewModel);
        }

        // GET: Admin/Details/[id]
        public ActionResult Details(int id)
        {
            var movie = _dbMovieRepo.Find(id);

            return View(movie);
        }

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