//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogSitesi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web;
    public partial class Blog
    {
        public int KullaniciID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Baslik { get; set; }
        public string Yazi { get; set; }
        [DisplayName("Upload File")]
        public string imagePath { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string isim { get; set; }
        public string profilPath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
