using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.ResponseModel
{
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}