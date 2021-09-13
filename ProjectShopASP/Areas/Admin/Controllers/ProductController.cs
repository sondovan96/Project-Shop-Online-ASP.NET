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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            List<PRODUCT> model = new List<PRODUCT>();
            ProductLogic AllUser = new ProductLogic();
            model = AllUser.GetAllProduct();
            return View(model);
        }
        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            List<CATEGORY> listCate = new List<CATEGORY>();
            CategoryLogic cate = new CategoryLogic();
            listCate = cate.GetAllCategory();
            ViewBag.listcate = listCate;
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(PRODUCT product)
        {

            if (ModelState.IsValid)
            {
                string url = "/";
                ProductLogic insertPro = new ProductLogic();
                product.meta_title =url+ StringHelpers.ToSeoUrl(product.name_product);
                product.created_date = DateTime.Now;
                insertPro.Insert(product);
                RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Thêm sản phẩm không thành công");
            }
            List<CATEGORY> listCate = new List<CATEGORY>();
            CategoryLogic cate = new CategoryLogic();
            listCate = cate.GetAllCategory();
            ViewBag.listcate = listCate;
            return View();
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            List<CATEGORY> listCate = new List<CATEGORY>();
            CategoryLogic cate = new CategoryLogic();
            listCate = cate.GetAllCategory();
            var pro = new PRODUCT();
            using (var context = new ProjectASPEntities())
            {
                pro = context.PRODUCTs.Find(id);
            }
            ViewBag.listcate = listCate;
            return View(pro);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PRODUCT product)
        {
            if(ModelState.IsValid)
            {
                string url = "/";
                ProductLogic updatePro = new ProductLogic();
                product.meta_title = url + StringHelpers.ToSeoUrl(product.name_product);
                product.image = product.image;
                product.id_product = id;
                updatePro.Update(product);
                RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Sửa sản phẩm không thành công");
            }
            List<CATEGORY> listCate = new List<CATEGORY>();
            CategoryLogic cate = new CategoryLogic();
            listCate = cate.GetAllCategory();
            ViewBag.listcate = listCate;
            return RedirectToAction("Index", "Product");
        }


        // POST: Admin/Product/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductLogic().Delete(id);
            return RedirectToAction("Index","Product");
        }
    }
}
