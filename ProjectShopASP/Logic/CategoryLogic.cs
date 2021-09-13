using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Logic
{
    public class CategoryLogic
    {
        private ProjectASPEntities db = null;
        public CategoryLogic()
        {
            db = new ProjectASPEntities();
        }

        public List<CATEGORY> GetAllCategory()
        {
            return db.CATEGORies.ToList();
        }
        public bool Insert(CATEGORY cate)
        {
            try
            {
                db.CATEGORies.Add(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool Update(CATEGORY cate)
        {
            try
            {
                var cateFind = db.CATEGORies.Find(cate.id_cate);
                cateFind.name_cate = cate.name_cate;
                cateFind.type_cate = cate.type_cate;
                cateFind.link = cate.link;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var cate = db.CATEGORies.Find(id);
                db.CATEGORies.Remove(cate);
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