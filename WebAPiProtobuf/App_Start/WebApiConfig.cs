using System.Net.Http.Headers;
using System.Web.Http;
using Model;
using WebApiContrib.Formatting;

namespace WebAPiProtobuf
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new ProtoBufFormatter());
            ProtoBufFormatter.Model.Add(typeof(Film), true);
            ProtoBufFormatter.Model.Add(typeof(DevelopingTime), true);
            ProtoBufFormatter.Model.CompileInPlace();
            
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
