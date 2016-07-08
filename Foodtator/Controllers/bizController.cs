using Foodtator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodtator.Controllers
{
    [RoutePrefix("biz")]
    public class bizController : BaseController
    {
        
        public ActionResult Index()
        {
            BaseViewModel vm = new BaseViewModel();
            return View(vm);
        }
    }
}