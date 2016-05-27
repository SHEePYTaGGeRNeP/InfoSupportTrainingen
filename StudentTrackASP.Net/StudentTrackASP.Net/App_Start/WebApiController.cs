namespace StudentTrackASP.Net.App_Start
{
    using System.Web.Http;
    class WebApiController : ApiController
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                    );
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
