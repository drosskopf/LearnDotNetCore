using System.Collections.Generic;
using System.Threading.Tasks;

namespace webapp
{

    public interface IChildrenService
    {
        Task<IList<Child>> Get();
        Child Get(int id);
        Child Create(Child child);
    }
}