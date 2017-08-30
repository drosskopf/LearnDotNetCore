using Newtonsoft.Json.Linq;

namespace Lds.Mvc.Extensions.CloudFoundryConfig
{
    public class VcapServicesEntry
    {
        public string Name { get; set; }

        public JObject Credentials { get; set; }
    }
}
