using Foodtator.Interfaces;
using Foodtator.Models.RequestModel;
using Foodtator.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Foodtator.Controllers.Api
{
    [RoutePrefix("api/search")]
    public class SearchApiController : ApiController
    {
        private ISearchService _UserSearch { get; set; }

        public SearchApiController(ISearchService UserSearch)
        {
            _UserSearch = UserSearch;
        }

        // List all Users
        [Route("list"), HttpGet]
        public HttpResponseMessage ListAllUsers([FromUri] UserSearchRequestModel model)
        {
            if (model == null)
            {
                model = new UserSearchRequestModel();

                model.CurrentPage = 1;
                model.ItemsPerPage = 3;
            }

            if (model.CurrentPage < 1)
                model.CurrentPage = 1;

            if (model.ItemsPerPage < 1)
                model.ItemsPerPage = 3;

            PaginateItemsResponse<Domain.UserDetails> response = new PaginateItemsResponse<Domain.UserDetails>();

            response.Items = _UserSearch.ListUsers(model);

            response.CurrentPage = model.CurrentPage;

            response.ItemsPerPage = model.ItemsPerPage;

            //response.TotalItems = _UserSearch.getUserMatchCount(model);



            return Request.CreateResponse(response);

        }
    }
}