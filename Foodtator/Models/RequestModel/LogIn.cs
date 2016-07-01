using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class LogIn
    {
        [Required]
        [EmailAddress]
        public string UserLogInEmail { get; set; }

        [Required]
        public string UserLogInPassword { get; set; }
    }
}