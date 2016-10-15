using System;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Web.ViewModels
{
    public class SimpleMovieViewModel
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Popularity { get; set; }
        public double AverageVote { get; set; }
        public int VoteCount { get; set; }
    }

    public class MoviesViewModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public List<SimpleMovieViewModel> TMDbMovies { get; set; }
        public List<SimpleMovieViewModel> GeekPeekedMovies { get; set; }

        public MoviesViewModel()
        {
            TMDbMovies = new List<SimpleMovieViewModel>();
            GeekPeekedMovies = new List<SimpleMovieViewModel>();
        }

    }

    public class NowPlayingViewModel
    {
        public List<SimpleMovieViewModel> TMDbMovies { get; set; }
        public List<SimpleMovieViewModel> GeekPeekedMovies { get; set; }

        public NowPlayingViewModel()
        {
            TMDbMovies = new List<SimpleMovieViewModel>();
            GeekPeekedMovies = new List<SimpleMovieViewModel>();
        }
    }

    public class GenresViewModel
    {
        public List<Genre> TMDbGenres { get; set; }
        public List<Genre> GeekPeekedGenres { get; set; }

        public GenresViewModel()
        {
            TMDbGenres = new List<Genre>();
            GeekPeekedGenres = new List<Genre>();
        }
    }

    public class CertificationsViewModel
    {
        public List<Certification> TMDbCertifications { get; set; }
        public List<Certification> GeekPeekedCertifications { get; set; }

        public CertificationsViewModel()
        {
            TMDbCertifications = new List<Certification>();
            GeekPeekedCertifications = new List<Certification>();
        }
    }
}