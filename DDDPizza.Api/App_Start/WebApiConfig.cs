using System.Net.Http.Formatting;
using System.Web.Http;
using DDDPizza.Api.Formatters;
using Mindscape.Raygun4Net.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DDDPizza.Api
{



    public static class WebApiConfig
    {

      
        public static void Register(HttpConfiguration config)
        {

            RaygunWebApiClient.Attach(config);

            // Web API configuration and services

            var jsonFormatter = new JsonMediaTypeFormatter();
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));

            var settings = jsonFormatter.SerializerSettings;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = AutofacBootStrapper.AutofacWebApiDependencyResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
