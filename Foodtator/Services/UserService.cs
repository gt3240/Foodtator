using Foodtator.Classes.Exceptions;
using Foodtator.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Foodtator.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace Foodtator.Services
{
    public class UserService : BaseService
    {
        private static ApplicationUserManager GetUserManager()
        {
            return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        public static IdentityUser CreateUser(string email, string password)
        {
            ApplicationUserManager userManager = GetUserManager();

            ApplicationUser newUser = new ApplicationUser { UserName = email, Email = email, LockoutEnabled = false };
            IdentityResult result = null;
            try
            {
                result = userManager.Create(newUser, password);

            }
            catch
            {
                new IdentityResultException(result);
            }

            if (result.Succeeded)
            {
                return newUser;
            }
            else
            {
                throw new IdentityResultException(result);
            }
        }

        public static IdentityUser InsertUser(RegistrationModel model)
        {
            int uid = 0;
            IdentityUser newUser = UserService.CreateUser(model.email, model.confirmPassword);

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", newUser.Id);
                   paramCollection.AddWithValue("@FirstName", model.firstName);
                   paramCollection.AddWithValue("@LastName", model.lastName);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;
                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@UserId"].Value.ToString(), out uid);
               });

            //TokenRequest Request = new TokenRequest();

            //Request.UserId = new Guid(newUser.Id);

            //// assign Buyer role to new users
            //userInitialRoleInsert(newUser.Id, "e1a6b7f6-7b8c-4205-bd93-c0c2af0ef103");

            //Request.TokenType = 1;

            //Guid Token = TokenService.InsertToken(Request);


            //ConfirmationRequestModel RequestEmail = new ConfirmationRequestModel();

            //RequestEmail.Email = model.email;

            //RequestEmail.Token = Token;

            //RequestEmail.Name = model.firstName;

            //NotifyServices.SendConfirmationEmail(RequestEmail);

            //// insert System Event
            //SystemEventRequestModel se = new SystemEventRequestModel();
            //se.ActorUserId = newUser.Id;
            //se.EventType = Enums.SystemEventType.NewRegister;
            ////SystemEventService.Insert(se);

            return newUser;
        }


        public static bool Signin(string emailaddress, string password)
        {
            bool result = false;

            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.Find(emailaddress, password);
            if (user != null)
            {
                ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);
                result = true;

            }
            return result;
        }

        public static bool ExternalAuthSignIn(ApplicationUser user)
        {
            bool result = false;

            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (user != null)
            {
                ClaimsIdentity signin = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, signin);
                result = true;

            }
            return result;
        }

        public static bool IsUser(string emailaddress)
        {
            bool result = false;

            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.FindByEmail(emailaddress);


            if (user != null)
            {

                result = true;

            }

            return result;
        }

        public static ApplicationUser GetUser(string emailaddress)
        {


            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.FindByEmail(emailaddress);

            return user;
        }


        public static ApplicationUser GetUserById(string userId)
        {

            ApplicationUserManager userManager = GetUserManager();
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            ApplicationUser user = userManager.FindById(userId);

            return user;
        }

        public static bool ChangePassWord(string userId, string newPassword)
        {
            bool result = false;

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(newPassword))
            {
                throw new Exception("You must provide a userId and a password");
            }

            ApplicationUser user = GetUserById(userId);

            if (user != null)
            {

                ApplicationUserManager userManager = GetUserManager();

                userManager.RemovePassword(userId);
                IdentityResult res = userManager.AddPassword(userId, newPassword);

                result = res.Succeeded;

            }

            return result;
        }


        public static bool Logout()
        {
            bool result = false;

            IdentityUser user = GetCurrentUser();

            if (user != null)
            {
                IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                result = true;
            }

            return result;
        }


        public static IdentityUser GetCurrentUser()
        {
            if (!IsLoggedIn())
                return null;
            ApplicationUserManager userManager = GetUserManager();

            IdentityUser currentUserId = userManager.FindById(GetCurrentUserId());
            return currentUserId;
        }

        public static string GetCurrentUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId(); //Current.User.Identity.GetUserId(asp.net built in) gets the current logged in user id info
        }

        public static bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(GetCurrentUserId());

        }

        public static void TheEmailConfirmed(Guid Id)
        {

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.AspNetUsers_EmailConfirmed"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@EmailConfirmed", true);
                   paramCollection.AddWithValue("@Id", Id);


               });
        }

        public static Domain.UserDetails GetById(Guid id)
        {
            Domain.UserDetails p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.AspNetUsers_GetUserById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ID", id);

               }, map: delegate (IDataReader reader, short set)
               {
                   p = new Domain.UserDetails();
                   int startingIndex = 0; //startingOrdinal

                   //p.Id = reader.GetSafeString(startingIndex++);
                   //p.Email = reader.GetSafeString(startingIndex++);
                   //p.PhoneNumber = reader.GetSafeString(startingIndex++);
                   //p.UserName = reader.GetSafeString(startingIndex++);
               }
               );

            return p;
        }


    }
}