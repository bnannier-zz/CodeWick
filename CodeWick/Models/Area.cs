using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class Area {
        [DisplayName("Area Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AreaId { get; set; }

        [DisplayName("Area Name"), Required]
        public string AreaName { get; set; }
    }
}