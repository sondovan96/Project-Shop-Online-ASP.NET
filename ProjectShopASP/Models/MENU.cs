//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectShopASP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MENU
    {
        public int id { get; set; }
        public string text { get; set; }
        public string link { get; set; }
        public Nullable<int> display_order { get; set; }
        public string target { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> id_type { get; set; }
    }
}
