using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Enums
{
    public enum SystemEventType : int
    {
        NewRegister = 1,
        UserUpgradToDealer = 2,
        NewInventory = 3,
        NewBlog = 4,
        NewComment = 5,
        Followed = 6
    }
}