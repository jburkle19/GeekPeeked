using GeekPeeked.Common.Configuration;

namespace GeekPeeked.Common.Repositories.TMDb
{
    public class BaseRepository
    {
        public string ApiKey = CoreConfiguration.TmdbApiKey;
    }
}