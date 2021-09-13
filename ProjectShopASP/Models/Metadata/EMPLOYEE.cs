using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Models
{
    [MetadataTypeAttribute(typeof(EMPLOYEEMetadata))]
    public partial class EMPLOYEE
    {
        internal sealed class EMPLOYEEMetadata
        {
            //Các thuộc tính

            public int id_emp { get; set; }

            [Display(Name = "Tên người dùng")]
            [Required(ErrorMessage = "Mời nhập tên người dùng")]
            public string name_emp { get; set; }
            [Display(Name = "Tên đăng nhập")]
            [Required(ErrorMessage = "Mời nhập username")]
            public string user_name { get; set; }
            [Display(Name = "Password")]
            [Required(ErrorMessage = "Mời nhập password")]
            public string password { get; set; }
        }
    }
}