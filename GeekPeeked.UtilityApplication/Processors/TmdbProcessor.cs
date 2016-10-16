using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;

namespace GeekPeeked.UtilityApplication.Processors
{
    public class TmdbProcessor
    {
        private TmdbRepository _tmdbMovieRepo;
        private JobRepository _dbJobRepo;
        private GenreRepository _dbGenreRepo;
        private CertificationRepository _dbCertificationRepo;
        private MovieRepository _dbMovieRepo;

        public TmdbProcessor()
        {
            _tmdbMovieRepo = new TmdbRepository();
            _dbJobRepo = new JobRepository(new GeekPeekedDbContext());
            _dbGenreRepo = new GenreRepository(new GeekPeekedDbContext());
            _dbCertificationRepo = new CertificationRepository(new GeekPeekedDbContext());
            _dbMovieRepo = new MovieRepository(new GeekPeekedDbContext());
        }

        public async Task ProcessTmdbJobs()
        {
            var response = await Task.Run(() => _tmdbMovieRepo.AllJobs());

            foreach (var department in response.jobs)
            {
                foreach (var job in department.job_list)
                {
                    Console.WriteLine(string.Format("\t\tAdding Job: {0} - {1}", department.department, job));
                    _dbJobRepo.AddJob(new Job() { Department = department.department, JobTitle = job });
                }
            }

            _dbJobRepo.Save();
        }

        public async Task ProcessTmdbGenres()
        {
            var response = await Task.Run(() => _tmdbMovieRepo.AllGenres());

            foreach (var genre in response.genres)
            {
                Console.WriteLine(string.Format("\t\tAdding Genre:{0} ({1})", genre.name, genre.id));
                _dbGenreRepo.AddGenre(new Genre() { Id = genre.id, Name = genre.name });
            }

            _dbGenreRepo.Save();
        }

        public async Task ProcessTmdbCertifications()
        {
            var response = await Task.Run(() => _tmdbMovieRepo.AllCertifications());

            foreach (var certification in response.certifications.US)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: US - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "US", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.AU)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: AU - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "AU", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.BG)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: BG - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "BG", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.BR)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: BR - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "BR", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.CA)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: CA - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "CA", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.DE)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: DE - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "DE", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.ES)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: ES - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "ES", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.FI)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: FI - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "FI", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.FR)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: FR - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "FR", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.GB)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: GB - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "GB", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.IN)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: IN - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "IN", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.NL)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: NL - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "NL", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.NZ)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: NZ - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "NZ", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.PH)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: PH - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "PH", Name = certification.certification, Description = certification.meaning });
            }
            foreach (var certification in response.certifications.PT)
            {
                Console.WriteLine(string.Format("\t\tAdding Certification: PT - {0} ({1})", certification.certification, certification.order));
                _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "PT", Name = certification.certification, Description = certification.meaning });
            }

            _dbCertificationRepo.Save();
        }

        public async Task ProcessTmdbMoviesByYear(int year)
        {
            var responses = await Task.Run(() => _tmdbMovieRepo.AllMovies(year));

            int currentMovie = 1;
            int totalMovies = responses.Sum(r => r.total_results);

            foreach (var response in responses)
            {
                foreach (var result in response.results)
                {
                    await Task.Delay(300); // added delay in order to not violate the TMDb limit of 40 requests / 10 seconds (4 requests per 1 second == 1 request per 250 milliseconds)
                    var movie = await Task.Run(() => _tmdbMovieRepo.MovieDetails(result.id));

                    Console.WriteLine(string.Format("\t\tAdding {0} of {1}: {2} ({3})", currentMovie, totalMovies, result.title, result.id));
                    _dbMovieRepo.AddMovie(movie);
                    currentMovie++;
                }
            }

            try
            {
                _dbMovieRepo.Save();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("\tProperty: {0} ({1})", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
