using Sabio.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpSharp;

namespace Foodtator.Controllers
{
    public class BusinessController:BaseController
    {
        public ActionResult Details(string id)
        {
            Yelp y = new Yelp(Config.Options);
            var result = y.GetBusiness(id).Result;
            return View(result);
        }
    }
}