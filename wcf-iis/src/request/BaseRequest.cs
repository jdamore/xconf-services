
using System.Web.Script.Serialization;

namespace wcf_iis.request
{
    public class BaseRequest
    {
        public string Country       { get; set; }
        public string Language      { get; set; }
        public string Application   { get; set; }
        public string Version       { get; set; }

        public string ToString()
        {
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}