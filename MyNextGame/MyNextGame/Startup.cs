using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyNextGame.Configuration;
using MyNextGame.Services;
using System;
using System.Xml;

namespace MyNextGame
{
    class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;    
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigReader configReader = new ConfigReader(configuration);
            services.Add(new ServiceDescriptor(typeof(GameService), new GameService(configReader.getConfig())));

            services.AddMvcCore(options => {
                options.RespectBrowserAcceptHeader = true;
                options.EnableEndpointRouting = false;
            }).AddNewtonsoftJson().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            /*services.AddMvcCore(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.EnableEndpointRouting = false;
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter(new XmlWriterSettings
                {
                    OmitXmlDeclaration = false
                }));
            }).AddXmlSerializerFormatters();*/
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
