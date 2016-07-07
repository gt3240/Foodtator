using Foodtator.Interfaces;
using Foodtator.Models.RequestModel;
using Foodtator.Models.ResponseModel;
using Foodtator.Services;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Foodtator.Controllers.Api
{
    [RoutePrefix("api/photouploader")]
    public class PhotoUploadAPIController : ApiController
    {
        [Dependency]
        public IFileUploadService _fileUploadService { get; set; }
        [Dependency]
        public IMediaService _mediaUploadService { get; set; }

        // post picture to s3 and sql
        [Route("")]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;

            ItemResponse<int> response = new ItemResponse<int>();

            if (httpRequest.Files.Count > 0)
            {
                string filePath = null;
                string fileName = null;
                //string mediaType = null;

                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    //string path = @"~\Media";
                    //if (!Directory.Exists(path))
                    //{
                    //    Directory.CreateDirectory(path);
                    //}
                    filePath = HttpContext.Current.Server.MapPath("~/Media/" + postedFile.FileName);

                    // get unix time stamp
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    fileName = unixTimestamp + "." + postedFile.FileName;

                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);

                    // upload to amazon S3
                    _fileUploadService.uploadFiles(filePath, fileName);

                    // insert into db.
                    MediaRequestModel mediaModel = new MediaRequestModel();

                    mediaModel.FileName = fileName;
                    mediaModel.Path = ConfigService.uploadFileS3Prefix;
                    mediaModel.MediaType = "1";
                    // by default the title is the file name
                    mediaModel.Title = postedFile.FileName;
                    mediaModel.Description = "";
                    // get file type
                    string mimeType = System.Web.MimeMapping.GetMimeMapping(fileName);
                    mediaModel.FileType = mimeType;

                    //MediaService.InsertMedia(mediaModel);
                    response.Item = _mediaUploadService.InsertMedia(mediaModel);

                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(response);
        }

        // post picture to s3 and sql with other form elements ***NOT WORKING YET****
        [Route("UploadWithData")]
        public HttpResponseMessage Upload()
        {
            HttpResponseMessage result = null;

            var httpRequest = HttpContext.Current.Request;

            ItemResponse<int> response = new ItemResponse<int>();

            if (httpRequest.Files.Count > 0)
            {
                string filePath = null;
                string fileName = null;
                //string fileTitle = null;

                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                    filePath = HttpContext.Current.Server.MapPath("~/Content/images/" + postedFile.FileName);
                    fileName = postedFile.FileName;
                    //fileTitle = postedFile.;
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    fileName = unixTimestamp + "." + postedFile.FileName;
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);

                    // upload to amazon S3
                    FileUploadService uploadNow = new FileUploadService();
                    uploadNow.uploadFiles(filePath, fileName);

                    // insert into db.
                    MediaRequestModel mediaModel = new MediaRequestModel();
                    mediaModel.FileName = fileName;
                    mediaModel.Path = ConfigService.uploadFileS3Prefix;
                    mediaModel.MediaType = "1";
                    mediaModel.Title = httpRequest.Form["Title"];  // STACKOVER FLOW SAVES TE DAY!!
                    mediaModel.Description = httpRequest.Form["Description"];
                    mediaModel.Latitude = httpRequest.Form["Latitude"];
                    mediaModel.Longitude = httpRequest.Form["Longitude"];
                    string mimeType = System.Web.MimeMapping.GetMimeMapping(fileName);
                    mediaModel.FileType = mimeType;

                    //MediaService.InsertMedia(mediaModel);
                    response.Item = _mediaUploadService.InsertMedia(mediaModel);

                    File.Delete(filePath);

                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(response);
        }
    }
}
