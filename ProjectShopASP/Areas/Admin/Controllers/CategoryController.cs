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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<CATEGORY> model = new List<CATEGORY>();
            CategoryLogic AllCate = new CategoryLogic();
            model = AllCate.GetAllCategory();
            return View(model);
        }
        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            var listType = new List<type_cate> {new type_cate {
                    idtype = 1,
                    nametype = "Thời trang nam"
                },
                new type_cate {
                     idtype = 2,
                    nametype = "Thời trang nữ"
                } };
            ViewBag.TypeCate = listType;
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(CATEGORY cate)
        {
            if (ModelState.IsValid)
            {
                CategoryLogic cateLogic = new CategoryLogic();
                string seper = "/";
                cate.link = seper+ StringHelpers.ToSeoUrl(cate.name_cate);
                //cate.
                bool result = cateLogic.Insert(cate);
                if (result == true)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục không thành công");
                }
            }
            var listType = new List<type_cate> {new type_cate {
                    idtype = 1,
                    nametype = "Thời trang nam"
                },
                new type_cate {
                     idtype = 2,
                    nametype = "Thời trang nữ"
                } };
            ViewBag.TypeCate = listType;
            return View();
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var listType = new List<type_cate> {new type_cate {
                    idtype = 1,
                    nametype = "Thời trang nam"
                },
                new type_cate {
                     idtype = 2,
                    nametype = "Thời trang nữ"
                } };
            var cate = new CATEGORY();
            using (var context = new ProjectASPEntities())
            {
                cate = context.CATEGORies.Find(id);
            }
            ViewBag.TypeCate = listType;
            return View(cate);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,CATEGORY cate)
        {
            if (ModelState.IsValid)
            {
                CategoryLogic cateLogic = new CategoryLogic();
                string seper = "/";
                cate.link = seper + StringHelpers.ToSeoUrl(cate.name_cate);
                cate.id_cate = id;
                cate.type_cate = cate.type_cate;
                bool result = cateLogic.Update(cate);
                if (result == true)
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Sửa danh mục không thành công");
                }
            }
            var listType = new List<type_cate> {new type_cate {
                    idtype = 1,
                    nametype = "Thời trang nam"
                },
                new type_cate {
                     idtype = 2,
                    nametype = "Thời trang nữ"
                } };
            ViewBag.TypeCate = listType;
            return View();
        }

        // GET: Admin/Category/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryLogic().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
