using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class Category {
        [DisplayName("Category Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CategoryId { get; set; }

        [DisplayName("Parent Category"), ForeignKey("Parent")]
        public long? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        [DisplayName("SEO URL"), Required]
        public string SEOURL { get; set; }

        [DisplayName("Title"), DataType(DataType.Html), AllowHtml]
        public string Title { get; set; }

        [DisplayName("Body"), Required, DataType(DataType.Html), AllowHtml]
        public string Body { get; set; }

        [DisplayName("CSS"), DataType(DataType.MultilineText), AllowHtml]
        public string CSS { get; set; }

        [DisplayName("Created Date"), Required]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Last Update"), Required]
        public DateTime LastUpdate { get; set; }
    }
}