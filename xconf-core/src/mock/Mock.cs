using System.Collections.Generic;
using xconf_core.model;

namespace xconf_core.mock
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