using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class LocationRequestModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string State { get; set; }
        public int PhoneNumber { get; set; }
    }
}