using System.Web.Mvc;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Jobs()
        {
            JobsViewModel viewModel = new JobsViewModel();

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
            GenresViewModel viewModel = new GenresViewModel();

            var genres = await _dbGenreRepo.AllGenres();

            foreach (var genre in genres)
            {
                viewModel.GeekPeekedGenres.Add(genre);
            }

            return View(viewModel);
        }

        // GET: Admin/Certifications
        public async Task<ActionResult> Certifications()
        {
            CertificationsViewModel viewModel = new CertificationsViewModel();

            var certifications = await _dbCertificationRepo.AllCertifications();

            foreach (var certification in certifications)
            {
                viewModel.GeekPeekedCertifications.Add(certification);
            }

            return View(viewModel);
        }

        // GET: Admin/Movies
        public async Task<ActionResult> Movies(MoviesViewModel viewModel)
        {
            var movies = await _dbMovieRepo.AllMovies();

            foreach (var movie in movies)
            {
                viewModel.GeekPeekedMovies.Add(movie);
            }

            return View(viewModel);
        }

        // GET: Admin/Details/[id]
        public async Task<ActionResult> Details(int id)
        {
            var movie = await _dbMovieRepo.Find(id);

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