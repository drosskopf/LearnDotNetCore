using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace webapp
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCloudFoundryStartup(this IConfigurationBuilder builder, IHostingEnvironment environment)
        {
            return builder
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddCloudFoundryVcapService();
        }

        public static IConfigurationBuilder AddCloudFoundryHost(this IConfigurationBuilder builder, string[] args)
        {
            return builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .AddJsonFile("hosting.json", optional: true)
                .AddCommandLine(args);
        }

        public static IConfigurationBuilder AddCloudFoundryVcapService(this IConfigurationBuilder builder)
        {
            var vcapConfig = new ConfigurationBuilder()
                .AddEnvironmentVariables("VCAP_")
                .Build();

            var section = vcapConfig["SERVICES"];
            if (!string.IsNullOrWhiteSpace(section))
            {
                var servicesConfig = JsonConvert.DeserializeObject<VcapServicesConfig>(section);
                var mergedConfig = MergeVcapServicesCredentials(servicesConfig);
                var servicesJson = JsonConvert.SerializeObject(mergedConfig);
                var memoryStream = GetMemoryStream(servicesJson);
                var configurationSource = new JsonStreamConfigurationSource(memoryStream);
                builder.Add(configurationSource);
            }

            return builder;
        }

        private static JObject MergeVcapServicesCredentials(VcapServicesConfig servicesConfig)
        {
            var settings = new JObject();
            if (servicesConfig?.UserProvided != null)
            {
                servicesConfig.UserProvided.ForEach(entry => AddUserProvidedSettings(settings, entry));
            }

            return settings;
        }

        //// SourceRef: https://github.com/SteeltoeOSS/Configuration

        private static MemoryStream GetMemoryStream(string json)
        {
            var memStream = new MemoryStream();
            var textWriter = new StreamWriter(memStream);
            textWriter.Write(json);
            textWriter.Flush();
            memStream.Seek(0, SeekOrigin.Begin);
            return memStream;
        }

        private static void AddUserProvidedSettings(JObject settings, VcapServicesEntry entry)
        {
            foreach (var credential in entry.Credentials)
            {
                settings.Add(credential.Key, credential.Value);
            }
        }
    }
}
