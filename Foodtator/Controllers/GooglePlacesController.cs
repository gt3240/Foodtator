using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpSharp;

namespace Foodtator.Controllers
{
    public class GooglePlacesController : Controller
    {
        // GET: GooglePlaces
        public ActionResult Restaurants()
        {
            return View();
        }
        
    }
}