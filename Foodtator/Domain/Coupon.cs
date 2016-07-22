using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CouponCode { get; set; }
        public string Locations { get; set; }
        public string Discounts { get; set; }
        public string Description { get; set; }
        public DateTime Activation { get; set; }
        public DateTime Expires { get; set; }
        public int MaxRedemptions { get; set; }
    }
}