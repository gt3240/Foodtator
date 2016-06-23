using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.ResponseModel
{
    public class PaginateItemsResponse<T> : ItemsResponse<T>
    {

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }


    }
}