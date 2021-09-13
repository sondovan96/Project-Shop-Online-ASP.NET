using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập username")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string password { get; set; }
        public bool remember { get; set; }
    }
}