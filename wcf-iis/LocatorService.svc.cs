using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using xconf_core.helper;
using xconf_core.model;

namespace wcf_iis
{
    [ServiceContract]
    public interface ILocatorService
    {
        [OperationContract]
        [WebInvoke(
            Method          = "GET",
            ResponseFormat  = WebMessageFormat.Xml,
            BodyStyle       = WebMessageBodyStyle.Bare,
            UriTemplate     = "xml/")]
        List<Service> LocationsXml();

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "xml/{service}")]
        string LocationXml(string service);
    }

    public class LocatorService : ILocatorService
    {

        public List<Service> LocationsXml()
        {
            var serviceLocations = new List<Service>();
            foreach (var service in ConfigHelper.GetServices())
            {
                serviceLocations.Add(new Service
                    {
                        Name = service,
                        Url = UrlHelper.ServiceUrl(service)
                    });
            }
            return serviceLocations;
        }

        public string LocationXml(string serviceName)
        {
            var service = LocationsXml().FirstOrDefault(s => s.Name == serviceName);
            return (service == null) ? "Unknow service" : service.Url;
        }
    }
}
