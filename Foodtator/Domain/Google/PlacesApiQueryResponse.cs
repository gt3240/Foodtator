using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class PlacesApiQueryResponse
    {
        public List<object> html_attributions { get; set; }
        public List<GoogleApiResults> results { get; set; }
        public string status { get; set; }
    }
}