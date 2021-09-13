using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectShopASP.Models
{
    [MetadataTypeAttribute(typeof(PRODUCTMetadata))]
    public partial class PRODUCT
    {
        internal sealed class PRODUCTMetadata
        {
            //Các thuộc tính
            public int id_product { get; set; }

            [Display(Name = "Tên sản phẩm")]
            [Required(ErrorMessage = "Mời nhập tên sản phẩm")]
            public string name_product { get; set; }

            [Display(Name = "Loại sản phẩm")]
            [Required(ErrorMessage = "Mời chọn loại sản phẩm")]
            public int id_cate { get; set; }

            [Display(Name = "Gía sản phẩm")]
            [Required(ErrorMessage = "Mời nhập giá sản phẩm")]
            public Nullable<double> price { get; set; }


            [AllowHtml]
            [Display(Name = "Mô tả sản phẩm")]
            [Required(ErrorMessage = "Mời nhập mô tả sản phẩm")]
            public string description { get; set; }

            [Display(Name = "Hình sản phẩm")]
            [Required(ErrorMessage = "Chưa chọn hình ảnh")]
            public string image { get; set; }
            public Nullable<System.DateTime> created_date { get; set; }
            public Nullable<System.DateTime> top_hot { get; set; }
            public string more_image { get; set; }

            [Display(Name = "Số lượng")]
            [Required(ErrorMessage = "Mời nhập số lượng sản phẩm")]
            public int quantity { get; set; }
            public string meta_title { get; set; }

            [AllowHtml]
            [Display(Name = "Chi tiết sản phẩm")]
            public string detail { get; set; }
            [Display(Name = "Gía khuyến mãi")]
            public Nullable<double> promotion_price { get; set; }
        }
    }
}