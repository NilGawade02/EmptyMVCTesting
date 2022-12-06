using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmptyMVCTesting.Models
{
    public class UserDetails
    {
        public UserDetails()
        {
            GenderList = new List<Gender>
            {
                new Gender{ID=1, Type="Male" },
                new Gender{ID=2, Type="Female" },
                new Gender{ID=3, Type="Transgender" },
            };

            HobbyList = new List<Hobby>
            {
                new Hobby{ID=1,Name="Football",Checked=false},
                new Hobby{ID=2,Name="Hocky",Checked=false},
                new Hobby{ID=3,Name="Cricket",Checked=false},
                new Hobby{ID=4,Name="Video Games",Checked=false},
            };

            IndianList = new List<Indian>
            {
                new Indian{ID=1,Name="YES"},
                new Indian{ID=2,Name="NO"},
            };

            U_Hobbies = new List<string>();
        }

        [Required(ErrorMessage = "User ID Is Required!..")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "User ID")]
        public int U_ID { get; set; }


        [Required(ErrorMessage = "First Name Is Required!..")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "First Name At Least 3 Characters Required!..")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage ="First Name At Least 3 Characters!..")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name Cannot be longer than 20 characters!..")]
        public string U_FName { get; set; }


        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Last Name Cannot be longer than 20 characters!..")]
        public string U_LName { get; set; }


        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender Is Required!..")]
        public int U_Gen { get; set; }

        public List<Gender> GenderList { get; set; }


        [Display(Name = "Email Address")]
        [RegularExpression(@"^.{8,}$", ErrorMessage = "Email Address At Least 8 Characters Required!..")]
        [Required(ErrorMessage = "Email Address Is Required!..")]
        [StringLength(40, ErrorMessage = "Email Address Cannot be longer than 40 characters!..")]
        [EmailAddress(ErrorMessage = "Email Address Is Not Valid!..")]
        public string U_EId { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Is Required!..")]
        [StringLength(10, ErrorMessage = "Phone Number Cannot be longer than 10 Digits!..")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Phone Number Is Not Valid!..")]
        public string U_PhNo { get; set; }


        [Display(Name = "Address")]
        [RegularExpression(@"^.{10,}$", ErrorMessage = "Address At Least 10 Characters Required!..")]
        [StringLength(200, ErrorMessage = "Address Cannot be longer than 200 characters!..")]
        public string U_Address { get; set; }


        [Display(Name = "Are You Indian?")]
        public int U_Indian { get; set; }

        public List<Indian> IndianList { get; set; }


        [Display(Name = "Hobbies")]
        public IList<string> U_Hobbies { get; set; }

        public IList<Hobby> HobbyList { get; set; }


        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture Is Required!..")]
        public string U_ProfilePic { get; set; }

    }

    public class Gender//Radio buttons
    {
        public int ID { get; set; }
        public string Type { get; set; }
    }

    public class Hobby // CheckBoxes
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }

    public class Indian // DropDown 
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }
}