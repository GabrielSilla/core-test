using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MyNextGame.Configuration
{
    public class ConfigReader
    {
        IConfiguration configuration;
        public ConfigReader(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Models.Config getConfig()
        {
            String rootPath = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
            var path = Path.Combine(Directory.GetParent(rootPath).Parent.Parent.FullName, "Configuration\\config.json");

            try {
                return JsonConvert.DeserializeObject<Models.Config>(File.ReadAllText(path));
            } catch (Exception e) {
                throw new Exception("Could not deserialize json to object", e);
            }
        }
    }
}
