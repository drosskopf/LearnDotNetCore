using System.Threading.Tasks;

namespace webapp{
    public interface IMoviesService{
        Task<Movie> Get(string id);
    }
}