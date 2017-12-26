using FiboApp.Configuration;
using FiboApp.DependencyInjection;
using Swashbuckle.Application;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace FiboApp
{
    /// <summary>
    /// WebApiConfig.
    /// </summary>
    public static class WebApiConfig
    {

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Fibonacci Assessment",
                routeTemplate: string.Empty,
                defaults: null,
                constraints: null,
                handler: new RedirectHandler(message => message.RequestUri.ToString().TrimEnd('/'), "FrontPage_Sources/index.html"));


            config.Services.Replace(typeof(IHttpControllerActivator), new CustomHttpControllerActivator());


            // Configure web api to only accept an serve json
            JsonMediaTypeFormatter jsonMediaTypeFormatter = new JsonMediaTypeFormatter();
            var jsonSettings = jsonMediaTypeFormatter.SerializerSettings;
            jsonSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            jsonSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;
            jsonSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            config.Formatters.Clear();
            config.Formatters.Add(jsonMediaTypeFormatter);
            SwaggerConfig.Register(config);
        }
    }
}
