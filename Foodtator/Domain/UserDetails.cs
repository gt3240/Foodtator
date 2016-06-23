using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Domain
{
    public class UserDetails
    {
        public String Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int UserType { get; set; }
        public int FollowersCount { get; set; }
        public int FollowedCount { get; set; }
        public String RoleId { get; set; }
    }
}