﻿using System;
using System.Configuration;
using System.Collections.Generic;

namespace GeekPeeked.Common.Configuration
{
    public class CoreConfiguration
    {
        public static string SQLConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
                    return ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                else
                    return string.Empty;
            }
        }

        public static string MailSentFromName
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpSentFromName"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpSentFromName"].ToString()))
                    return ConfigurationManager.AppSettings["smtpSentFromName"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailSentFromAddress
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpSentFrom"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpSentFrom"].ToString()))
                    return ConfigurationManager.AppSettings["smtpSentFrom"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailUserName
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpUserName"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpUserName"].ToString()))
                    return ConfigurationManager.AppSettings["smtpUserName"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailPassword
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpPassword"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpPassword"].ToString()))
                    return ConfigurationManager.AppSettings["smtpPassword"].ToString();
                else
                    return string.Empty;
            }
        }
        public static string MailServer
        {
            get
            {
                if (ConfigurationManager.AppSettings["smtpServer"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpServer"].ToString()))
                    return ConfigurationManager.AppSettings["smtpServer"].ToString();
                else
                    return string.Empty;
            }
        }
        public static int MailPort
        {
            get
            {
                int result = 0; // default value

                int.TryParse(ConfigurationManager.AppSettings["smtpPort"].ToString(), out result);

                return result;
            }
        }
        public static bool MailTLS
        {
            get
            {
                bool result = false; // default value

                if (ConfigurationManager.AppSettings["smtpTLS"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["smtpTLS"].ToString()))
                    bool.TryParse(ConfigurationManager.AppSettings["smtpTLS"].ToString(), out result);

                return result;
            }
        }

        public static string SeedAdminPassword
        {
            get
            {
                if (ConfigurationManager.AppSettings["SeedAdminPassword"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["SeedAdminPassword"].ToString()))
                    return ConfigurationManager.AppSettings["SeedAdminPassword"].ToString();
                else
                    return string.Empty;
            }
        }
    }

    public class TMDbCoreConfiguration
    {
        public static string TmdbApiKey
        {
            get
            {
                if (ConfigurationManager.AppSettings["TmdbApiKey"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TmdbApiKey"].ToString()))
                    return ConfigurationManager.AppSettings["TmdbApiKey"].ToString();
                else
                    return string.Empty;
            }
        }

        public static string TmdbBaseUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["TmdbBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TmdbBaseUrl"].ToString()))
                    return string.Format(ConfigurationManager.AppSettings["TmdbBaseUrl"].ToString());
                else
                    return string.Empty;
            }
        }

        public static string ImageTmdbUrlFormatString(string imagePath)
        {
            if (ConfigurationManager.AppSettings["ImageTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ImageTmdbUrlFormatString"].ToString()))
                return string.Format(ConfigurationManager.AppSettings["ImageTmdbUrlFormatString"].ToString(), imagePath);
            else
                return string.Empty;
        }

        public static string JobListTmdbUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["JobListTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["JobListTmdbUrlFormatString"].ToString()))
                    return string.Format(ConfigurationManager.AppSettings["JobListTmdbUrlFormatString"].ToString(), TmdbApiKey);
                else
                    return string.Empty;
            }
        }
        public static string GenreListTmdbUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["GenreListTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["GenreListTmdbUrlFormatString"].ToString()))
                    return string.Format(ConfigurationManager.AppSettings["GenreListTmdbUrlFormatString"].ToString(), TmdbApiKey);
                else
                    return string.Empty;
            }
        }
        public static string CertificationListTmdbUrl
        {
            get
            {
                if (ConfigurationManager.AppSettings["CertificationListTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["CertificationListTmdbUrlFormatString"].ToString()))
                    return string.Format(ConfigurationManager.AppSettings["CertificationListTmdbUrlFormatString"].ToString(), TmdbApiKey);
                else
                    return string.Empty;
            }
        }

        public static string PersonDetailsTmdbUrl(int personId)
        {
            if (ConfigurationManager.AppSettings["PersonDetailsTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["PersonDetailsTmdbUrlFormatString"].ToString()))
                return string.Format("{0}&append_to_response=movie_credits,external_ids,images", string.Format(ConfigurationManager.AppSettings["PersonDetailsTmdbUrlFormatString"].ToString(), TmdbApiKey, personId));
            else
                return string.Empty;
        }
        public static string MovieDetailsTmdbUrl(int tmdbMovieId)
        {
            if (ConfigurationManager.AppSettings["MovieDetailsTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MovieDetailsTmdbUrlFormatString"].ToString()))
                return string.Format("{0}&append_to_response=credits,images,keywords,release_dates,videos", string.Format(ConfigurationManager.AppSettings["MovieDetailsTmdbUrlFormatString"].ToString(), TmdbApiKey, tmdbMovieId));
            else
                return string.Empty;
        }
        public static string FindImdbObjectTmdbUrl(string imdbObjectId)
        {
            if (ConfigurationManager.AppSettings["FindImdbObjectTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["FindImdbObjectTmdbUrlFormatString"].ToString()))
                return string.Format("{0}&external_source=imdb_id", string.Format(ConfigurationManager.AppSettings["FindImdbObjectTmdbUrlFormatString"].ToString(), TmdbApiKey, imdbObjectId));
            else
                return string.Empty;
        }

        public class DiscoverMoviesSearchOptions
        {
            #region DiscoverMovies Url Options

            public int PageNumber { get; set; }
            public int? Year { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public List<int> GenreIds { get; set; }
            public List<int> PeopleIds { get; set; }
            public List<int> ProductionCompanyIds { get; set; }
            public List<int> KeywordIds { get; set; }
            public int? ExactCertificationId { get; set; }
            public int? GTE_CertificationId { get; set; }
            public int? LTE_CertificationId { get; set; }

            #endregion DiscoverMovies Url Options

            public DiscoverMoviesSearchOptions()
            {
                PageNumber = 1;
                Year = null;
                StartDate = null;
                EndDate = null;
                GenreIds = new List<int>();
                PeopleIds = new List<int>();
                ProductionCompanyIds = new List<int>();
                KeywordIds = new List<int>();
                ExactCertificationId = null;
                GTE_CertificationId = null;
                LTE_CertificationId = null;
            }

            public string DiscoverMoviesTmdbUrl
            {
                get
                {
                    string url = string.Empty;

                    if (ConfigurationManager.AppSettings["DiscoverMoviesTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["DiscoverMoviesTmdbUrlFormatString"].ToString()))
                    {
                        url = string.Format(ConfigurationManager.AppSettings["DiscoverMoviesTmdbUrlFormatString"].ToString(), TmdbApiKey);

                        if (PageNumber > 0)
                            url += string.Format("&page={0}", PageNumber);
                        else
                            url += string.Format("&page=1"); // defaults to 1

                        #region Optional Filters

                        if (Year != null && Convert.ToInt32(Year) > 0)
                            url += string.Format("&year={0}", Year);
                        if (StartDate != null)
                            url += string.Format("&primary_release_date.gte={0}", Convert.ToDateTime(StartDate).ToString("yyyy-MM-dd"));
                        if (EndDate != null)
                            url += string.Format("&primary_release_date.lte={0}", Convert.ToDateTime(EndDate).ToString("yyyy-MM-dd"));
                        if (GenreIds.Count > 0)
                            url += string.Format("&with_genres={0}", string.Join(",", GenreIds));
                        if (PeopleIds.Count > 0)
                            url += string.Format("&with_people={0}", string.Join(",", PeopleIds));
                        if (ProductionCompanyIds.Count > 0)
                            url += string.Format("&with_companies={0}", string.Join(",", ProductionCompanyIds));
                        if (KeywordIds.Count > 0)
                            url += string.Format("&with_keywords={0}", string.Join(",", KeywordIds));
                        if (ExactCertificationId != null)
                            url += string.Format("&certification_country=US&certification={0}", ExactCertificationId);
                        if (GTE_CertificationId != null)
                            url += string.Format("&certification_country=US&certification.gte={0}", GTE_CertificationId);
                        if (LTE_CertificationId != null)
                            url += string.Format("&certification_country=US&certification.lte={0}", LTE_CertificationId);

                        #endregion Optional Filters
                    }

                    return url;
                }
            }
        }
    }

    public class LegacyGeekPeekedConfiguration
    {
        public static string LegacyGeekPeekedConnectionString
        {
            get
            {
                if (ConfigurationManager.ConnectionStrings["LegacyGeekPeekedDdConnection"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings["LegacyGeekPeekedDdConnection"].ToString()))
                    return ConfigurationManager.ConnectionStrings["LegacyGeekPeekedDdConnection"].ToString();
                else
                    return string.Empty;
            }
        }
    }
}
