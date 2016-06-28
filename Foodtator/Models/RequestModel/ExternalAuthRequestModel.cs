using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class ExternalAuthRequestModel
    {
        [Required]
        public string id { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string type { get; set; }

        public string userId { get; set; }
    }
}