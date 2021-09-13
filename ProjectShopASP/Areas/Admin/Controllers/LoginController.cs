using ProjectShopASP.Areas.Admin.Code;
using ProjectShopASP.Common;
using ProjectShopASP.Logic;
using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectShopASP.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = new UserLogic().Login(model.user_name,Encryptor.MD5Hash(model.password));
                if (result == true)
                {
                    var userSession = new UserLogin();
                    var user = new UserLogic().GetUserID(model.user_name);
                    userSession.UserId = user.id_emp;
                    userSession.UserName = user.user_name;
                    Session.Add(CommonConst.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
           
            return View("Index");
        }
        
    }
}