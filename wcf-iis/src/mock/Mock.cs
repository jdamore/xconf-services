using System.Collections.Generic;

using wcf_iis.model;

namespace wcf_iis.mock
{
    public class Mock
    {
        public static List<Voucher> Vouchers(int storeNumber)
        {
            var theVouchers = new List<Voucher>
                {
                    new Voucher
                        {
                            Code = "ABCD",
                            Title = "The Best Voucher In Ze World",
                            Description = "Really??",
                            Image = "http://animage.png"
                        },

                    new Voucher
                        {
                            Code = "EFGH",
                            Title = "The Second Best Voucher In Ze World",
                            Description = "Yeah Sure!",
                            Image = "http://animage2.png"
                        }
                };
            return theVouchers;
        }

    }
}