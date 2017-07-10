using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace webapp{
    public class FamilyService:IFamilyService {
        private FamilyContext _familyContext {get;set;}
        public FamilyService(FamilyContext familyContext){
            _familyContext=familyContext;
        }
        public IEnumerable<Family> Get(){
            return _familyContext.Families;
        }
        public Family Get(int id){
            //return _familyContext.Families.Find(id);
            return _familyContext.Families.Include(f=>f.Children).Single(f=>f.Id==id);
        }

        public Family Add(Family family){
            _familyContext.Families.Add(family);
            _familyContext.SaveChanges();
            //return _familyContext.Families.Find(family);
            return family;
        }
        public Family Update(Family family){
            _familyContext.Families.Update(family);
            _familyContext.SaveChanges();
            return family;
        }
        public Family Remove(Family family){
            _familyContext.Families.Remove(family);
            return family;
        }
        public Family Remove(int id){
            _familyContext.Families.Remove(new Family{Id=id});
            return null;
        }
    }
}