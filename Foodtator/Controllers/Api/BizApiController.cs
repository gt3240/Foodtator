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
            ItemsResponse<Domain.Coupon> response = new ItemsResponse<Domain.Coupon>();

            response.Items = _couponService.GetCouponsByUserID();

            return Request.CreateResponse(response);
        }

        [Route("{couponId:int}"), HttpGet]
        public HttpResponseMessage GetCouponById(int couponId)
        {
            ItemResponse<Domain.Coupon> response = new ItemResponse<Domain.Coupon>();

            response.Item = _couponService.GetCouponById(couponId);

            return Request.CreateResponse(response);
        }

        [Route ("{couponId:int}"), HttpDelete]
        public HttpResponseMessage DeleteCoupon(int couponId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            SuccessResponse response = new SuccessResponse();

             _couponService.DeleteCouponById(couponId);

            return Request.CreateResponse(response);


        }
    }
}
