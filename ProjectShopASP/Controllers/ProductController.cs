using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ProjectShopASP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            List<PRODUCT> listAllProduct = new List<PRODUCT>();
            using (var context = new ProjectASPEntities())
            {
                listAllProduct = context.PRODUCTs.ToList();
            }
            return PartialView(listAllProduct);
        }
        public ActionResult Category(int cateID, int page = 1)
        {
            int totalRecord = 0;
            
            int pageSize = 5;
            CATEGORY Cate = new CATEGORY();
            List<PRODUCT> listProductCate = new List<PRODUCT>();
            using (var context = new ProjectASPEntities())
            {
                Cate = context.CATEGORies.Where(x => x.id_cate == cateID).SingleOrDefault();
                totalRecord = context.PRODUCTs.Where(x => x.id_cate == cateID).Count();
                listProductCate = context.PRODUCTs.Where(x => x.id_cate == cateID).OrderByDescending(x => x.created_date).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }           
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)totalRecord / (double)pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            ViewBag.Category = Cate;
            return View(listProductCate);
        }
            public ActionResult DetailProduct(int idProduct)
        {
            var listProduct = new PRODUCT();
            List<PRODUCT> listProductCate = new List<PRODUCT>();
            using (var context = new ProjectASPEntities())
            {
                listProduct = context.PRODUCTs.Where(x => x.id_product == idProduct).SingleOrDefault();
                listProductCate = context.PRODUCTs.Where(x => x.id_cate == listProduct.id_cate && x.id_product!= idProduct).ToList();
            }
            ViewBag.listProductCate = listProductCate;
            return View(listProduct);
        }
        public ActionResult ShowAllProduct(int page = 1, int pageSize = 5)
        {
            IEnumerable<PRODUCT> listProduct;
            using (var context = new ProjectASPEntities())
            {
                listProduct = context.PRODUCTs.OrderByDescending(x=>x.created_date).ToPagedList(page,pageSize);
            }
            return View(listProduct);
        }
        public JsonResult ListName(string q)
        {
            var context = new ProjectASPEntities();

            var data = context.PRODUCTs.Where(x => x.name_product.Contains(q)).Select(x=> new { x.name_product,x.image }).ToList();
            
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1)
        {
            int totalRecord = 0;

            int pageSize = 5;
            List<PRODUCT> listProductCate = new List<PRODUCT>();
            using (var context = new ProjectASPEntities())
            {
                totalRecord = context.PRODUCTs.Where(x => x.name_product.Contains(keyword)).Count();
                listProductCate = context.PRODUCTs.Where(x => x.name_product.Contains(keyword)).OrderByDescending(x => x.created_date).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Keyword = keyword;
            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)totalRecord / (double)pageSize);
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(listProductCate);
        }
    }
}