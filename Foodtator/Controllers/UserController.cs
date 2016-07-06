using Foodtator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        // GET: User
        [Route("register")]
        public ActionResult Register()
        {
            BaseViewModel vm = new BaseViewModel();
            return View();
        }

        [Route("login")]
        public ActionResult Login()
        {
            BaseViewModel vm = new BaseViewModel();
            return View();
        }
    }
}