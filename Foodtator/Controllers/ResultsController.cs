using Foodtator.Domain;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using YelpSharp;

using YelpSharp.Data;

using YelpSharp.Data.Options;



namespace Foodtator.Controllers

{

    [RoutePrefix("{Results}")]

    public class ResultsController : Controller

    {

        // GET: Results

        public ActionResult Index()

        {

            return View();

        }

        [Route("{location}")]
        public ActionResult Results(string location)
        {
            Yelp yelp = new Yelp(Config.Options);

            var searchOptions = new SearchOptions();

            searchOptions.GeneralOptions = new GeneralOptions()
            {

                term = "Restaurant",

                offset = 19

            };

            searchOptions.LocationOptions = new LocationOptions()
            {

                location = location

            };

            var results = yelp.Search(searchOptions).Result;

            List<Business> resultsList = new List<Business>();

            for (int i = 0; i <= results.businesses.Count(); i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    resultsList.Add(results.businesses[j]);
                }

                System.Diagnostics.Debug.WriteLine(results);

            }

            foreach (var business in resultsList)
            {
                if (business.image_url != null)
                {
                    String s = business.image_url;

                    s = s.Replace("/ms.jpg", "/o.jpg");

                    business.image_url = s;

                }

            }
            results.businesses = resultsList;



            return View(results);

        }

    }

}