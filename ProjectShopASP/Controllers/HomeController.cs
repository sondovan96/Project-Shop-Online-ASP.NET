using ProjectShopASP.Common;
using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectShopASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SLIDE> listSlide = new List<SLIDE>();
            List<PRODUCT> listNewProduct = new List<PRODUCT>();
            List<PRODUCT> listFeatureProduct = new List<PRODUCT>();
            using (var context = new ProjectASPEntities())
            {
                listSlide = context.SLIDEs.Where(x => x.status == true).OrderBy(x => x.display_order).ToList();
                listNewProduct = context.PRODUCTs.OrderByDescending(x => x.created_date).Take(8).ToList();
                listFeatureProduct = context.PRODUCTs.Where(x => x.top_hot != null && x.top_hot < DateTime.Now).OrderByDescending(x => x.created_date).Take(8).ToList();
            }
            ViewBag.Slide = listSlide;
            ViewBag.NewProduct = listNewProduct;
            ViewBag.FeatureProduct = listFeatureProduct;

            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            List<MENU> listMenu = new List<MENU>();
            List<CATEGORY> listCate = new List<CATEGORY>();
            using (var context = new ProjectASPEntities())
            {
                listMenu = context.MENUs.Where(x => x.id_type == 1 && x.status == true).OrderBy(x => x.display_order).ToList();
                listCate = context.CATEGORies.Where(x => x.type_cate == 1).ToList();
            }
            ViewBag.Category = listCate;
            return PartialView(listMenu);
        }
        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            List<MENU> listMenu = new List<MENU>();
            using (var context = new ProjectASPEntities())
            {
                listMenu = context.MENUs.Where(x => x.id_type == 2 && x.status == true).OrderBy(x => x.display_order).ToList();
            }
            return PartialView(listMenu);
        }
        [ChildActionOnly]
        public ActionResult CartItem()
        {
            var cart = Session[CommonConst.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

    }
}