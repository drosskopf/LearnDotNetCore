using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace webapp
{
    //// SourceRef: https://github.com/SteeltoeOSS/Configuration

    public class JsonStreamConfigurationSource : JsonConfigurationSource
    {
        private MemoryStream _stream;

        internal JsonStreamConfigurationSource(MemoryStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            _stream = stream;
        }
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new JsonStreamConfigurationProvider(this, _stream);
        }
    }
}
