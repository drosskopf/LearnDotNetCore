using System.Collections.Generic;

namespace webapp{
    public class Family
    {
        public int Id {get;set;}
        public string Dad {get;set;}
        public string Mom {get;set;}
        public IList<Child> Children {get;set;}
    }
}