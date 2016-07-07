using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    public class CouponController : Controller
    {
        // GET: Coupon
        public ActionResult CouponView()
        {
            return View();
        }
    }
}