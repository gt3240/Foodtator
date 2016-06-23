using Foodtator.Domain;
using Foodtator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.ViewModels
{
    
    public class BaseViewModel
    {
        public bool IsLoggedIn { get; set; }
        public string CurrentNav { get; set; }
        public UserDetails AppUser { get; set; }
        public UserRolesType CurrentRole { get; set; }


    }
}