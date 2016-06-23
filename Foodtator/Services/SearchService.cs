using BoilerPlate.Web.Domain;
using BoilerPlate.Web.Interfaces;
using BoilerPlate.Web.Models.RequestModel;
using Sabio.Data;
using Sabio.Web.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BoilerPlate.Web.Services
{
    public class SearchService:BaseService,ISearchService
    {
        //List Users 
        public List<UserDetails> ListUsers(UserSearchRequestModel model)
        {
            List<UserDetails> list = new List<UserDetails>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.User_Search_Paginate"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Query", model.Query);
                   paramCollection.AddWithValue("@CurrentPage", model.CurrentPage);
                   paramCollection.AddWithValue("@ItemsPerPage", model.ItemsPerPage);
               }
               , map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
               {
                   UserDetails p = new UserDetails();
                   int startingIndex = 0; //startingOrdinal

                   p.Id = reader.GetSafeString(startingIndex++);
                   p.UserName = reader.GetSafeString(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
              

                   list.Add(p);
               });

            return list;
        }
        public int getUserMatchCount(UserSearchRequestModel model)
        {
            int count = 0;
            DataProvider.ExecuteCmd(GetConnection, "dbo.Users_Query_Count"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Query", model.Query);

               }, map: delegate (IDataReader reader, short set)
               {
                   int startingIndex = 0; //startingOrdinal

                   count = reader.GetSafeInt32(startingIndex++);

               }
               );

            return count;
        }


        public List<UserDetails> searchUsers(UserSearchRequestModel model)
        {
            List<UserDetails> list = new List<UserDetails>();

            DataProvider.ExecuteCmd(GetConnection, "dbo.User_Search_Paginate"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@User", model.Query);

               }
               , map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
               {
                   UserDetails p = new UserDetails();
                   //Media m = new Media();
                   int startingIndex = 0; //startingOrdinal

                   p.UserName = reader.GetSafeString(startingIndex++);
                   p.FirstName = reader.GetSafeString(startingIndex++);
                   p.LastName = reader.GetSafeString(startingIndex++);
                   //m.ID = reader.GetSafeInt32(startingIndex++);
                   //m.MediaType = reader.GetSafeString(startingIndex++);
                   //m.Path = reader.GetSafeString(startingIndex++);
                   //m.FileName = reader.GetSafeString(startingIndex++);
                   //m.FileType = reader.GetSafeString(startingIndex++);
                   //m.Title = reader.GetSafeString(startingIndex++);
                   //m.Description = reader.GetSafeString(startingIndex++);

                   //if (m.ID == 0)
                   //{
                   //    p.Avatar = null;
                   //}

                   //else
                   //{
                   //    p.Avatar = m;
                   //}

                   list.Add(p);
               });

            return list;
        }


    }
}