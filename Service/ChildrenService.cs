using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapp
{
    public class ChildrenService:IChildrenService
    {
        private IList<Child> _children {get;set;}
        private IMoviesService _movieService {get;set;}
        public ChildrenService(IMoviesService movieService){
            _children =new List<Child>(){
                new Child(1,"Alex",15,"tt0080684"),
                new Child(2,"Brad",11,"tt0080685"),
                new Child(3,"Summer",10, "tt0080686"),
                new Child(4,"Jeremy",7, "tt0080687")
            }; 
            _movieService = movieService;
        }
        public async Task<IList<Child>> Get(){
            foreach(Child child in _children){
                child.FavoriteMovie  = await _movieService.Get(child.FavoriteMovieId);
            }
            
            return _children;
        }
        public Child Get(int id){
            return _children.Where(c=>c.Id ==id).First();
        }
        public Child Create(Child child){
            var nextId = _children.Max(c=>c.Id)+1;
            child.Id = nextId;
           _children.Add(child);
           return child;
        }

    }
}