using System;
using System.Threading.Tasks;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;

namespace GeekPeeked.UtilityApplication.Processors
{
    public class MovieProcessor
    {
        private TmdbRepository _tmdbMovieRepo;
        private MovieRepository _dbMovieRepo;

        public MovieProcessor()
        {
            _tmdbMovieRepo = new TmdbRepository();
            _dbMovieRepo = new MovieRepository(new GeekPeekedDbContext());
        }

        //public async Task ProcessMovieGenres()
        //{
        //}

        //public async Task ProcessMovieCertifications()
        //{
        //    var response = await Task.Run(() => _tmdbMovieRepo.AllCertifications());

        //    #region Non-US Country Certifications

        //    //foreach (var certification in response.certifications.AU)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tAU - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "AU",  Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.BG)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tBG - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "BG", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.BR)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tBR - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "BR", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.CA)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tCA - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "CA", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.DE)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tDE - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "DE", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.ES)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tES - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "ES", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.FI)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tFI - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "FI", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.FR)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tFR - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "FR", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.GB)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tGB - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "GB", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.IN)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tIN - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "IN", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.NL)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tNL - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "NL", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.NZ)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tNZ - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "NZ", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.PH)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tPH - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "PH", Name = certification.certification, Description = certification.meaning });
        //    //}
        //    //foreach (var certification in response.certifications.PT)
        //    //{
        //    //    Console.WriteLine(string.Format("Adding Certification:\tPT - {0} ({1})", certification.certification, certification.order));
        //    //    _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "PT", Name = certification.certification, Description = certification.meaning });
        //    //}

        //    #endregion Non-US Country Certifications

        //    foreach (var certification in response.certifications.US)
        //    {
        //        Console.WriteLine(string.Format("Adding Certification:\tUS - {0} ({1})", certification.certification, certification.order));
        //        _dbMovieRepo.AddCertification(new Certification() { TypeId = certification.order, Country = "US", Name = certification.certification, Description = certification.meaning });
        //    }

        //    _dbMovieRepo.Save();
        //}
    }
}
