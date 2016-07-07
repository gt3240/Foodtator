using Foodtator.Interfaces;
using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Foodtator.Services
{
    public class PointsService: BaseService, IPointsService
    {
        //Our point system as of June 30 2016
        private int NewUserPoints = 10;
        private int RestaurantAccepted = 5;
        private int RestaurantCheckedIn = 10;
        private int Restaurantdenied = 1;
        private int PhotoUploaded = 10;
        private int RestaurantPoints = 0;
        //Depending on what the user does different commands will get passed in

        public int InsertPoints(PointsRecordRequestModel model)
        {
            int uid = 0;
                   
            string userId = UserService.GetCurrentUserId();

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Points_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   switch (model.eventType)
                   {
                       case "NewUser":
                           RestaurantPoints = NewUserPoints;
                           break;
                       case "RestaurantAccepted":
                           RestaurantPoints = RestaurantAccepted;
                           break;
                       case "RestaurantCheckedIn":
                           RestaurantPoints = RestaurantCheckedIn;
                           break;
                       case "PhotoUploaded":
                           RestaurantPoints = PhotoUploaded;
                           break;
                       default:
                           RestaurantPoints = 0;
                           break;
                   }
                   paramCollection.AddWithValue("@Points", RestaurantPoints);
                   paramCollection.AddWithValue("@UserId", userId);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
               });

            model.userId = userId;
            model.points = RestaurantPoints;
            model.locationName = "toms";
            PointsService.insertPointsRecord(model);

            return uid;
        }

        public int dismissEstablishment(PointsRecordRequestModel model)
        {
            int uid = 0;
            string userId = UserService.GetCurrentUserId();
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Points_SubtractPoints"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   if(model.eventType == "RestaurantDenied")
                   {
                       RestaurantPoints = Restaurantdenied;
                   }
                   paramCollection.AddWithValue("@Points", RestaurantPoints);
                   paramCollection.AddWithValue("@UserId", userId);

                
               }, returnParameters: delegate (SqlParameterCollection param)
               {
               });

            model.userId = userId;
            model.points = RestaurantPoints;
            model.locationName = "toms";
            PointsService.insertPointsRecord(model);

            return uid;
        }

        public static void insertPointsRecord(PointsRecordRequestModel model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PointsHistory_Insert"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                  
                   paramCollection.AddWithValue("@UserId", model.userId);
                   paramCollection.AddWithValue("@Event", model.eventType);
                   paramCollection.AddWithValue("@LocationName", model.locationName);
                   paramCollection.AddWithValue("@Points", model.points);


               }, returnParameters: delegate (SqlParameterCollection param)
               {
               });
        }
    }
}