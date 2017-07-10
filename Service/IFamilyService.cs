using System.Collections.Generic;

namespace webapp{
    public interface IFamilyService{
         IEnumerable<Family> Get();
         Family Get(int id);
         Family Add(Family family);

    }
}