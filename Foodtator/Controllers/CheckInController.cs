using Foodtator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("checkin")]
    public class CheckInController : BaseController
    {
        // GET: CheckIn
        public ActionResult Index()
        {
            CheckInViewModel vm = new CheckInViewModel();

            return View(vm);
        }
    }
}