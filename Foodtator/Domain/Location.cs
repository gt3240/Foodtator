﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class Location
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public string State { get; set; }
        public int PhoneNumber { get; set; }
    }
}