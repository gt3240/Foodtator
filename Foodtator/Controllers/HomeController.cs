using Foodtator.Models.RequestModel;
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
    
    public class HomeController : Controller
    {
     
        public ActionResult Index(BusinessSearchRequestModel model)
        {
            Yelp yelp = new Yelp(Config.Options);
            var results = yelp.Search("Restaurant","Seattle").Result;
            List<Business> resultsList = new List<Business>();
            System.Diagnostics.Debug.WriteLine(results.businesses);
            foreach (var result in results.businesses)
            {
                String s = result.image_url;
                s = s.Replace("/ms.jpg", "/o.jpg");
                result.image_url = s;

            }

            Random array = new Random();
            var num = UtilityService.NextNumber(array);
            for(int i = 1; i < results.businesses.Count; i++)
            {
                resultsList.Add(results.businesses[num]);
            }
            
         

            results.businesses = resultsList;
            
            return View(results);
            
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
        public ActionResult Results(BusinessSearchRequestModel model)
        {
            Yelp yelp = new Yelp(Config.Options);
            var results = yelp.Search("Restaurant", "Seattle").Result;
            List<Business> resultsList = new List<Business>();
            System.Diagnostics.Debug.WriteLine(results.businesses);
            foreach (var result in results.businesses)
            {
                String s = result.image_url;
                s = s.Replace("/ms.jpg", "/o.jpg");
                result.image_url = s;

            }

            //Random array = new Random();
            //var num = UtilityService.NextNumber(array);
          
            //    resultsList.Add(results.businesses[num]);
      
            //results.businesses = resultsList;

            return View(results);
        }

        public ActionResult PageSample()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



    }
}