using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class CouponRequestModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string CouponCode { get; set; }
        public string Description { get; set; }
        public DateTime Expires { get; set; }
        public int MaxRedemptions { get; set; }

    }
}