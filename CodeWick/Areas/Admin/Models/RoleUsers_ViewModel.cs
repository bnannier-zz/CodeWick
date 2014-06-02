using System;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CodeWick.Models;

namespace CodeWick.Areas.Admin.Models {
    [Serializable]
    public class RoleUsers_ViewModel {
        [DisplayName("Role")]
        public Role Role { get; set; }

        [DisplayName("Users In Role")]
        public List<User> UsersInRole { get; set; }

        [DisplayName("Users Available")]
        public List<User> UsersAvailable { get; set; }
    }
}