using System.Configuration;

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

        public static string ImageTmdbUrlFormatString(string imagePath)
        {
            if (ConfigurationManager.AppSettings["ImageTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ImageTmdbUrlFormatString"].ToString()))
                return string.Format(ConfigurationManager.AppSettings["ImageTmdbUrlFormatString"].ToString(), imagePath);
            else
                return string.Empty;
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

        public static string PersonDetailsTmdbUrl(string personId)
        {
            if (ConfigurationManager.AppSettings["PersonDetailsTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["PersonDetailsTmdbUrlFormatString"].ToString()))
                return string.Format("{0}&append_to_response=movie_credits,external_ids,images", string.Format(ConfigurationManager.AppSettings["PersonDetailsTmdbUrlFormatString"].ToString(), TmdbApiKey, personId));
            else
                return string.Empty;
        }
        public static string DiscoverMovieTmdbUrl(int pageNumber)
        {
            if (ConfigurationManager.AppSettings["DiscoverMovieTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["DiscoverMovieTmdbUrlFormatString"].ToString()))
                return string.Format(ConfigurationManager.AppSettings["DiscoverMovieTmdbUrlFormatString"].ToString(), TmdbApiKey, pageNumber);
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
        public static string MovieDetailsTmdbUrl(string tmdbMovieId)
        {
            if (ConfigurationManager.AppSettings["MovieDetailsTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MovieDetailsTmdbUrlFormatString"].ToString()))
                return string.Format("{0}&append_to_response=credits,images,keywords,release_dates,videos,similar", string.Format(ConfigurationManager.AppSettings["MovieDetailsTmdbUrlFormatString"].ToString(), TmdbApiKey, tmdbMovieId));
            else
                return string.Empty;
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
