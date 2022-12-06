using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMVCTesting.Controllers
{
    public class RedirectController : Controller
    {
        public ActionResult Home()
        {
            return View();  
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View("~/Views/MyViews/ContactUs.cshtml");
        }

        public ActionResult Details()
        {
            return View("Detail");
        }
    }
}