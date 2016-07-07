using Foodtator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("PhotoUpload")]
    public class PhotoUploadController : BaseController
    {
        // GET: PhotoUpload
        public ActionResult Index()
        {
            BaseViewModel vm = new BaseViewModel();
            return View(vm);
        }
    }
}