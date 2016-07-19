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
    public class LocationService:BaseService,ILocationService
    {
        public int createLocation(LocationRequestModel model)
        {

            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Coupon_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@Address1", model.Address1);
                   paramCollection.AddWithValue("@City",model.City);
                   paramCollection.AddWithValue("@Zip", model.ZipCode);
                   paramCollection.AddWithValue("@State", model.State);
                   paramCollection.AddWithValue("@PhoneNumber", model.PhoneNumber);
  
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

   
        public List<Domain.Location> GetLocationsByUserID()
        {
            List<Domain.Location> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Location_SelectByUserID"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserID", UserService.GetCurrentUserId());

               }, map: delegate (IDataReader reader, short set)
               {
                   Domain.Location p = new Domain.Location();
                   int startingIndex = 0; //startingOrdinal

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.Name = reader.GetSafeString(startingIndex++);
                   p.Address1 = reader.GetSafeString(startingIndex++);
                   p.City = reader.GetSafeString(startingIndex++);
                   p.ZipCode = reader.GetSafeInt32(startingIndex++);
                   p.State = reader.GetSafeString(startingIndex++);
                   p.PhoneNumber = reader.GetSafeInt32(startingIndex++);

                   if (list == null)
                   {
                       list = new List<Domain.Location>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }
        public Domain.Location GetLocationById(int Id)
        {
            Domain.Location p = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Location_SelectById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@Id", Id);

               }, map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
               {
                   p = new Domain.Location();
                   int startingIndex = 0; //startingOrdinal

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.Name = reader.GetSafeString(startingIndex++);
                   p.Address1 = reader.GetSafeString(startingIndex++);
                   p.City = reader.GetSafeString(startingIndex++);
                   p.ZipCode = reader.GetSafeInt32(startingIndex++);
                   p.State = reader.GetSafeString(startingIndex++);
                   p.PhoneNumber = reader.GetSafeInt32(startingIndex++);

               });

            return p;
        }


        public int UpdateLocation(LocationRequestModel model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Location_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@Address1", model.Address1);
                   paramCollection.AddWithValue("@City", model.City);
                   paramCollection.AddWithValue("@Zip", model.ZipCode);
                   paramCollection.AddWithValue("@State", model.State);
                   paramCollection.AddWithValue("@PhoneNumber", model.PhoneNumber);


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

        public void DeleteLocationById(int Id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Location_Delete"
            , inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@Id", Id);
            }, returnParameters: delegate (SqlParameterCollection param)
            {
            });
        }

    }
}