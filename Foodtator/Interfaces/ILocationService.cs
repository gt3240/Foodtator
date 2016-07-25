using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface ILocationService
    {
        int CreateLocation(LocationRequestModel model);
        List<Domain.Location> GetLocationsByUserID();
        Domain.Location GetLocationById(int Id);
        int UpdateLocation(LocationRequestModel model);
        void DeleteLocationById(int Id);

    }
}
