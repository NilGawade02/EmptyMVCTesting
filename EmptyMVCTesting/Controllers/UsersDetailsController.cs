using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmptyMVCTesting.Models;

namespace EmptyMVCTesting.Controllers
{
    [RoutePrefix("Users")]
    public class UsersDetailsController : Controller
    {
        [HttpGet]
        [Route("Home")]
        public ActionResult Index()
        {
            return View("UsersHome");
        }

        [HttpPost]
        [Route("DocUpload")]
        public string PhotoUpload()
        {
            return "True";
        }

        [Route("CreateUser")]
        public ActionResult CreateUser()
        {
            //UserDetails UD = new UserDetails
            //{
            //    GenderList = new List<Gender>
            //    {
            //        new Gender{ID=1, Type="Male" },
            //        new Gender{ID=2, Type="Female" },
            //        new Gender{ID=3, Type="Transgender" },
            //    }
            //};
            UserDetails UD = new UserDetails();

            return View("RegisterUser", UD);
        }
    }
}