using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GeekPeeked.Common.Configuration;
using GenreList = GeekPeeked.Common.Models.TMDb.Response.GenreList;
using ImdbDetails = GeekPeeked.Common.Models.TMDb.Response.ImdbDetails;
using MovieDetails = GeekPeeked.Common.Models.TMDb.Response.MovieDetails;
using PersonDetails = GeekPeeked.Common.Models.TMDb.Response.PersonDetails;
using DiscoverMovies = GeekPeeked.Common.Models.TMDb.Response.DiscoverMovies;
using CertificationList = GeekPeeked.Common.Models.TMDb.Response.CertificationList;

namespace GeekPeeked.Common.TMDb.Repositories
{
    public class TmdbRepository : ITmdbRepository
    {
        private static string TMDbApiKey = TMDbCoreConfiguration.TmdbApiKey;

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
                await Task.Delay(251); // added delay in order to not violate the TMDb limit of 40 requests / 10 seconds (4 requests per 1 second == 1 request per 250 milliseconds)

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

        public async Task<ImdbDetails.ResponseModel> MovieDetailsByImdbId(string imdbId)
        {
            return await CallTmdbApi<ImdbDetails.ResponseModel>(TMDbCoreConfiguration.FindImdbObjectTmdbUrl(imdbId));
        }

        public async Task<PersonDetails.ResponseModel> PersonDetails(int personId)
        {
            return await CallTmdbApi<PersonDetails.ResponseModel>(TMDbCoreConfiguration.PersonDetailsTmdbUrl(personId));
        }
    }
}