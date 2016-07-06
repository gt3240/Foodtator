using Foodtator.Models.RequestModel;
using Foodtator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpSharp;

namespace Foodtator.Controllers
{
    [RoutePrefix("dashboard")]
    public class GooglePlacesController : BaseController
    {
        // GET: GooglePlaces
        [Route("")]
        public ActionResult dashboard()
        {
            BaseViewModel vm = new BaseViewModel(); 
            return View(vm);
        }

      

    }
}