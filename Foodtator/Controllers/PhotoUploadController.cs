using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("PhotoUpload")]
    public class PhotoUploadController : Controller
    {
        // GET: PhotoUpload
        public ActionResult Index()
        {
            return View();
        }
    }
}