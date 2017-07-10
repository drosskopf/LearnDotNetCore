using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace webapp{
    [Route("/api/child")]
    public class ChildController:Controller{
        private IChildrenService _childrenService {get;set;}
        
        public ChildController(IChildrenService childrenService){
            _childrenService = childrenService;
        }
        [HttpGet()]
        public async Task<IEnumerable<Child>> Get(){
            return await _childrenService.Get();
        }
        [HttpGet("{id:int}")]
        public Child Get(int id){

            return _childrenService.Get(id);
        }
        [HttpPost()]
        [Produces("application/json",Type=typeof(Child))]
        public IActionResult Create([FromBody] Child child){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            child = _childrenService.Create(child);
           return CreatedAtAction("Get",new {id=child.Id},child);
        }
    }
}

