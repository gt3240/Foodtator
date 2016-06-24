using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Enums
{
    public sealed class UserRolesType

    /*
        this enum is used to keep track of languages and their corresponding classes that can be used for the highlight.js library
        see https://github.com/isagalaev/highlight.js/tree/master/src/languages
    */
    //public sealed class HighlightLanguages
    {
        private static readonly Dictionary<string, UserRolesType> instance = new Dictionary<string, UserRolesType>();

        private readonly string RoleName;
        private readonly string RoleID;

        public static readonly UserRolesType User = new UserRolesType("User", "18AD5E6C-87AC-4218-B529-3CB405E99355".ToLower());
        public static readonly UserRolesType Websitemanager = new UserRolesType("Websitemanager", "09B66209-A898-4A02-850A-DACA5E5E2FD1".ToLower());
        public static readonly UserRolesType Admin = new UserRolesType("Admin", "A80FA228-0972-4A80-844F-97B8A94C042B".ToLower());
        public static readonly UserRolesType Buyer = new UserRolesType("Buyer", "e1a6b7f6-7b8c-4205-bd93-c0c2af0ef103");
        public static readonly UserRolesType contentmanager = new UserRolesType("content manager", "68FB8EE9-61C9-45E3-B3F5-251935A3EBD9".ToLower());
        public static readonly UserRolesType Dealer = new UserRolesType("Dealer", "18fea797-9551-4d1e-a38c-09ca2dd64b91");
        public static readonly UserRolesType SuperAdmin = new UserRolesType("Super Admin", "dbf587ad-9595-4c78-84b5-2c2fb886f3e1");
        public static readonly UserRolesType Guest = new UserRolesType("Guest", "guest");


        private UserRolesType(string RoleName, string RoleID)
        {
            this.RoleName = RoleName;
            this.RoleID = RoleID.ToLower();
            instance[RoleID] = this;
        }

        public override String ToString()
        {
            return RoleID.ToLower() ;
        }

        public String ToName()
        {
            return RoleName;
        }

        public static Dictionary<string, string> getDictionary()
        {
            Dictionary<string, string> output = new Dictionary<string, string>();

            foreach (KeyValuePair<string, UserRolesType> entry in instance)
            {
                output.Add(entry.Value.RoleID, entry.Value.RoleName);
            }
            return output;
        }

        public static explicit operator UserRolesType(string str)
        {
            if(null == str)
                return UserRolesType.Guest;

            UserRolesType result;
            if (instance.TryGetValue(str.ToLower(), out result))
                return result;
            else
                return UserRolesType.Guest;
        }
    }
}


