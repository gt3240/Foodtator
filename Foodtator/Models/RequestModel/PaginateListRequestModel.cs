using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.RequestModel
{
    public class PaginateListRequestModel
    {
        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string Query { get; set; }

    }
}