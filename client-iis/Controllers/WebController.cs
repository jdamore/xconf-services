
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace client_iis.Controllers
{
    public class WebController : Controller
    {
        public class ViewModel
        {
            public string Url           { get; set; }
            public string Query         { get; set; }
            public string WebMethod     { get; set; }
            public string Response      { get; set; }
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(new ViewModel());
        }

        [HttpPost]
        public ViewResult Submit(ViewModel model)
        {
            model.Response = Curl(model.Url, model.Query, model.WebMethod);
            return View("Index", model);
        }

        private string Curl(string url, string query = null, string webMethod = "GET")
        {
            var request             = (HttpWebRequest)WebRequest.Create(url);
            request.Method          = webMethod;
            if (webMethod != "GET")
            {
                request.ContentType = "application/x-www-form-urlencoded";
                using (var stOut = new StreamWriter(request.GetRequestStream(), Encoding.ASCII))
                {
                    if (query != null) stOut.Write(query);
                    stOut.Close();
                }
            }

            using (var response = request.GetResponse().GetResponseStream())
            {
                if (response != null)
                {
                    using (var stIn = new StreamReader(response))
                    {
                        return stIn.ReadToEnd();
                    }
                }
            }

            return "No Response";
        }

    }
}
