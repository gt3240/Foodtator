using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain.Google
{
    public class GooglePhoto
    {
        public int height { get; set; }
        public List<string> html_attributions { get; set; }
        public string photo_reference { get; set; }
        public int width { get; set; }
    }
}