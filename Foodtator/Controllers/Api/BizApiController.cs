using Foodtator.Interfaces;
using Foodtator.Models.RequestModel;
using Foodtator.Models.ResponseModel;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Foodtator.Controllers.Api
{
    [RoutePrefix("api/Biz")]
    public class BizApiController : ApiController
    {
        [Dependency]
        public ICouponService _couponService { get; set; }

        [Route("CreateCoupon"), HttpPost]
        public HttpResponseMessage CreateCoupon(CouponRequestModel model)
        {

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _couponService.CreateCoupon(model);

            SuccessResponse response = new SuccessResponse();


            return Request.CreateResponse(response);
        }

        [Route("UpdateCoupon"), HttpPut]
        public HttpResponseMessage UpdateCoupon(CouponRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _couponService.UpdateCoupon(model);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }

        [Route("GetCoupon"), HttpGet]
        public HttpResponseMessage GetCoupon()
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _couponService.GetCouponsByUserID();

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }

        [Route ("DeleteCoupon"), HttpDelete]
        public HttpResponseMessage DeleteCoupon(CouponRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _couponService.DeleteCouponById(model);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);


        }
    }
}
