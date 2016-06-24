using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Enums
{
    public enum NotificationType: int
    {
        //NewRegister = 1,
        //UserUpgradToDealer = 2,
        //NewInventory = 3,
        //NewBlog = 4,
        //NewComment = 5,
        //Followed = 6

        NewRegisterInbox = 1,
        NewRegisterTextMesage = 2,
        NewRegisterEmail = 3,
        UserUpgradToDealerInbox = 4,
        UserUpgradToDealerTextMesage = 5,
        UserUpgradToDealerEmail = 6,
        NewInventoryInbox = 7,
        NewInventoryTextMesage = 8,
        NewInventoryEmail = 9,
        NewBlogInbox = 10,
        NewBlogTextMesage = 11,
        NewBlogEmail = 12,
        NewCommentInbox = 13,
        NewCommentTextMesage = 14,
        NewCommentEmail = 15,
        FollowedInbox = 16,
        FollowedTextMesage = 17,
        FollowedEmail = 18,
    }
}