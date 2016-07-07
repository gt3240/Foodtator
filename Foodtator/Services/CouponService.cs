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
    public class CouponService:BaseService
    {
        public int CreateCoupon(CouponRequestModel model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Coupon_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@CouponCode", model.CouponCode);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Expires", model.Expires);
                   paramCollection.AddWithValue("@MaxRedemptions", model.MaxRedemptions);

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

        // get coupons by userID
        public List<Domain.Coupon> GetCouponsByUserID()
        {
            List<Domain.Coupon> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Coupon_SelectByUserID"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
               paramCollection.AddWithValue("@UserID", UserService.GetCurrentUserId());

               }, map: delegate (IDataReader reader, short set)
               {
                   Domain.Coupon p = new Domain.Coupon();
                   int startingIndex = 0; //startingOrdinal

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.Name = reader.GetSafeString(startingIndex++);
                   p.CouponCode = reader.GetSafeString(startingIndex++);
                   p.Description = reader.GetSafeString(startingIndex++);
                   p.Expires = reader.GetSafeDateTime(startingIndex++);
                   p.MaxRedemptions = reader.GetSafeInt32(startingIndex++);
                   
                   if (list == null)
                   {
                       list = new List<Domain.Coupon>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }


        public int UpdateCoupon(CouponRequestModel model)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Coupon_Update"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
                   paramCollection.AddWithValue("@Name", model.Name);
                   paramCollection.AddWithValue("@CouponCode", model.CouponCode);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@Expires", model.Expires);
                   paramCollection.AddWithValue("@MaxRedemptions", model.MaxRedemptions);

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

        public void DeleteCouponById(CouponRequestModel model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Coupon_Delete"
            , inputParamMapper: delegate (SqlParameterCollection paramCollection)
            {
                paramCollection.AddWithValue("@Id", model.Id);
            }, returnParameters: delegate (SqlParameterCollection param)
            {
            });
        }

    }
}