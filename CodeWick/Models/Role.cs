using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeWick.Models {
    [Serializable]
    public class Role {
        [DisplayName("Role Id"), Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid RoleId { get; set; }

        [DisplayName("Role Name"), Required]
        public virtual string RoleName { get; set; }

        [DisplayName("Description")]
        public virtual string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}