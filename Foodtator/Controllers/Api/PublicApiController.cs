using Foodtator.Interfaces;
using Foodtator.Models;
using Foodtator.Models.RequestModel;
using Foodtator.Models.ResponseModel;
using Foodtator.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Foodtator.Controllers.Api
{
    [RoutePrefix("api/public")]
    public class PublicApiController : ApiController
    {

        private IAdminUsersService _AdminUserService { get; set; }


        public PublicApiController(IAdminUsersService AdminUserService)
        {
            _AdminUserService = AdminUserService;
        }

        [Route("Register"), HttpPost]
        public HttpResponseMessage Register(RegistrationModel model)
        {
            // if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            // check if external auth user
            string isExternalAuth = UserService.GetExternalAuthEmail(model.email);

            if (isExternalAuth != null)
            {
                ItemResponse<string> externalAuthResponse = new ItemResponse<string>();
                externalAuthResponse.Item = "externalAuthUser";
                return Request.CreateResponse(externalAuthResponse);
            }
            else
            {
                //ItemResponse<IdentityUser> response = new ItemResponse<IdentityUser>();

                UserService.InsertUser(model);

                bool response = UserService.Signin(model.email, model.confirmPassword);

                if (response == true)
                {
                    ItemResponse<Domain.UserDetails> newResponse = new ItemResponse<Domain.UserDetails>();
                    string userId = UserService.GetCurrentUserId();
                    Guid userGuid = new Guid(userId);
                    newResponse.Item = _AdminUserService.GetUserById(userGuid);
                    return Request.CreateResponse(newResponse);

                }
                else
                {
                    return Request.CreateResponse(response);
                }
            }

        }



        [Route("LogIn"), HttpPost]
        public HttpResponseMessage LogIn(LogIn model)
        {
            // if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            // check if external auth user
            string isExternalAuth = UserService.GetExternalAuthEmail(model.UserLogInEmail);

            if (isExternalAuth != null)
            {
                ItemResponse<string> externalAuthResponse = new ItemResponse<string>();
                externalAuthResponse.Item = "externalAuthUser";
                return Request.CreateResponse(externalAuthResponse);
            }
            else
            {
                bool response = UserService.Signin(model.UserLogInEmail, model.UserLogInPassword);

                if (response == true)
                {
                    ItemResponse<Domain.UserDetails> newResponse = new ItemResponse<Domain.UserDetails>();
                    string userId = UserService.GetCurrentUserId();
                    Guid userGuid = new Guid(userId);
                    newResponse.Item = _AdminUserService.GetUserById(userGuid);
                    return Request.CreateResponse(newResponse);

                }
                else
                {
                    return Request.CreateResponse(response);
                }
            }
        }

        [Route("LogOut"), HttpPost]
        public HttpResponseMessage LogOut()
        {
            //if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            bool response = UserService.Logout();

            return Request.CreateResponse(response);

        }


        [Route("ExternalAuth/{email}"), HttpGet]
        public HttpResponseMessage ExternalUserLogin([FromUri]ExternalAuthRequestModel model)
        {
            ItemResponse<string> response = new ItemResponse<string>();

            bool isUser = UserService.IsUser(model.email);

            string isAuthUserId = null;

            // if isUser then check externalAuth
            if (isUser)
            {
                isAuthUserId = UserService.GetExternalAuthEmail(model.email);

                if (isAuthUserId == null)
                {
                    // user already register, ask to merge
                    ApplicationUser userId = UserService.GetUser(model.email);
                    //ItemResponse<ApplicationUser> newResponse = new ItemResponse<ApplicationUser>();
                    response.Item = userId.Id;
                }
                else
                {
                    // if exist in both db, then log in

                    ApplicationUser loginUser = UserService.GetUserById(isAuthUserId);

                    bool signIn = UserService.ExternalAuthSignIn(loginUser);

                    if (signIn == true)
                    {
                        ItemResponse<Domain.UserDetails> newResponse = new ItemResponse<Domain.UserDetails>();
                        //string userId = UserService.GetCurrentUserId();
                        Guid userGuid = new Guid(isAuthUserId);
                        newResponse.Item = _AdminUserService.GetUserById(userGuid);
                        return Request.CreateResponse(newResponse);
                    }
                }
            }
            else
            {
                // insert in both table
                RegistrationModel user = new RegistrationModel();
                user.email = model.email;
                user.firstName = model.firstName;
                user.lastName = model.lastName;
                user.password = "Sabiopass1!";
                user.confirmPassword = "Sabiopass1!";

                IdentityUser newUser = UserService.InsertUser(user);

                model.userId = newUser.Id;

                UserService.InsertUserExternalAuth(model);

                ApplicationUser loginUser = UserService.GetUserById(newUser.Id);

                bool signIn = UserService.ExternalAuthSignIn(loginUser);

                if (signIn == true)
                {
                    ItemResponse<Domain.UserDetails> newResponse = new ItemResponse<Domain.UserDetails>();
                    //string userId = UserService.GetCurrentUserId();
                    Guid userGuid = new Guid(newUser.Id);
                    newResponse.Item = _AdminUserService.GetUserById(userGuid);
                    return Request.CreateResponse(newResponse);
                }

            }
            return Request.CreateResponse(response);
        }

        [Route("ExternalAuth"), HttpPost]
        public HttpResponseMessage ExternalUserInsert(ExternalAuthRequestModel model)
        {
            ItemResponse<string> response = new ItemResponse<string>();

            UserService.InsertUserExternalAuth(model);

            ApplicationUser loginUser = UserService.GetUserById(model.userId);

            bool signIn = UserService.ExternalAuthSignIn(loginUser);

            if (signIn == true)
            {
                ItemResponse<Domain.UserDetails> newResponse = new ItemResponse<Domain.UserDetails>();
                //string userId = UserService.GetCurrentUserId();
                Guid userGuid = new Guid(model.userId);
                newResponse.Item = _AdminUserService.GetUserById(userGuid);
                return Request.CreateResponse(newResponse);
            }
            else
            {
                return Request.CreateResponse(response);
            }

        }

    }
}
