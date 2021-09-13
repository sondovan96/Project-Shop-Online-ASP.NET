using ProjectShopASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Logic
{
    public class CartLogic
    {
        private ProjectASPEntities db = null;
        public CartLogic()
        {
            db = new ProjectASPEntities();
        }

        public List<CART> GetAllCart()
        {
            return db.CARTs.ToList();
        }
    }
}