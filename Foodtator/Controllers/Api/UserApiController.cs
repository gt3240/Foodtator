using Foodtator.Classes.Exceptions;
using Foodtator.Interfaces;
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
    [RoutePrefix("api/user")]
    public class UserApiController : ApiController
    {

        [Route("register"), HttpPost]
        public HttpResponseMessage Register(RegisterRequestModel model)
        {
            // if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<IdentityUser> response = new ItemResponse<IdentityUser>();

            try
            {
                response.Item = UserService.InsertUser(model);

            }
            catch (IdentityResultException ire)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ire.Result.Errors.ElementAt(0));

            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong, contact admin.");
            }

            return Request.CreateResponse(response);

        }

        [Route("LogIn"), HttpPost]
        public HttpResponseMessage LogIn(LogInRequestModel model)
        {
            // if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            bool response = UserService.Signin(model.email, model.password);

            if (response == true)
            {
                ItemResponse<Domain.UserDetails> newResponse = new ItemResponse<Domain.UserDetails>();
                string userId = UserService.GetCurrentUserId();
                Guid userGuid = new Guid(userId);
                newResponse.Item = UserService.GetUserById(userGuid);
                return Request.CreateResponse(newResponse);

            }
            else
            {
                return Request.CreateResponse(response);
            }
        }


    }
}
