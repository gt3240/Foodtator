//using Sabio.Web.Enums;
//using Sabio.Web.Models.ViewModels;
//using Sabio.Web.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Sabio.Web.Controllers
//{
//    public class BaseController : Controller
//    {
//        public new ViewResult View()
//        {
//            BaseViewModel BaseModel = GetViewModel<BaseViewModel>();
//            BaseModel = DecorateViewModel<BaseViewModel>(BaseModel);
//            return base.View(BaseModel);

//        }

//        public new ViewResult View(string viewString)
//        {
//            BaseViewModel BaseModel = GetViewModel<BaseViewModel>();

//            BaseModel = DecorateViewModel<BaseViewModel>(BaseModel);

//            return base.View(viewString, BaseModel);
//        }

//        public ViewResult View(string ViewStrings, BaseViewModel baseVMS)
//        {
//            BaseViewModel BaseModel = DecorateViewModel<BaseViewModel>(baseVMS);

//            return base.View(ViewStrings, BaseModel);
//        }

//        public ViewResult View(BaseViewModel baseVM)
//        {
//            BaseViewModel BaseModel = DecorateViewModel<BaseViewModel>(baseVM);

//            return base.View(BaseModel);
//        }

//        protected T GetViewModel<T>() where T : BaseViewModel, new()
//        {
//            BaseViewModel NewView = new BaseViewModel();
//            return (T)NewView;

//        }

//        //Add Function that takes in string and view model

//        protected T DecorateViewModel<T>(T model) where T : BaseViewModel
//        {

//            model.IsLoggedIn = UserService.IsLoggedIn();

//            model.CurrentNav = "PublicNav.cshtml";

//            if (model.IsLoggedIn)
//            {
//                Guid currentUserId = new Guid(UserService.GetCurrentUserId());
//                AdminUsersService aus = new AdminUsersService();
//                //model.AppUser = aus.GetUserById(currentemail);
//                model.AppUser = aus.GetUserById(currentUserId);

//                if (model.AppUser != null)
//                {
//                    model.CurrentRole = (UserRolesType)model.AppUser.RoleId;

//                    if(model.CurrentRole == UserRolesType.SuperAdmin)
//                        model.CurrentNav = "AdminNav.cshtml";
//                    else if (model.CurrentRole == UserRolesType.Dealer)
//                        model.CurrentNav = "DealerNav.cshtml";
//                    else if (model.CurrentRole == UserRolesType.Buyer)
//                        model.CurrentNav = "UserNav.cshtml";
//                }
//            }               

//            return (T)model;
//        }
//    }
//}