using System.Web.Mvc;
using xconf_core.mock;

namespace mvc_iis.Controllers
{
    public class VoucherController : Controller
    {
        public ActionResult Index()
        {
            return View(Mock.Vouchers(123));
        }

    }
}
