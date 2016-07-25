using Foodtator.Domain;
using Foodtator.Interfaces;
using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tkj.Data;

namespace Foodtator.Services
{
    public class AdminUserService : BaseService, IAdminUsersService
    {
        //Update User by Id  //update website by userId put method service
        public void Update(AdminUsersRequestModel model, Guid Id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_Admin_Update_By_Id"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", Id.ToString());
                   paramCollection.AddWithValue("@UserName", model.UserName);
                   paramCollection.AddWithValue("@FirstName", model.FirstName);
                   paramCollection.AddWithValue("@LastName", model.LastName);
                   paramCollection.AddWithValue("@Email", model.Email);
                   paramCollection.AddWithValue("@PhoneNumber", model.PhoneNumber);
                   paramCollection.AddWithValue("@RoleId", model.RoleId);



               });

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UserWebsite_DeleteByUserId"
           , inputParamMapper: delegate (SqlParameterCollection paramCollection)
           {
               paramCollection.AddWithValue("@UserId", Id.ToString());

           }, returnParameters: null);

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.UserWebsite_Insert"
           , inputParamMapper: delegate (SqlParameterCollection paramCollection)
           {
               paramCollection.AddWithValue("@UserId", Id.ToString());



           }, returnParameters: null);
        }

        //List Users 
        public List<UserDetails> ListUsers()
        {
            List<UserDetails> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_Admin_Select_All"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   //  this is where your input params go. it works the same way as with ExecuteNonQuery. 
                   //  Employees_Select proc does not have any input parameters specified so we leave this commented out
                   //  paramCollection.AddWithValue("@AppUserId", 36);                                    
               }
               , map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
               {
                   UserDetails p = new UserDetails();
                   int startingIndex = 0; //startingOrdinal

                   //string idUsers = reader.GetSafeString(startingIndex++);
                   //if (idUsers != null)
                   //{
                   //    p.Id = new Guid(idUsers);
                   //};

                   p.Id = reader.GetSafeString(startingIndex++);
                   p.UserName = reader.GetSafeString(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
                   p.PhoneNumber = reader.GetSafeString(startingIndex++);
                   p.Email = reader.GetSafeString(startingIndex++);
                   p.DateAdded = reader.GetSafeDateTime(startingIndex++);
                   p.DateModified = reader.GetSafeDateTime(startingIndex++);
                   p.UserType = reader.GetSafeInt32(startingIndex++);

                   if (list == null)
                   {
                       list = new List<UserDetails>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

        //Select User by Id
        public UserDetails GetUserById(Guid id)
        {
            //UserDetails p = null;
            UserDetails p = new UserDetails();

            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_Select_By_Id"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@ID", id);

              },
              map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
              {

                  if (set == 0)
                  {
                      int startingIndex = 0; //startingOrdinal

                      p.Id = reader.GetSafeString(startingIndex++);
                      p.UserName = reader.GetSafeString(startingIndex++);
                      p.FirstName = reader.GetSafeString(startingIndex++);
                      p.LastName = reader.GetSafeString(startingIndex++);
                      p.PhoneNumber = reader.GetSafeString(startingIndex++);
                      p.Email = reader.GetSafeString(startingIndex++);
                      p.DateAdded = reader.GetSafeDateTime(startingIndex++);
                      p.DateModified = reader.GetSafeDateTime(startingIndex++);
                      p.UserType = reader.GetSafeInt32(startingIndex++);
                      p.redeemPoints = reader.GetSafeInt32(startingIndex++);
                      p.rankingPoints = reader.GetSafeInt32(startingIndex++);
                      p.avatarFileName = reader.GetSafeString(startingIndex++);
                  }
              });

            return p;
        }

        //Delete User by Id
        public void DeleteUserById(Guid id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_Admin_Delete_By_Id"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ID", id);

               }, returnParameters: delegate (SqlParameterCollection param)
               {

               }
               );
        }

        //AdminUser pagination list

        public List<Domain.UserDetails> GetPaginationList(PaginateListRequestModel model)
        {
            List<Domain.UserDetails> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_Admin_Select"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Query", model.Query);
                   paramCollection.AddWithValue("@CurrentPage", model.CurrentPage);
                   paramCollection.AddWithValue("@ItemsPerPage", model.ItemsPerPage);

               }, map: delegate (IDataReader reader, short set)
               {
                   UserDetails p = new UserDetails();
                   int startingIndex = 0;
                   p.Id = reader.GetSafeString(startingIndex++);
                   p.UserName = reader.GetSafeString(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
                   p.PhoneNumber = reader.GetSafeString(startingIndex++);
                   p.Email = reader.GetSafeString(startingIndex++);
                   p.DateAdded = reader.GetSafeDateTime(startingIndex++);
                   p.DateModified = reader.GetSafeDateTime(startingIndex++);
                   p.UserType = reader.GetSafeInt32(startingIndex++);
                   if (list == null)
                   {
                       list = new List<UserDetails>();
                   }
                   list.Add(p);
               }
               );
            return list;
        }

        // AdminUser pagination count
        public int AdminUserCount(PaginateListRequestModel model)
        {

            int count = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_Admin_Count"
                   , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                   {
                       paramCollection.AddWithValue("@Query", model.Query);
                   }, map: delegate (IDataReader reader, short set)
                   {
                       int startingIndex = 0; //startingOrdinal
                       count = reader.GetSafeInt32(startingIndex++);
                   });

            return count;
        }
    }
}