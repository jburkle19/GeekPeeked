using System.Linq;
using System.Web.Mvc;
using GeekPeeked.Web.App_Start;
using GeekPeeked.Web.ViewModels;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;

namespace GeekPeeked.Web.Controllers.Admin
{
    public class AdminController : Controller
    {
        private GeekPeekedDbContext _context;

        private Repository<Movie> _movie;
        private Repository<Genre> _genre;
        private Repository<Image> _image;
        private Repository<Video> _video;
        private Repository<Credit> _credit;
        private Repository<Person> _person;
        private Repository<Keyword> _keyword;
        private Repository<Certification> _certification;
        private Repository<ProductionCompany> _productionCompany;

        public AdminController()
        {
            _context = new GeekPeekedDbContext();

            _movie = new Repository<Movie>(_context);
            _genre = new Repository<Genre>(_context);
            _image = new Repository<Image>(_context);
            _video = new Repository<Video>(_context);
            _credit = new Repository<Credit>(_context);
            _person = new Repository<Person>(_context);
            _keyword = new Repository<Keyword>(_context);
            _certification = new Repository<Certification>(_context);
            _productionCompany = new Repository<ProductionCompany>(_context);

        }

        // GET: Admin
        [Authorization(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Genres
        public ActionResult Genres()
        {
            GenresViewModel viewModel = new GenresViewModel();

            viewModel.Genres = _genre.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Keywords
        public ActionResult Keywords()
        {
            KeywordsViewModel viewModel = new KeywordsViewModel();

            viewModel.Keywords = _keyword.GetAll().ToList();
            
            return View(viewModel);
        }

        // GET: Admin/ProductionCompanies
        public ActionResult ProductionCompanies()
        {
            ProductionCompaniesViewModel viewModel = new ProductionCompaniesViewModel();

            viewModel.ProductionCompanies = _productionCompany.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Certifications
        public ActionResult Certifications()
        {
            CertificationsViewModel viewModel = new CertificationsViewModel();

            viewModel.Certifications = _certification.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Credits
        public ActionResult Credits()
        {
            CreditsViewModel viewModel = new CreditsViewModel();

            viewModel.Credits = _credit.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Images
        public ActionResult Images()
        {
            ImagesViewModel viewModel = new ImagesViewModel();

            viewModel.Images = _image.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/People
        public ActionResult People()
        {
            PeopleViewModel viewModel = new PeopleViewModel();

            viewModel.People = _person.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Videos
        public ActionResult Videos()
        {
            VideosViewModel viewModel = new VideosViewModel();

            viewModel.Videos = _video.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Movies
        public ActionResult Movies(MoviesViewModel viewModel)
        {
            viewModel.Movies = _movie.GetAll().ToList();

            return View(viewModel);
        }

        // GET: Admin/Details/[id]
        public ActionResult Details(int id)
        {
            var movie = _movie.GetById(id);

            return View(movie);
        }
    }
}