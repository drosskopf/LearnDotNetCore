using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace webapp
{
    public class MoviesService:IMoviesService
    {
        private string _url { get; set; }
        private ILogger _logger {get;set;}
        public MoviesService(ILogger<MoviesService> logger, IOptions<MoviesServiceOption> moviesServiceOption)
        {
            _logger = logger;
            _url = moviesServiceOption.Value.Url;
        }

        public async Task<Movie> Get(string id)
        {
            _logger.LogDebug($"Lazy Movie Id:{id}");
            _logger.LogError("Movie Id:{id}",id);
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{_url}?i={id}");
                return JsonConvert.DeserializeObject<Movie>(response);
            }
        }
    }
}