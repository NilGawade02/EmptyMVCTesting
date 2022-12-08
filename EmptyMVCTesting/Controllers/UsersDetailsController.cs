using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult PhotoUpload()
        {
            if(Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for(int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Docs/UploadsDocs/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
                return Json("No files selected.");
            //Resquest
            //return "True";
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

        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult CreateUser(FormCollection form, UserDetails UD)
        {
            if (ModelState.IsValid)
            {
                var U_FName = form["U_FName"];
                var U_Gen = form["U_Gen"];
                var U_Hobbies = form["U_Hobbies"];
                var HobbyList = form["HobbyList"];
            }
            return View("RegisterUser",UD);
        }
    }
}