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
    public class AdminUserService:BaseService, IAdminUsersService
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
           
            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_Admin_Select_By_Id2"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@ID", id);

              },
              map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
              {

                  //if (set == 0)
                  //{

                     
                  //    int startingIndex = 0; //startingOrdinal

                       //string idUsers = reader.GetSafeString(startingIndex++);
                       //if (idUsers != null)
                       //{
                       //    p.Id = new Guid(idUsers);
                       //}
                       //else
                       //{
                       //    throw new Exception("UserId is not valid");
                       //}
                      // p.Id = reader.GetSafeString(startingIndex++);
                      //p.UserName = reader.GetSafeString(startingIndex++);
                      //p.FirstName = reader.GetSafeString(startingIndex++);
                      //p.LastName = reader.GetSafeString(startingIndex++);
                      //p.PhoneNumber = reader.GetSafeString(startingIndex++);
                      //p.Email = reader.GetSafeString(startingIndex++);
                      //p.DateAdded = reader.GetSafeDateTime(startingIndex++);
                      //p.DateModified = reader.GetSafeDateTime(startingIndex++);
                      //p.UserType = reader.GetSafeInt32(startingIndex++);
                  //    int MediaId = reader.GetSafeInt32(startingIndex++);
                  //    m.ID = reader.GetSafeInt32(startingIndex++);
                  //    m.MediaType = reader.GetSafeString(startingIndex++);
                  //    m.Path = reader.GetSafeString(startingIndex++);
                  //    m.FileName = reader.GetSafeString(startingIndex++);
                  //    m.FileType = reader.GetSafeString(startingIndex++);
                  //    m.Title = reader.GetSafeString(startingIndex++);
                  //    m.Description = reader.GetSafeString(startingIndex++);
                  //    m.UserID = reader.GetSafeString(startingIndex++);
                  //    m.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                  //    m.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                  //    m.ThumbnailPath = reader.GetSafeString(startingIndex++);
                  //    p.FollowersCount = reader.GetSafeInt32(startingIndex++);
                  //    p.FollowedCount = reader.GetSafeInt32(startingIndex++);
                  //    b.ID = reader.GetSafeInt32(startingIndex++);
                  //    b.MediaType = reader.GetSafeString(startingIndex++);
                  //    b.Path = reader.GetSafeString(startingIndex++);
                  //    b.FileName = reader.GetSafeString(startingIndex++);
                  //    b.FileType = reader.GetSafeString(startingIndex++);
                  //    b.Title = reader.GetSafeString(startingIndex++);
                  //    b.Description = reader.GetSafeString(startingIndex++);
                  //    b.UserID = reader.GetSafeString(startingIndex++);
                  //    b.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                  //    b.ModifiedDate = reader.GetSafeDateTime(startingIndex++);
                  //    b.ThumbnailPath = reader.GetSafeString(startingIndex++);
                  //     // m.BaseUrl = reader.GetSafeString(startingIndex++);
                  //     if (m.ID == 0)
                  //    {
                  //        p.Avatar = null;
                  //    }
                  //    else
                  //    {
                  //        p.Avatar = m;
                  //    }
                  //    if (b.ID == 0)
                  //    {
                  //        p.BackGroundPhoto = null;
                  //    }
                  //    else
                  //    {
                  //        p.BackGroundPhoto = b;
                  //    }

                  //    p.Website = new List<Website>();
                  //}
                  //else if (set == 1)
                  //{

                  //    if (p != null)
                  //    {
                  //        Website site = new Website();
                  //        int startingIndex = 0;
                  //        site.ID = reader.GetSafeInt32(startingIndex++);
                  //        site.Name = reader.GetSafeString(startingIndex++);
                  //        site.Slug = reader.GetSafeString(startingIndex++);
                  //        site.Url = reader.GetSafeString(startingIndex++);
                  //        site.Theme = reader.GetSafeString(startingIndex++);
                  //        site.Description = reader.GetSafeString(startingIndex++);
                  //        site.Active = reader.GetSafeBool(startingIndex++);
                  //        p.Website.Add(site);
                  //    }

                  //}

                  //else if (set == 2)
                  //{
                  //    if (p != null)
                  //    {
                  //        int startingIndex = 0;
                  //        p.RoleId = reader.GetSafeString(startingIndex++);
                  //    }
                  //}
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