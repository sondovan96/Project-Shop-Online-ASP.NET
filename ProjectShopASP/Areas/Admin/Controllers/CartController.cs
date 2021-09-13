using ProjectShopASP.Logic;
using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectShopASP.Areas.Admin.Controllers
{
    public class CartController : BaseController
    {
        // GET: Admin/Cart
        public ActionResult Index()
        {
            List<CART> model = new List<CART>();
            CartLogic AllCate = new CartLogic();
            model = AllCate.GetAllCart();
            return View(model);
        }



        // GET: Admin/Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Cart/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Cart/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
