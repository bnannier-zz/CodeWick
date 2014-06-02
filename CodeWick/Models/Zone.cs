using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class Zone {
        [DisplayName("Zone Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ZoneId { get; set; }

        [DisplayName("Area"), Required]
        public long AreaId { get; set; }
        public Area Area { get; set; }

        [DisplayName("View"), Required]
        public long ViewId { get; set; }
        public View View { get; set; }

        [DisplayName("Width"), Required]
        public int Width { get; set; }

        [DisplayName("Height"), Required]
        public int Height { get; set; }

        [DisplayName("Order"), Required]
        public int Order { get; set; }
    }
}