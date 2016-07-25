using Foodtator.Models.RequestModel;
using Foodtator.Models.ViewModels;
using Foodtator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpSharp;
using YelpSharp.Data;


namespace Foodtator.Controllers
{

    public class HomeController : BaseController
    {

        public ActionResult Index(BusinessSearchRequestModel model)
        {

            BaseViewModel vm = new BaseViewModel();
            return View(vm);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("test")]
        public ActionResult PageSample()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}