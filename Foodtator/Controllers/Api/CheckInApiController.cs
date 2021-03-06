﻿using Foodtator.Domain;
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
using YelpSharp.Data;

namespace Foodtator.Controllers.Api
{
    [RoutePrefix("api/CheckIn")]
    public class CheckInApiController : ApiController
    {
       
        [Dependency]
        public ICheckInService _CheckInService { get; set; }

        [Dependency]
        public IPointsService _PointsService { get; set; }

        [Route("Selected"), HttpPost]
        public HttpResponseMessage SelectEstablishment(Business model)
        {

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _CheckInService.EstablishmentSelected(model);

            PointsRecordRequestModel pointsModel = new PointsRecordRequestModel();
            pointsModel.eventType = "RestaurantAccepted";
            _PointsService.InsertPoints(pointsModel);

            SuccessResponse response = new SuccessResponse();


            return Request.CreateResponse(response);
        }

        [Route("Selected"), HttpGet]
        public HttpResponseMessage GetSelectEstablishment()
        {

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<SelectedEstablishment> response = new ItemResponse<SelectedEstablishment>();
            response.Item = _CheckInService.getSelectedEstablishment();

            return Request.CreateResponse(response);
        }

        [Route("checkIn"), HttpPut]
        public HttpResponseMessage checkIn([FromUri]int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();

            _CheckInService.CheckIn(id);

            PointsRecordRequestModel pointsModel = new PointsRecordRequestModel();
            pointsModel.eventType = "RestaurantCheckedIn";
            _PointsService.InsertPoints(pointsModel);

            return Request.CreateResponse(response);
        }

        [Route("dismiss"), HttpPost]
        public HttpResponseMessage DismissEstablishment()
        {
            PointsRecordRequestModel pointsModel = new PointsRecordRequestModel();
            pointsModel.eventType = "RestaurantDenied";
            _PointsService.dismissEstablishment(pointsModel);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }

    }
}
