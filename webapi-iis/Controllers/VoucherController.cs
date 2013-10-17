using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using xconf_core.mock;
using xconf_core.model;

namespace webapi_iis.Controllers
{
    public class VoucherController : ApiController
    {
        // GET api/voucher
        public IEnumerable<Voucher> GetAll()
        {
            return Mock.Vouchers(98001);
        }

        // GET api/voucher/5
        public Voucher Get(string id)
        {
           return Mock.Vouchers(98001).SingleOrDefault(v=>v.Code==id);
        }

        // POST api/voucher
        public void Post([FromBody]string value)
        {
        }

        // PUT api/voucher/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/voucher/5
        public void Delete(int id)
        {
        }
    }
}