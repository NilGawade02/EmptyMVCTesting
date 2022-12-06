using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMVCTesting.Controllers
{
    public class EmployeeController : Controller
    {
        public string Name(string Name)
        {
            return "Welcome to my page. Hii " + Name + "...";
        }

        public string FullName(string FName=null, string LName=null)
        {
            string rtn=string.Empty;

            if (FName != null && FName != string.Empty && LName != null && LName != string.Empty)
            {
                rtn="Your First Name is "+FName+" and Last Name is "+LName;
            }
            else if (FName != null && FName != string.Empty)
            {
                rtn = "Your First Name is " + FName;
            }
            else if (LName != null && LName != string.Empty)
            {
                rtn = "Your Last Name is " + LName;
            }
            else
            {
                rtn = "Your Fisrt Name and Last name is blank";
            }
            return rtn;
        }
    }
}