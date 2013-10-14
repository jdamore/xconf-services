using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using wcf_iis.mock;
using wcf_iis.model;
using wcf_iis.request;

namespace wcf_iis
{
    [ServiceContract]
    public interface IVoucherService
    {
        [OperationContract]
        List<Voucher> Vouchers(VouchersRequest request);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            ResponseFormat = WebMessageFormat.Xml,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{storeNumber}")]
        List<Voucher> VouchersXml(string storeNumber);

        [OperationContract]
        [WebInvoke(
            Method          = "GET",
            ResponseFormat  = WebMessageFormat.Json,
            BodyStyle       = WebMessageBodyStyle.Wrapped,
            UriTemplate     = "json/{storeNumber}")]
        List<Voucher> VouchersJson(string storeNumber);
    }

    public class VoucherService : IVoucherService
    {
        public List<Voucher> Vouchers(VouchersRequest request)
        {
            return Mock.Vouchers(Convert.ToInt32(request.StoreNumber));
        }
        public List<Voucher> VouchersXml(string storeNumber)
        {
            return Mock.Vouchers(Convert.ToInt32(storeNumber));
        }
        public List<Voucher> VouchersJson(string storeNumber)
        {
            return Mock.Vouchers(Convert.ToInt32(storeNumber));
        }
    }

}
