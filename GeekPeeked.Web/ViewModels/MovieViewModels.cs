using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Web.ViewModels
{
    public class GenresViewModel
    {
        public List<Genre> GeekPeekedGenres { get; set; }

        public GenresViewModel()
        {
            GeekPeekedGenres = new List<Genre>();
        }
    }

    public class JobsViewModel
    {
        public List<Job> GeekPeekedJobs { get; set; }

        public JobsViewModel()
        {
            GeekPeekedJobs = new List<Job>();
        }
    }

    public class CertificationsViewModel
    {
        public List<Certification> GeekPeekedCertifications { get; set; }

        public CertificationsViewModel()
        {
            GeekPeekedCertifications = new List<Certification>();
        }
    }

    public class MoviesViewModel
    {
        public List<Movie> GeekPeekedMovies { get; set; }

        public MoviesViewModel()
        {
            GeekPeekedMovies = new List<Movie>();
        }

    }
}