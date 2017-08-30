using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lds.Mvc.Extensions.CloudFoundryConfig
{
    public class VcapServicesConfig
    {
        [JsonProperty("user-provided")]
        public List<VcapServicesEntry> UserProvided { get; set; }
    }
}
