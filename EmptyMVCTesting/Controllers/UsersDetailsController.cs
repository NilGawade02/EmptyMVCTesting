using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmptyMVCTesting.Models;

namespace EmptyMVCTesting.Controllers
{
    [RoutePrefix("Users")]
    public class UsersDetailsController : Controller
    {
        #region Public fiels
        DataTable dt = new DataTable("UserDetailsTable");
        int U_ID;
        string U_FName=string.Empty;
        string U_LName=string.Empty;
        int U_Gen;
        string U_EId=string.Empty;
        string U_PhNo=string.Empty;
        string U_Address=string.Empty;
        int U_Indian;
        string U_Hobbies=string.Empty;
        string U_ProfilePic=string.Empty;
        #endregion

        #region Commented TempData because of some issue by Anil
        //public UsersDetailsController()
        //{
        //    #region Commented TempData because of some issue by Anil
        //    if (TempData["UserDetailsTable"] == null)
        //    {
        //        UserDetailsTableColumns();//For Table Structure
        //        //UserDetailsTableColumnsValues();//For Sample Data Pass Parameters to it

        //        UserDetailsTableColumnsValuesDef();//For Testing Sample data

        //        TempData["UserDetailsTable"] = dt;
        //    }
        //    else
        //        dt = (DataTable)TempData.Peek("UserDetailsTable");
        //    #endregion
        //}
        #endregion

        public void UserDetailsTableColumns()
        {
            dt.Columns.Add("U_ID", typeof(int));
            dt.Columns["U_ID"].AutoIncrement = true;
            dt.Columns["U_ID"].AutoIncrementSeed = 1; dt.Columns["U_ID"].AutoIncrementStep = 1;

            dt.Columns.Add("U_FName", typeof(string));
            dt.Columns.Add("U_LName", typeof(string));
            dt.Columns.Add("U_Gen", typeof(int));
            dt.Columns.Add("U_EId", typeof(string));
            dt.Columns.Add("U_PhNo", typeof(string));
            dt.Columns.Add("U_Address", typeof(string));
            dt.Columns.Add("U_Indian", typeof(int));
            dt.Columns.Add("U_Hobbies", typeof(string));
            dt.Columns.Add("U_ProfilePic", typeof(string));
        }

        public void UserDetailsTableColumnsValues(string U_FName, string U_LName, int U_Gen, string U_EId, string U_PhNo, 
            string U_Address, int U_Indian, string U_Hobbies, string U_ProfilePic)
        {
            dt.Rows.Add(null, U_FName, U_LName, U_Gen, U_EId, U_PhNo, U_Address, U_Indian, U_Hobbies, U_ProfilePic);
        }

        public void UserDetailsTableColumnsValuesDef()
        {
            dt.Rows.Add(null, "Anil", "Gawade", 1, "anil@vieva.in", "9757203681", "Powai,Mumbai 400072",
                    2, "Football,Cricket,Video Games", "/Docs/UploadsDocs/Sample.jpg");

            dt.Rows.Add(null, "Nil", "Gawade", 2, "nil@vieva.in", "9757203681", "Powai,Mumbai 400072",
                    1, "Hocky,Cricket,Video Games", "/Docs/UploadsDocs/Sample.jpg");

            dt.Rows.Add(null, "Hru", "", 2, "hru@vieva.in", "9757203681", "Powai,Mumbai 400072",
                    1, "Cricket,Video Games", "/Docs/UploadsDocs/Sample.jpg");

            #region Commented
            //DataRow dr = dt.NewRow();
            //dr["U_ID"] = DBNull.Value;
            //dr["U_FName"] = DBNull.Value;
            //dr["U_LName"] = DBNull.Value;
            //dr["U_Gen"] = DBNull.Value;
            //dr["U_EId"] = DBNull.Value;
            //dr["U_PhNo"] = DBNull.Value;
            //dr["U_Address"] = DBNull.Value;
            //dr["U_Indian"] = DBNull.Value;
            //dr["U_Hobbies"] = DBNull.Value;
            //dr["U_ProfilePic"] = DBNull.Value;

            //dt.Rows.Add(dr); 
            #endregion
        }

        [HttpGet]
        [Route("Home")]
        public ActionResult Index()
        {
            #region Commented TempData because of some issue by Anil
            //if (TempData["UserDetailsTable"] == null)
            //{
            //    UserDetailsTableColumns();//For Table Structure
            //    //UserDetailsTableColumnsValues();//For Sample Data Pass Parameters to it

            //    UserDetailsTableColumnsValuesDef();//For Testing Sample data

            //    TempData["UserDetailsTable"] = dt;
            //}
            //else
            //    dt = (DataTable)TempData.Peek("UserDetailsTable"); 
            #endregion

            if (Session["UserDetailsTable"] == null)
            {
                UserDetailsTableColumns();//For Table Structure
                //UserDetailsTableColumnsValues();//For Sample Data Pass Parameters to it
                UserDetailsTableColumnsValuesDef();//For Testing Sample data

                Session["UserDetailsTable"] = dt;
            }
            else
                dt = (DataTable)Session["UserDetailsTable"];

            return View("UsersHome");
        }

        [HttpPost]
        [Route("DocUpload")]
        public ActionResult PhotoUpload()
        {
            #region Commented TempData because of some issue by Anil
            //dt = (DataTable)TempData.Peek("UserDetailsTable");

            //if(dt == null)
            //{
            //    UserDetailsTableColumns();
            //    TempData["UserDetailsTable"] = dt;
            //} 
            #endregion

            if (Request.Files.Count > 0)
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
                        string path = ConfigurationManager.AppSettings["DocumentPath"];

                        path= Server.MapPath(path);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        path += "/Users/";
                        if (!Directory.Exists(path))
                            Directory.CreateDirectory(path);

                        fname = Path.Combine(path, fname);
                        //file.SaveAs(fname);//For Temp
                        ViewBag.FilePath = fname;
                    }
                    // Returns message that successfully uploaded  
                    return Json(ViewBag.FilePath);
                    //E:\Anil\Git Projects\MVC\EmptyMVCTesting\EmptyMVCTesting\Docs/Users/Sample.jpg
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
                return Json("No files selected.");
        }

        [Route("CreateUser")]
        public ActionResult CreateUser()
        {
            #region Commented TempData because of some issue by Anil
            //dt = (DataTable)TempData.Peek("UserDetailsTable");

            //if (dt == null)
            //{
            //    UserDetailsTableColumns();
            //    TempData["UserDetailsTable"] = dt;
            //} 
            #endregion

            UserDetails UD = new UserDetails();

            return View("RegisterUser", UD);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult CreateUser(UserDetails UD)
        {
            #region Commented TempData because of some issue by Anil
            //dt = (DataTable)TempData.Peek("UserDetailsTable");

            //if (dt == null)
            //{
            //    UserDetailsTableColumns();
            //    TempData["UserDetailsTable"] = dt;
            //} 
            #endregion

            if (Session["UserDetailsTable"] == null)
            {
                UserDetailsTableColumns();

            }
            else
                dt = (DataTable)Session["UserDetailsTable"];

            if (ModelState.IsValid)
            {
                U_FName = UD.U_FName;
                U_LName = UD.U_LName;
                U_Gen = UD.U_Gen;
                U_EId = UD.U_EId;
                U_PhNo = UD.U_PhNo;
                U_Address = UD.U_Address;
                U_Indian = UD.U_Indian;
                //U_Hobbies = UD.U_Hobbies;
                U_ProfilePic = UD.U_ProfilePic;

                int i = 1;
                foreach(Hobby obj in UD.HobbyList)
                {
                    if (obj.Checked == true)
                    {
                        if (i == 1)
                            U_Hobbies = obj.Name;
                        else
                            U_Hobbies += "," + obj.Name;
                        i++;
                    }
                    
                }

                UserDetailsTableColumnsValues(U_FName, U_LName, U_Gen, U_EId, U_PhNo, U_Address, U_Indian, U_Hobbies, U_ProfilePic);
                //TempData["UserDetailsTable"] = dt;//Commented TempData because of some issue by Anil
                Session["UserDetailsTable"] = dt;

                return RedirectToAction("Home", "Users");
            }

            return View("RegisterUser",UD);
        }

        [Route("AllUsers")]
        public ActionResult GetAllUserDetails()
        {
            UserDetails UD=new UserDetails();

            if (Session["UserDetailsTable"] == null)
            {
                UserDetailsTableColumns();//For Table Structure
                //UserDetailsTableColumnsValues();//For Sample Data Pass Parameters to it
                UserDetailsTableColumnsValuesDef();//For Testing Sample data

                Session["UserDetailsTable"] = dt;
            }
            else
                dt = (DataTable)Session["UserDetailsTable"];

            DataTable AllUsersDt=new DataTable();
            AllUsersDt.Columns.Add("ID", typeof(int));
            AllUsersDt.Columns.Add("Profile Picture", typeof(string));
            AllUsersDt.Columns.Add("Name", typeof(string));
            AllUsersDt.Columns.Add("Gender", typeof(string));
            AllUsersDt.Columns.Add("Email ID", typeof(string));
            AllUsersDt.Columns.Add("Phone Number", typeof(string));
            AllUsersDt.Columns.Add("Address", typeof(string));
            AllUsersDt.Columns.Add("Indian", typeof(string));
            AllUsersDt.Columns.Add("Hobbies", typeof(List<string>));

            if (dt!= null)
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow UsersDet=AllUsersDt.NewRow();
                    string UsersGender=string.Empty;
                    string UsersIsIndian=string.Empty;
                    List<string> Hobbies=new List<string>();

                    UsersDet["ID"] = (int)dr["U_ID"];
                    UsersDet["Name"] = dr["U_FName"].ToString().Trim() +" "+ dr["U_LName"].ToString().Trim();
                    //UsersDet["Gender"] = (int)dr["U_Gen"];
                    UsersDet["Email ID"] = dr["U_EId"];
                    UsersDet["Phone Number"] = dr["U_PhNo"];
                    UsersDet["Address"] = dr["U_Address"];
                    //UsersDet["Indian"] = dr["U_Indian"];
                    //UsersDet["Hobbies"] = dr["U_Hobbies"];
                    UsersDet["Profile Picture"] = dr["U_ProfilePic"];
                    
                    foreach(Gender str in UD.GenderList)
                    {
                        if (((int)(dr["U_Gen"]) == str.ID))
                            UsersGender = str.Type;
                    }
                    UsersDet["Gender"] = UsersGender;

                    foreach (Indian str in UD.IndianList)
                    {
                        if (((int)dr["U_Indian"]) == str.ID)
                            UsersIsIndian = str.Name;
                    }
                    UsersDet["Indian"] = UsersIsIndian;

                    string U_Hobbies = dr["U_Hobbies"].ToString();
                    Hobbies = U_Hobbies.Split(',').ToList();

                    UsersDet["Hobbies"] =Hobbies;

                    AllUsersDt.Rows.Add(UsersDet);

                    ViewBag.AllUsersDt = AllUsersDt;
                }

                

            return View("UsersDetails");
        }

        [Route("EditUser/{ID}")]
        public ActionResult EditUser(int ID)
        {
            if (Session["UserDetailsTable"] != null)
                dt = (DataTable)Session["UserDetailsTable"];
            else
                return RedirectToAction("AllUsers", "Users");

            dt.AcceptChanges();

            DataRow dr = dt.AsEnumerable().FirstOrDefault(x => x.Field<int>("U_ID") == ID);

            UserDetails UD = new UserDetails();
            UD.U_ID = (int)dr["U_ID"];
            UD.U_FName = dr["U_FName"].ToString();
            UD.U_LName = dr["U_LName"].ToString();
            UD.U_Gen = (int)dr["U_Gen"];
            UD.U_EId = dr["U_EId"].ToString();
            UD.U_PhNo = dr["U_PhNo"].ToString();
            UD.U_Address = dr["U_Address"].ToString();
            UD.U_Indian = (int)dr["U_Indian"];
            UD.U_Hobbies = dr["U_Hobbies"].ToString();
            UD.U_ProfilePic = dr["U_ProfilePic"].ToString();

            U_Hobbies= dr["U_Hobbies"].ToString();
            string[] Hobbies = U_Hobbies.Split(',');

            foreach(Hobby obj in UD.HobbyList)
            {
                foreach(string str in Hobbies)
                {
                    if (obj.Name == str)
                    {
                        obj.Checked=true;
                    }
                }
            }

            ViewBag.Hobbies = Hobbies;

            Session["UserDetailsTable"] = dt;

            return View("EditUserDetails",UD);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public ActionResult EditUserDetails(UserDetails UD)
        {
            if (Session["UserDetailsTable"] != null)
                dt = (DataTable)Session["UserDetailsTable"];
            else
                return RedirectToAction("AllUsers", "Users");

            dt.AcceptChanges();

            if (ModelState.IsValid)
            {
                U_ID=UD.U_ID;
                U_FName = UD.U_FName;
                U_LName = UD.U_LName;
                U_Gen = UD.U_Gen;
                U_EId = UD.U_EId;
                U_PhNo = UD.U_PhNo;
                U_Address = UD.U_Address;
                U_Indian = UD.U_Indian;
                //U_Hobbies = UD.U_Hobbies;
                U_ProfilePic = UD.U_ProfilePic;

                int i = 1;
                foreach (Hobby obj in UD.HobbyList)
                {
                    if (obj.Checked == true)
                    {
                        if (i == 1)
                            U_Hobbies = obj.Name;
                        else
                            U_Hobbies += "," + obj.Name;
                        i++;
                    }

                }

                foreach (DataRow dr in dt.Rows)
                {
                    if ((int)dr["U_ID"] == U_ID)
                    {
                        dr["U_ID"] = UD.U_ID;
                        dr["U_FName"] = UD.U_FName;
                        dr["U_LName"] = UD.U_LName;
                        dr["U_Gen"] = UD.U_Gen;
                        dr["U_EId"] = UD.U_EId;
                        dr["U_PhNo"] = UD.U_PhNo;
                        dr["U_Address"] = UD.U_Address;
                        dr["U_Hobbies"] = U_Hobbies;
                        dr["U_ProfilePic"] = UD.U_ProfilePic;
                    }
                }

                dt.AcceptChanges();

                Session["UserDetailsTable"] = dt;

                return RedirectToAction("Home", "Users");
            }

            return View();
        }

        //[HttpPost]
        [Route("DeleteUser/{ID}")]
        public ActionResult DelUser(int ID)
        {
            if(Session["UserDetailsTable"] != null)
                dt = (DataTable)Session["UserDetailsTable"];
            else
                return RedirectToAction("AllUsers", "Users");

            dt.AcceptChanges();
            foreach(DataRow dr in dt.Rows)
            {
                if (((int)dr["U_ID"]) == ID)
                    dr.Delete();
            }
            dt.AcceptChanges();

            Session["UserDetailsTable"] = dt;

            return RedirectToAction("AllUsers", "Users");
        }
    }
}