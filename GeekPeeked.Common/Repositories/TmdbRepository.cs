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
using DiscoverMovie = GeekPeeked.Common.Models.TMDb.Response.DiscoverMovie;
using CertificationList = GeekPeeked.Common.Models.TMDb.Response.CertificationList;

namespace GeekPeeked.Common.Repositories
{
    public class TmdbRepository : BaseRepository, ITmdbRepository
    {
        private async Task<T> CallTmdbAPI<T>(string url)
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


        public async Task<JobList.ResponseModel> AllJobs()
        {
            return await CallTmdbAPI<JobList.ResponseModel>(TMDbCoreConfiguration.JobListTmdbUrl);
        }

        public async Task<GenreList.ResponseModel> AllGenres()
        {
            return await CallTmdbAPI<GenreList.ResponseModel>(TMDbCoreConfiguration.GenreListTmdbUrl);
        }

        //public async Task<IEnumerable<DiscoverMovie.ResponseModel>> AllMovies(int year)
        //{
        //    int totalPageCount = 1;
        //    int currentPageCount = 1;
        //    var result = new List<DiscoverMovie.ResponseModel>();

        //    while (currentPageCount <= totalPageCount)
        //    {
        //        await Task.Delay(300);

        //        try
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                client.BaseAddress = new Uri(CoreConfiguration.DiscoverMoviesTmdbBaseUrl);
        //                client.DefaultRequestHeaders.Accept.Clear();

        //                DateTime startDate = new DateTime(year, 01, 01);
        //                DateTime endDate = startDate.AddYears(1);
        //                string url = string.Format("{0}?api_key={1}&primary_release_date.gte={2}&primary_release_date.lt={3}&page={4}", CoreConfiguration.DiscoverMoviesTmdbBaseUrl, CoreConfiguration.TmdbApiKey, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), currentPageCount);

        //                var response = client.GetAsync(url).Result;

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                    if (!string.IsNullOrWhiteSpace(jsonResponse))
        //                    {
        //                        try
        //                        {
        //                            DiscoverMovie.ResponseModel responseModel = JToken.Parse(jsonResponse).ToObject<DiscoverMovie.ResponseModel>();
        //                            result.Add(responseModel);

        //                            totalPageCount = responseModel.total_pages;
        //                        }
        //                        catch (JsonSerializationException jsex)
        //                        {
        //                            Console.WriteLine(jsex.ToString());
        //                        }
        //                    }
        //                }
        //                else
        //                    Console.WriteLine(response.ReasonPhrase);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }

        //        currentPageCount++;
        //    }

        //    return result;
        //}
        //public async Task<IEnumerable<DiscoverMovie.ResponseModel>> AllMovies(DateTime startDate, DateTime endDate)
        //{
        //    int totalPageCount = 1;
        //    int currentPageCount = 1;
        //    var result = new List<DiscoverMovie.ResponseModel>();

        //    while (currentPageCount <= totalPageCount)
        //    {
        //        await Task.Delay(300);

        //        try
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                client.BaseAddress = new Uri(CoreConfiguration.DiscoverMoviesTmdbBaseUrl);
        //                client.DefaultRequestHeaders.Accept.Clear();

        //                string url = string.Format("{0}?api_key={1}&primary_release_date.gte={2}&primary_release_date.lte={3}&page={4}", CoreConfiguration.DiscoverMoviesTmdbBaseUrl, CoreConfiguration.TmdbApiKey, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"), currentPageCount);
        //                var response = client.GetAsync(url).Result;

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                    if (!string.IsNullOrWhiteSpace(jsonResponse))
        //                    {
        //                        try
        //                        {
        //                            DiscoverMovie.ResponseModel responseModel = JToken.Parse(jsonResponse).ToObject<DiscoverMovie.ResponseModel>();
        //                            result.Add(responseModel);

        //                            totalPageCount = responseModel.total_pages;
        //                        }
        //                        catch (JsonSerializationException jsex)
        //                        {
        //                            Console.WriteLine(jsex.ToString());
        //                        }
        //                    }
        //                }
        //                else
        //                    Console.WriteLine(response.ReasonPhrase);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }

        //        currentPageCount++;
        //    }

        //    return result;
        //}

        //public async Task<IEnumerable<Upcoming.ResponseModel>> AllUpcomingMovies()
        //{
        //    int totalPageCount = 1;
        //    int currentPageCount = 1;
        //    var result = new List<Upcoming.ResponseModel>();

        //    while (currentPageCount <= totalPageCount)
        //    {
        //        await Task.Delay(300);

        //        try
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                client.BaseAddress = new Uri(CoreConfiguration.UpcomingMoviesTmdbBaseUrl);
        //                client.DefaultRequestHeaders.Accept.Clear();

        //                var response = client.GetAsync(string.Format("{0}?api_key={1}&page={2}", CoreConfiguration.UpcomingMoviesTmdbBaseUrl, CoreConfiguration.TmdbApiKey, currentPageCount)).Result;

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                    if (!string.IsNullOrWhiteSpace(jsonResponse))
        //                    {
        //                        try
        //                        {
        //                            Upcoming.ResponseModel responseModel = JToken.Parse(jsonResponse).ToObject<Upcoming.ResponseModel>();
        //                            result.Add(responseModel);

        //                            totalPageCount = responseModel.total_pages;
        //                        }
        //                        catch (JsonSerializationException jsex)
        //                        {
        //                            Console.WriteLine(jsex.ToString());
        //                        }
        //                    }
        //                }
        //                else
        //                    Console.WriteLine(response.ReasonPhrase);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }

        //        currentPageCount++;
        //    }

        //    return result;
        //}
        //public async Task<IEnumerable<NowPlaying.ResponseModel>> AllNowPlayingMovies()
        //{
        //    int totalPageCount = 1;
        //    int currentPageCount = 1;
        //    var result = new List<NowPlaying.ResponseModel>();

        //    while (currentPageCount <= totalPageCount)
        //    {
        //        await Task.Delay(300);

        //        try
        //        {
        //            using (var client = new HttpClient())
        //            {
        //                client.BaseAddress = new Uri(CoreConfiguration.NowPlayingTmdbBaseUrl);
        //                client.DefaultRequestHeaders.Accept.Clear();

        //                var response = client.GetAsync(string.Format("{0}?api_key={1}&page={2}", CoreConfiguration.NowPlayingTmdbBaseUrl, CoreConfiguration.TmdbApiKey, currentPageCount)).Result;

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                    if (!string.IsNullOrWhiteSpace(jsonResponse))
        //                    {
        //                        try
        //                        {
        //                            NowPlaying.ResponseModel responseModel = JToken.Parse(jsonResponse).ToObject<NowPlaying.ResponseModel>();
        //                            result.Add(responseModel);

        //                            totalPageCount = responseModel.total_pages;
        //                        }
        //                        catch (JsonSerializationException jsex)
        //                        {
        //                            Console.WriteLine(jsex.ToString());
        //                        }
        //                    }
        //                }
        //                else
        //                    Console.WriteLine(response.ReasonPhrase);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.ToString());
        //        }

        //        currentPageCount++;
        //    }

        //    return result;
        //}

        //public async Task<Movie.ResponseModel> Find(string id)
        //{
        //    var result = new Movie.ResponseModel();

        //    await Task.Delay(1);

        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(CoreConfiguration.MovieDetailsTmdbBaseUrl(id));
        //            client.DefaultRequestHeaders.Accept.Clear();

        //            string url = string.Format("{0}?api_key={1}&append_to_response=videos,images,release_dates,credits", CoreConfiguration.MovieDetailsTmdbBaseUrl(id), CoreConfiguration.TmdbApiKey);
        //            var response = client.GetAsync(url).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                if (!string.IsNullOrWhiteSpace(jsonResponse))
        //                {
        //                    try
        //                    {
        //                        result = JToken.Parse(jsonResponse).ToObject<Movie.ResponseModel>();
        //                    }
        //                    catch (JsonSerializationException jsex)
        //                    {
        //                        Console.WriteLine(jsex.ToString());
        //                    }
        //                }
        //            }
        //            else
        //                Console.WriteLine(response.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //    return result;
        //}


        //public async Task<CertificationList.ResponseModel> AllCertifications()
        //{
        //    var result = new CertificationList.ResponseModel();

        //    await Task.Delay(1);

        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(CoreConfiguration.TmdbCertificationListBaseUrl);
        //            client.DefaultRequestHeaders.Accept.Clear();

        //            var response = client.GetAsync(string.Format("{0}?api_key={1}", CoreConfiguration.TmdbCertificationListBaseUrl, CoreConfiguration.TmdbApiKey)).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                if (!string.IsNullOrWhiteSpace(jsonResponse))
        //                {
        //                    try
        //                    {
        //                        result = JToken.Parse(jsonResponse).ToObject<CertificationList.ResponseModel>();
        //                    }
        //                    catch (JsonSerializationException jsex)
        //                    {
        //                        Console.WriteLine(jsex.ToString());
        //                    }
        //                }
        //            }
        //            else
        //                Console.WriteLine(response.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //    return result;
        //}
    }
}