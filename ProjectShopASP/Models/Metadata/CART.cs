using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Models
{
    [MetadataTypeAttribute(typeof(CARTMetadata))]
    public partial class CART
    {
        internal sealed class CARTMetadata
        {
            public int id_cart { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public string email { get; set; }
            public Nullable<double> total_price { get; set; }
            public string status { get; set; }
            public Nullable<System.DateTime> created_date { get; set; }
        }

    }
}