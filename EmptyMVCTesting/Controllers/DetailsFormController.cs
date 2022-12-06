using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMVCTesting.Controllers
{
    public class DetailsFormController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegisterFrom()
        {
            return View("RegistrationDetails");
        }

        public ActionResult DataTransFrmCTOV()
        {
            int ID;
            string Name, Group;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Group", typeof(string));

            for(int i=1; i<=5; i++)
            {
                ID=i;
                Name="Name "+i;
                Group = "Group " + (i % 2 == 0 ? "1st" : "2nd");
                dt.Rows.Add(ID, Name, Group);
            }

            ViewBag.DT = dt;
            ViewData["DT"] = dt;

            TempData["DT"] = dt;//Temdata usses internally session so if session is abondand then it will not show on next view
            TempData.Keep();
            ViewBag.DT2 = TempData.Peek("DT");

            return View();
        }
    }
}