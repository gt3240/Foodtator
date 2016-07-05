using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class PointsRecordRequestModel
    {
        public string userId { get; set; }
        public string eventType { get; set; }
        public string locationName { get; set; }
        public int points { get; set; }
    }
}