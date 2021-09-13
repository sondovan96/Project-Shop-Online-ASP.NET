using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Logic
{
    public class ProductLogic
    {
        private ProjectASPEntities db = null;
        public ProductLogic()
        {
            db = new ProjectASPEntities();
        }

        public List<PRODUCT> GetAllProduct()
        {
            return db.PRODUCTs.ToList();
        }
        public bool Insert(PRODUCT product)
        {
            try
            {
                db.PRODUCTs.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update(PRODUCT product)
        {
            try
            {
                var NowProduct = db.PRODUCTs.Find(product.id_product);
                NowProduct.id_cate = product.id_cate;
                NowProduct.name_product = product.name_product;
                NowProduct.meta_title = product.meta_title;
                NowProduct.image = product.image;
                NowProduct.price = product.price;
                NowProduct.promotion_price = product.promotion_price;
                NowProduct.quantity = product.quantity;
                NowProduct.description = product.description;
                NowProduct.detail = product.detail;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var pro = db.PRODUCTs.Find(id);
                db.PRODUCTs.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}