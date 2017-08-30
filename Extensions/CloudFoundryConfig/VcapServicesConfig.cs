using System.Collections.Generic;
using Newtonsoft.Json;

namespace webapp
{
    public class VcapServicesConfig
    {
        [JsonProperty("user-provided")]
        public List<VcapServicesEntry> UserProvided { get; set; }
    }
}
