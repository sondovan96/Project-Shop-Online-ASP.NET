using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Models
{
    [Serializable]
    public class CartItem
    {

        public PRODUCT Product { get; set; }
        public int Quantity { get; set; }
    }
}