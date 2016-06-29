using Foodtator.Domain.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YelpSharp.Data;

namespace Foodtator.Domain
{
    public class GoogleApiResults
    {
        public GoogleGeometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public List<GooglePhoto> photos { get; set; }
        public string place_id { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public string scope { get; set; }
        public List<string> types { get; set; }
        public string vicinity { get; set; }

    }
}
