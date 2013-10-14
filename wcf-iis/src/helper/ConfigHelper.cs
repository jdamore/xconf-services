using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml;

namespace wcf_iis.helper
{
    public class ConfigHelper
    {
        public static List<string> GetServices()
        {
            var config = new ConfigXmlDocument();
            config.Load(System.Web.HttpContext.Current.Server.MapPath("~/web.config"));
            var services = config.SelectNodes("configuration/system.serviceModel/services/service");
            return (from object service in services select (service as XmlElement).GetAttribute("name").Replace("wcf_iis.", "")).ToList();
        }
    }
}