using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.ResponseModel
{
    
    public class ItemResponse<T> : SuccessResponse
    {

        public T Item { get; set; }

    }
}