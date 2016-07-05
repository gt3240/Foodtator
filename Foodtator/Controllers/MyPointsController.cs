using Foodtator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    public class MyPointsController : BaseController
    {
        // GET: MyPoints
        public ActionResult Index()
        {
            CheckInViewModel vm = new CheckInViewModel();
            return View(vm);
        }
    }
}