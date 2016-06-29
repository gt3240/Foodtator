using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        // GET: User
        [Route("register")]
        public ActionResult Register()
        {
            return View();
        }

        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }
    }
}