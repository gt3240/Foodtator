using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("checkin")]
    public class CheckInController : Controller
    {
        // GET: CheckIn
        public ActionResult Index()
        {
            return View();
        }
    }
}