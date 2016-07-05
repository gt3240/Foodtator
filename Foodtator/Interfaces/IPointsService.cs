using Foodtator.Models.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodtator.Interfaces
{
    public interface IPointsService
    {
        int InsertPoints(PointsRecordRequestModel model);
        int dismissEstablishment(PointsRecordRequestModel model);

    }
}
