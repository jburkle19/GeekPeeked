using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GeekPeeked.Common.Configuration;
using JobList = GeekPeeked.Common.Models.TMDb.Response.JobList;
using GenreList = GeekPeeked.Common.Models.TMDb.Response.GenreList;
using ImdbDetails = GeekPeeked.Common.Models.TMDb.Response.ImdbDetails;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;
using PersonDetails = GeekPeeked.Common.Models.TMDb.Response.PersonDetails;
using DiscoverMovies = GeekPeeked.Common.Models.TMDb.Response.DiscoverMovies;
using CertificationList = GeekPeeked.Common.Models.TMDb.Response.CertificationList;

namespace GeekPeeked.Common.Repositories
{
    public class TmdbRepository : BaseRepository, ITmdbRepository
    {
        private async Task<T> CallTmdbApi<T>(string url)
        {
            T result = default(T);

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(TMDbCoreConfiguration.TmdbBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        if (!string.IsNullOrWhiteSpace(jsonResponse))
                        {
                            try
                            {
                                result = JToken.Parse(jsonResponse).ToObject<T>();
                            }
                            catch (JsonSerializationException jsex)
                            {
                                Console.WriteLine(jsex.ToString());
                            }
                        }
                    }
                    else
                        Console.WriteLine(response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }
        private async Task<IEnumerable<DiscoverMovies.ResponseModel>> CallDiscoverMoviesTmdbApi(TMDbCoreConfiguration.DiscoverMoviesSearchOptions options)
        {
            var result = new List<DiscoverMovies.ResponseModel>();

            int totalPageCount = 1;
            options.PageNumber = 1;

            while (options.PageNumber <= totalPageCount)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(TMDbCoreConfiguration.TmdbBaseUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = await client.GetAsync(options.DiscoverMoviesTmdbUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = response.Content.ReadAsStringAsync().Result;

                            if (!string.IsNullOrWhiteSpace(jsonResponse))
                            {
                                try
                                {
                                    var discoverMoviesResponse = JToken.Parse(jsonResponse).ToObject<DiscoverMovies.ResponseModel>();
                                    result.Add(discoverMoviesResponse);

                                    totalPageCount = discoverMoviesResponse.total_pages;
                                }
                                catch (JsonSerializationException jsex)
                                {
                                    Console.WriteLine(jsex.ToString());
                                }
                            }
                        }
                        else
                            Console.WriteLine(response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                options.PageNumber++;
            }

            return result;
        }

        public async Task<JobList.ResponseModel> AllJobs()
        {
            return await CallTmdbApi<JobList.ResponseModel>(TMDbCoreConfiguration.JobListTmdbUrl);
        }
        public async Task<GenreList.ResponseModel> AllGenres()
        {
            return await CallTmdbApi<GenreList.ResponseModel>(TMDbCoreConfiguration.GenreListTmdbUrl);
        }
        public async Task<CertificationList.ResponseModel> AllCertifications()
        {
            return await CallTmdbApi<CertificationList.ResponseModel>(TMDbCoreConfiguration.CertificationListTmdbUrl);
        }

        public async Task<IEnumerable<DiscoverMovies.ResponseModel>> AllMovies(int year)
        {
            TMDbCoreConfiguration.DiscoverMoviesSearchOptions options = new TMDbCoreConfiguration.DiscoverMoviesSearchOptions()
            {
                PageNumber = 1,
                Year = year
            };

            return await CallDiscoverMoviesTmdbApi(options);
        }

        public async Task<IEnumerable<DiscoverMovies.ResponseModel>> AllMovies(DateTime startDate, DateTime endDate)
        {
            TMDbCoreConfiguration.DiscoverMoviesSearchOptions options = new TMDbCoreConfiguration.DiscoverMoviesSearchOptions()
            {
                PageNumber = 1,
                StartDate = startDate,
                EndDate = endDate
            };

            return await CallDiscoverMoviesTmdbApi(options);
        }

        public async Task<MovieDetails.ResponseModel> MovieDetails(int id)
        {
            return await CallTmdbApi<MovieDetails.ResponseModel>(TMDbCoreConfiguration.MovieDetailsTmdbUrl(id));
        }
    }
}