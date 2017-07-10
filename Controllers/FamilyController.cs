using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace webapp{
    [Route("api/family")]
    public class FamilyController{
        private IFamilyService _familyService {get;set;}
        public FamilyController(IFamilyService familyService){
                _familyService = familyService;
        }
        [HttpGet]
        public IEnumerable<Family> Get(){
             return _familyService.Get();
        }
        [HttpGet("{id}")]
        public Family Get(int id){
             return _familyService.Get(id);
        }
        [HttpPost]
        public Family Add([FromBody]Family family)
        {
            return _familyService.Add(family);
        }
    }
}