using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class RegisterRequestModel
    {
        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6)]
        [RegularExpression(@"^(?=^.{6,20}$)(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@!#$%^&+=.\-_*])([a-zA-Z0-9@!#$%^&+=*.\-_]){3,}$",
            ErrorMessage = "Required: min 1 capital letter, min 1 lowercase letter, min 1 digit, min 1 special character")]
        public string password { get; set; }

        [Compare("password")]
        [Required]
        public string confirmPassword { get; set; }
    }
}