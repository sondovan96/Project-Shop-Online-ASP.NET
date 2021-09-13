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
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            List<EMPLOYEE> model = new List<EMPLOYEE>();
            UserLogic AllUser = new UserLogic();
            model = AllUser.GetAllUser();
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public ActionResult Create(EMPLOYEE user)
        {
            if(ModelState.IsValid)
            {
                UserLogic userLogic = new UserLogic();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.password);
                user.password = encryptedMd5Pas;
                int id = userLogic.Insert(user);
                if(id>0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = new EMPLOYEE();
            using (var context = new ProjectASPEntities())
            {
                user = context.EMPLOYEEs.Find(id);
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(EMPLOYEE user)
        {
            if (ModelState.IsValid)
            {
                UserLogic userLogic = new UserLogic();
                if (!string.IsNullOrEmpty(user.password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.password);
                    user.password = encryptedMd5Pas;
                }


                var result = userLogic.Update(user);
                if (result ==true)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View();
        }

        // GET: Admin/User/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserLogic().Delete(id);

            return RedirectToAction("Index");
        }


    }
}
