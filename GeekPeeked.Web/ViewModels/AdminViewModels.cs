using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Web.ViewModels
{
    public class GenresViewModel
    {
        public List<Genre> Genres { get; set; }

        public GenresViewModel()
        {
            Genres = new List<Genre>();
        }
    }

    public class KeywordsViewModel
    {
        public List<Keyword> Keywords { get; set; }

        public KeywordsViewModel()
        {
            Keywords = new List<Keyword>();
        }
    }

    public class ImagesViewModel
    {
        public List<Image> Images { get; set; }

        public ImagesViewModel()
        {
            Images = new List<Image>();
        }
    }

    public class VideosViewModel
    {
        public List<Video> Videos { get; set; }

        public VideosViewModel()
        {
            Videos = new List<Video>();
        }
    }

    public class ProductionCompaniesViewModel
    {
        public List<ProductionCompany> ProductionCompanies { get; set; }

        public ProductionCompaniesViewModel()
        {
            ProductionCompanies = new List<ProductionCompany>();
        }
    }

    public class PeopleViewModel
    {
        public List<Person> People { get; set; }

        public PeopleViewModel()
        {
            People = new List<Person>();
        }
    }

    public class CreditsViewModel
    {
        public List<Credit> Credits { get; set; }

        public CreditsViewModel()
        {
            Credits = new List<Credit>();
        }
    }

    public class CertificationsViewModel
    {
        public List<Certification> Certifications { get; set; }

        public CertificationsViewModel()
        {
            Certifications = new List<Certification>();
        }
    }

    public class MoviesViewModel
    {
        public List<Movie> Movies { get; set; }

        public MoviesViewModel()
        {
            Movies = new List<Movie>();
        }

    }
}