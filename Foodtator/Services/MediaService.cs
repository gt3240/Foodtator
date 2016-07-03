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
    public class MediaService: BaseService, IMediaService
    {
        public int InsertMedia(MediaRequestModel model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Media_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   ///string userId = UserService.GetCurrentUserId();
                   paramCollection.AddWithValue("@MediaType", model.MediaType);
                   paramCollection.AddWithValue("@Path", model.Path);
                   paramCollection.AddWithValue("@FileName", model.FileName);
                   paramCollection.AddWithValue("@FileType", model.FileType);
                   paramCollection.AddWithValue("@Title", model.Title);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@UserID", null);
                   paramCollection.AddWithValue("@ThumbnailPath", model.ThumbnailPath);

                   SqlParameter p = new SqlParameter("@OID", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@OID"].Value.ToString(), out uid);
               }
               );
            return uid;
        }

        // update a update
        public void UpdateMedia(MediaRequestModel model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Media_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ID", model.ID);
                   paramCollection.AddWithValue("@Title", model.Title);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@UserID", 32000);

               }
               );

        }

        // get media by userID
        public List<Domain.Media> GetMediaByUserID(int UserID)
        {
            List<Domain.Media> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Media_SelectByUserID"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserID", UserID);

               }, map: delegate (IDataReader reader, short set)
               {
                   Domain.Media p = new Domain.Media();
                   int startingIndex = 0; //startingOrdinal

                   p.ID = reader.GetSafeInt32(startingIndex++);
                   p.MediaType = reader.GetSafeString(startingIndex++);
                   p.Path = reader.GetSafeString(startingIndex++);
                   p.FileName = reader.GetSafeString(startingIndex++);
                   p.FileType = reader.GetSafeString(startingIndex++);
                   p.Title = reader.GetSafeString(startingIndex++);
                   p.Description = reader.GetSafeString(startingIndex++);
                   if (list == null)
                   {
                       list = new List<Domain.Media>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

        // get media ID
        public Domain.Media GetMediaByID(int ID)
        {
            Domain.Media item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Media_SelectByID"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ID", ID);

               }, map: delegate (IDataReader reader, short set)
               {
                   Domain.Media p = new Domain.Media();
                   int startingIndex = 0; //startingOrdinal

                   p.ID = reader.GetSafeInt32(startingIndex++);
                   p.MediaType = reader.GetSafeString(startingIndex++);
                   p.Path = reader.GetSafeString(startingIndex++);
                   p.FileName = reader.GetSafeString(startingIndex++);
                   p.FileType = reader.GetSafeString(startingIndex++);
                   p.Title = reader.GetSafeString(startingIndex++);
                   p.Description = reader.GetSafeString(startingIndex++);
                   item = p;
               }
               );

            return item;
        }

        // delete a website
        public void DeleteMedia(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Media_Delete"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ID", id);

               }
               );

        }

    }
}