using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Foodtator.Services
{
    public class PointsService: BaseService
    {
        //Our point system as of June 30 2016
        private int RestaurantAccepted = 5;
        private int Restaurantdenied = 1;
        private int PhotoUploaded = 10;
        private int RestaurantPoints;
        //Depending on what the user does different commands will get passed in
        public int InsertPoints(string Points)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_InsertPoints"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   switch (Points)
                   {
                       case "RestaurantAccepted":
                           RestaurantPoints = RestaurantAccepted;
                           break;
                       case "PhotoUploaded":
                           RestaurantPoints = PhotoUploaded;
                           break;
                       default:
                           RestaurantPoints = 0;
                           break;
                   }
                   paramCollection.AddWithValue("@Points", RestaurantPoints);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int); //passing my output Id, Id is type int, so (System.Data.SqlDbType.Int)
                   p.Direction = System.Data.ParameterDirection.Output;
                   paramCollection.Add(p); //those three lines in the last, because in the store proc ID is the last one.

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out uid);
               });
            return uid;
        }

        public int SubtractPoints(string Points)
        {
            int uid = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Users_SubtractPoints"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   if(Points== "RestaurantDenied")
                   {
                       RestaurantPoints = Restaurantdenied;
                   }
                   paramCollection.AddWithValue("@Points", RestaurantPoints);
                   paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int); //passing my output Id, Id is type int, so (System.Data.SqlDbType.Int)
                   p.Direction = System.Data.ParameterDirection.Output;
                   paramCollection.Add(p); //those three lines in the last, because in the store proc ID is the last one.

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out uid);
               });
            return uid;
        }
    }
}