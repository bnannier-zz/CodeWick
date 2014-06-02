using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    public class SiteIndexModel {
        public List<Zone> Zones { get; set; }
    }
}