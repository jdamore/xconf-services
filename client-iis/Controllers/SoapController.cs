
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using wcf_iis;
using wcf_iis.request;
using Service = xconf_core.model.Service;

namespace client_iis.Controllers
{
    public class SoapController : Controller
    {
        public class ViewModel
        {
            public List<Service> Services { get; set; }
            public string SelectecServiceName { get; set; }
            public IEnumerable<SelectListItem> ServiceItems
            {
                get { return new SelectList(Services, "Name", "Url"); }
            }
            public object Response    { get; set; }
        }

        [HttpGet]
        public ViewResult Index()
        {
            var viewModel = new ViewModel();
            viewModel.Services = GetServices();
            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Submit(ViewModel model)
        {
            model.Services = GetServices();
            var service = model.Services.First(s => s.Name == model.SelectecServiceName);
            model.Response = GetResponse(service);
            return View("Index", model);
        }

        private static string GetResponse(Service service)
        {
            object response = null;
            switch (service.Name)
            {
                case "LocatorService":
                    response = GetService<ILocatorService>(service.Name, service.Url).Locations();
                    break;
                case "VoucherService":
                    response = GetService<IVoucherService>(service.Name, service.Url).Vouchers(new VouchersRequest { StoreNumber = 98001 });
                    break;
            }
            return ToString(response);
        }

        private static string ToString(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj);
        }

        private static List<Service> GetServices()
        {
            var locator = GetService<ILocatorService>(
                "LocatorService",
                "http://localhost:90/wcf-iis/LocatorService.svc/soap"
                );
            return new List<Service>(locator.Locations());
        }

        private static T GetService<T>(string serviceName, string serviceUrl)
        {
            var channel = new ChannelFactory<T>(serviceName, new EndpointAddress(serviceUrl));
            return channel.CreateChannel();
        }

    }
}
