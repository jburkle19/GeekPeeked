﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;

namespace GeekPeeked.UtilityApplication.Processors
{
    public class TmdbProcessor
    {
        private TmdbRepository _tmdbMovieRepo;

        private GeekPeekedDbContext _context;
        private JobRepository _dbJobRepo;
        private GenreRepository _dbGenreRepo;
        private CertificationRepository _dbCertificationRepo;
        private MovieRepository _dbMovieRepo;

        public TmdbProcessor()
        {
            _tmdbMovieRepo = new TmdbRepository();

            _context = new GeekPeekedDbContext();
            _dbJobRepo = new JobRepository(_context);
            _dbGenreRepo = new GenreRepository(_context);
            _dbCertificationRepo = new CertificationRepository(_context);
            _dbMovieRepo = new MovieRepository(_context);
        }

        public async Task ProcessTmdbJobs()
        {
            var response = await Task.Run(() => _tmdbMovieRepo.AllJobs());

            foreach (var department in response.jobs)
            {
                foreach (var job in department.job_list)
                {
                    try
                    {
                        var myJob = _context.Jobs.FirstOrDefault(j => j.Department == department.department && j.JobTitle == job);

                        if (myJob == null)
                        {
                            _dbJobRepo.AddJob(new Job() { Department = department.department, JobTitle = job });
                            _dbJobRepo.Save();
                            Helpers.OutputMessage(string.Format("\tJob: {0} - {1}", department.department, job), ConsoleColor.Cyan);
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                    }
                }
            }
        }
        public async Task ProcessTmdbGenres()
        {
            var response = await Task.Run(() => _tmdbMovieRepo.AllGenres());

            foreach (var genre in response.genres)
            {
                try
                {
                    var myGenre = _context.Genres.FirstOrDefault(g => g.Id == genre.id);

                    if (myGenre == null)
                    {
                        _dbGenreRepo.AddGenre(new Genre() { Id = genre.id, Name = genre.name });
                        _dbGenreRepo.Save();
                        Helpers.OutputMessage(string.Format("\tGenre:{0} ({1})", genre.name, genre.id), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
        }
        public async Task ProcessTmdbCertifications()
        {
            var response = await Task.Run(() => _tmdbMovieRepo.AllCertifications());

            foreach (var certification in response.certifications.US)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "US");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "US", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: US - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.AU)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "AU");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "AU", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: AU - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.BG)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "BG");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "BG", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: BG - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.BR)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "BR");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "BR", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: BR - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.CA)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "CA");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "CA", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: CA - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.DE)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "DE");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "DE", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: DE - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.ES)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "ES");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "ES", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: ES - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.FI)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "FI");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "FI", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: FI - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.FR)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "FR");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "FR", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: FR - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.GB)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "GB");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "GB", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: GB - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.IN)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "IN");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "IN", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: IN - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.NL)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "NL");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "NL", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: NL - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.NZ)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "NZ");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "NZ", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: NZ - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.PH)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "PH");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "PH", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: PH - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
            foreach (var certification in response.certifications.PT)
            {
                try
                {
                    var myCertification = _context.Certifications.FirstOrDefault(c => c.TypeId == certification.order && c.Country == "PT");

                    if (myCertification == null)
                    {
                        _dbCertificationRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "PT", Name = certification.certification, Description = certification.meaning });
                        _dbCertificationRepo.Save();
                        Helpers.OutputMessage(string.Format("\tCertification: PT - {0} ({1})", certification.certification, certification.order), ConsoleColor.Cyan);
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }
            }
        }

        public async Task ProcessTmdbMoviesByYear(int year)
        {
            var responses = await Task.Run(() => _tmdbMovieRepo.AllMovies(year));

            int currentMovie = 1;
            int totalMovies = responses.Sum(r => r.total_results) / responses.Count();

            foreach (var response in responses)
            {
                foreach (var result in response.results)
                {
                    await Task.Delay(251); // added delay in order to not violate the TMDb limit of 40 requests / 10 seconds (4 requests per 1 second == 1 request per 250 milliseconds)

                    try
                    {
                        var movie = await Task.Run(() => _tmdbMovieRepo.MovieDetails(result.id));

                        _dbMovieRepo.AddMovie(movie);
                        _dbMovieRepo.Save();
                        Helpers.OutputMessage(string.Format("\t{0} of {1}: {2} ({3})", currentMovie, totalMovies, result.title, result.id), ConsoleColor.Cyan);
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Helpers.OutputMessage(string.Format("!!!! Property: {0} ({1})", validationError.PropertyName, validationError.ErrorMessage), ConsoleColor.Red);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                    }

                    currentMovie++;
                }
            }
        }
        public async Task ProcessTmdbMoviesByDates(DateTime startDate, DateTime endDate)
        {
            var responses = await Task.Run(() => _tmdbMovieRepo.AllMovies(startDate, endDate));

            int currentMovie = 1;
            int totalMovies = responses.Sum(r => r.total_results) / responses.Count();

            foreach (var response in responses)
            {
                foreach (var result in response.results)
                {
                    await Task.Delay(251); // added delay in order to not violate the TMDb limit of 40 requests / 10 seconds (4 requests per 1 second == 1 request per 250 milliseconds)

                    try
                    {
                        var movie = await Task.Run(() => _tmdbMovieRepo.MovieDetails(result.id));

                        _dbMovieRepo.AddMovie(movie);
                        _dbMovieRepo.Save();
                        Helpers.OutputMessage(string.Format("\t{0} of {1}: {2} ({3})", currentMovie, totalMovies, result.title, result.id), ConsoleColor.Cyan);
                    }
                    catch (DbEntityValidationException dbEx)
                    {
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                Helpers.OutputMessage(string.Format("!!!! Property: {0} ({1})", validationError.PropertyName, validationError.ErrorMessage), ConsoleColor.Red);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                    }

                    currentMovie++;
                }
            }
        }

        public async Task ProcessImdbMovies()
        {
            List<string> imdbIds = new List<string>();

            #region IMDb Movie Ids

            imdbIds.Add("tt1837709");
            imdbIds.Add("tt5325452");
            imdbIds.Add("tt5225338");
            imdbIds.Add("tt4981636");
            imdbIds.Add("tt4950110");
            imdbIds.Add("tt4824308");
            imdbIds.Add("tt4824302");
            imdbIds.Add("tt4786282");
            imdbIds.Add("tt4731008");
            imdbIds.Add("tt4698584");
            imdbIds.Add("tt4682786");
            imdbIds.Add("tt4669186");
            imdbIds.Add("tt4651520");
            imdbIds.Add("tt4649416");
            imdbIds.Add("tt4624424");
            imdbIds.Add("tt4572514");
            imdbIds.Add("tt4550098");
            imdbIds.Add("tt4540710");
            imdbIds.Add("tt4520364");
            imdbIds.Add("tt4501244");
            imdbIds.Add("tt4468634");
            imdbIds.Add("tt4438848");
            imdbIds.Add("tt4405668");
            imdbIds.Add("tt4385888");
            imdbIds.Add("tt4383594");
            imdbIds.Add("tt4361050");
            imdbIds.Add("tt4326444");
            imdbIds.Add("tt4302938");
            imdbIds.Add("tt4288636");
            imdbIds.Add("tt4276820");
            imdbIds.Add("tt4263482");
            imdbIds.Add("tt4258698");
            imdbIds.Add("tt4257926");
            imdbIds.Add("tt4196776");
            imdbIds.Add("tt4196450");
            imdbIds.Add("tt4191054");
            imdbIds.Add("tt4185572");
            imdbIds.Add("tt4178092");
            imdbIds.Add("tt4160708");
            imdbIds.Add("tt4154858");
            imdbIds.Add("tt4154796");
            imdbIds.Add("tt4154756");
            imdbIds.Add("tt4154664");
            imdbIds.Add("tt4139124");
            imdbIds.Add("tt4136084");
            imdbIds.Add("tt4094724");
            imdbIds.Add("tt4062536");
            imdbIds.Add("tt4056738");
            imdbIds.Add("tt4052882");
            imdbIds.Add("tt4046784");
            imdbIds.Add("tt4034354");
            imdbIds.Add("tt4034256");
            imdbIds.Add("tt4034228");
            imdbIds.Add("tt4030600");
            imdbIds.Add("tt4009460");
            imdbIds.Add("tt3960412");
            imdbIds.Add("tt3922818");
            imdbIds.Add("tt3915174");
            imdbIds.Add("tt3915172");
            imdbIds.Add("tt3896198");
            imdbIds.Add("tt3884528");
            imdbIds.Add("tt3874544");
            imdbIds.Add("tt3862750");
            imdbIds.Add("tt3859304");
            imdbIds.Add("tt3850590");
            imdbIds.Add("tt3850544");
            imdbIds.Add("tt3850214");
            imdbIds.Add("tt3838992");
            imdbIds.Add("tt3835080");
            imdbIds.Add("tt3801316");
            imdbIds.Add("tt3799694");
            imdbIds.Add("tt3787590");
            imdbIds.Add("tt3783958");
            imdbIds.Add("tt3774114");
            imdbIds.Add("tt3760922");
            imdbIds.Add("tt3748528");
            imdbIds.Add("tt3741834");
            imdbIds.Add("tt3741700");
            imdbIds.Add("tt3731562");
            imdbIds.Add("tt3729594");
            imdbIds.Add("tt3722070");
            imdbIds.Add("tt3721936");
            imdbIds.Add("tt3719896");
            imdbIds.Add("tt3717490");
            imdbIds.Add("tt3717252");
            imdbIds.Add("tt3715320");
            imdbIds.Add("tt3713166");
            imdbIds.Add("tt3707106");
            imdbIds.Add("tt3704538");
            imdbIds.Add("tt3703148");
            imdbIds.Add("tt3691740");
            imdbIds.Add("tt3682448");
            imdbIds.Add("tt3663184");
            imdbIds.Add("tt3660770");
            imdbIds.Add("tt3659388");
            imdbIds.Add("tt3640424");
            imdbIds.Add("tt3631112");
            imdbIds.Add("tt3628584");
            imdbIds.Add("tt3623726");
            imdbIds.Add("tt3622592");
            imdbIds.Add("tt3614802");
            imdbIds.Add("tt3614530");
            imdbIds.Add("tt3578504");
            imdbIds.Add("tt3569230");
            imdbIds.Add("tt3567288");
            imdbIds.Add("tt3544082");
            imdbIds.Add("tt3534602");
            imdbIds.Add("tt3534282");
            imdbIds.Add("tt3532608");
            imdbIds.Add("tt3531824");
            imdbIds.Add("tt3530002");
            imdbIds.Add("tt3526286");
            imdbIds.Add("tt3522806");
            imdbIds.Add("tt3521164");
            imdbIds.Add("tt3521134");
            imdbIds.Add("tt3513498");
            imdbIds.Add("tt3507138");
            imdbIds.Add("tt3501632");
            imdbIds.Add("tt3499096");
            imdbIds.Add("tt3498820");
            imdbIds.Add("tt3496992");
            imdbIds.Add("tt3488710");
            imdbIds.Add("tt3486626");
            imdbIds.Add("tt3471098");
            imdbIds.Add("tt3470600");
            imdbIds.Add("tt3469046");
            imdbIds.Add("tt3466248");
            imdbIds.Add("tt3460252");
            imdbIds.Add("tt3455740");
            imdbIds.Add("tt3450958");
            imdbIds.Add("tt3450650");
            imdbIds.Add("tt3442006");
            imdbIds.Add("tt3416828");
            imdbIds.Add("tt3416742");
            imdbIds.Add("tt3416532");
            imdbIds.Add("tt3416532");
            imdbIds.Add("tt3411444");
            imdbIds.Add("tt3410834");
            imdbIds.Add("tt3402242");
            imdbIds.Add("tt3398268");
            imdbIds.Add("tt3397884");
            imdbIds.Add("tt3393786");
            imdbIds.Add("tt3387542");
            imdbIds.Add("tt3385516");
            imdbIds.Add("tt3381008");
            imdbIds.Add("tt3369806");
            imdbIds.Add("tt3364774");
            imdbIds.Add("tt3352390");
            imdbIds.Add("tt3345056");
            imdbIds.Add("tt3344922");
            imdbIds.Add("tt3343784");
            imdbIds.Add("tt3332064");
            imdbIds.Add("tt3322940");
            imdbIds.Add("tt3322364");
            imdbIds.Add("tt3319920");
            imdbIds.Add("tt3316960");
            imdbIds.Add("tt3316948");
            imdbIds.Add("tt3312830");
            imdbIds.Add("tt3300542");
            imdbIds.Add("tt3297554");
            imdbIds.Add("tt3297330");
            imdbIds.Add("tt3276924");
            imdbIds.Add("tt3268668");
            imdbIds.Add("tt3263904");
            imdbIds.Add("tt3244446");
            imdbIds.Add("tt3236120");
            imdbIds.Add("tt3235888");
            imdbIds.Add("tt3216348");
            imdbIds.Add("tt3210686");
            imdbIds.Add("tt3203606");
            imdbIds.Add("tt3200980");
            imdbIds.Add("tt3195644");
            imdbIds.Add("tt3183660");
            imdbIds.Add("tt3183630");
            imdbIds.Add("tt3181822");
            imdbIds.Add("tt3179568");
            imdbIds.Add("tt3174376");
            imdbIds.Add("tt3171096");
            imdbIds.Add("tt3171094");
            imdbIds.Add("tt3170832");
            imdbIds.Add("tt3168230");
            imdbIds.Add("tt3164256");
            imdbIds.Add("tt3163304");
            imdbIds.Add("tt3152624");
            imdbIds.Add("tt3138104");
            imdbIds.Add("tt3125324");
            imdbIds.Add("tt3110958");
            imdbIds.Add("tt3110770");
            imdbIds.Add("tt3099498");
            imdbIds.Add("tt3095734");
            imdbIds.Add("tt3083016");
            imdbIds.Add("tt3079380");
            imdbIds.Add("tt3076658");
            imdbIds.Add("tt3072482");
            imdbIds.Add("tt3065204");
            imdbIds.Add("tt3063516");
            imdbIds.Add("tt3062096");
            imdbIds.Add("tt3060492");
            imdbIds.Add("tt3045616");
            imdbIds.Add("tt3040964");
            imdbIds.Add("tt3021360");
            imdbIds.Add("tt3014866");
            imdbIds.Add("tt3014666");
            imdbIds.Add("tt3014284");
            imdbIds.Add("tt2994190");
            imdbIds.Add("tt2980706");
            imdbIds.Add("tt2980648");
            imdbIds.Add("tt2980516");
            imdbIds.Add("tt2978462");
            imdbIds.Add("tt2975590");
            imdbIds.Add("tt2975578");
            imdbIds.Add("tt2974918");
            imdbIds.Add("tt2967224");
            imdbIds.Add("tt2948840");
            imdbIds.Add("tt2948356");
            imdbIds.Add("tt2938956");
            imdbIds.Add("tt2937898");
            imdbIds.Add("tt2936180");
            imdbIds.Add("tt2935564");
            imdbIds.Add("tt2935476");
            imdbIds.Add("tt2933544");
            imdbIds.Add("tt2929890");
            imdbIds.Add("tt2926810");
            imdbIds.Add("tt2918436");
            imdbIds.Add("tt2914838");
            imdbIds.Add("tt2911666");
            imdbIds.Add("tt2910814");
            imdbIds.Add("tt2910274");
            imdbIds.Add("tt2908446");
            imdbIds.Add("tt2893490");
            imdbIds.Add("tt2884018");
            imdbIds.Add("tt2883512");
            imdbIds.Add("tt2883434");
            imdbIds.Add("tt2872750");
            imdbIds.Add("tt2872732");
            imdbIds.Add("tt2872718");
            imdbIds.Add("tt2870808");
            imdbIds.Add("tt2870708");
            imdbIds.Add("tt2870612");
            imdbIds.Add("tt2869728");
            imdbIds.Add("tt2865120");
            imdbIds.Add("tt2852470");
            imdbIds.Add("tt2852406");
            imdbIds.Add("tt2850386");
            imdbIds.Add("tt2848292");
            imdbIds.Add("tt2828996");
            imdbIds.Add("tt2820852");
            imdbIds.Add("tt2802154");
            imdbIds.Add("tt2802144");
            imdbIds.Add("tt2799166");
            imdbIds.Add("tt2793490");
            imdbIds.Add("tt2790236");
            imdbIds.Add("tt2788732");
            imdbIds.Add("tt2788716");
            imdbIds.Add("tt2788710");
            imdbIds.Add("tt2788556");
            imdbIds.Add("tt2784678");
            imdbIds.Add("tt2784512");
            imdbIds.Add("tt2771372");
            imdbIds.Add("tt2756032");
            imdbIds.Add("tt2752772");
            imdbIds.Add("tt2752758");
            imdbIds.Add("tt2752688");
            imdbIds.Add("tt2737050");
            imdbIds.Add("tt2726560");
            imdbIds.Add("tt2719848");
            imdbIds.Add("tt2717822");
            imdbIds.Add("tt2713180");
            imdbIds.Add("tt2711898");
            imdbIds.Add("tt2709768");
            imdbIds.Add("tt2709692");
            imdbIds.Add("tt2707848");
            imdbIds.Add("tt2702724");
            imdbIds.Add("tt2692904");
            imdbIds.Add("tt2692250");
            imdbIds.Add("tt2679042");
            imdbIds.Add("tt2674426");
            imdbIds.Add("tt2674354");
            imdbIds.Add("tt2671706");
            imdbIds.Add("tt2660888");
            imdbIds.Add("tt2652092");
            imdbIds.Add("tt2649554");
            imdbIds.Add("tt2649554");
            imdbIds.Add("tt2638144");
            imdbIds.Add("tt2637378");
            imdbIds.Add("tt2637294");
            imdbIds.Add("tt2637276");
            imdbIds.Add("tt2626350");
            imdbIds.Add("tt2626090");
            imdbIds.Add("tt2618368");
            imdbIds.Add("tt2609912");
            imdbIds.Add("tt2609758");
            imdbIds.Add("tt2597760");
            imdbIds.Add("tt2582846");
            imdbIds.Add("tt2582802");
            imdbIds.Add("tt2582500");
            imdbIds.Add("tt2582496");
            imdbIds.Add("tt2567026");
            imdbIds.Add("tt2562232");
            imdbIds.Add("tt2561572");
            imdbIds.Add("tt2557490");
            imdbIds.Add("tt2557478");
            imdbIds.Add("tt2555736");
            imdbIds.Add("tt2554274");
            imdbIds.Add("tt2553908");
            imdbIds.Add("tt2547584");
            imdbIds.Add("tt2545118");
            imdbIds.Add("tt2543164");
            imdbIds.Add("tt2532528");
            imdbIds.Add("tt2531334");
            imdbIds.Add("tt2528814");
            imdbIds.Add("tt2524674");
            imdbIds.Add("tt2517300");
            imdbIds.Add("tt2515086");
            imdbIds.Add("tt2515034");
            imdbIds.Add("tt2515030");
            imdbIds.Add("tt2513074");
            imdbIds.Add("tt2510894");
            imdbIds.Add("tt2503944");
            imdbIds.Add("tt2494384");
            imdbIds.Add("tt2488496");
            imdbIds.Add("tt2486682");
            imdbIds.Add("tt2486678");
            imdbIds.Add("tt2479800");
            imdbIds.Add("tt2473794");
            imdbIds.Add("tt2473682");
            imdbIds.Add("tt2473602");
            imdbIds.Add("tt2473510");
            imdbIds.Add("tt2467046");
            imdbIds.Add("tt2465146");
            imdbIds.Add("tt2465140");
            imdbIds.Add("tt2463288");
            imdbIds.Add("tt2461150");
            imdbIds.Add("tt2458776");
            imdbIds.Add("tt2452254");
            imdbIds.Add("tt2452042");
            imdbIds.Add("tt2450186");
            imdbIds.Add("tt2446980");
            imdbIds.Add("tt2446042");
            imdbIds.Add("tt2436516");
            imdbIds.Add("tt2436386");
            imdbIds.Add("tt2431286");
            imdbIds.Add("tt2404463");
            imdbIds.Add("tt2404435");
            imdbIds.Add("tt2404425");
            imdbIds.Add("tt2404311");
            imdbIds.Add("tt2404233");
            imdbIds.Add("tt2404181");
            imdbIds.Add("tt2403029");
            imdbIds.Add("tt2403021");
            imdbIds.Add("tt2402927");
            imdbIds.Add("tt2402157");
            imdbIds.Add("tt2402105");
            imdbIds.Add("tt2401878");
            imdbIds.Add("tt2401097");
            imdbIds.Add("tt2400463");
            imdbIds.Add("tt2398231");
            imdbIds.Add("tt2396566");
            imdbIds.Add("tt2395427");
            imdbIds.Add("tt2390361");
            imdbIds.Add("tt2388771");
            imdbIds.Add("tt2388715");
            imdbIds.Add("tt2388637");
            imdbIds.Add("tt2387559");
            imdbIds.Add("tt2387499");
            imdbIds.Add("tt2387433");
            imdbIds.Add("tt2387408");
            imdbIds.Add("tt2386490");
            imdbIds.Add("tt2383068");
            imdbIds.Add("tt2382298");
            imdbIds.Add("tt2382009");
            imdbIds.Add("tt2381991");
            imdbIds.Add("tt2381941");
            imdbIds.Add("tt2381335");
            imdbIds.Add("tt2381249");
            imdbIds.Add("tt2381111");
            imdbIds.Add("tt2379713");
            imdbIds.Add("tt2378281");
            imdbIds.Add("tt2377322");
            imdbIds.Add("tt2375605");
            imdbIds.Add("tt2370248");
            imdbIds.Add("tt2369205");
            imdbIds.Add("tt2369135");
            imdbIds.Add("tt2366450");
            imdbIds.Add("tt2364975");
            imdbIds.Add("tt2364949");
            imdbIds.Add("tt2364897");
            imdbIds.Add("tt2364841");
            imdbIds.Add("tt2361509");
            imdbIds.Add("tt2361317");
            imdbIds.Add("tt2358925");
            imdbIds.Add("tt2358891");
            imdbIds.Add("tt2358456");
            imdbIds.Add("tt2357291");
            imdbIds.Add("tt2357129");
            imdbIds.Add("tt2355540");
            imdbIds.Add("tt2347569");
            imdbIds.Add("tt2345759");
            imdbIds.Add("tt2345737");
            imdbIds.Add("tt2345567");
            imdbIds.Add("tt2339741");
            imdbIds.Add("tt2334879");
            imdbIds.Add("tt2334873");
            imdbIds.Add("tt2334649");
            imdbIds.Add("tt2333784");
            imdbIds.Add("tt2332579");
            imdbIds.Add("tt2328678");
            imdbIds.Add("tt2326574");
            imdbIds.Add("tt2322441");
            imdbIds.Add("tt2321549");
            imdbIds.Add("tt2318527");
            imdbIds.Add("tt2318092");
            imdbIds.Add("tt2316868");
            imdbIds.Add("tt2316411");
            imdbIds.Add("tt2312718");
            imdbIds.Add("tt2310332");
            imdbIds.Add("tt2309788");
            imdbIds.Add("tt2309260");
            imdbIds.Add("tt2306745");
            imdbIds.Add("tt2305051");
            imdbIds.Add("tt2304933");
            imdbIds.Add("tt2304771");
            imdbIds.Add("tt2302755");
            imdbIds.Add("tt2301155");
            imdbIds.Add("tt2300975");
            imdbIds.Add("tt2294965");
            imdbIds.Add("tt2294677");
            imdbIds.Add("tt2294629");
            imdbIds.Add("tt2294449");
            imdbIds.Add("tt2293640");
            imdbIds.Add("tt2292959");
            imdbIds.Add("tt2281587");
            imdbIds.Add("tt2279373");
            imdbIds.Add("tt2279339");
            imdbIds.Add("tt2278871");
            imdbIds.Add("tt2278388");
            imdbIds.Add("tt2277860");
            imdbIds.Add("tt2273657");
            imdbIds.Add("tt2268016");
            imdbIds.Add("tt2267998");
            imdbIds.Add("tt2267968");
            imdbIds.Add("tt2265398");
            imdbIds.Add("tt2265171");
            imdbIds.Add("tt2262227");
            imdbIds.Add("tt2247476");
            imdbIds.Add("tt2246565");
            imdbIds.Add("tt2245084");
            imdbIds.Add("tt2245003");
            imdbIds.Add("tt2243537");
            imdbIds.Add("tt2243389");
            imdbIds.Add("tt2241351");
            imdbIds.Add("tt2239832");
            imdbIds.Add("tt2238050");
            imdbIds.Add("tt2235779");
            imdbIds.Add("tt2234155");
            imdbIds.Add("tt2229499");
            imdbIds.Add("tt2226597");
            imdbIds.Add("tt2226417");
            imdbIds.Add("tt2224026");
            imdbIds.Add("tt2218003");
            imdbIds.Add("tt2215719");
            imdbIds.Add("tt2209764");
            imdbIds.Add("tt2209418");
            imdbIds.Add("tt2205401");
            imdbIds.Add("tt2203939");
            imdbIds.Add("tt2199571");
            imdbIds.Add("tt2195548");
            imdbIds.Add("tt2194499");
            imdbIds.Add("tt2193215");
            imdbIds.Add("tt2192016");
            imdbIds.Add("tt2191701");
            imdbIds.Add("tt2190838");
            imdbIds.Add("tt2184339");
            imdbIds.Add("tt2183034");
            imdbIds.Add("tt2182256");
            imdbIds.Add("tt2180411");
            imdbIds.Add("tt2179136");
            imdbIds.Add("tt2179116");
            imdbIds.Add("tt2177771");
            imdbIds.Add("tt2172935");
            imdbIds.Add("tt2172934");
            imdbIds.Add("tt2172584");
            imdbIds.Add("tt2170593");
            imdbIds.Add("tt2170439");
            imdbIds.Add("tt2170299");
            imdbIds.Add("tt2170242");
            imdbIds.Add("tt2167202");
            imdbIds.Add("tt2140479");
            imdbIds.Add("tt2140379");
            imdbIds.Add("tt2140373");
            imdbIds.Add("tt2140037");
            imdbIds.Add("tt2139919");
            imdbIds.Add("tt2139555");
            imdbIds.Add("tt2132285");
            imdbIds.Add("tt2126355");
            imdbIds.Add("tt2126235");
            imdbIds.Add("tt2125666");
            imdbIds.Add("tt2125608");
            imdbIds.Add("tt2125435");
            imdbIds.Add("tt2125423");
            imdbIds.Add("tt2124803");
            imdbIds.Add("tt2120152");
            imdbIds.Add("tt2120120");
            imdbIds.Add("tt2119532");
            imdbIds.Add("tt2115295");
            imdbIds.Add("tt2109248");
            imdbIds.Add("tt2109184");
            imdbIds.Add("tt2106651");
            imdbIds.Add("tt2106476");
            imdbIds.Add("tt2106361");
            imdbIds.Add("tt2105044");
            imdbIds.Add("tt2103281");
            imdbIds.Add("tt2103267");
            imdbIds.Add("tt2103264");
            imdbIds.Add("tt2103254");
            imdbIds.Add("tt2103217");
            imdbIds.Add("tt2101441");
            imdbIds.Add("tt2101383");
            imdbIds.Add("tt2101341");
            imdbIds.Add("tt2097307");
            imdbIds.Add("tt2097298");
            imdbIds.Add("tt2096673");
            imdbIds.Add("tt2096672");
            imdbIds.Add("tt2095649");
            imdbIds.Add("tt2094766");
            imdbIds.Add("tt2094155");
            imdbIds.Add("tt2094064");
            imdbIds.Add("tt2093991");
            imdbIds.Add("tt2091473");
            imdbIds.Add("tt2091256");
            imdbIds.Add("tt2088003");
            imdbIds.Add("tt2085910");
            imdbIds.Add("tt2084989");
            imdbIds.Add("tt2084970");
            imdbIds.Add("tt2083383");
            imdbIds.Add("tt2083355");
            imdbIds.Add("tt2083231");
            imdbIds.Add("tt2080374");
            imdbIds.Add("tt2077851");
            imdbIds.Add("tt2076220");
            imdbIds.Add("tt2070862");
            imdbIds.Add("tt2070852");
            imdbIds.Add("tt2063781");
            imdbIds.Add("tt2059255");
            imdbIds.Add("tt2058673");
            imdbIds.Add("tt2053463");
            imdbIds.Add("tt2053425");
            imdbIds.Add("tt2044729");
            imdbIds.Add("tt2042568");
            imdbIds.Add("tt2039393");
            imdbIds.Add("tt2039345");
            imdbIds.Add("tt2034139");
            imdbIds.Add("tt2034031");
            imdbIds.Add("tt2027064");
            imdbIds.Add("tt2025690");
            imdbIds.Add("tt2024544");
            imdbIds.Add("tt2024519");
            imdbIds.Add("tt2024469");
            imdbIds.Add("tt2024432");
            imdbIds.Add("tt2023690");
            imdbIds.Add("tt2023587");
            imdbIds.Add("tt2023453");
            imdbIds.Add("tt2017038");
            imdbIds.Add("tt2017020");
            imdbIds.Add("tt2015381");
            imdbIds.Add("tt2014338");
            imdbIds.Add("tt2013293");
            imdbIds.Add("tt2011159");
            imdbIds.Add("tt2006295");
            imdbIds.Add("tt2005151");
            imdbIds.Add("tt2004420");
            imdbIds.Add("tt2002718");
            imdbIds.Add("tt1999995");
            imdbIds.Add("tt1996264");
            imdbIds.Add("tt1995341");
            imdbIds.Add("tt1991245");
            imdbIds.Add("tt1988781");
            imdbIds.Add("tt1985966");
            imdbIds.Add("tt1985949");
            imdbIds.Add("tt1985019");
            imdbIds.Add("tt1981677");
            imdbIds.Add("tt1981128");
            imdbIds.Add("tt1981115");
            imdbIds.Add("tt1980929");
            imdbIds.Add("tt1980209");
            imdbIds.Add("tt1979388");
            imdbIds.Add("tt1979376");
            imdbIds.Add("tt1979320");
            imdbIds.Add("tt1976009");
            imdbIds.Add("tt1974420");
            imdbIds.Add("tt1972779");
            imdbIds.Add("tt1971352");
            imdbIds.Add("tt1969062");
            imdbIds.Add("tt1966604");
            imdbIds.Add("tt1965065");
            imdbIds.Add("tt1964418");
            imdbIds.Add("tt1959490");
            imdbIds.Add("tt1959438");
            imdbIds.Add("tt1956620");
            imdbIds.Add("tt1954352");
            imdbIds.Add("tt1951266");
            imdbIds.Add("tt1951265");
            imdbIds.Add("tt1951264");
            imdbIds.Add("tt1951261");
            imdbIds.Add("tt1939659");
            imdbIds.Add("tt1937390");
            imdbIds.Add("tt1937118");
            imdbIds.Add("tt1935897");
            imdbIds.Add("tt1935896");
            imdbIds.Add("tt1935859");
            imdbIds.Add("tt1935179");
            imdbIds.Add("tt1932767");
            imdbIds.Add("tt1932718");
            imdbIds.Add("tt1931533");
            imdbIds.Add("tt1931435");
            imdbIds.Add("tt1930463");
            imdbIds.Add("tt1930294");
            imdbIds.Add("tt1929263");
            imdbIds.Add("tt1924435");
            imdbIds.Add("tt1924429");
            imdbIds.Add("tt1922777");
            imdbIds.Add("tt1922685");
            imdbIds.Add("tt1921064");
            imdbIds.Add("tt1920849");
            imdbIds.Add("tt1915581");
            imdbIds.Add("tt1912398");
            imdbIds.Add("tt1911658");
            imdbIds.Add("tt1911644");
            imdbIds.Add("tt1907668");
            imdbIds.Add("tt1905041");
            imdbIds.Add("tt1904996");
            imdbIds.Add("tt1899353");
            imdbIds.Add("tt1895587");
            imdbIds.Add("tt1893326");
            imdbIds.Add("tt1885300");
            imdbIds.Add("tt1885299");
            imdbIds.Add("tt1881002");
            imdbIds.Add("tt1878870");
            imdbIds.Add("tt1878841");
            imdbIds.Add("tt1877832");
            imdbIds.Add("tt1876451");
            imdbIds.Add("tt1872818");
            imdbIds.Add("tt1872194");
            imdbIds.Add("tt1872181");
            imdbIds.Add("tt1870529");
            imdbIds.Add("tt1869716");
            imdbIds.Add("tt1866249");
            imdbIds.Add("tt1862079");
            imdbIds.Add("tt1860357");
            imdbIds.Add("tt1860353");
            imdbIds.Add("tt1860213");
            imdbIds.Add("tt1859650");
            imdbIds.Add("tt1855325");
            imdbIds.Add("tt1855199");
            imdbIds.Add("tt1854564");
            imdbIds.Add("tt1854236");
            imdbIds.Add("tt1853739");
            imdbIds.Add("tt1853728");
            imdbIds.Add("tt1850457");
            imdbIds.Add("tt1850397");
            imdbIds.Add("tt1846472");
            imdbIds.Add("tt1843866");
            imdbIds.Add("tt1841642");
            imdbIds.Add("tt1840417");
            imdbIds.Add("tt1840309");
            imdbIds.Add("tt1839492");
            imdbIds.Add("tt1837703");
            imdbIds.Add("tt1837574");
            imdbIds.Add("tt1826590");
            imdbIds.Add("tt1825683");
            imdbIds.Add("tt1824254");
            imdbIds.Add("tt1823672");
            imdbIds.Add("tt1823664");
            imdbIds.Add("tt1821694");
            imdbIds.Add("tt1821658");
            imdbIds.Add("tt1821549");
            imdbIds.Add("tt1820488");
            imdbIds.Add("tt1817771");
            imdbIds.Add("tt1817273");
            imdbIds.Add("tt1816518");
            imdbIds.Add("tt1815862");
            imdbIds.Add("tt1814621");
            imdbIds.Add("tt1810683");
            imdbIds.Add("tt1809398");
            imdbIds.Add("tt1800741");
            imdbIds.Add("tt1800302");
            imdbIds.Add("tt1800246");
            imdbIds.Add("tt1800241");
            imdbIds.Add("tt1798709");
            imdbIds.Add("tt1798684");
            imdbIds.Add("tt1798603");
            imdbIds.Add("tt1795369");
            imdbIds.Add("tt1792647");
            imdbIds.Add("tt1791682");
            imdbIds.Add("tt1791528");
            imdbIds.Add("tt1790886");
            imdbIds.Add("tt1790885");
            imdbIds.Add("tt1790864");
            imdbIds.Add("tt1790809");
            imdbIds.Add("tt1786751");
            imdbIds.Add("tt1783732");
            imdbIds.Add("tt1781922");
            imdbIds.Add("tt1781827");
            imdbIds.Add("tt1781769");
            imdbIds.Add("tt1778924");
            imdbIds.Add("tt1772341");
            imdbIds.Add("tt1772271");
            imdbIds.Add("tt1767372");
            imdbIds.Add("tt1764651");
            imdbIds.Add("tt1764234");
            imdbIds.Add("tt1764183");
            imdbIds.Add("tt1763264");
            imdbIds.Add("tt1762399");
            imdbIds.Add("tt1758830");
            imdbIds.Add("tt1758795");
            imdbIds.Add("tt1758595");
            imdbIds.Add("tt1754811");
            imdbIds.Add("tt1753422");
            imdbIds.Add("tt1748227");
            imdbIds.Add("tt1748207");
            imdbIds.Add("tt1748179");
            imdbIds.Add("tt1748122");
            imdbIds.Add("tt1747967");
            imdbIds.Add("tt1745787");
            imdbIds.Add("tt1742334");
            imdbIds.Add("tt1742044");
            imdbIds.Add("tt1741273");
            imdbIds.Add("tt1735898");
            imdbIds.Add("tt1733125");
            imdbIds.Add("tt1731697");
            imdbIds.Add("tt1731141");
            imdbIds.Add("tt1727776");
            imdbIds.Add("tt1727388");
            imdbIds.Add("tt1726669");
            imdbIds.Add("tt1726592");
            imdbIds.Add("tt1723811");
            imdbIds.Add("tt1723121");
            imdbIds.Add("tt1722476");
            imdbIds.Add("tt1720616");
            imdbIds.Add("tt1716777");
            imdbIds.Add("tt1715873");
            imdbIds.Add("tt1714915");
            imdbIds.Add("tt1714206");
            imdbIds.Add("tt1714203");
            imdbIds.Add("tt1712261");
            imdbIds.Add("tt1712170");
            imdbIds.Add("tt1711525");
            imdbIds.Add("tt1711425");
            imdbIds.Add("tt1710417");
            imdbIds.Add("tt1707386");
            imdbIds.Add("tt1706620");
            imdbIds.Add("tt1706598");
            imdbIds.Add("tt1706593");
            imdbIds.Add("tt1704573");
            imdbIds.Add("tt1702439");
            imdbIds.Add("tt1700845");
            imdbIds.Add("tt1700841");
            imdbIds.Add("tt1699755");
            imdbIds.Add("tt1698648");
            imdbIds.Add("tt1698641");
            imdbIds.Add("tt1694020");
            imdbIds.Add("tt1691917");
            imdbIds.Add("tt1690953");
            imdbIds.Add("tt1687901");
            imdbIds.Add("tt1686821");
            imdbIds.Add("tt1684925");
            imdbIds.Add("tt1682181");
            imdbIds.Add("tt1682180");
            imdbIds.Add("tt1680138");
            imdbIds.Add("tt1680045");
            imdbIds.Add("tt1679335");
            imdbIds.Add("tt1675161");
            imdbIds.Add("tt1674771");
            imdbIds.Add("tt1673434");
            imdbIds.Add("tt1673376");
            imdbIds.Add("tt1670345");
            imdbIds.Add("tt1667889");
            imdbIds.Add("tt1667353");
            imdbIds.Add("tt1667310");
            imdbIds.Add("tt1666801");
            imdbIds.Add("tt1663662");
            imdbIds.Add("tt1663207");
            imdbIds.Add("tt1663202");
            imdbIds.Add("tt1663143");
            imdbIds.Add("tt1661382");
            imdbIds.Add("tt1661199");
            imdbIds.Add("tt1659337");
            imdbIds.Add("tt1655442");
            imdbIds.Add("tt1655441");
            imdbIds.Add("tt1650554");
            imdbIds.Add("tt1649419");
            imdbIds.Add("tt1648179");
            imdbIds.Add("tt1647668");
            imdbIds.Add("tt1646987");
            imdbIds.Add("tt1646971");
            imdbIds.Add("tt1645170");
            imdbIds.Add("tt1645131");
            imdbIds.Add("tt1641841");
            imdbIds.Add("tt1640548");
            imdbIds.Add("tt1638355");
            imdbIds.Add("tt1637725");
            imdbIds.Add("tt1637706");
            imdbIds.Add("tt1637688");
            imdbIds.Add("tt1634003");
            imdbIds.Add("tt1631867");
            imdbIds.Add("tt1629757");
            imdbIds.Add("tt1625346");
            imdbIds.Add("tt1623288");
            imdbIds.Add("tt1623205");
            imdbIds.Add("tt1621039");
            imdbIds.Add("tt1620935");
            imdbIds.Add("tt1618448");
            imdbIds.Add("tt1618442");
            imdbIds.Add("tt1617661");
            imdbIds.Add("tt1615065");
            imdbIds.Add("tt1614989");
            imdbIds.Add("tt1613750");
            imdbIds.Add("tt1611224");
            imdbIds.Add("tt1606378");
            imdbIds.Add("tt1605783");
            imdbIds.Add("tt1605717");
            imdbIds.Add("tt1602620");
            imdbIds.Add("tt1602613");
            imdbIds.Add("tt1601913");
            imdbIds.Add("tt1600196");
            imdbIds.Add("tt1599348");
            imdbIds.Add("tt1598642");
            imdbIds.Add("tt1596753");
            imdbIds.Add("tt1596365");
            imdbIds.Add("tt1596363");
            imdbIds.Add("tt1596350");
            imdbIds.Add("tt1595656");
            imdbIds.Add("tt1588398");
            imdbIds.Add("tt1588173");
            imdbIds.Add("tt1587310");
            imdbIds.Add("tt1586265");
            imdbIds.Add("tt1583421");
            imdbIds.Add("tt1582507");
            imdbIds.Add("tt1582248");
            imdbIds.Add("tt1580426");
            imdbIds.Add("tt1572315");
            imdbIds.Add("tt1568911");
            imdbIds.Add("tt1568346");
            imdbIds.Add("tt1567609");
            imdbIds.Add("tt1564585");
            imdbIds.Add("tt1562899");
            imdbIds.Add("tt1560985");
            imdbIds.Add("tt1560747");
            imdbIds.Add("tt1559547");
            imdbIds.Add("tt1549920");
            imdbIds.Add("tt1547234");
            imdbIds.Add("tt1540128");
            imdbIds.Add("tt1540011");
            imdbIds.Add("tt1538403");
            imdbIds.Add("tt1535438");
            imdbIds.Add("tt1535109");
            imdbIds.Add("tt1535108");
            imdbIds.Add("tt1534085");
            imdbIds.Add("tt1532958");
            imdbIds.Add("tt1532503");
            imdbIds.Add("tt1531901");
            imdbIds.Add("tt1528854");
            imdbIds.Add("tt1528100");
            imdbIds.Add("tt1528071");
            imdbIds.Add("tt1524930");
            imdbIds.Add("tt1524575");
            imdbIds.Add("tt1517260");
            imdbIds.Add("tt1509788");
            imdbIds.Add("tt1506999");
            imdbIds.Add("tt1502712");
            imdbIds.Add("tt1499658");
            imdbIds.Add("tt1496422");
            imdbIds.Add("tt1491044");
            imdbIds.Add("tt1490785");
            imdbIds.Add("tt1490017");
            imdbIds.Add("tt1489889");
            imdbIds.Add("tt1485796");
            imdbIds.Add("tt1483013");
            imdbIds.Add("tt1482459");
            imdbIds.Add("tt1480656");
            imdbIds.Add("tt1478964");
            imdbIds.Add("tt1477855");
            imdbIds.Add("tt1473832");
            imdbIds.Add("tt1472584");
            imdbIds.Add("tt1465522");
            imdbIds.Add("tt1464335");
            imdbIds.Add("tt1462900");
            imdbIds.Add("tt1462769");
            imdbIds.Add("tt1462756");
            imdbIds.Add("tt1462041");
            imdbIds.Add("tt1458169");
            imdbIds.Add("tt1457767");
            imdbIds.Add("tt1456635");
            imdbIds.Add("tt1454468");
            imdbIds.Add("tt1453405");
            imdbIds.Add("tt1450321");
            imdbIds.Add("tt1447981");
            imdbIds.Add("tt1446714");
            imdbIds.Add("tt1446192");
            imdbIds.Add("tt1441951");
            imdbIds.Add("tt1441395");
            imdbIds.Add("tt1440129");
            imdbIds.Add("tt1433822");
            imdbIds.Add("tt1433811");
            imdbIds.Add("tt1431045");
            imdbIds.Add("tt1430626");
            imdbIds.Add("tt1430612");
            imdbIds.Add("tt1430132");
            imdbIds.Add("tt1428538");
            imdbIds.Add("tt1426329");
            imdbIds.Add("tt1425922");
            imdbIds.Add("tt1418377");
            imdbIds.Add("tt1413495");
            imdbIds.Add("tt1411697");
            imdbIds.Add("tt1411250");
            imdbIds.Add("tt1409024");
            imdbIds.Add("tt1408253");
            imdbIds.Add("tt1408101");
            imdbIds.Add("tt1405365");
            imdbIds.Add("tt1403241");
            imdbIds.Add("tt1399103");
            imdbIds.Add("tt1398426");
            imdbIds.Add("tt1397280");
            imdbIds.Add("tt1392214");
            imdbIds.Add("tt1392190");
            imdbIds.Add("tt1392170");
            imdbIds.Add("tt1391034");
            imdbIds.Add("tt1390411");
            imdbIds.Add("tt1389139");
            imdbIds.Add("tt1389096");
            imdbIds.Add("tt1386703");
            imdbIds.Add("tt1386697");
            imdbIds.Add("tt1375670");
            imdbIds.Add("tt1375666");
            imdbIds.Add("tt1374992");
            imdbIds.Add("tt1371150");
            imdbIds.Add("tt1371111");
            imdbIds.Add("tt1355683");
            imdbIds.Add("tt1355644");
            imdbIds.Add("tt1355631");
            imdbIds.Add("tt1355630");
            imdbIds.Add("tt1351685");
            imdbIds.Add("tt1349451");
            imdbIds.Add("tt1345836");
            imdbIds.Add("tt1343727");
            imdbIds.Add("tt1343092");
            imdbIds.Add("tt1340138");
            imdbIds.Add("tt1336608");
            imdbIds.Add("tt1335975");
            imdbIds.Add("tt1333125");
            imdbIds.Add("tt1327773");
            imdbIds.Add("tt1327194");
            imdbIds.Add("tt1325004");
            imdbIds.Add("tt1324999");
            imdbIds.Add("tt1322313");
            imdbIds.Add("tt1322269");
            imdbIds.Add("tt1321870");
            imdbIds.Add("tt1321511");
            imdbIds.Add("tt1320253");
            imdbIds.Add("tt1320244");
            imdbIds.Add("tt1318514");
            imdbIds.Add("tt1311071");
            imdbIds.Add("tt1311060");
            imdbIds.Add("tt1308729");
            imdbIds.Add("tt1307068");
            imdbIds.Add("tt1306980");
            imdbIds.Add("tt1300854");
            imdbIds.Add("tt1298649");
            imdbIds.Add("tt1294970");
            imdbIds.Add("tt1292566");
            imdbIds.Add("tt1291150");
            imdbIds.Add("tt1289401");
            imdbIds.Add("tt1288558");
            imdbIds.Add("tt1285016");
            imdbIds.Add("tt1277953");
            imdbIds.Add("tt1276419");
            imdbIds.Add("tt1276104");
            imdbIds.Add("tt1272878");
            imdbIds.Add("tt1270798");
            imdbIds.Add("tt1267297");
            imdbIds.Add("tt1259571");
            imdbIds.Add("tt1259521");
            imdbIds.Add("tt1258972");
            imdbIds.Add("tt1255953");
            imdbIds.Add("tt1253863");
            imdbIds.Add("tt1250777");
            imdbIds.Add("tt1247690");
            imdbIds.Add("tt1245526");
            imdbIds.Add("tt1245492");
            imdbIds.Add("tt1243974");
            imdbIds.Add("tt1242460");
            imdbIds.Add("tt1235522");
            imdbIds.Add("tt1234721");
            imdbIds.Add("tt1234719");
            imdbIds.Add("tt1232838");
            imdbIds.Add("tt1232829");
            imdbIds.Add("tt1232200");
            imdbIds.Add("tt1231587");
            imdbIds.Add("tt1231586");
            imdbIds.Add("tt1230168");
            imdbIds.Add("tt1229340");
            imdbIds.Add("tt1229238");
            imdbIds.Add("tt1228987");
            imdbIds.Add("tt1228705");
            imdbIds.Add("tt1226774");
            imdbIds.Add("tt1220634");
            imdbIds.Add("tt1220201");
            imdbIds.Add("tt1219289");
            imdbIds.Add("tt1217209");
            imdbIds.Add("tt1216491");
            imdbIds.Add("tt1213663");
            imdbIds.Add("tt1212450");
            imdbIds.Add("tt1211956");
            imdbIds.Add("tt1211837");
            imdbIds.Add("tt1210819");
            imdbIds.Add("tt1210166");
            imdbIds.Add("tt1206543");
            imdbIds.Add("tt1205537");
            imdbIds.Add("tt1204977");
            imdbIds.Add("tt1204975");
            imdbIds.Add("tt1196956");
            imdbIds.Add("tt1195478");
            imdbIds.Add("tt1194173");
            imdbIds.Add("tt1183921");
            imdbIds.Add("tt1181614");
            imdbIds.Add("tt1178665");
            imdbIds.Add("tt1175709");
            imdbIds.Add("tt1171222");
            imdbIds.Add("tt1170358");
            imdbIds.Add("tt1156398");
            imdbIds.Add("tt1152758");
            imdbIds.Add("tt1151410");
            imdbIds.Add("tt1142977");
            imdbIds.Add("tt1139797");
            imdbIds.Add("tt1130884");
            imdbIds.Add("tt1127180");
            imdbIds.Add("tt1126591");
            imdbIds.Add("tt1126590");
            imdbIds.Add("tt1124037");
            imdbIds.Add("tt1121096");
            imdbIds.Add("tt1120985");
            imdbIds.Add("tt1119646");
            imdbIds.Add("tt1109624");
            imdbIds.Add("tt1104001");
            imdbIds.Add("tt1103982");
            imdbIds.Add("tt1100089");
            imdbIds.Add("tt1099212");
            imdbIds.Add("tt1091191");
            imdbIds.Add("tt1086772");
            imdbIds.Add("tt1077368");
            imdbIds.Add("tt1074638");
            imdbIds.Add("tt1071804");
            imdbIds.Add("tt1065073");
            imdbIds.Add("tt1055369");
            imdbIds.Add("tt1051904");
            imdbIds.Add("tt1047540");
            imdbIds.Add("tt1047011");
            imdbIds.Add("tt1046173");
            imdbIds.Add("tt1045658");
            imdbIds.Add("tt1043726");
            imdbIds.Add("tt1033575");
            imdbIds.Add("tt1029360");
            imdbIds.Add("tt1029231");
            imdbIds.Add("tt1024648");
            imdbIds.Add("tt1022603");
            imdbIds.Add("tt1020072");
            imdbIds.Add("tt1019454");
            imdbIds.Add("tt1018765");
            imdbIds.Add("tt1014763");
            imdbIds.Add("tt1002563");
            imdbIds.Add("tt0993846");
            imdbIds.Add("tt0993842");
            imdbIds.Add("tt0975645");
            imdbIds.Add("tt0971209");
            imdbIds.Add("tt0948470");
            imdbIds.Add("tt0947798");
            imdbIds.Add("tt0938330");
            imdbIds.Add("tt0938283");
            imdbIds.Add("tt0929632");
            imdbIds.Add("tt0918940");
            imdbIds.Add("tt0907657");
            imdbIds.Add("tt0903657");
            imdbIds.Add("tt0903624");
            imdbIds.Add("tt0892769");
            imdbIds.Add("tt0884732");
            imdbIds.Add("tt0884726");
            imdbIds.Add("tt0882977");
            imdbIds.Add("tt0869977");
            imdbIds.Add("tt0864835");
            imdbIds.Add("tt0850677");
            imdbIds.Add("tt0848537");
            imdbIds.Add("tt0848228");
            imdbIds.Add("tt0837562");
            imdbIds.Add("tt0835418");
            imdbIds.Add("tt0831387");
            imdbIds.Add("tt0830558");
            imdbIds.Add("tt0829150");
            imdbIds.Add("tt0816711");
            imdbIds.Add("tt0816692");
            imdbIds.Add("tt0816442");
            imdbIds.Add("tt0815178");
            imdbIds.Add("tt0814255");
            imdbIds.Add("tt0810988");
            imdbIds.Add("tt0810922");
            imdbIds.Add("tt0810819");
            imdbIds.Add("tt0804497");
            imdbIds.Add("tt0803096");
            imdbIds.Add("tt0800080");
            imdbIds.Add("tt0796366");
            imdbIds.Add("tt0795461");
            imdbIds.Add("tt0790736");
            imdbIds.Add("tt0790724");
            imdbIds.Add("tt0790636");
            imdbIds.Add("tt0790628");
            imdbIds.Add("tt0787474");
            imdbIds.Add("tt0780504");
            imdbIds.Add("tt0770828");
            imdbIds.Add("tt0770703");
            imdbIds.Add("tt0765446");
            imdbIds.Add("tt0498381");
            imdbIds.Add("tt0490215");
            imdbIds.Add("tt0490076");
            imdbIds.Add("tt0486551");
            imdbIds.Add("tt0482571");
            imdbIds.Add("tt0481499");
            imdbIds.Add("tt0481369");
            imdbIds.Add("tt0478970");
            imdbIds.Add("tt0478304");
            imdbIds.Add("tt0475290");
            imdbIds.Add("tt0472399");
            imdbIds.Add("tt0470752");
            imdbIds.Add("tt0468569");
            imdbIds.Add("tt0465580");
            imdbIds.Add("tt0460791");
            imdbIds.Add("tt0460745");
            imdbIds.Add("tt0460740");
            imdbIds.Add("tt0458481");
            imdbIds.Add("tt0458339");
            imdbIds.Add("tt0455944");
            imdbIds.Add("tt0454970");
            imdbIds.Add("tt0454876");
            imdbIds.Add("tt0453562");
            imdbIds.Add("tt0452623");
            imdbIds.Add("tt0443465");
            imdbIds.Add("tt0443272");
            imdbIds.Add("tt0436339");
            imdbIds.Add("tt0435651");
            imdbIds.Add("tt0432283");
            imdbIds.Add("tt0432021");
            imdbIds.Add("tt0431021");
            imdbIds.Add("tt0430634");
            imdbIds.Add("tt0426459");
            imdbIds.Add("tt0425210");
            imdbIds.Add("tt0424136");
            imdbIds.Add("tt0418279");
            imdbIds.Add("tt0416449");
            imdbIds.Add("tt0409459");
            imdbIds.Add("tt0407887");
            imdbIds.Add("tt0404364");
            imdbIds.Add("tt0401792");
            imdbIds.Add("tt0401729");
            imdbIds.Add("tt0398913");
            imdbIds.Add("tt0393109");
            imdbIds.Add("tt0385002");
            imdbIds.Add("tt0384537");
            imdbIds.Add("tt0378194");
            imdbIds.Add("tt0377107");
            imdbIds.Add("tt0377092");
            imdbIds.Add("tt0376994");
            imdbIds.Add("tt0376541");
            imdbIds.Add("tt0372784");
            imdbIds.Add("tt0371746");
            imdbIds.Add("tt0369610");
            imdbIds.Add("tt0369445");
            imdbIds.Add("tt0365907");
            imdbIds.Add("tt0365748");
            imdbIds.Add("tt0364376");
            imdbIds.Add("tt0361127");
            imdbIds.Add("tt0359950");
            imdbIds.Add("tt0348333");
            imdbIds.Add("tt0348150");
            imdbIds.Add("tt0340377");
            imdbIds.Add("tt0337978");
            imdbIds.Add("tt0337692");
            imdbIds.Add("tt0333766");
            imdbIds.Add("tt0332375");
            imdbIds.Add("tt0330373");
            imdbIds.Add("tt0318627");
            imdbIds.Add("tt0317740");
            imdbIds.Add("tt0309987");
            imdbIds.Add("tt0309698");
            imdbIds.Add("tt0308411");
            imdbIds.Add("tt0298130");
            imdbIds.Add("tt0290334");
            imdbIds.Add("tt0289765");
            imdbIds.Add("tt0287978");
            imdbIds.Add("tt0266697");
            imdbIds.Add("tt0266543");
            imdbIds.Add("tt0266452");
            imdbIds.Add("tt0266308");
            imdbIds.Add("tt0265208");
            imdbIds.Add("tt0264935");
            imdbIds.Add("tt0264472");
            imdbIds.Add("tt0264464");
            imdbIds.Add("tt0264395");
            imdbIds.Add("tt0258000");
            imdbIds.Add("tt0253556");
            imdbIds.Add("tt0246578");
            imdbIds.Add("tt0243655");
            imdbIds.Add("tt0240515");
            imdbIds.Add("tt0238380");
            imdbIds.Add("tt0232500");
            imdbIds.Add("tt0218817");
            imdbIds.Add("tt0209958");
            imdbIds.Add("tt0209144");
            imdbIds.Add("tt0208196");
            imdbIds.Add("tt0208092");
            imdbIds.Add("tt0206634");
            imdbIds.Add("tt0198781");
            imdbIds.Add("tt0198781");
            imdbIds.Add("tt0190590");
            imdbIds.Add("tt0190138");
            imdbIds.Add("tt0185183");
            imdbIds.Add("tt0183790");
            imdbIds.Add("tt0172495");
            imdbIds.Add("tt0168172");
            imdbIds.Add("tt0167261");
            imdbIds.Add("tt0167260");
            imdbIds.Add("tt0164181");
            imdbIds.Add("tt0151804");
            imdbIds.Add("tt0145487");
            imdbIds.Add("tt0144084");
            imdbIds.Add("tt0137523");
            imdbIds.Add("tt0133093");
            imdbIds.Add("tt0126886");
            imdbIds.Add("tt0121766");
            imdbIds.Add("tt0121765");
            imdbIds.Add("tt0120915");
            imdbIds.Add("tt0120903");
            imdbIds.Add("tt0120815");
            imdbIds.Add("tt0120804");
            imdbIds.Add("tt0120737");
            imdbIds.Add("tt0120399");
            imdbIds.Add("tt0120338");
            imdbIds.Add("tt0120148");
            imdbIds.Add("tt0120082");
            imdbIds.Add("tt0119698");
            imdbIds.Add("tt0119361");
            imdbIds.Add("tt0119174");
            imdbIds.Add("tt0119116");
            imdbIds.Add("tt0119081");
            imdbIds.Add("tt0118688");
            imdbIds.Add("tt0117571");
            imdbIds.Add("tt0117509");
            imdbIds.Add("tt0117381");
            imdbIds.Add("tt0116768");
            imdbIds.Add("tt0116629");
            imdbIds.Add("tt0116367");
            imdbIds.Add("tt0114814");
            imdbIds.Add("tt0114709");
            imdbIds.Add("tt0114694");
            imdbIds.Add("tt0114369");
            imdbIds.Add("tt0113492");
            imdbIds.Add("tt0112864");
            imdbIds.Add("tt0112573");
            imdbIds.Add("tt0112462");
            imdbIds.Add("tt0111161");
            imdbIds.Add("tt0110912");
            imdbIds.Add("tt0110413");
            imdbIds.Add("tt0110357");
            imdbIds.Add("tt0110148");
            imdbIds.Add("tt0109830");
            imdbIds.Add("tt0109686");
            imdbIds.Add("tt0109520");
            imdbIds.Add("tt0109040");
            imdbIds.Add("tt0108941");
            imdbIds.Add("tt0108265");
            imdbIds.Add("tt0107692");
            imdbIds.Add("tt0107614");
            imdbIds.Add("tt0107290");
            imdbIds.Add("tt0107034");
            imdbIds.Add("tt0106856");
            imdbIds.Add("tt0105236");
            imdbIds.Add("tt0104952");
            imdbIds.Add("tt0104868");
            imdbIds.Add("tt0103776");
            imdbIds.Add("tt0103064");
            imdbIds.Add("tt0102945");
            imdbIds.Add("tt0102926");
            imdbIds.Add("tt0100814");
            imdbIds.Add("tt0100802");
            imdbIds.Add("tt0099864");
            imdbIds.Add("tt0099423");
            imdbIds.Add("tt0099088");
            imdbIds.Add("tt0098663");
            imdbIds.Add("tt0098554");
            imdbIds.Add("tt0098439");
            imdbIds.Add("tt0098084");
            imdbIds.Add("tt0097815");
            imdbIds.Add("tt0096895");
            imdbIds.Add("tt0096874");
            imdbIds.Add("tt0096446");
            imdbIds.Add("tt0096438");
            imdbIds.Add("tt0096256");
            imdbIds.Add("tt0095016");
            imdbIds.Add("tt0094862");
            imdbIds.Add("tt0094721");
            imdbIds.Add("tt0094625");
            imdbIds.Add("tt0094226");
            imdbIds.Add("tt0093793");
            imdbIds.Add("tt0093779");
            imdbIds.Add("tt0093773");
            imdbIds.Add("tt0093560");
            imdbIds.Add("tt0093409");
            imdbIds.Add("tt0093177");
            imdbIds.Add("tt0093075");
            imdbIds.Add("tt0092991");
            imdbIds.Add("tt0092005");
            imdbIds.Add("tt0091369");
            imdbIds.Add("tt0091064");
            imdbIds.Add("tt0091059");
            imdbIds.Add("tt0091042");
            imdbIds.Add("tt0090915");
            imdbIds.Add("tt0090728");
            imdbIds.Add("tt0090605");
            imdbIds.Add("tt0089469");
            imdbIds.Add("tt0089218");
            imdbIds.Add("tt0089114");
            imdbIds.Add("tt0088847");
            imdbIds.Add("tt0088763");
            imdbIds.Add("tt0087800");
            imdbIds.Add("tt0087332");
            imdbIds.Add("tt0087050");
            imdbIds.Add("tt0086320");
            imdbIds.Add("tt0086190");
            imdbIds.Add("tt0084787");
            imdbIds.Add("tt0084516");
            imdbIds.Add("tt0083944");
            imdbIds.Add("tt0083907");
            imdbIds.Add("tt0083658");
            imdbIds.Add("tt0082307");
            imdbIds.Add("tt0082010");
            imdbIds.Add("tt0081573");
            imdbIds.Add("tt0081505");
            imdbIds.Add("tt0080761");
            imdbIds.Add("tt0080684");
            imdbIds.Add("tt0080516");
            imdbIds.Add("tt0079522");
            imdbIds.Add("tt0078767");
            imdbIds.Add("tt0078748");
            imdbIds.Add("tt0078346");
            imdbIds.Add("tt0077975");
            imdbIds.Add("tt0077745");
            imdbIds.Add("tt0077687");
            imdbIds.Add("tt0077651");
            imdbIds.Add("tt0077402");
            imdbIds.Add("tt0076786");
            imdbIds.Add("tt0076759");
            imdbIds.Add("tt0076723");
            imdbIds.Add("tt0076162");
            imdbIds.Add("tt0075314");
            imdbIds.Add("tt0075005");
            imdbIds.Add("tt0074285");
            imdbIds.Add("tt0074174");
            imdbIds.Add("tt0073195");
            imdbIds.Add("tt0072271");
            imdbIds.Add("tt0071853");
            imdbIds.Add("tt0071562");
            imdbIds.Add("tt0071230");
            imdbIds.Add("tt0070047");
            imdbIds.Add("tt0069704");
            imdbIds.Add("tt0068646");
            imdbIds.Add("tt0068612");
            imdbIds.Add("tt0067992");
            imdbIds.Add("tt0063522");
            imdbIds.Add("tt0063350");
            imdbIds.Add("tt0056869");
            imdbIds.Add("tt0054215");
            imdbIds.Add("tt0052618");
            imdbIds.Add("tt0035575");
            imdbIds.Add("tt0032138");
            imdbIds.Add("tt0433035");
            imdbIds.Add("tt0448694");
            imdbIds.Add("tt2141773");
            imdbIds.Add("tt1445520");
            imdbIds.Add("tt1536048");
            imdbIds.Add("tt0983193");
            imdbIds.Add("tt1478338");
            imdbIds.Add("tt1615147");
            imdbIds.Add("tt1673702");
            imdbIds.Add("tt1568921");
            imdbIds.Add("tt1454029");
            imdbIds.Add("tt1628841");
            imdbIds.Add("tt1340800");
            imdbIds.Add("tt1521197");
            imdbIds.Add("tt0477302");
            imdbIds.Add("tt2011971");
            imdbIds.Add("tt1124035");
            imdbIds.Add("tt1440266");
            imdbIds.Add("tt1007029");
            imdbIds.Add("tt1201607");
            imdbIds.Add("tt1417075");
            imdbIds.Add("tt0970179");
            imdbIds.Add("tt1832382");
            imdbIds.Add("tt1860355");
            imdbIds.Add("tt1821593");
            imdbIds.Add("tt1302011");
            imdbIds.Add("tt1235830");
            imdbIds.Add("tt2028530");
            imdbIds.Add("tt1787725");
            imdbIds.Add("tt2223990");
            imdbIds.Add("tt1602098");
            imdbIds.Add("tt1229822");
            imdbIds.Add("tt3949660");
            imdbIds.Add("tt1957945");
            imdbIds.Add("tt1192628");

            #endregion IMDb Movie Ids

            int currentMovie = 1;
            int totalMovies = imdbIds.Count;

            foreach (var imdbId in imdbIds)
            {
                await Task.Delay(501); // added delay in order to not violate the TMDb limit of 40 requests / 10 seconds (4 requests per 1 second == 1 request per 250 milliseconds)

                try
                {
                    var response = await Task.Run(() => _tmdbMovieRepo.MovieDetailsByImdbId(imdbId));
                    var imdbMovie = response.movie_results.FirstOrDefault();

                    if (imdbMovie != null)
                    {
                        var movie = await Task.Run(() => _tmdbMovieRepo.MovieDetails(imdbMovie.id));

                        _dbMovieRepo.AddMovie(movie);
                        _dbMovieRepo.Save();
                        Helpers.OutputMessage(string.Format("\t{0} of {1}: {2} ({3})", currentMovie, totalMovies, imdbMovie.title, imdbMovie.id), ConsoleColor.Cyan);
                    }
                    else
                        Helpers.OutputMessage(string.Format("!!!! Imdb Id {0} not found!", imdbId), ConsoleColor.Red);
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Helpers.OutputMessage(string.Format("!!!! Property: {0} ({1})", validationError.PropertyName, validationError.ErrorMessage), ConsoleColor.Red);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Helpers.OutputMessage(string.Format("!!!! Exception: {0}", ex.ToString()), ConsoleColor.Red);
                }

                currentMovie++;
            }
        }
    }
}
