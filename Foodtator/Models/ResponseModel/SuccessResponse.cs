using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foodtator.Models.ResponseModel
{
    public class SuccessResponse:BaseResponse
    {
        public SuccessResponse()
        {

            this.IsSuccessFul = true;
        }
    }
}