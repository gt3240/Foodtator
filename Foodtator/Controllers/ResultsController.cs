using Foodtator.Domain;
using Foodtator.Interfaces;
using Newtonsoft.Json;
using Foodtator.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using YelpSharp;
using YelpSharp.Data;
using YelpSharp.Data.Options;
using Foodtator.Services;
using Microsoft.Practices.Unity;

namespace Foodtator.Controllers
{
    [RoutePrefix("Results")]
    public class ResultsController : BaseController
    {
        [Dependency]
        public IResultsService _ResultsService { get; set; }


        public ActionResult Index()
        {

            return View();

        }


        //Yelp Results controller 
        [Route("location/{location}")]
        public ActionResult Results(string location)
        {
            SearchResults results = _ResultsService.Results(location);
            return View(results);
        }


        //Google results function, not used yet but if we decide to use google places as well this is ready to go. 
        public async System.Threading.Tasks.Task<ActionResult> GoogleResults(string Userlocation)
        {
            PlacesApiQueryResponse result = null;
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(string.Format("https://maps.googleapis.com/maps/api/place/textsearch/json?query=restaurants+in+" + Userlocation + "&key=AIzaSyDFkdz1Hnu4Ob2B5kal_Jl-T8a7NecU8Bw"));
                result = JsonConvert.DeserializeObject<PlacesApiQueryResponse>(response);

                System.Diagnostics.Debug.WriteLine(result.results[0].photos[0].photo_reference);
            }
            return View(result);
        }

    }

}