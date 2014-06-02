using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class View {
        [DisplayName("View Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ViewId { get; set; }

        [DisplayName("View Name"), Required]
        public string ViewName { get; set; }
    }
}