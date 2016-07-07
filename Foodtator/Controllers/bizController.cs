using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("biz")]
    public class bizController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}