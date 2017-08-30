using Newtonsoft.Json.Linq;

namespace webapp
{
    public class VcapServicesEntry
    {
        public string Name { get; set; }

        public JObject Credentials { get; set; }
    }
}
