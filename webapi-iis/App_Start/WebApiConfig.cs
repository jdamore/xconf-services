using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;

namespace webapi_iis
{
    public static class WebApiConfig
    {
        public static void Format(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "ApiGetWithId",      
                "Api/{controller}/{id}",        
                new { action = "Get" });
            
            config.Routes.MapHttpRoute(
                "ApiAction",  
                "Api/{controller}/{action}");
            
            config.Routes.MapHttpRoute(
                "ApiGet",         
                "Api/{controller}",             
                new { action = "GetAll" }, 
                new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            
            config.Routes.MapHttpRoute(
                "ApiPost",        
                "Api/{controller}",             
                new { action = "Post" },   
                new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
        }
    }
}
