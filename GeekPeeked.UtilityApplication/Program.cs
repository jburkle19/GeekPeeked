using System;
using System.Linq;
using System.Threading.Tasks;
using GeekPeeked.Common.Models;
using GeekPeeked.UtilityApplication.Helpers;
using GeekPeeked.Common.Repositories;
using GeekPeeked.Common.TMDb.Repositories;
using GeekPeeked.Common.LegacyGeekPeeked.Repositories;

namespace GeekPeeked.UtilityApplication
{
    class Program
    {
        #region Repositories

        private static TmdbRepository _tmdb { get; set; }
        private static LegacyMovieRepository _legacyMovie { get; set; }

        private static Repository<Movie> _movie { get; set; }
        private static Repository<Genre> _genre { get; set; }
        private static Repository<Image> _image { get; set; }
        private static Repository<Video> _video { get; set; }
        private static Repository<Keyword> _keyword { get; set; }
        private static Repository<Certification> _certficiation { get; set; }
        private static Repository<ProductionCompany> _productionCompany { get; set; }

        private static Repository<Person> _person { get; set; }
        private static Repository<Credit> _credit { get; set; }

        #endregion Repositories

        static void Main(string[] args)
        {
            using (var _context = new GeekPeekedDbContext())
            {
                #region Initialize Repositories

                _tmdb = new TmdbRepository();
                _legacyMovie = new LegacyMovieRepository();

                _movie = new Repository<Movie>(_context);
                _genre = new Repository<Genre>(_context);
                _image = new Repository<Image>(_context);
                _video = new Repository<Video>(_context);
                _keyword = new Repository<Keyword>(_context);
                _certficiation = new Repository<Certification>(_context);
                _productionCompany = new Repository<ProductionCompany>(_context);

                _person = new Repository<Person>(_context);
                _credit = new Repository<Credit>(_context);

                #endregion Initialize Repositories

                bool keepRunning = true;

                MyConsole.OutputMessage("########################################################################", ConsoleColor.Yellow);
                MyConsole.OutputMessage(string.Format("Starting the GeekPeeked Utility Application - {0}", DateTime.Now.ToString()), ConsoleColor.Yellow);
                MyConsole.OutputMessage("########################################################################", ConsoleColor.Yellow);
                MyConsole.OutputMessage();

                do
                {
                    #region Main Menu 

                    MyConsole.OutputMessage("1: import TMDb Genres", ConsoleColor.Magenta);
                    MyConsole.OutputMessage("2: import TMDb Certifications", ConsoleColor.Magenta);
                    MyConsole.OutputMessage("3: import IMDb Movie", ConsoleColor.Magenta);
                    MyConsole.OutputMessage("4: import Legacy GeekPeeked Movies", ConsoleColor.Magenta);
                    MyConsole.OutputMessage("----------------------------------", ConsoleColor.Magenta);
                    MyConsole.OutputMessage("0: Exit", ConsoleColor.Magenta);
                    MyConsole.OutputMessage();

                    MyConsole.RequestInput("Option", ConsoleColor.Magenta);
                    string selection = Console.ReadLine();
                    MyConsole.OutputMessage();
                    int resultCount = 0;

                    #endregion Main Menu 

                    switch (selection)
                    {
                        case "1": // import Genres

                            resultCount = 0;

                            MyConsole.OutputMessage("starting TMDb Genres import...", ConsoleColor.Yellow);
                            MyConsole.OutputMessage();

                            #region Import Genres

                            var tmdbGenres = _tmdb.AllGenres().Result;

                            if (tmdbGenres != null)
                            {
                                foreach (var tmdbGenre in tmdbGenres.genres)
                                {
                                    var genre = _genre.GetAll().FirstOrDefault(g => g.Id == tmdbGenre.id);
                                    if (genre != null)
                                    {
                                        if (genre.Name != tmdbGenre.name)
                                        {
                                            genre.Name = tmdbGenre.name;
                                            genre.ModifiedDate = DateTime.Now;
                                        }
                                    }
                                    else
                                    {
                                        genre = new Genre(tmdbGenre);
                                        _genre.Insert(genre);

                                        MyConsole.OutputMessage(string.Format("\t {0}: {1}", tmdbGenre.id, tmdbGenre.name), ConsoleColor.Cyan);
                                        resultCount++;
                                    }
                                }

                                try
                                {
                                    _context.SaveChanges();
                                    MyConsole.OutputMessage(string.Format("\t {0} genres imported", resultCount), ConsoleColor.Cyan);
                                }
                                catch (Exception ex)
                                {
                                    MyConsole.OutputMessage(string.Format("\t Failed to import genres! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                }
                            }

                            #endregion Import Genres

                            MyConsole.OutputMessage();
                            MyConsole.OutputMessage("TMDd Genres import completed", ConsoleColor.Yellow);

                            break;
                        case "2": // import Certifications

                            resultCount = 0;

                            MyConsole.OutputMessage("starting TMDb Certifications import...", ConsoleColor.Yellow);
                            MyConsole.OutputMessage();

                            #region Import Certifications (US only)

                            var tmdbCertifications = _tmdb.AllCertifications().Result;

                            if (tmdbCertifications != null)
                            {
                                foreach (var tmdbCertification in tmdbCertifications.certifications.US)
                                {
                                    var certification = _certficiation.GetAll().FirstOrDefault(c => c.Country == "US" && c.Name.ToUpper() == tmdbCertification.certification.ToUpper());
                                    if (certification != null)
                                    {
                                        if (certification.Description != tmdbCertification.meaning || certification.Sequence != tmdbCertification.order)
                                        {
                                            certification.Description = tmdbCertification.meaning;
                                            certification.Sequence = tmdbCertification.order;
                                            certification.ModifiedDate = DateTime.Now;
                                        }
                                    }
                                    else
                                    {
                                        certification = new Certification(tmdbCertification);
                                        _certficiation.Insert(certification);

                                        MyConsole.OutputMessage(string.Format("\t {0}: {1}", tmdbCertification.order, tmdbCertification.certification), ConsoleColor.Cyan);
                                        resultCount++;
                                    }
                                }

                                try
                                {
                                    _context.SaveChanges();
                                    MyConsole.OutputMessage();
                                    MyConsole.OutputMessage(string.Format("\t {0} certifications imported", resultCount), ConsoleColor.Cyan);
                                }
                                catch (Exception ex)
                                {
                                    MyConsole.OutputMessage();
                                    MyConsole.OutputMessage(string.Format("\t Failed to import certifications! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                }
                            }

                            #endregion Import Certifications (US only)

                            MyConsole.OutputMessage();
                            MyConsole.OutputMessage("TMDb Certifications import completed", ConsoleColor.Yellow);

                            break;
                        case "3": // import IMDb Movie

                            resultCount = 0;

                            MyConsole.RequestInput("IMDb Id", ConsoleColor.Magenta);
                            string imdbSelection = Console.ReadLine();

                            #region Import IMDb Movie

                            if (!string.IsNullOrWhiteSpace(imdbSelection))
                            {
                                MyConsole.OutputMessage();
                                MyConsole.OutputMessage("starting IMDb movie import...", ConsoleColor.Yellow);
                                MyConsole.OutputMessage();

                                var tmdbResult = _tmdb.MovieDetailsByImdbId(imdbSelection).Result;

                                if (tmdbResult != null && tmdbResult.movie_results != null)
                                {
                                    var tmdbMovieResult = tmdbResult.movie_results.FirstOrDefault();
                                    if (tmdbMovieResult != null)
                                    {
                                        var tmdbMovie = _tmdb.MovieDetails(tmdbMovieResult.id).Result;
                                        if (tmdbMovie != null)
                                        {
                                            var movie = _movie.GetAll().FirstOrDefault(m => m.TmdbId == tmdbMovie.id);
                                            if (movie == null)
                                            {
                                                #region Import Movie Details (Genres, Keywords, Production Companies, Images, Videos, and Ceritifications)

                                                movie = new Movie(tmdbMovie);

                                                #region Add Genres

                                                if (tmdbMovie.genres != null)
                                                {
                                                    resultCount = 0;
                                                    foreach (var tmdbGenre in tmdbMovie.genres)
                                                    {
                                                        var genre = _genre.GetAll().FirstOrDefault(g => g.Id == tmdbGenre.id);
                                                        if (genre != null)
                                                        {
                                                            if (genre.Name != tmdbGenre.name)
                                                            {
                                                                genre.Name = tmdbGenre.name;
                                                                genre.ModifiedDate = DateTime.Now;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            genre = new Genre(tmdbGenre);
                                                            _genre.Insert(genre);
                                                            resultCount++;
                                                        }

                                                        movie.Genres.Add(genre);
                                                    }

                                                    try
                                                    {
                                                        _context.SaveChanges();
                                                        MyConsole.OutputMessage(string.Format("\t {0} genres imported", resultCount), ConsoleColor.Cyan);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MyConsole.OutputMessage(string.Format("\t Failed to import genres! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                    }
                                                }

                                                #endregion Add Genres

                                                #region Add Keywords

                                                if (tmdbMovie.keywords != null && tmdbMovie.keywords.keywords != null)
                                                {
                                                    resultCount = 0;
                                                    foreach (var tmdbKeyword in tmdbMovie.keywords.keywords)
                                                    {
                                                        var keyword = _keyword.GetAll().FirstOrDefault(k => k.Id == tmdbKeyword.id);
                                                        if (keyword != null)
                                                        {
                                                            if (keyword.Name != tmdbKeyword.name)
                                                            {
                                                                keyword.Name = tmdbKeyword.name;
                                                                keyword.ModifiedDate = DateTime.Now;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            keyword = new Keyword(tmdbKeyword);
                                                            _keyword.Insert(keyword);
                                                            resultCount++;
                                                        }

                                                        movie.Keywords.Add(keyword);
                                                    }

                                                    try
                                                    {
                                                        _context.SaveChanges();
                                                        MyConsole.OutputMessage(string.Format("\t {0} keywords imported", resultCount), ConsoleColor.Cyan);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MyConsole.OutputMessage(string.Format("\t Failed to import keywords! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                    }
                                                }

                                                #endregion Add Keywords

                                                #region Add Production Companies

                                                if (tmdbMovie.production_companies != null)
                                                {
                                                    resultCount = 0;
                                                    foreach (var tmdbProductionCompany in tmdbMovie.production_companies)
                                                    {
                                                        var productionCompany = _productionCompany.GetAll().FirstOrDefault(p => p.Id == tmdbProductionCompany.id);
                                                        if (productionCompany != null)
                                                        {
                                                            if (productionCompany.Name != tmdbProductionCompany.name)
                                                            {
                                                                productionCompany.Name = tmdbProductionCompany.name;
                                                                productionCompany.ModifiedDate = DateTime.Now;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            productionCompany = new ProductionCompany(tmdbProductionCompany);
                                                            _productionCompany.Insert(productionCompany);
                                                            resultCount++;
                                                        }

                                                        movie.ProductionCompanies.Add(productionCompany);
                                                    }

                                                    try
                                                    {
                                                        _context.SaveChanges();
                                                        MyConsole.OutputMessage(string.Format("\t {0} production companies imported", resultCount), ConsoleColor.Cyan);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MyConsole.OutputMessage(string.Format("\t Failed to import production companies! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                    }
                                                }

                                                #endregion Add Production Companies

                                                #region Add Certifications (US only)

                                                if (tmdbMovie.release_dates != null && tmdbMovie.release_dates.results != null)
                                                {
                                                    foreach (var tmdbReleaseDate in tmdbMovie.release_dates.results)
                                                    {
                                                        if (tmdbReleaseDate.iso_3166_1 == "US")
                                                        {
                                                            foreach (var tmdbCertification in tmdbReleaseDate.release_dates)
                                                            {
                                                                var myCertification = _certficiation.GetAll().FirstOrDefault(c => c.Country == tmdbReleaseDate.iso_3166_1 && c.Name == tmdbCertification.certification);
                                                                if (myCertification != null)
                                                                {
                                                                    movie.Certifications.Add(myCertification);
                                                                }
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} certifications saved", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\t Failed to save certifications! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }
                                                    }
                                                }

                                                #endregion Add Certifications (US only)

                                                #region Add Backdrop Images

                                                if (tmdbMovie.images != null && tmdbMovie.images.backdrops != null)
                                                {
                                                    resultCount = 0;
                                                    foreach (var tmdbBackdrop in tmdbMovie.images.backdrops)
                                                    {
                                                        var backdrop = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbBackdrop.file_path && i.IsBackdrop);
                                                        if (backdrop == null)
                                                        {
                                                            backdrop = new Image(tmdbBackdrop);
                                                            _image.Insert(backdrop);
                                                            resultCount++;
                                                        }

                                                        movie.Images.Add(backdrop);
                                                    }

                                                    try
                                                    {
                                                        _context.SaveChanges();
                                                        MyConsole.OutputMessage(string.Format("\t {0} backdrop images imported", resultCount), ConsoleColor.Cyan);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MyConsole.OutputMessage(string.Format("\t Failed to import backdrop images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                    }
                                                }

                                                #endregion Add Backdrop Images

                                                #region Add Poster Images

                                                if (tmdbMovie.images != null && tmdbMovie.images.posters != null)
                                                {
                                                    resultCount = 0;
                                                    foreach (var tmdbPoster in tmdbMovie.images.posters)
                                                    {
                                                        var poster = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbPoster.file_path && !i.IsBackdrop);
                                                        if (poster == null)
                                                        {
                                                            poster = new Image(tmdbPoster);
                                                            _image.Insert(poster);
                                                            resultCount++;
                                                        }

                                                        movie.Images.Add(poster);
                                                    }

                                                    try
                                                    {
                                                        _context.SaveChanges();
                                                        MyConsole.OutputMessage(string.Format("\t {0} poster images imported", resultCount), ConsoleColor.Cyan);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MyConsole.OutputMessage(string.Format("\tFailed to import poster images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                    }
                                                }

                                                #endregion Add Poster Images

                                                #region Add Videos

                                                if (tmdbMovie.videos != null && tmdbMovie.videos.results != null)
                                                {
                                                    resultCount = 0;
                                                    foreach (var tmdbVideo in tmdbMovie.videos.results)
                                                    {
                                                        var video = _video.GetAll().FirstOrDefault(v => v.Id == tmdbVideo.id);
                                                        if (video == null)
                                                        {
                                                            video = new Video(tmdbVideo);
                                                            _video.Insert(video);
                                                            resultCount++;
                                                        }

                                                        movie.Videos.Add(video);
                                                    }

                                                    try
                                                    {
                                                        _context.SaveChanges();
                                                        MyConsole.OutputMessage(string.Format("\t {0} videos imported!", resultCount), ConsoleColor.Cyan);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MyConsole.OutputMessage(string.Format("\t Failed to import videos! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                    }
                                                }

                                                #endregion Add Videos

                                                _movie.Insert(movie);

                                                try
                                                {
                                                    _context.SaveChanges();
                                                    MyConsole.OutputMessage(string.Format("\t IMDb movie {0} imported", imdbSelection), ConsoleColor.Cyan);
                                                }
                                                catch (Exception ex)
                                                {
                                                    MyConsole.OutputMessage(string.Format("\t Failed to import IMDb movie {0}! Exception: {1}", imdbSelection, ex.Message.ToString()), ConsoleColor.Red);
                                                }

                                                #endregion Import Movie Details (Genres, Keywords, Production Companies, Images, Videos, and Ceritifications)

                                                #region Import People (Images) and Movie Credits

                                                if (tmdbMovie.credits != null)
                                                {
                                                    MyConsole.OutputMessage();
                                                    MyConsole.OutputMessage(string.Format("\t starting import of {0} credits...", tmdbMovie.title), ConsoleColor.Yellow);
                                                    MyConsole.OutputMessage();

                                                    #region Import Cast Credits 

                                                    if (tmdbMovie.credits.cast != null)
                                                    {
                                                        foreach (var tmdbCast in tmdbMovie.credits.cast)
                                                        {
                                                            var person = _person.GetAll().FirstOrDefault(p => p.Id == tmdbCast.id);
                                                            if (person == null)
                                                            {
                                                                Task.Delay(251); // TMDb Api limits to 40 requests / 10 seconds so we need to throttle and TMDb Api calls within loops
                                                                var tmdbPerson = _tmdb.PersonDetails(tmdbCast.id).Result;
                                                                if (tmdbPerson != null)
                                                                {
                                                                    person = new Person(tmdbPerson);

                                                                    #region Add Profile Images

                                                                    if (tmdbPerson.images != null && tmdbPerson.images.profiles != null)
                                                                    {
                                                                        resultCount = 0;
                                                                        foreach (var tmdbProfile in tmdbPerson.images.profiles)
                                                                        {
                                                                            var profile = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbProfile.file_path && !i.IsBackdrop);
                                                                            if (profile == null)
                                                                            {
                                                                                profile = new Image(tmdbProfile);
                                                                                _image.Insert(profile);
                                                                                resultCount++;
                                                                            }

                                                                            person.Images.Add(profile);
                                                                        }

                                                                        try
                                                                        {
                                                                            _context.SaveChanges();
                                                                            MyConsole.OutputMessage(string.Format("\t {0} profile images imported", resultCount), ConsoleColor.Cyan);
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            MyConsole.OutputMessage(string.Format("\t Failed to import profile images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                                        }
                                                                    }

                                                                    #endregion Add Profile Images

                                                                    _person.Insert(person);

                                                                    try
                                                                    {
                                                                        _context.SaveChanges();
                                                                        MyConsole.OutputMessage(string.Format("\t {0} imported", person.Name), ConsoleColor.Cyan);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        MyConsole.OutputMessage(string.Format("\t Failed to import {0}! Exception: {1}", person.Name, ex.Message.ToString()), ConsoleColor.Red);
                                                                    }
                                                                }
                                                            }

                                                            if (person != null)
                                                            {
                                                                _credit.Insert(new Credit() { Movie = movie, Person = person, CreditId = tmdbCast.credit_id, CharacterName = tmdbCast.character, Department = "Cast", JobTitle = "Actor", Sequence = tmdbCast.order });

                                                                try
                                                                {
                                                                    _context.SaveChanges();
                                                                    MyConsole.OutputMessage(string.Format("\t {0} imported", tmdbCast.character), ConsoleColor.Cyan);
                                                                    MyConsole.OutputMessage();
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    MyConsole.OutputMessage(string.Format("\t Failed to import character credit {0}! Exception: {1}", tmdbCast.character, ex.Message.ToString()), ConsoleColor.Red);
                                                                }
                                                            }
                                                        }
                                                    }

                                                    #endregion Import Cast Credits 

                                                    #region Import Crew Credits 

                                                    if (tmdbMovie.credits.crew != null)
                                                    {
                                                        foreach (var tmdbCrew in tmdbMovie.credits.crew)
                                                        {
                                                            var person = _person.GetAll().FirstOrDefault(p => p.Id == tmdbCrew.id);
                                                            if (person == null)
                                                            {
                                                                Task.Delay(251); // TMDb Api limits to 40 requests / 10 seconds so we need to throttle and TMDb Api calls within loops
                                                                var tmdbPerson = _tmdb.PersonDetails(tmdbCrew.id).Result;
                                                                if (tmdbPerson != null)
                                                                {
                                                                    person = new Person(tmdbPerson);

                                                                    #region Add Profile Images

                                                                    if (tmdbPerson.images != null && tmdbPerson.images.profiles != null)
                                                                    {
                                                                        resultCount = 0;
                                                                        foreach (var tmdbProfile in tmdbPerson.images.profiles)
                                                                        {
                                                                            var profile = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbProfile.file_path && !i.IsBackdrop);
                                                                            if (profile == null)
                                                                            {
                                                                                profile = new Image(tmdbProfile);
                                                                                _image.Insert(profile);
                                                                                resultCount++;
                                                                            }

                                                                            person.Images.Add(profile);
                                                                        }
                                                                        try
                                                                        {
                                                                            _context.SaveChanges();
                                                                            MyConsole.OutputMessage(string.Format("\t {0} profile images imported", resultCount), ConsoleColor.Cyan);
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            MyConsole.OutputMessage(string.Format("\t Failed to import profile images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                                        }

                                                                    }

                                                                    #endregion Add Profile Images

                                                                    _person.Insert(person);

                                                                    try
                                                                    {
                                                                        _context.SaveChanges();
                                                                        MyConsole.OutputMessage(string.Format("\t {0} imported", person.Name), ConsoleColor.Cyan);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        MyConsole.OutputMessage(string.Format("\t Failed to import {0}! Exception: {1}", person.Name, ex.Message.ToString()), ConsoleColor.Red);
                                                                    }
                                                                }
                                                            }

                                                            if (person != null)
                                                            {
                                                                _credit.Insert(new Credit() { Movie = movie, Person = person, CreditId = tmdbCrew.credit_id, Department = tmdbCrew.department, JobTitle = tmdbCrew.job });

                                                                try
                                                                {
                                                                    _context.SaveChanges();
                                                                    MyConsole.OutputMessage(string.Format("\t {0} ({1}) imported", tmdbCrew.name, tmdbCrew.job), ConsoleColor.Cyan);
                                                                    MyConsole.OutputMessage();
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    MyConsole.OutputMessage(string.Format("\t Failed to import character credit {0} ({1} - {2})! Exception: {3}", tmdbCrew.name, tmdbCrew.department, tmdbCrew.job, ex.Message.ToString()), ConsoleColor.Red);
                                                                }
                                                            }
                                                        }
                                                    }

                                                    #endregion Import Crew Credits 

                                                    MyConsole.OutputMessage();
                                                    MyConsole.OutputMessage(string.Format("\t {0} credits import completed", tmdbMovie.title), ConsoleColor.Yellow);
                                                }

                                                #endregion Import People (Images) and Movie Credits
                                            }
                                            else
                                                MyConsole.OutputMessage(string.Format("IMDb movie {0} already exists!", imdbSelection), ConsoleColor.Red);
                                        }
                                    }
                                    else
                                        MyConsole.OutputMessage("IMDb Movie not found!", ConsoleColor.Red);
                                }
                                else
                                    MyConsole.OutputMessage("IMDb Movie not found!", ConsoleColor.Red);

                                MyConsole.OutputMessage();
                                MyConsole.OutputMessage("IMDb movie import completed!", ConsoleColor.Yellow);
                            }
                            else
                            {
                                MyConsole.OutputMessage();
                                MyConsole.OutputMessage("Invalid IMDb Id entered!", ConsoleColor.Red);
                                MyConsole.OutputMessage();
                            }

                            #endregion Import IMDb Movie

                            break;
                        case "4": // import Legacy GeekPeeked Movies

                            resultCount = 0;

                            MyConsole.OutputMessage("starting Legacy GeekPeeked Movies import...", ConsoleColor.Yellow);
                            MyConsole.OutputMessage();

                            var legacyMovies = _legacyMovie.AllMovies();
                            foreach (var legacyMovie in legacyMovies)
                            {
                                var movie = _movie.GetAll().FirstOrDefault(m => m.OldMovieId == legacyMovie.MovieId);
                                if (movie == null)
                                {
                                    string imdbString = legacyMovie.ImdbUrl.Replace("http://www.imdb.com/title/", string.Empty).Replace("https://www.imdb.com/title/", string.Empty).Replace("/", string.Empty);

                                    #region Import Movies

                                    if (!string.IsNullOrWhiteSpace(imdbString))
                                    {
                                        MyConsole.OutputMessage();
                                        MyConsole.OutputMessage("starting IMDb movie import...", ConsoleColor.Yellow);
                                        MyConsole.OutputMessage();

                                        Task.Delay(501); // TMDb Api limits to 40 requests / 10 seconds so we need to throttle and TMDb Api calls within loops
                                        var tmdbResult = _tmdb.MovieDetailsByImdbId(imdbString).Result;

                                        if (tmdbResult != null && tmdbResult.movie_results != null)
                                        {
                                            var tmdbMovieResult = tmdbResult.movie_results.FirstOrDefault();
                                            if (tmdbMovieResult != null)
                                            {
                                                var tmdbMovie = _tmdb.MovieDetails(tmdbMovieResult.id).Result;
                                                if (tmdbMovie != null)
                                                {
                                                    movie = _movie.GetAll().FirstOrDefault(m => m.TmdbId == tmdbMovie.id);
                                                    if (movie == null)
                                                    {
                                                        #region Import Movie Details (Genres, Keywords, Production Companies, Images, Videos, and Ceritifications)

                                                        movie = new Movie(tmdbMovie);

                                                        #region Add Genres

                                                        if (tmdbMovie.genres != null)
                                                        {
                                                            resultCount = 0;
                                                            foreach (var tmdbGenre in tmdbMovie.genres)
                                                            {
                                                                var genre = _genre.GetAll().FirstOrDefault(g => g.Id == tmdbGenre.id);
                                                                if (genre != null)
                                                                {
                                                                    if (genre.Name != tmdbGenre.name)
                                                                    {
                                                                        genre.Name = tmdbGenre.name;
                                                                        genre.ModifiedDate = DateTime.Now;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    genre = new Genre(tmdbGenre);
                                                                    _genre.Insert(genre);
                                                                    resultCount++;
                                                                }

                                                                movie.Genres.Add(genre);
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} genres imported", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\t Failed to import genres! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }

                                                        #endregion Add Genres

                                                        #region Add Keywords

                                                        if (tmdbMovie.keywords != null && tmdbMovie.keywords.keywords != null)
                                                        {
                                                            resultCount = 0;
                                                            foreach (var tmdbKeyword in tmdbMovie.keywords.keywords)
                                                            {
                                                                var keyword = _keyword.GetAll().FirstOrDefault(k => k.Id == tmdbKeyword.id);
                                                                if (keyword != null)
                                                                {
                                                                    if (keyword.Name != tmdbKeyword.name)
                                                                    {
                                                                        keyword.Name = tmdbKeyword.name;
                                                                        keyword.ModifiedDate = DateTime.Now;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    keyword = new Keyword(tmdbKeyword);
                                                                    _keyword.Insert(keyword);
                                                                    resultCount++;
                                                                }

                                                                movie.Keywords.Add(keyword);
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} keywords imported", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\t Failed to import keywords! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }

                                                        #endregion Add Keywords

                                                        #region Add Production Companies

                                                        if (tmdbMovie.production_companies != null)
                                                        {
                                                            resultCount = 0;
                                                            foreach (var tmdbProductionCompany in tmdbMovie.production_companies)
                                                            {
                                                                var productionCompany = _productionCompany.GetAll().FirstOrDefault(p => p.Id == tmdbProductionCompany.id);
                                                                if (productionCompany != null)
                                                                {
                                                                    if (productionCompany.Name != tmdbProductionCompany.name)
                                                                    {
                                                                        productionCompany.Name = tmdbProductionCompany.name;
                                                                        productionCompany.ModifiedDate = DateTime.Now;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    productionCompany = new ProductionCompany(tmdbProductionCompany);
                                                                    _productionCompany.Insert(productionCompany);
                                                                    resultCount++;
                                                                }

                                                                movie.ProductionCompanies.Add(productionCompany);
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} production companies imported", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\t Failed to import production companies! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }

                                                        #endregion Add Production Companies

                                                        #region Add Certifications (US only)

                                                        if (tmdbMovie.release_dates != null && tmdbMovie.release_dates.results != null)
                                                        {
                                                            foreach (var tmdbReleaseDate in tmdbMovie.release_dates.results)
                                                            {
                                                                if (tmdbReleaseDate.iso_3166_1 == "US")
                                                                {
                                                                    foreach (var tmdbCertification in tmdbReleaseDate.release_dates)
                                                                    {
                                                                        var myCertification = _certficiation.GetAll().FirstOrDefault(c => c.Country == tmdbReleaseDate.iso_3166_1 && c.Name == tmdbCertification.certification);
                                                                        if (myCertification != null)
                                                                        {
                                                                            movie.Certifications.Add(myCertification);
                                                                        }
                                                                    }

                                                                    try
                                                                    {
                                                                        _context.SaveChanges();
                                                                        MyConsole.OutputMessage(string.Format("\t {0} certifications saved", resultCount), ConsoleColor.Cyan);
                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        MyConsole.OutputMessage(string.Format("\t Failed to save certifications! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                                    }
                                                                }
                                                            }
                                                        }

                                                        #endregion Add Certifications (US only)

                                                        #region Add Backdrop Images

                                                        if (tmdbMovie.images != null && tmdbMovie.images.backdrops != null)
                                                        {
                                                            resultCount = 0;
                                                            foreach (var tmdbBackdrop in tmdbMovie.images.backdrops)
                                                            {
                                                                var backdrop = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbBackdrop.file_path && i.IsBackdrop);
                                                                if (backdrop == null)
                                                                {
                                                                    backdrop = new Image(tmdbBackdrop);
                                                                    _image.Insert(backdrop);
                                                                    resultCount++;
                                                                }

                                                                movie.Images.Add(backdrop);
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} backdrop images imported", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\t Failed to import backdrop images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }

                                                        #endregion Add Backdrop Images

                                                        #region Add Poster Images

                                                        if (tmdbMovie.images != null && tmdbMovie.images.posters != null)
                                                        {
                                                            resultCount = 0;
                                                            foreach (var tmdbPoster in tmdbMovie.images.posters)
                                                            {
                                                                var poster = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbPoster.file_path && !i.IsBackdrop);
                                                                if (poster == null)
                                                                {
                                                                    poster = new Image(tmdbPoster);
                                                                    _image.Insert(poster);
                                                                    resultCount++;
                                                                }

                                                                movie.Images.Add(poster);
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} poster images imported", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\tFailed to import poster images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }

                                                        #endregion Add Poster Images

                                                        #region Add Videos

                                                        if (tmdbMovie.videos != null && tmdbMovie.videos.results != null)
                                                        {
                                                            resultCount = 0;
                                                            foreach (var tmdbVideo in tmdbMovie.videos.results)
                                                            {
                                                                var video = _video.GetAll().FirstOrDefault(v => v.Id == tmdbVideo.id);
                                                                if (video == null)
                                                                {
                                                                    video = new Video(tmdbVideo);
                                                                    _video.Insert(video);
                                                                    resultCount++;
                                                                }

                                                                movie.Videos.Add(video);
                                                            }

                                                            try
                                                            {
                                                                _context.SaveChanges();
                                                                MyConsole.OutputMessage(string.Format("\t {0} videos imported!", resultCount), ConsoleColor.Cyan);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                MyConsole.OutputMessage(string.Format("\t Failed to import videos! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                            }
                                                        }

                                                        #endregion Add Videos

                                                        movie.OldMovieId = legacyMovie.MovieId;
                                                        _movie.Insert(movie);

                                                        try
                                                        {
                                                            _context.SaveChanges();
                                                            MyConsole.OutputMessage(string.Format("\t IMDb movie {0} imported", imdbString), ConsoleColor.Cyan);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MyConsole.OutputMessage(string.Format("\t Failed to import IMDb movie {0}! Exception: {1}", imdbString, ex.Message.ToString()), ConsoleColor.Red);
                                                        }

                                                        #endregion Import Movie Details (Genres, Keywords, Production Companies, Images, Videos, and Ceritifications)

                                                        #region Import People (Images) and Movie Credits

                                                        if (tmdbMovie.credits != null)
                                                        {
                                                            MyConsole.OutputMessage();
                                                            MyConsole.OutputMessage(string.Format("\t starting import of {0} credits...", tmdbMovie.title), ConsoleColor.Yellow);
                                                            MyConsole.OutputMessage();

                                                            #region Import Cast Credits 

                                                            if (tmdbMovie.credits.cast != null)
                                                            {
                                                                foreach (var tmdbCast in tmdbMovie.credits.cast)
                                                                {
                                                                    var person = _person.GetAll().FirstOrDefault(p => p.Id == tmdbCast.id);
                                                                    if (person == null)
                                                                    {
                                                                        Task.Delay(251); // TMDb Api limits to 40 requests / 10 seconds so we need to throttle and TMDb Api calls within loops
                                                                        var tmdbPerson = _tmdb.PersonDetails(tmdbCast.id).Result;
                                                                        if (tmdbPerson != null)
                                                                        {
                                                                            person = new Person(tmdbPerson);

                                                                            #region Add Profile Images

                                                                            if (tmdbPerson.images != null && tmdbPerson.images.profiles != null)
                                                                            {
                                                                                resultCount = 0;
                                                                                foreach (var tmdbProfile in tmdbPerson.images.profiles)
                                                                                {
                                                                                    var profile = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbProfile.file_path && !i.IsBackdrop);
                                                                                    if (profile == null)
                                                                                    {
                                                                                        profile = new Image(tmdbProfile);
                                                                                        _image.Insert(profile);
                                                                                        resultCount++;
                                                                                    }

                                                                                    person.Images.Add(profile);
                                                                                }

                                                                                try
                                                                                {
                                                                                    _context.SaveChanges();
                                                                                    MyConsole.OutputMessage(string.Format("\t {0} profile images imported", resultCount), ConsoleColor.Cyan);
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                    MyConsole.OutputMessage(string.Format("\t Failed to import profile images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                                                }
                                                                            }

                                                                            #endregion Add Profile Images

                                                                            _person.Insert(person);

                                                                            try
                                                                            {
                                                                                _context.SaveChanges();
                                                                                MyConsole.OutputMessage(string.Format("\t {0} imported", person.Name), ConsoleColor.Cyan);
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                MyConsole.OutputMessage(string.Format("\t Failed to import {0}! Exception: {1}", person.Name, ex.Message.ToString()), ConsoleColor.Red);
                                                                            }
                                                                        }
                                                                    }

                                                                    if (person != null)
                                                                    {
                                                                        _credit.Insert(new Credit() { Movie = movie, Person = person, CreditId = tmdbCast.credit_id, CharacterName = tmdbCast.character, Department = "Cast", JobTitle = "Actor", Sequence = tmdbCast.order });

                                                                        try
                                                                        {
                                                                            _context.SaveChanges();
                                                                            MyConsole.OutputMessage(string.Format("\t {0} imported", tmdbCast.character), ConsoleColor.Cyan);
                                                                            MyConsole.OutputMessage();
                                                                        }
                                                                        catch (Exception ex)
                                                                        {
                                                                            MyConsole.OutputMessage(string.Format("\t Failed to import character credit {0}! Exception: {1}", tmdbCast.character, ex.Message.ToString()), ConsoleColor.Red);
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            #endregion Import Cast Credits 

                                                            #region Import Crew Credits 

                                                            if (tmdbMovie.credits.crew != null)
                                                            {
                                                                foreach (var tmdbCrew in tmdbMovie.credits.crew)
                                                                {
                                                                    if (tmdbCrew.department.ToLower() == "writing" || 
                                                                        tmdbCrew.department.ToLower() == "directing" || 
                                                                        tmdbCrew.department.ToLower() == "actors" ||
                                                                        (tmdbCrew.department.ToLower() == "camera" && tmdbCrew.job.ToLower() == "director of photography") ||
                                                                        (tmdbCrew.department.ToLower() == "art" && (tmdbCrew.job.ToLower() == "production design" || tmdbCrew.job.ToLower() == "art direction")) ||
                                                                        (tmdbCrew.department.ToLower() == "costume & make-up" && (tmdbCrew.job.ToLower() == "costume design" || tmdbCrew.job.ToLower() == "makeup artist" || tmdbCrew.job.ToLower() == "hairstylist")) ||
                                                                        (tmdbCrew.department.ToLower() == "sound" && (tmdbCrew.job.ToLower() == "original music composer" || tmdbCrew.job.ToLower() == "sound designer" || tmdbCrew.job.ToLower() == "sound editor" || tmdbCrew.job.ToLower() == "sound director")) ||
                                                                        (tmdbCrew.department.ToLower() == "visual effects" && (tmdbCrew.job.ToLower() == "animation" || tmdbCrew.job.ToLower() == "visual effects" || tmdbCrew.job.ToLower() == "creature design")) ||
                                                                        (tmdbCrew.department.ToLower() == "production" && (tmdbCrew.job.ToLower() == "producer" || tmdbCrew.job.ToLower() == "executive producer")))
                                                                    {
                                                                        var person = _person.GetAll().FirstOrDefault(p => p.Id == tmdbCrew.id);
                                                                        if (person == null)
                                                                        {
                                                                            Task.Delay(251); // TMDb Api limits to 40 requests / 10 seconds so we need to throttle and TMDb Api calls within loops
                                                                            var tmdbPerson = _tmdb.PersonDetails(tmdbCrew.id).Result;
                                                                            if (tmdbPerson != null)
                                                                            {
                                                                                person = new Person(tmdbPerson);

                                                                                #region Add Profile Images

                                                                                if (tmdbPerson.images != null && tmdbPerson.images.profiles != null)
                                                                                {
                                                                                    resultCount = 0;
                                                                                    foreach (var tmdbProfile in tmdbPerson.images.profiles)
                                                                                    {
                                                                                        var profile = _image.GetAll().FirstOrDefault(i => i.FilePath == tmdbProfile.file_path && !i.IsBackdrop);
                                                                                        if (profile == null)
                                                                                        {
                                                                                            profile = new Image(tmdbProfile);
                                                                                            _image.Insert(profile);
                                                                                            resultCount++;
                                                                                        }

                                                                                        person.Images.Add(profile);
                                                                                    }
                                                                                    try
                                                                                    {
                                                                                        _context.SaveChanges();
                                                                                        MyConsole.OutputMessage(string.Format("\t {0} profile images imported", resultCount), ConsoleColor.Cyan);
                                                                                    }
                                                                                    catch (Exception ex)
                                                                                    {
                                                                                        MyConsole.OutputMessage(string.Format("\t Failed to import profile images! Exception: {0}", ex.Message.ToString()), ConsoleColor.Red);
                                                                                    }

                                                                                }

                                                                                #endregion Add Profile Images

                                                                                _person.Insert(person);

                                                                                try
                                                                                {
                                                                                    _context.SaveChanges();
                                                                                    MyConsole.OutputMessage(string.Format("\t {0} imported", person.Name), ConsoleColor.Cyan);
                                                                                }
                                                                                catch (Exception ex)
                                                                                {
                                                                                    MyConsole.OutputMessage(string.Format("\t Failed to import {0}! Exception: {1}", person.Name, ex.Message.ToString()), ConsoleColor.Red);
                                                                                }
                                                                            }
                                                                        }

                                                                        if (person != null)
                                                                        {
                                                                            _credit.Insert(new Credit() { Movie = movie, Person = person, CreditId = tmdbCrew.credit_id, Department = tmdbCrew.department, JobTitle = tmdbCrew.job });

                                                                            try
                                                                            {
                                                                                _context.SaveChanges();
                                                                                MyConsole.OutputMessage(string.Format("\t {0} ({1}) imported", tmdbCrew.name, tmdbCrew.job), ConsoleColor.Cyan);
                                                                                MyConsole.OutputMessage();
                                                                            }
                                                                            catch (Exception ex)
                                                                            {
                                                                                MyConsole.OutputMessage(string.Format("\t Failed to import character credit {0} ({1} - {2})! Exception: {3}", tmdbCrew.name, tmdbCrew.department, tmdbCrew.job, ex.Message.ToString()), ConsoleColor.Red);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }

                                                            #endregion Import Crew Credits 

                                                            MyConsole.OutputMessage();
                                                            MyConsole.OutputMessage(string.Format("\t {0} credits import completed", tmdbMovie.title), ConsoleColor.Yellow);
                                                        }

                                                        #endregion Import People (Images) and Movie Credits
                                                    }
                                                    else
                                                        MyConsole.OutputMessage(string.Format("IMDb movie {0} already exists!", imdbString), ConsoleColor.Red);
                                                }
                                            }
                                            else
                                                MyConsole.OutputMessage("IMDb Movie not found!", ConsoleColor.Red);
                                        }
                                        else
                                            MyConsole.OutputMessage("IMDb Movie not found!", ConsoleColor.Red);

                                        MyConsole.OutputMessage();
                                        MyConsole.OutputMessage("IMDb movie import completed!", ConsoleColor.Yellow);
                                    }
                                    else
                                    {
                                        MyConsole.OutputMessage();
                                        MyConsole.OutputMessage("Invalid IMDb Id entered!", ConsoleColor.Red);
                                        MyConsole.OutputMessage();
                                    }

                                    #endregion Import Movies
                                }
                            }

                            MyConsole.OutputMessage();
                            MyConsole.OutputMessage("Legacy GeekPeeked Movies import completed", ConsoleColor.Yellow);

                            break;

                        #region Old Code

                        //case "": // process Movies By Year

                        //    MyConsole.RequestInput("Year", ConsoleColor.Magenta);
                        //    int year = 0;
                        //    string yearSelection = Console.ReadLine();
                        //    if (Int32.TryParse(yearSelection, out year) && year > 0)
                        //    {
                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage(string.Format("Processing {0} Movies...", year), ConsoleColor.Yellow);
                        //        MyConsole.OutputMessage();

                        //        TmdbMovieImporter movieImporter = new TmdbMovieImporter(_tmdbRepository, _jobRepository, _imageRepository, _videoRepository, _movieRepository, _genreRepository, _personRepository, _keywordRepository, _certificationRepository, _productionCompanRepository, _castCreditRepository, _crewCreditRepository);
                        //        resultCount = movieImporter.Import(year);

                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage(string.Format("{0} Movies ({1}) processed!", resultCount, year), ConsoleColor.Yellow);
                        //    }
                        //    else
                        //    {
                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage("!!! Invalid Year entered !!!", ConsoleColor.Red);
                        //        MyConsole.OutputMessage();
                        //    }

                        //    break;
                        //case "": // process Movies By Month

                        //    MyConsole.RequestInput("Date", ConsoleColor.Magenta);
                        //    DateTime startDate = new DateTime();
                        //    string dateSelection = Console.ReadLine();
                        //    if (DateTime.TryParse(dateSelection, out startDate))
                        //    {
                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage(string.Format("Processing Movies between {0} and {1}...", startDate, startDate.AddMonths(1).AddDays(-1)), ConsoleColor.Yellow);
                        //        MyConsole.OutputMessage();

                        //        TmdbMovieImporter movieImporter = new TmdbMovieImporter(_tmdbRepository, _jobRepository, _imageRepository, _videoRepository, _movieRepository, _genreRepository, _personRepository, _keywordRepository, _certificationRepository, _productionCompanRepository, _castCreditRepository, _crewCreditRepository);
                        //        resultCount = movieImporter.Import(startDate, startDate.AddMonths(1).AddDays(-1));

                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage(string.Format("{0} Movies between {1} and {2} processed!", resultCount, startDate, startDate.AddMonths(1).AddDays(-1)), ConsoleColor.Yellow);
                        //    }
                        //    else
                        //    {
                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage("!!! Invalid Date entered !!!", ConsoleColor.Red);
                        //        MyConsole.OutputMessage();
                        //    }

                        //    break;
                        //case "": // process Movies By Day

                        //    MyConsole.RequestInput("Date", ConsoleColor.Magenta);
                        //    DateTime dayStartDate = new DateTime();
                        //    string daySelection = Console.ReadLine();
                        //    if (DateTime.TryParse(daySelection, out dayStartDate))
                        //    {
                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage(string.Format("Processing Movies on {0}...", dayStartDate), ConsoleColor.Yellow);
                        //        MyConsole.OutputMessage();

                        //        TmdbMovieImporter movieImporter = new TmdbMovieImporter(_tmdbRepository, _jobRepository, _imageRepository, _videoRepository, _movieRepository, _genreRepository, _personRepository, _keywordRepository, _certificationRepository, _productionCompanRepository, _castCreditRepository, _crewCreditRepository);
                        //        resultCount = movieImporter.Import(dayStartDate, dayStartDate);

                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage(string.Format("{0} Movies on {1} processed!", resultCount, dayStartDate), ConsoleColor.Yellow);
                        //    }
                        //    else
                        //    {
                        //        MyConsole.OutputMessage();
                        //        MyConsole.OutputMessage("!!! Invalid Date entered !!!", ConsoleColor.Red);
                        //        MyConsole.OutputMessage();
                        //    }

                        //    break;
                        #endregion Old Code

                        case "0":
                            keepRunning = false;
                            break;
                        default:
                            break;
                    }

                    MyConsole.OutputMessage();

                } while (keepRunning);

                MyConsole.OutputMessage();
                MyConsole.OutputMessage("########################################################################", ConsoleColor.Yellow);
                MyConsole.OutputMessage(string.Format("Exiting the GeekPeeked Utility Application - {0}", DateTime.Now.ToString()), ConsoleColor.Yellow);
                MyConsole.OutputMessage("########################################################################", ConsoleColor.Yellow);
            }

            Console.ReadLine();
        }
    }
}
