using System;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections.Generic;
using GeekPeeked.Common.Configuration;
using GeekPeeked.Common.Models.LegacyGeekPeeked;

namespace GeekPeeked.Common.LegacyGeekPeeked.Repositories
{
    public class LegacyMovieRepository : BaseRepository, ILegacyMovieRepository
    {
        public ICollection<LegacyMovie> AllMovies()
        {
            List<LegacyMovie> result = new List<LegacyMovie>();

            try
            {
                using (SqlConnection conn = new SqlConnection(LegacyGeekPeekedConfiguration.LegacyGeekPeekedConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT MovieId, Title, ReleaseDate, IMDB FROM Movie";

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            result.Add(new LegacyMovie()
                            {
                                MovieId = Guid.Parse(dr["MovieId"].ToString()),
                                Title = dr["Title"].ToString(),
                                ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"].ToString()),
                                ImdbUrl = dr["IMDB"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return result;
        }
    }
}
