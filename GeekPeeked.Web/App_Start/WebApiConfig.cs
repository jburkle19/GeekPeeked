using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json.Serialization;
using GeekPeeked.Web.App_Start;

namespace GeekPeeked.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
