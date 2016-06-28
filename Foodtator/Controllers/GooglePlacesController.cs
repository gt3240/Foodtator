using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpSharp;

namespace Foodtator.Controllers
{
    [RoutePrefix("GooglePlaces")]
    public class GooglePlacesController : Controller
    {
        // GET: GooglePlaces
        [Route("")]
        public ActionResult Restaurants()
        {
            return View();
        }
        
    }
}