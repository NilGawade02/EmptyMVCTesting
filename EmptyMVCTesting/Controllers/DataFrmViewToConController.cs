using EmptyMVCTesting.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EmptyMVCTesting.Controllers
{
    [RoutePrefix("DataFrmViewToCon")]
    public class DataFrmViewToConController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitDataUaingParameters/{ID:alpha}/{Name:alpha}")]
        public string SubmitDataUaingParameters(string ID, string Name)
        {
            return "Data Using Parameters ID is " + ID + ", Name is " + Name;
        }

        [HttpPost]
        [Route("SubmitDataUaingParameters/{ID:int}/{Name:int}")]
        public string SubmitDataUaingParameters(int ID, int Name)
        {
            return "Data Using Parameters ID is " + ID + ", Name is " + Name;
        }

        [HttpPost]
        public string SubmitDataUaingRequest()
        {
            string ID = Request["ID"].ToString();
            string Name = Request["Name"].ToString();
            return "Data Using Requests ID is " + ID + ", Name is " + Name;
        }

        [HttpPost]
        public string SubmitDataUaingFormCollection(FormCollection form)
        {
            string ID = form["ID"].ToString();
            string Name = form["Name"].ToString();
            return "Data Using Form Collection ID is " + ID + ", Name is " + Name;
        }

        [HttpPost]
        public string SubmitDataUaingStronglyBind(StronglyDataBind SDB)
        {
            string ID = SDB.ID;
            string Name = SDB.Name;
            return "Data Using Strongly Data Types By Model ID is " + ID + ", Name is " + Name;
        }

        [HttpPost]
        public string SubmitDataUaingAjaxCall(Test t)
        {

            //string ab=req;
            //var Req = Request.Form[0].ToString();//"%22ID=0207&Name=Anil%22"
            //string a = "%22ID=0207&Name=Anil%22";
            //a = System.Web.HttpUtility.UrlEncode(a);
            //a = a.Replace("+", "%20");
            //var decodedData = decodeURIComponent(Req);
            //var jsonObject = JSON.parse(decodedData);
            //var json= new JavaScriptSerializer().Serialize(Req);
            //int i = Request;
            //StronglyDataBind SDB = new StronglyDataBind();
            //string ID = SDB.ID;
            //string Name = SDB.Name;
            string ID = t.ID;
            string Name = t.Name;
            return "Data Using Strongly Data Types By Model ID is " + ID + ", Name is " + Name;
        }

        public class Test
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
    }
}