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

        //public static string TmdbImageBaseUrl
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["TmdbImageBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TmdbImageBaseUrl"].ToString()))
        //            return ConfigurationManager.AppSettings["TmdbImageBaseUrl"].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}
        //public static string TmdbGenreListBaseUrl
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["TmdbGenreListBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TmdbGenreListBaseUrl"].ToString()))
        //            return ConfigurationManager.AppSettings["TmdbGenreListBaseUrl"].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}
        //public static string TmdbCertificationListBaseUrl
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["TmdbCertificationListBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["TmdbCertificationListBaseUrl"].ToString()))
        //            return ConfigurationManager.AppSettings["TmdbCertificationListBaseUrl"].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}

        //public static string DiscoverMoviesTmdbBaseUrl
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["DiscoverMoviesTmdbBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["DiscoverMoviesTmdbBaseUrl"].ToString()))
        //            return ConfigurationManager.AppSettings["DiscoverMoviesTmdbBaseUrl"].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}
        //public static string UpcomingMoviesTmdbBaseUrl
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["UpcomingMoviesTmdbBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["UpcomingMoviesTmdbBaseUrl"].ToString()))
        //            return ConfigurationManager.AppSettings["UpcomingMoviesTmdbBaseUrl"].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}
        //public static string NowPlayingTmdbBaseUrl
        //{
        //    get
        //    {
        //        if (ConfigurationManager.AppSettings["NowPlayingTmdbBaseUrl"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["NowPlayingTmdbBaseUrl"].ToString()))
        //            return ConfigurationManager.AppSettings["NowPlayingTmdbBaseUrl"].ToString();
        //        else
        //            return string.Empty;
        //    }
        //}

        //public static string MovieDetailsTmdbBaseUrl(string movieId)
        //{
        //    if (ConfigurationManager.AppSettings["MovieDetailsTmdbBaseUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MovieDetailsTmdbBaseUrlFormatString"].ToString()))
        //        return string.Format(ConfigurationManager.AppSettings["MovieDetailsTmdbBaseUrlFormatString"].ToString(), movieId);
        //    else
        //        return string.Empty;
        //}

        /*

            public static string MovieVideosTmdbUrlFormatString
        {
            get
            {
                if (ConfigurationManager.AppSettings["MovieVideosTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MovieVideosTmdbUrlFormatString"].ToString()))
                    return ConfigurationManager.AppSettings["MovieVideosTmdbUrlFormatString"].ToString();
                else
                    return string.Empty;
            }
        }
            public static string MovieImagesTmdbUrlFormatString
        {
            get
            {
                if (ConfigurationManager.AppSettings["MovieImagesTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MovieImagesTmdbUrlFormatString"].ToString()))
                    return ConfigurationManager.AppSettings["MovieImagesTmdbUrlFormatString"].ToString();
                else
                    return string.Empty;
            }
        }
            public static string MovieCreditsTmdbUrlFormatString
        {
            get
            {
                if (ConfigurationManager.AppSettings["MovieCreditsTmdbUrlFormatString"] != null && !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["MovieCreditsTmdbUrlFormatString"].ToString()))
                    return ConfigurationManager.AppSettings["MovieCreditsTmdbUrlFormatString"].ToString();
                else
                    return string.Empty;
            }
        }
        */
    }
}
