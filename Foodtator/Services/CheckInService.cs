using Foodtator.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using YelpSharp.Data;

namespace Foodtator.Services
{
    public class CheckInService : BaseService,ICheckInService
    {
        public int EstablishmentSelected(Business model)
        {
            int uid = 0;
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            DataProvider.ExecuteNonQuery(GetConnection, "Establishment_Selected"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
               paramCollection.AddWithValue("@UserId", UserService.GetCurrentUserId());
               paramCollection.AddWithValue("@EstablishmentName", model.name);
               paramCollection.AddWithValue("@Latitude", model.location.coordinate.latitude);
               paramCollection.AddWithValue("@Longitude", model.location.coordinate.longitude);
               paramCollection.AddWithValue("@ImageUrl", model.image_url);
               paramCollection.AddWithValue("@Selected", unixTimestamp);

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                   p.Direction = System.Data.ParameterDirection.Output;
                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out uid);
               });
         

            return uid;
        }




    }
}
