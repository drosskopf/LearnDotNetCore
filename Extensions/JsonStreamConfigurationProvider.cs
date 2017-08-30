using System;
using System.IO;
using Microsoft.Extensions.Configuration.Json;

namespace webapp
{
    public class JsonStreamConfigurationProvider : JsonConfigurationProvider
    {
        //// SourceRef: https://github.com/SteeltoeOSS/Configuration

        MemoryStream _stream;
        internal JsonStreamConfigurationProvider(JsonConfigurationSource source, MemoryStream stream) : base(source)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            _stream = stream;
        }
        public override void Load()
        {
            base.Load(_stream);
        }
    }
}