using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using GeekPeeked.Common.Models;

namespace GeekPeeked.Common.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(GeekPeekedDbContext context) : base(context) { }

        //public async Task<IEnumerable<Movie>> AllMovies()
        //{
        //    var movies = from m in _context.Movies select m;

        //    return await (movies.ToListAsync());
        //}
        //public async Task<Movie> CreateMovie(TMDbMovie.ResponseModel tmdbMovie)
        //{
        //    var movie = _context.Movies.FirstOrDefault(m => m.TmdbId == tmdbMovie.id);
        //    if (movie == null)
        //    {
        //        movie = new Movie();
        //        movie.Id = Guid.NewGuid();
        //        movie.CreatedDate = DateTime.Now;
        //        _context.Movies.Add(movie);
        //    }
        //    else
        //        movie.ModifiedDate = DateTime.Now;

        //    movie.TmdbId = tmdbMovie.id;
        //    movie.ImdbId = tmdbMovie.imdb_id;
        //    movie.Title = tmdbMovie.title;
        //    movie.OriginalTitle = tmdbMovie.original_title;
        //    movie.Description = tmdbMovie.overview;
        //    movie.Tagline = tmdbMovie.tagline;
        //    movie.Runtime = tmdbMovie.runtime;
        //    movie.PosterPath = tmdbMovie.poster_path;
        //    movie.HomePage = tmdbMovie.homepage;
        //    movie.Budget = tmdbMovie.budget;
        //    movie.Revenue = tmdbMovie.revenue;

        //    try
        //    {
        //        movie.ReleaseDate = Convert.ToDateTime(tmdbMovie.release_date);
        //    }
        //    catch
        //    {
        //        movie.ReleaseDate = new DateTime();
        //    }

        //    movie.Status = tmdbMovie.status;

        //    if (tmdbMovie.vote_count >= 10 ||
        //        (!string.IsNullOrWhiteSpace(tmdbMovie.poster_path) && tmdbMovie.popularity >= 2) ||
        //        (!string.IsNullOrWhiteSpace(tmdbMovie.poster_path) && tmdbMovie.original_language == "en" && tmdbMovie.vote_count >= 2))
        //    {
        //        movie.IsVisible = true;
        //    }
        //    else
        //        movie.IsVisible = false;

        //    movie.IsAdult = tmdbMovie.adult;
        //    movie.HasVideos = tmdbMovie.video;

        //    #region Set Genres

        //    foreach (var genre in tmdbMovie.genres)
        //    {
        //        var myGenre = _context.Genres.FirstOrDefault(g => g.Id == genre.id);
        //        if (myGenre == null)
        //            movie.Genres.Add(new Genre() { Id = genre.id, Name = genre.name });
        //        else
        //            movie.Genres.Add(myGenre);
        //    }

        //    _context.SaveChanges();

        //    #endregion Set Genres

        //    #region Set Production Companies

        //    foreach (var company in tmdbMovie.production_companies)
        //    {
        //        var myCompany = _context.ProductionCompanies.FirstOrDefault(pc => pc.Id == company.id);
        //        if (myCompany == null)
        //            movie.ProductionCompanies.Add(new ProductionCompany() { Id = company.id, Name = company.name });
        //        else
        //            movie.ProductionCompanies.Add(myCompany);
        //    }

        //    #endregion Set Production Companies

        //    #region Set Videos

        //    foreach (var video in tmdbMovie.videos.results)
        //    {
        //        var myVideo = _context.Videos.FirstOrDefault(v => v.Id == video.id);
        //        if (myVideo == null)
        //            movie.Videos.Add(new Video() { Id = video.id, Key = video.key, Name = video.name, Site = video.site, Size = video.size, Type = video.type });
        //        else
        //            movie.Videos.Add(myVideo);
        //    }


        //    #endregion Set Videos

        //    #region Set Images

        //    foreach (var poster in tmdbMovie.images.posters)
        //    {
        //        var myPoster = _context.Posters.FirstOrDefault(p => p.FilePath == poster.file_path);
        //        if (myPoster == null)
        //            movie.Posters.Add(new Poster() { AspectRatio = poster.aspect_ratio, FilePath = poster.file_path, Height = poster.height, Width = poster.width });
        //        else
        //            movie.Posters.Add(myPoster);
        //    }

        //    #endregion Set Images

        //    //#region Set Crew Members

        //    //foreach (var crew in tmdbMovie.credits.crew)
        //    //{
        //    //    var myCrew = _context.CrewMembers.FirstOrDefault(c => c.Id == crew.id);
        //    //    if (myCrew == null)
        //    //        movie.CrewMembers.Add(new CrewMember() { Id = crew.id, CreditId = crew.credit_id, Department = crew.department, Job = crew.job, Name = crew.name, ProfilePath = crew.profile_path });
        //    //    else
        //    //        movie.CrewMembers.Add(myCrew);
        //    //}


        //    //#endregion Set Crew Members

        //    //#region Set Cast Members

        //    //foreach (var cast in tmdbMovie.credits.cast)
        //    //{
        //    //    var myCast = _context.CastMembers.FirstOrDefault(c => c.Id == cast.id);
        //    //    if (myCast == null)
        //    //        movie.CastMembers.Add(new CastMember() { Id = cast.id, CastId = cast.cast_id, CharacterName = cast.character, CreditId = cast.credit_id, Name = cast.name, Sequence = cast.order, ProfilePath = cast.profile_path });
        //    //    else
        //    //        movie.CastMembers.Add(myCast);
        //    //}

        //    //#endregion Set Cast Members

        //    await _context.SaveChangesAsync();

        //    return movie;
        //}
        //public void RemoveMovie(Movie movie)
        //{
        //    _context.Movies.Remove(movie);
        //}

        //public async Task<IEnumerable<Genre>> AllGenres()
        //{
        //    var genres = from g in _context.Genres select g;

        //    return await (genres.ToListAsync());
        //}
        //public void AddGenre(Genre genre)
        //{
        //    genre.CreatedDate = DateTime.Now;
        //    _context.Genres.Add(genre);
        //}
        //public void RemoveGenre(Genre genre)
        //{
        //    _context.Genres.Remove(genre);
        //}

        //public async Task<IEnumerable<Certification>> AllCertifications()
        //{
        //    var certifications = from c in _context.Certifications select c;

        //    return await (certifications.ToListAsync());
        //}
        //public void AddCertification(Certification certification)
        //{
        //    certification.CreatedDate = DateTime.Now;
        //    _context.Certifications.Add(certification);
        //}
        //public void RemoveCertification(Certification certification)
        //{
        //    _context.Certifications.Remove(certification);
        //}

        //public async Task<IEnumerable<ProductionCompany>> AllProductionCompanies()
        //{
        //    var productionCompanies = from pc in _context.ProductionCompanies select pc;

        //    return await (productionCompanies.ToListAsync());
        //}
        //public void AddProductionCompany(ProductionCompany productionCompany)
        //{
        //    productionCompany.CreatedDate = DateTime.Now;
        //    _context.ProductionCompanies.Add(productionCompany);
        //}
        //public void RemoveProductionCompany(ProductionCompany productionCompany)
        //{
        //    _context.ProductionCompanies.Remove(productionCompany);
        //}

        ////public async Task<IEnumerable<CastMember>> AllCastMembers()
        ////{
        ////    var castMembers = from c in _context.CastMembers select c;

        ////    return await (castMembers.ToListAsync());
        ////}
        ////public void AddCastMember(CastMember castMember)
        ////{
        ////    castMember.CreatedDate = DateTime.Now;
        ////    _context.CastMembers.Add(castMember);
        ////}
        ////public void RemoveCastMember(CastMember castMember)
        ////{
        ////    _context.CastMembers.Remove(castMember);
        ////}

        ////public async Task<IEnumerable<CrewMember>> AllCrewMembers()
        ////{
        ////    var crewMembers = from c in _context.CrewMembers select c;

        ////    return await (crewMembers.ToListAsync());
        ////}
        ////public void AddCrewMember(CrewMember crewMember)
        ////{
        ////    crewMember.CreatedDate = DateTime.Now;
        ////    _context.CrewMembers.Add(crewMember);
        ////}
        ////public void RemoveCrewMember(CrewMember crewMember)
        ////{
        ////    _context.CrewMembers.Remove(crewMember);
        ////}

        //public async Task<IEnumerable<Poster>> AllPosters()
        //{
        //    var posters = from p in _context.Posters select p;

        //    return await (posters.ToListAsync());
        //}
        //public void AddPoster(Poster poster)
        //{
        //    poster.CreatedDate = DateTime.Now;
        //    _context.Posters.Add(poster);
        //}
        //public void RemovePoster(Poster poster)
        //{
        //    _context.Posters.Remove(poster);
        //}

        //public async Task<IEnumerable<Video>> AllVideos()
        //{
        //    var videos = from v in _context.Videos select v;

        //    return await (videos.ToListAsync());
        //}
        //public void AddVideo(Video video)
        //{
        //    video.CreatedDate = DateTime.Now;
        //    _context.Videos.Add(video);
        //}
        //public void RemoveVideo(Video video)
        //{
        //    _context.Videos.Remove(video);
        //}
    }
}
