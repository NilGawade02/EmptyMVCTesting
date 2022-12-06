using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMVCTesting.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hii There";
        }

        public string Name()
        {
            return "Anil Is here";
        }
    }
}