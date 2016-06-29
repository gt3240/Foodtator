using Foodtator.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;



namespace Foodtator.Controllers

{

    [RoutePrefix("Results")]
    public class ResultsController : Controller
    {
        // GET: Results

        public ActionResult Index()
        {

            return View();

        }

        [Route("location/{location}")]
        public ActionResult Results(string location)
        {
            SearchResults results = null;
            int offset = 0;
            Yelp yelp = new Yelp(Config.Options);
            var searchOptions = new SearchOptions();
            List<Business> resultsList = new List<Business>();
            searchOptions.GeneralOptions = new GeneralOptions()
            {
                term = "Restaurant",
                offset = offset
            };
            searchOptions.LocationOptions = new LocationOptions()
            {
                location = location
            };
            for (int x = 0; x <= 3; x++)
            {
                searchOptions.GeneralOptions = new GeneralOptions()
                {
                    term = "Restaurant",
                    offset = offset
                };
                results = yelp.Search(searchOptions).Result;
                offset += 25;
                Random rnd = new Random();
                int rndBusiness = rnd.Next(1, results.businesses.Count());
                resultsList.Add(results.businesses[rndBusiness]);
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
            for (int i = 0; i < resultsList.Count(); i++)
            {
                System.Diagnostics.Debug.WriteLine(results.businesses[i].name);
            }
         
            return View(results);

        }
        
        public async System.Threading.Tasks.Task<ActionResult> GoogleResults(string Userlocation)
        {
            PlacesApiQueryResponse result = null;
            using (var client = new HttpClient())
            {
                var response = await client.
                    GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?query=restaurants+in+" + Userlocation + "&key=AIzaSyDFkdz1Hnu4Ob2B5kal_Jl-T8a7NecU8Bw"));
                result = JsonConvert.DeserializeObject<PlacesApiQueryResponse>(response);
                System.Diagnostics.Debug.WriteLine(result.results[0].photos[0].photo_reference);
            }
            return View(result);
        }

    }

}