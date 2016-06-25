using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class BusinessSearchRequestModel
    {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Search Term (ex. coffee)")]
            public string Term { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Location (ex. Seattle)")]
            public string Location { get; set; }
        
    }
}