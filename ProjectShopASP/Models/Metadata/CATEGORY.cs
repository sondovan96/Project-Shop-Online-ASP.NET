using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectShopASP.Models
{
    [MetadataTypeAttribute(typeof(CATEGORYMetadata))]
    public partial class CATEGORY
    {
        internal sealed class CATEGORYMetadata
        {
            public int id_cate { get; set; }
            [Display(Name = "Tên Danh Mục")]
            [Required(ErrorMessage = "Mời nhập tên danh mục")]
            public string name_cate { get; set; }
            
            [Display(Name = "Loại Danh Mục")]
            [Required(ErrorMessage = "Mời chọn tên danh mục")]
            public Nullable<int> type_cate { get; set; }
            [Display(Name = "URL SEO")]
            public string link { get; set; }
        }
        
    }
}