﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class Location
    {
        public string[] address { get; set; }
        public string city { get; set; }
        public Coordinate coordinate { get; set; }
        public string country_code { get; set; }
        public string cross_streets { get; set; }
        public string[] display_address { get; set; }
        public double geo_accuracy { get; set; }
        public string[] neighborhoods { get; set; }
        public string postal_code { get; set; }
        public string state_code { get; set; }
    }
}