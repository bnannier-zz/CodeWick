using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace CodeWick.Areas.Account.Models {
    public class RecoverModel {
        [Required]
        [Display(Name = "Please enter your user name or email")]
        public string UserName_Email { get; set; }
    }
}