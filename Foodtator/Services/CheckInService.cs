using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tkj.Data;
using YelpSharp.Data;
using Foodtator.Interfaces;
using Foodtator.Domain;

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

        public SelectedEstablishment getSelectedEstablishment(string userId)
        {
            SelectedEstablishment p = new SelectedEstablishment();
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            DataProvider.ExecuteCmd(GetConnection, "dbo.EstablishmentCheckIn_Get"
              , inputParamMapper: delegate (SqlParameterCollection paramCollection)
              {
                  paramCollection.AddWithValue("@UserId", userId);
                  paramCollection.AddWithValue("@Selected", unixTimestamp - 10800);
              },
              map: (Action<IDataReader, short>)delegate (IDataReader reader, short set)
              {
                  if (set == 0)
                  {
                      int startingIndex = 0; //startingOrdinal

                      p.establishmentName = reader.GetSafeString(startingIndex++);
                      p.lat = reader.GetSafeDecimal(startingIndex++);
                      p.lon = reader.GetSafeDecimal(startingIndex++);
                      p.imageUrl = reader.GetSafeString(startingIndex++);
                  }
              });

            return p;

        }


    }
}
