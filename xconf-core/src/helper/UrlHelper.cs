
namespace xconf_core.helper
{
    public class UrlHelper
    {
        public static string BaseUrl
        {
            get
            {
                var port = System.Web.HttpContext.Current.Request.Url.Port;
                var host = System.Web.HttpContext.Current.Request.Url.Host;
                return "http://" + host + ":" + port + "/wcf-iis";
            }
        }

        public static string ServiceUrl(string service)
        {
            return BaseUrl + "/" + service + ".svc";
        }
    }
}