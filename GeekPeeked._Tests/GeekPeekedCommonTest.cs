using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeekPeeked.Common.Models;
using GeekPeeked.Common.Repositories;

namespace GeekPeeked.Tests
{
    [TestClass]
    public class GenreRepositoryInitegrationTests
    {
        private string ThrillerStr = "Thriller";
        private Genre ThrillerGenre = new Genre() { Id = 1, Name = "Thriller" };

        #region Init and Cleanup

        [TestInitialize]
        public void Init()
        {
            Cleanup();

            using (var dataContext = new GeekPeekedDbContext())
            {
                dataContext.Genres.Add(ThrillerGenre);
                
                var m1 = new Movie() { Title = "Title 1", };
                m1.Genres.Add(ThrillerGenre);

                var m2 = new Movie() { Title = "Title 2" };
                m2.Genres.Add(ThrillerGenre);

                dataContext.Movies.Add(m1);
                dataContext.Movies.Add(m2);
                dataContext.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dataContext = new GeekPeekedDbContext())
            {
                IQueryable<Movie> movies = dataContext.Movies.Select(m => m);
                IQueryable<Genre> genres = dataContext.Genres.Select(g => g);

                foreach (Genre genre in genres)
                {
                    dataContext.Genres.Remove(genre);
                }

                foreach (Movie movie in movies)
                {
                    dataContext.Movies.Remove(movie);
                }

                dataContext.SaveChanges();
            }
        }

        #endregion
    }
}