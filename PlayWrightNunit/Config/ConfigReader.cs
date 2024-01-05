using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MagentoFrameworkCore.Config
{
    public static class ConfigReader
    {
        public static TestSettings ReadConfig()
        {
            var appsettingsLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appSettings.json";

            var configFile = File.ReadAllText(appsettingsLocation);

            var jsonSerializerSettins = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            jsonSerializerSettins.Converters.Add(new JsonStringEnumConverter());
            return JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerSettins);


        }
    }
}
