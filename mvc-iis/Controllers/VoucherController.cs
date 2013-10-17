using System.Web.Mvc;
using xconf_core.mock;

namespace mvc_iis.Controllers
{
    public class VoucherController : Controller
    {
        public ActionResult Index(int storeNumber)
        {
            return View(Mock.Vouchers(storeNumber));
        }


        public JsonResult Json(int storeNumber)
        {
            return Json(Mock.Vouchers(storeNumber), JsonRequestBehavior.AllowGet);
        }

    }
}
